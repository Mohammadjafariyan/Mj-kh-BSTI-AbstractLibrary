using System.Linq;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.MarketModel.Repository
{
    public class ProductRepository : AbstractRepository<Product, ApplicationDbContext>
    {

        public ProductRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor1 ) : base(dbContext, httpContextAccessor1)
        {
        }


        public override IQueryable<Product> Get()
        {
            return base.Get().Include(s=>s.ProductCategory);
        }
    }
}