using System.Collections.Generic;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.MarketModel.Repository;
using AbstractLibrary.Model.MultiLanguageModel;
using BigPardakht.Model;

namespace AbstractLibrary.Model.MarketModel
{
    public class ProductPropertyValue : Entity
    {
        
        [DontPrint]
        public Product Product { get; set; }

        [DontPrint]
        public ProductProperty ProductProperty { get; set; }  
        
        [SelectByService(ServiceType = typeof(ProductRepository))]
        public long ProductId { get; set; }

        
        [SelectByService(ServiceType = typeof(ProductPropertyRepository))]
        public long ProductPropertyId { get; set; }


        public string Value { get; set; }


    //    [Translate]  public TranslateColumn  TextValue { get; set; }
        
    }
}