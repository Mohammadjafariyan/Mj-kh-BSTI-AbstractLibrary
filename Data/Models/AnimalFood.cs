using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;

namespace my_webapp.Model
{
    public class AnimalFood:SafeDeleteEntity
    {
        [Text]
        [Display(Name = "عنوان نهاده")]
        public  string AnimalFoodName { get; set; }


 
        [Hidden]
        /// <summary>
        /// حواله ها
        /// </summary>
        /// <value></value>
        public List<Model.AnimalFoodBuy> AnimalFoodBuys { get; set; }
        
                



    }
}