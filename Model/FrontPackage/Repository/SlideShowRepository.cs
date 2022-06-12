using System.Linq;
using AbstractLibrary.Model.FrontModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Model.FrontPackage.Repository
{
    public class SlideShowRepository : AbstractRepository<SlideShow, ApplicationDbContext>
    {
        public SlideShowRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(
            dbContext, httpContextAccessor)
        {
        }


        public override IQueryable<SlideShow> Get()
        {
            return base.Get().Include(c => c.Product)
                .Include(c => c.Slide)
                .Include(c => c.ProductCategory);
        }
    }
}