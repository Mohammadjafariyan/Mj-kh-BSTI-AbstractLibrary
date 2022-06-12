using AbstractLibrary.Repository;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using SignalRMVCChat.Models.HelpDesk;


namespace SignalRMVCChat.Service.HelpDesk
{
    public class CategoryImageService : SafeDeleteRepository<CategoryImage,BigPardakht.Data.ApplicationDbContext>

    {
        public CategoryImageService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}