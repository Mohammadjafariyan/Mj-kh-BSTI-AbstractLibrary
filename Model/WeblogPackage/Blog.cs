using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BigPardakht.Model;
using SignalRMVCChat.Models.HelpDesk;

namespace SignalRMVCChat.Models.weblog
{
    public class Blog : Entity
    {

        public string Title { get; set; }

       // [AllowHtml]
        public string Content { get; set; }
        public BlogType Type { get; set; }
        public bool InHomePage { get; set; }
        public long? CategoryId { get; set; }
        public Category Category { get; set; }
    }


    public enum BlogType
    {
        [Display(Name = "درباره ما")]
        AboutUs = 1,

        [Display(Name = "قوانین")]
        Rules = 2,
        [Display(Name = "معرفی")]
        Intro=3,
        [Display(Name = "حریم خصوصی")]
        Privacy=4,
       
        [Display(Name = "ارتباط با ما")]
        ContactUs,
        [Display(Name = "شبکه های اجتماعی")]
        SocialNetworks,
        [Display(Name = "تیم")]
        Team,
        [Display(Name = "ما در اخبار")]
        InNews,
        [Display(Name = "قوانین  دولتی")]
        GovernmentRules,
        [Display(Name = "خدمات ما")]
        Services,
        [Display(Name = "سوالات متداول")]
        Questions
    }
}