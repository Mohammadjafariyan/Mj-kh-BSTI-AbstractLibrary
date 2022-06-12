using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BigPardakht.DynamicForm;
using BigPardakht.Model;
using BigPardakht.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbstractLibrary.Model.User
{
    public partial class ApplicationUser : IdentityUser<long>, IEntity
    {
        public string Name { get; set; }


        public RegisterType RegisterType { get; set; }


        [NotMapped] public Dictionary<string, SelectList> FormData { get; set; }
        [NotMapped] public Dictionary<string, List<CheckItem>> CheckList { get; set; }


        /// <summary>
        /// والت هایی که این کاربر دستکاری کرده است
        /// </summary>
        public decimal WalletBalance { get; set; }
    }

    public enum RegisterType
    {
        
        PercentFromBuyer=1,
        PercentFromUser=2,
        PerYearOrPerMonthReserve=3
    }
}