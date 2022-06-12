using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BigPardakht.Repository
{
    public abstract class AbstractRepository<TEntity, TContext> : IRepository<TEntity, TContext>, ISelectListProvider
        where TEntity : class, IEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected DbContext db
        {
            get { return _dbContext as DbContext; }
        }

        protected TContext _dbContext;

        protected readonly DbSet<TEntity> Table;

        public void SetContext(TContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public AbstractRepository(TContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor	 = httpContextAccessor;
            _dbContext = dbContext;
            Table = db.Set<TEntity>();
        }

        public virtual MyDataTableResponse<TEntity> GetAsPaging(int take, int? skip)
        {
            if (take <= 0)
            {
                take = 20;
            }

            if (skip <= 0)
            {
                throw new Exception("skip صفر یا کوچکتر از صفر پاس شده است");
            }

            var entities = Get();


            IQueryable<TEntity> res;
            if (skip.HasValue && skip > 0)
            {
                res = entities.OrderByDescending(e => e.Id).Skip(skip.Value).Take(take);
            }
            else
            {
                res = entities.OrderByDescending(e => e.Id).Take(take);
            }

            return new MyDataTableResponse<TEntity>
            {
                LastSkip = skip,
                LastTake = take,
                EntityList = res.ToList(),
                Total = res.Count(),
            };
        }

        public virtual SelectList ToSelectList(List<TEntity> list, TEntity selected = null, string Name = "Name",
            string Value = "Id")
        {
            return new SelectList(list, Value, Name, selected);
        }


        public virtual IQueryable<TEntity> Get()
        {
            return Table.AsNoTracking();
        }


        public virtual TEntity GetById(long id, string exceptionMsg = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var query = Table.AsQueryable().AsNoTracking();

            if (includes != null)
            {
                query = includes(query);
            }

            var record = query.FirstOrDefault(q => q.Id == id);

            if (record == null)
            {
                if (string.IsNullOrEmpty(exceptionMsg))
                {
                    return null;
                }

                throw new NotFindException(exceptionMsg);
            }

            return record;
        }

        public virtual async Task<TEntity> GetByIdAsync(long id, string exceptionMsg = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var query = Table.AsNoTracking().AsQueryable();

            if (includes != null)
            {
                query = includes(query);
            }

            var record = await query.FirstOrDefaultAsync(q => q.Id == id);

            if (string.IsNullOrEmpty(exceptionMsg) && record == null)
            {
                throw new NotFindException();
            }

            return record;
        }

        public virtual long Save(TEntity model)
        {
            if (model.Id == 0)
            {
                Table.Add(model);
            }
            else
            {
                db.Entry(model).State = EntityState.Detached;

                var record = Table.AsNoTracking().FirstOrDefault(f => f.Id == model.Id);
                if (record == null)
                    throw new NotFindException();

                db.Entry(record).CurrentValues.SetValues(model);
                db.Entry(record).State = EntityState.Modified;
            }

            db.SaveChanges();

            return model.Id;
        }

        public virtual async Task<List<TEntity>> SaveAsync(List<TEntity> models)
        {
            if (models == null || models.Count() == 0)
            {
                throw new Exception("هیچ رکوردی ارسال نشده است");
            }

            foreach (var model in models)
            {
                if (model.Id == 0)
                {
                    await Table.AddAsync(model);
                }
                else
                {
                    var record = await Table.FindAsync(model.Id);
                    if (record == null)
                        throw new NotFindException();

                    db.Entry(record).CurrentValues.SetValues(model);
                    db.Entry(record).State = EntityState.Modified;
                }
            }

            await db.SaveChangesAsync();

            return models;
        }

        public virtual async Task<long> SaveAsync(TEntity model)
        {
            if (model.Id == 0)
            {
                await Table.AddAsync(model);
            }
            else
            {
                var record = await Table.FindAsync(model.Id);
                if (record == null)
                    throw new NotFindException();

                db.Entry(record).CurrentValues.SetValues(model);
                db.Entry(record).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();

            return model.Id;
        }

        public virtual void Delete(long id)
        {
            var record = Table.Find(id);

            if (record == null)
            {
                throw new NotFindException();
            }

            db.Entry(record).State = EntityState.Deleted;

            db.SaveChanges();
        }

        public virtual async Task DeleteAsync(long id)
        {
            var record = await Table.FindAsync(id);

            if (record == null)
            {
                throw new NotFindException();
            }

            db.Entry(record).State = EntityState.Deleted;

            await db.SaveChangesAsync();
        }


        public virtual async Task DeleteAsync(List<TEntity> queryForDelete)
        {
            if (MyGlobal.IsAttached)
            {
                var list = Table.ToList();
            }

            var records = Table.Where(t => queryForDelete.Select(q => q.Id).Contains(t.Id));

            if (records == null || records.Any() == false)
            {
                throw new NotFindException();
            }

            Table.RemoveRange(records);

            await db.SaveChangesAsync();
        }

        public virtual TContext GetContext()
        {
            return _dbContext;
        }

        public virtual SelectList GetSelectList(dynamic value)
        {
            bool ihastranslate = typeof(TEntity).Implements(typeof(IHasTranslate));
            
            if (ihastranslate)
            {
                var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();

                var tranlatedLanguageList = Table.ToList().Select(s => new
                {
                    Name = ((IHasTranslate) s).Title?.Where(s => s.Code == requestCulture.RequestCulture.Culture.Name)
                        .Select(s => s.Text).FirstOrDefault(),
                    Id = s.Id
                });
                return new SelectList(tranlatedLanguageList, "Id", "Name", value);
            }

            return new SelectList(Table, "Id", "Name", value);
        }
        
        
        public virtual string GetSelectListSelectedValue(dynamic value)
        {
            bool ihastranslate = typeof(TEntity).Implements(typeof(IHasTranslate));

            if (ihastranslate)
            {
                var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();

                var tranlatedLanguageList = Table.ToList().Select(s => new
                {
                    Name = ((IHasTranslate) s).Title?.Where(s => s.Code == requestCulture.RequestCulture.Culture.Name)
                        .Select(s => s.Text).FirstOrDefault(),
                    Id = s.Id
                });
                return tranlatedLanguageList.Where(t=>t.Id==value).Select(s=>s.Name).FirstOrDefault();
            }

            long? id = value;
            return Table.Where(t=>t.Id==id).Select(s=>s.Name).FirstOrDefault();
        }
        
        
       
    }

    public class NotFindException : Exception
    {
        public NotFindException(string msg = null) : base(msg == null ? "رکورد یافت نشد" : msg)
        {
        }
    }
}