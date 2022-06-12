using AbstractLibrary.Model.FrontModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;

namespace AbstractLibrary.Model.FrontPackage.Repository
{
    public class SlideRepository : AbstractRepository<Slide, ApplicationDbContext>
    {
        public SlideRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}