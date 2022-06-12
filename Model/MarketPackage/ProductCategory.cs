using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.FrontModel;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;
using Xceed.Document.NET;

namespace AbstractLibrary.Model.MarketModel
{
    public class ProductCategory : Entity,IFileSupport,IHasTranslate
    {
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

        [DontPrint] public string TitleJson { get; set; }

        
        
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

        [Text]
        public string Tags { get; set; }




     
      
        
        [DontPrint]

        public List<Product> ProductList { get; set; }


        [DontPrint]

        public List<SlideShow> SlideShows { get; set; }
        
        
        
        [DontPrint]
        public string FilesJson { get; set; }
        
        
        [NotMapped]
        [SelectFile]
        public string FilesBind { get; set; }

        
        [NotMapped]
        [Images]
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

        [SelectEnum]
        public ProductCategoryType Type { get; set; }
    }


    public enum ProductCategoryType
    {      
        
       
        
        [Display(Name = "فروش ویژه")]
        SpecialSell,
        [Display(Name = "پر فروش")]
        MostSell,
        [Display(Name = "پر طرفدارترین ها")]
        Popular,
        [Display(Name = "پر فروش هفته")]
        WeekMostSell,
        [Display(Name = "دستگاه های جدید")]
        News,
        [Display(Name = "مشهور ترین ها")]
        MostPopular,
        
    }
    
}

