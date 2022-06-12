using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.FrontPackage.Repository;
using AbstractLibrary.Model.MarketModel;
using AbstractLibrary.Model.MarketModel.Repository;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace AbstractLibrary.Model.FrontModel
{
    public class SlideShow:Entity,IFileSupport
    {
        
        [DontPrint]
        public Slide Slide { get; set; }
        
       
        [SelectByService(ServiceType = typeof(SlideRepository))]
        public long SlideId { get; set; }

        [DontPrint]
        public Product Product { get; set; }
        

        [SelectByService(ServiceType = typeof(ProductRepository))]
        public long? ProductId { get; set; }

        
        [DontPrint]
        public ProductCategory ProductCategory { get; set; }
        
        
        [SelectByService(ServiceType = typeof(ProductCategoryRepository))]
        public long? ProductCategoryId { get; set; }


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
        
    }
}