using AbstractLibrary.Repository;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;


namespace SignalRMVCChat.Service.HelpDesk.Article
{
    public class ArticleService: SafeDeleteRepository<Models.HelpDesk.Article,BigPardakht.Data.ApplicationDbContext>
    {
        public ArticleService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}