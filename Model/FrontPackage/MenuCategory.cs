using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;
using Xceed.Document.NET;

namespace AbstractLibrary.Model.FrontModel
{
    public class MenuCategory:Entity,IHasTranslate
    {

        [DontPrint] public List<Menu> MenuList { get; set; } = new List<Menu>();



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


        [TextArea]
        public string Description { get; set; }  
        
        
        [Text]
        public string Url { get; set; }


        [SelectEnum(EnumType = typeof(MenuLocation))]
        public MenuLocation MenuLocation { get; set; }
    }

    public enum MenuLocation
    {
        [Display(Name = " بالای سایت")]
        Top,
        
        [Display(Name = " پایین سایت")]
        Footer,     
        
        [Display(Name = " بالا و پایین سایت")]
        TopAndFooter,
        
        
        
    }
}