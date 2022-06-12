using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigPardakht.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BigPardakht.Repository
{
    public class SingleEntityRepository<T,TContext> : AbstractRepository<T,TContext> where T : class, IEntity,new()
    {
        


        public virtual T GetSingle()
        {
            return Get().First();
        }
        public override IQueryable<T> Get()
        {
            var queryable = base.Get();
            if (!queryable.Any())
            {
                Save(new T());
            }

            return base.Get();
        }

        public override Task<List<T>> SaveAsync(List<T> models)
        {
            throw new NotImplementedException();
        }

        public override Task<long> SaveAsync(T model)
        {
            return Task.FromResult<long>(base.Save(model));
        }


        public override void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }


        public override Task DeleteAsync(List<T> queryForDelete)
        {
            throw new NotImplementedException();
        }
        

        public override long Save(T model)
        {


            var single= Table.SingleOrDefault();
            if (single == null)
            {
                Table.Add(model);
                single = model;
            }
            else
            {
                model.Id = single.Id;

                db.Entry(single).CurrentValues.SetValues(model);

                db.Entry(single).State = EntityState.Modified;
            }



            db.SaveChanges();
            db.Entry(single).State = EntityState.Detached;
            db.Entry(model).State = EntityState.Detached;

            return model.Id;
        }


        public override T GetById(long id, string exceptionMsg = null, Func<IQueryable<T>, IQueryable<T>> includes = null)
        {
            return  GetSingle();
        }

        public async override Task<T> GetByIdAsync(long id, string exceptionMsg = null, Func<IQueryable<T>, IQueryable<T>> includes = null)
        { 
            return  await Task.FromResult(GetSingle());
        }

        public SingleEntityRepository(TContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}