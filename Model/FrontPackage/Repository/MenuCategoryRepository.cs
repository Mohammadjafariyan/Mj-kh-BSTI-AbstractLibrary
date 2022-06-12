using AbstractLibrary.Model.FrontModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;

namespace AbstractLibrary.Model.FrontPackage.Repository
{
    public class MenuCategoryRepository : AbstractRepository<MenuCategory, ApplicationDbContext>
    {
        public MenuCategoryRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}