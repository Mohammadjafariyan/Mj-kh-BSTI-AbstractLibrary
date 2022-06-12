using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Xceed.Document.NET;

namespace AbstractLibrary.Model.MultiLanguageModel
{

    public interface IHasTranslate
    {
        List<Translate> Title { get; set; }
    }
    [ComplexType]
    public class Translate
    {
        
        public string Code { get; set; }
        public string LanguageName { get; set; }
        public string Text { get; set; }
        
        /*public string _Translates { get; set; }


        [NotMapped]
        public List<Translate> Translates
        {
            get
            {
                if (_Translates == null)
                {
                    return new List<Translate>();
                }

                return JsonConvert.DeserializeObject<List<Translate>>(_Translates);
            }
            set => _Translates = JsonConvert.SerializeObject(value);
        }*/
    }

  
}