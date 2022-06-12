using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using SignalRMVCChat.Models;


namespace SignalRMVCChat.Service
{
    public class CommentService:AbstractRepository<Comment,BigPardakht.Data.ApplicationDbContext>
    {
        public CommentService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
    
    
    
}