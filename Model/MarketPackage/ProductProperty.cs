using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace AbstractLibrary.Model.MarketModel
{
    public class ProductProperty : Entity,IHasTranslate
    {


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
        [DontPrint]
        public IEnumerable<ProductPropertyValue> ProductPropertyValueList { get; set; }
    }
}