using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.MarketModel;
using AbstractLibrary.Service;
using BigPardakht.Model;
using Newtonsoft.Json;
using SignalRMVCChat.Models.weblog;
using SignalRMVCChat.Service;
using SignalRMVCChat.Service.HelpDesk;
using SignalRMVCChat.Service.HelpDesk.Language;

namespace SignalRMVCChat.Models.HelpDesk
{
    public class Category : SafeDeleteEntity,IFileSupport
    {
        public Category()
        {
            Articles = new List<Article>();
            Order = 0;
        }

        
         
    
        [DontPrint]
        public string FilesJson { get; set; }
        
        
        [NotMapped]
        [SelectFile]
        public string FilesBind { get; set; }

        
        [DontPrintAttribute]
        [NotMapped]
        public int[] Files
        {
            get
            {
                if (string.IsNullOrEmpty(FilesJson))
                {
                    return new List<int>().ToArray();
                }

                return JsonConvert.DeserializeObject<int[]>(FilesJson);
            }
            set { FilesJson = JsonConvert.SerializeObject(value); }
        }


        [DontPrint]
        /// <summary>
        /// مقالات
        /// </summary>
        public List<Article> Articles { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        [TextArea]
        public string Description { get; set; }


        [Hidden]
        public DateTime LastUpdatedDateTime { get; set; } = DateTime.Now;
        [Hidden]
        public string LastUpdatedDescription { get; set; }


        [SelectColor]
        public string BgColor { get; set; }
     
        
        public long Order { get; set; }

       

      
        [DontPrint]
        public CategoryImage CategoryImage { get; set; }

        [SelectByService(ServiceType = typeof(HelpDeskService))]
        public long HelpDeskId { get; set; }
       
        
        [DontPrint]
        public HelpDesk HelpDesk { get; set; }


        /*
        [NotMapped]
        [DontPrint]
        public string Content { get; set; }*/

        [DontPrint]
        public List<Blog> Blogs { get; set; }
    }

    public class Article : SafeDeleteEntity
    {
        public Article()
        {
            Comments = new List<Comment>();
            ArticleVisits = new List<ArticleVisit>();
        }



        public Product Product { get; set; }

        public long? ProductId { get; set; }



        /// <summary>
        /// عنوان مقاله
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// متن مقاله
        /// </summary>

        /// <summary>
        /// html که موقع ارسال می آید
        /// </summary>
        [RichText]
       // [AllowHtml]
        public string Content { get; set; }

        /// <summary>
        /// متنی که موقع ارسال می آید
        /// </summary>
        ///
        [Hidden]
        public string textValue { get; set; }


        [Hidden]
        public DateTime LastUpdatedDateTime { get; set; }
       
        [Hidden]
        public string LastUpdatedDescription { get; set; }

        [Hidden]
        public ArticleStatus ArticleStatus { get; set; }



        [DontPrint]
        public List<ArticleVisit> ArticleVisits { get; set; }


        public long Order { get; set; }

        public string Description { get; set; }


        
        [SelectByService(ServiceType=typeof(CategoryService))]
        public long? CategoryId { get; set; }
      
        
        [DontPrint]
        public Category Category { get; set; }
       
        
        public string Summary { get; set; }


        [DontPrint]
        public List<Comment> Comments { get; set; }
        public string Keywords { get;  set; }
    }




    public class Language : SafeDeleteEntity
    {
        public Language()
        {
            HelpDesks = new List<HelpDesk>();
        }


        
        [DontPrint]
        public List<HelpDesk> HelpDesks { get; set; }
        
        
        
        public string nativeName { get; set; }
        
        [SelectByService(ServiceType = typeof(SupportedLanguagesService))]
        public string Code { get; set; }

    }

    public class HelpDesk : SafeDeleteEntity
    {
        public HelpDesk()
        {
            Categories = new List<Category>();
        }



        [DontPrint]
        public List<Category> Categories { get; set; }

        [DontPrint]
        public Language Language { get; set; }

        [SelectByService(ServiceType = typeof(LanguageService))]
        public long LanguageId { get; set; }
        
        [Hidden]
        public bool Selected { get; set; }

        /*/// <summary>
        /// مربوط به کدام وب سایت است
        /// </summary>
        public MyWebsite MyWebsite { get; set; }


        /// <summary>
        /// مربوط به کدام وب سایت است
        /// </summary>
        public long MyWebsiteId { get; set; }*/

        [SelectColor]
        public string BgColor { get; set; }
    }

    public class ArticleVisit : SafeDeleteEntity
    {
        public ArticleVisit()
        {
            DateTime = DateTime.Now;
        }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public long ArticleId { get; set; }
        public Article Article { get; set; }


        /// <summary>
        /// کد ای پی بازدید کننده
        /// </summary>
        public string IpAddress { get; set; }
        public string UserAgent { get; internal set; }
        public string Browser { get; internal set; }
    }

    public enum ArticleStatus
    {
        Publish = 2, Hidden = 1, Draft = 0
    }

    public class CategoryImage : SafeDeleteEntity
    {
        [ForeignKey("Category")]
        public override long Id { get; set; }

        public Category Category { get; set; }

        public string Content { get; set; }

        public string ImageExtention { get; set; }

    }
    /*public class ArticleContent : SafeDeleteEntity
    {
        [ForeignKey("Article")]
        public override long Id { get; set; }

        public Article Article { get; set; }


        public byte[] Content { get; set; }

        [NotMapped]
        public string HtmlContent
        {
            get
            {
                if (Content == null)
                {
                    return null;
                }
                return Encoding.UTF8.GetString(Content);
            }
        }
    }*/


}