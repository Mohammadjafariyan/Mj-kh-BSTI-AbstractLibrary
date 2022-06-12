using System.Linq;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.MarketModel.Repository
{
    public class ProductPropertyValueRepository : AbstractRepository<ProductPropertyValue, ApplicationDbContext>
    {
        public ProductPropertyValueRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }


        public override IQueryable<ProductPropertyValue> Get()
        {
            return base.Get().Include(s=>s.Product).Include(c=>c.ProductProperty);
        }
    }
}