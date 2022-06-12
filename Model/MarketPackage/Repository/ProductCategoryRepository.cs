using System.Linq;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.MarketModel.Repository
{
    public class ProductCategoryRepository:AbstractRepository<ProductCategory,ApplicationDbContext>
    {
        public ProductCategoryRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }


    }
}