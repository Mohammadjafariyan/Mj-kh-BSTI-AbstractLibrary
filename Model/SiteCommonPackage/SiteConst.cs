using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace AbstractLibrary.Model.SiteCommonModel
{
    public class SiteConst:Entity,IHasTranslate
    {
        public string Label { get; set; }


        [DontPrint] public string TitleJson { get; set; }



     
        [NotMapped]
        [Translate]
        [Display(Name = "متن نمایش در وب سایت")]
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

    }
}