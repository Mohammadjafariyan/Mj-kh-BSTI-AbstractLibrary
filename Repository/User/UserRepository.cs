
using AbstractLibrary.Model.User;
using Microsoft.AspNetCore.Http;

namespace BigPardakht.Repository.User
{
    public class AbstractUserRepository<TContext>:AbstractRepository<ApplicationUser,TContext>
    {
        public AbstractUserRepository(TContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
}