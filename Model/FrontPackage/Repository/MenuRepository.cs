using System.Linq;
using AbstractLibrary.Model.FrontModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.FrontPackage.Repository
{
    public class MenuRepository : AbstractRepository<Menu, ApplicationDbContext>
    {
        public MenuRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

        public override IQueryable<Menu> Get()
        {
            return base.Get().Include(c=>c.MenuCategory);
        }
    }
}