using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigPardakht.Model;

namespace BigPardakht.Repository
{
    /// <summary>
    /// دسترسی به دیتابیس
    /// استفاده برای کوئری ها
    /// </summary>
    public interface IRepository<TEntity,TContext> where TEntity : class, IEntity

    {

        Task<List<TEntity>> SaveAsync(List<TEntity> models);
        IQueryable<TEntity> Get();
        TEntity GetById(long id, string exceptionMsg = null,
            Func<IQueryable<TEntity>,IQueryable<TEntity>> includes=null);
        Task<TEntity> GetByIdAsync(long id, string exceptionMsg = null,Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        long Save(TEntity t);
        Task<long> SaveAsync(TEntity t);
        void Delete(long id);
        Task DeleteAsync(long id);


        Task DeleteAsync(List<TEntity> queryForDelete);



        MyDataTableResponse<TEntity> GetAsPaging(int take, int? skip);

        TContext GetContext();
    }
}