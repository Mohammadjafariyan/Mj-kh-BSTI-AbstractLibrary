using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.FrontPackage.Repository;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace AbstractLibrary.Model.FrontModel
{
    public class Menu : Entity,IHasTranslate
    {
        
        [DontPrint]
        public MenuCategory MenuCategory { get; set; }
        
        [SelectByService(ServiceType = typeof(MenuCategoryRepository))]
        public long MenuCategoryId { get; set; }

        [DontPrint] public string TitleJson { get; set; }

     
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


        [Text( Help = "برای مثال : https://www.googl.com")]
        public string Url { get; set; }
    }
}