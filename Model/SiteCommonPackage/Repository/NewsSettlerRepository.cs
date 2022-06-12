using AbstractLibrary.Model.SiteCommonModel;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;

namespace AbstractLibrary.Model.SiteCommonPackage.Repository
{
    public class NewsSettlerRepository : AbstractRepository<NewsSettler, ApplicationDbContext>
    {
        public NewsSettlerRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}