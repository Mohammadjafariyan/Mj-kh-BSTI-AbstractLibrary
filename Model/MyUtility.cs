using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AbstractLibrary.Model.User;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigPardakht.Model
{
    public static class MyUtility
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, bool equals = false,
            string cssClass = "active")
        {
            var path=htmlHelper.ViewContext.HttpContext.Request.GetDisplayUrl();

            // IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
         //   IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');

         if (!equals)
         {
             return path.Contains(controllers)
                 ? cssClass
                 : String.Empty;
         }
         else
         {
             return path.Equals(controllers)
                 ? cssClass
                 : String.Empty;
         }



         /*
         if (!equals)
         {
             return path.Contains(controllers)
                    || htmlHelper.ViewContext.ActionDescriptor.RouteValues["page"].Contains(controllers)
                 ? cssClass
                 : String.Empty;
         }
         else
         {
             return htmlHelper.ViewContext.ActionDescriptor.RouteValues["page"].Equals(controllers)
                 ? cssClass
                 : String.Empty;
         }*/
        }

        public static async Task<(List<ApplicationUser> admins, List<ApplicationUser> users,bool isCurrentUserIsAdmin)> GetAdminsAndUsers(
            ClaimsPrincipal user, UserManager<ApplicationUser> UserManager)
        {
            var users = UserManager.Users.ToList();

            bool isCurrentUserIsAdmin = false;
            List<ApplicationUser> targetUsers = new List<ApplicationUser>();
            var currentUser = await UserManager.GetUserAsync(user);
            if (await UserManager.IsInRoleAsync(currentUser, MyConstants.Admin)
                || await UserManager.IsInRoleAsync(currentUser, MyConstants.SystemAdmin))
            {
                isCurrentUserIsAdmin = true;
            }

            List<ApplicationUser> admins = new List<ApplicationUser>();
            List<ApplicationUser> _users = new List<ApplicationUser>();
            foreach (var applicationUser in users)
            {
                if (applicationUser.Id == currentUser.Id)
                {
                    continue;
                }

                var isAdmin = await UserManager.IsInRoleAsync(applicationUser, MyConstants.Admin);

                if (isAdmin)
                {
                    admins.Add(applicationUser);
                }
                else
                {
                    _users.Add(applicationUser);
                }
            }

            return (admins, _users,isCurrentUserIsAdmin);
        }
    }
}