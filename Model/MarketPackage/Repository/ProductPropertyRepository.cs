using System.Linq;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.MarketModel.Repository
{
    public class ProductPropertyRepository : AbstractRepository<ProductProperty, ApplicationDbContext>
    {
        public ProductPropertyRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

     
    }
}