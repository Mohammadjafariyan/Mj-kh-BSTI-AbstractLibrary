using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using SignalRMVCChat.Models.HelpDesk;


namespace SignalRMVCChat.Service.HelpDesk
{
    public class CategoryService: AbstractRepository<Category,BigPardakht.Data.ApplicationDbContext>
    {
        public CategoryService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}