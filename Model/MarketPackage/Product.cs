using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.FrontModel;
using AbstractLibrary.Model.MarketModel.Repository;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;
using SignalRMVCChat.Models;
using SignalRMVCChat.Models.HelpDesk;

namespace AbstractLibrary.Model.MarketModel
{
    public class Product : Entity,IFileSupport,IHasTranslate
    {

        [DontPrint] public string TitleJson { get; set; }


        [Display(Name = "قیمت")]
        public string Cost { get; set; }
     
        [NotMapped]
        [Translate] 
        public List<Translate> Title
        {
            get
            {
                if (string.IsNullOrEmpty(TitleJson))
                {
                    return new List<Translate>();
                }

                return JsonConvert.DeserializeObject<List<Translate>>(TitleJson);
            }
            set { TitleJson = JsonConvert.SerializeObject(value); }

        }
        
        
        [NotMapped]
        [Translate]
        public List<Translate> Description
        {
            get
            {
                if (string.IsNullOrEmpty(DescriptionJson))
                {
                    return new List<Translate>();
                }

                return JsonConvert.DeserializeObject<List<Translate>>(DescriptionJson);
            }
            set { DescriptionJson = JsonConvert.SerializeObject(value); }

        }

        [DontPrint] public string DescriptionJson { get; set; }
        
        //[Translate]  public TranslateColumn  Description { get; set; }


        public string Tags { get; set; }
        
        [DontPrint]
        public ProductCategory ProductCategory { get; set; }
        
        
        [SelectByService(ServiceType =typeof(ProductCategoryRepository))]
        public long ProductCategoryId { get; set; }


        [DontPrint]
        public List<SlideShow> SlideShows { get; set; }



        [DontPrint] public string FilesJson { get; set; }


        [NotMapped] [SelectFile] public string FilesBind { get; set; }


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
        public IEnumerable<ProductPropertyValue> ProductPropertyValueList { get; set; }

        public int? Discount { get; set; }
        public List<Article> Articles { get; set; }




        public List<Comment> Comments { get; set; }
    }
}