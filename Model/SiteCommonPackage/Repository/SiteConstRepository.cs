using AbstractLibrary.Model.SiteCommonModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;

namespace AbstractLibrary.Model.SiteCommonPackage.Repository
{
    public class SiteConstRepository : AbstractRepository<SiteConst, ApplicationDbContext>
    {
        public SiteConstRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}