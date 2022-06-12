using System.Security.Claims;
using System.Threading.Tasks;
using AbstractLibrary.Model.User;
using BigPardakht.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AbstractLibrary.Model
{
    public class MyCommonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyCommonService(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public async Task<bool> CurrentUserIsAdmin(ClaimsPrincipal User)
        {
            var currUser = await _userManager.GetUserAsync(User);

            var isAdmin = await _userManager.IsInRoleAsync(currUser, MyConstants.Admin)
                          || await _userManager.IsInRoleAsync(currUser, MyConstants.Admin);

            return isAdmin;
        }

        public bool IsGuideDisabled
        {
            get
            {
                var str = _httpContextAccessor.HttpContext.Request.Cookies[MyConstants.IsGuideDisabled];
                if (str == "true")
                {
                    return true;
                }

                return false;
            }
        }

      
    }
}