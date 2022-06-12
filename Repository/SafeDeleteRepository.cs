using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Repository
{
    public abstract class SafeDeleteRepository<TEntity,TContext> : AbstractRepository<TEntity,TContext> where TEntity : SafeDeleteEntity
    {
        protected SafeDeleteRepository(TContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
        
        public override async Task<List<TEntity>> SaveAsync(List<TEntity> models)
        {

            if (models==null || models.Count()==0)
            {
                throw new Exception("هیچ رکوردی ارسال نشده است");
            }
            
            foreach (var model in models)
            {
                
                if (model.Id == 0)
                {
                    Table.Add(model);
                }
                else
                {
                    var record = Table.Find(model.Id);
                    if (record == null)
                        throw new NotFindException();


                    var historyRecord = MyGlobal.Clone(record);
                    historyRecord.Id = 0;
                    historyRecord.IsModified = true;
                    historyRecord.NextId = record.Id;

                    // تغییر رکورد اصلی 
                    db.Entry(record).CurrentValues.SetValues(model);
                    db.Entry(record).State = EntityState.Modified;

                    Table.Add(historyRecord);
                }
              
            }
            await db.SaveChangesAsync();

            return models;
        }

        public override long Save(TEntity model)
        {
            if (model.Id == 0)
            {
                Table.Add(model);
            }
            else
            {
                (db as dynamic).DetachAll();
                var record = Table.FirstOrDefault(f=>f.Id== model.Id);
                if (record == null)
                    throw new NotFindException();

                

                var historyRecord = MyGlobal.Clone(record);
                historyRecord.Id = 0;
                historyRecord.IsModified = true;
                historyRecord.NextId = record.Id;

                // تغییر رکورد اصلی 
                db.Entry(record).CurrentValues.SetValues(model);
                db.Entry(record).State = EntityState.Modified;

                Table.Add(historyRecord);
            }

            db.SaveChanges();

            return model.Id;
        }

        public override async Task<long> SaveAsync(TEntity model)
        {
            if (model.Id == 0)
            {
                Table.Add(model);
            }
            else
            {
                var record = await Table.FindAsync(model.Id);
                if (record == null)
                    throw new NotFindException();


                var historyRecord = MyGlobal.Clone(record);
                historyRecord.Id = 0;
                historyRecord.IsModified = true;
                historyRecord.NextId = record.Id;

                // تغییر رکورد اصلی 
                db.Entry(record).CurrentValues.SetValues(model);
                db.Entry(record).State = EntityState.Modified;

                await Table.AddAsync(historyRecord);
            }

            await db.SaveChangesAsync();

            return model.Id;
        }


        public override void Delete(long id)
        {
            var record = Table.Find(id);

            if (record == null)
            {
                throw new NotFindException();
            }

            record.IsDeleted = true;

            db.Entry(record).State = EntityState.Modified;

            db.SaveChanges();
        }


        public override async Task DeleteAsync(long id)
        {
            var record = await Table.FindAsync(id);

            if (record == null)
            {
                throw new NotFindException();
            }

            record.IsDeleted = true;

            db.Entry(record).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }


        public async override Task DeleteAsync(List<TEntity> queryForDelete)
        {
            var records = await Table.Where(t => queryForDelete.Select(q => q.Id).Contains(t.Id)).ToListAsync();

            if (records == null || records.Any() == false)
            {
                throw new NotFindException();
            }

            foreach (var @record in records)
            {
                @record.IsDeleted = true;
                db.Entry(@record).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();
        }
    }
}