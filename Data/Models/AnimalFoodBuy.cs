using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;
using TelegramBotsWebApplication;

namespace my_webapp.Model
{
    public class AnimalFoodBuy:SafeDeleteEntity
    {
        
                
        [Select]
        [Required]
        [Display(Name = "نهاده")]
        public long AnimalFoodId{get;set;}
        
        [Text(Help = "قیمت خریداری شده هر کیلو (ریال)",Type = "money")]
        [Required]
        [Display(Name = "قیمت هر کیلو خرید")]
        [MinValue(1000)]
        public decimal BuyPerUnitPrice { get; set; }

        
                
        [Text(Type = "money")]
        [Required]
        [Display(Name = "قیمت هر کیلو برای فروش (ریال)")]
        [MinValue(1000)]
        public decimal SellPerUnitPrice { get; set; }

        [Text(Type = "number")]
        [Required]
        [MinValue(0)]
        [Display(Name = "مقدار نهاده برای هر گاو و گاومیش")]
        public decimal PerCowKg { get; set; }
        
        [Text(Type = "number")]
        [Required]
        [MinValue(0)]
        [Display(Name = "مقدار نهاده برای هر گوسفند و بز")]
        public decimal PerBozKg { get; set; }
        
                
        [Text(Type = "number")]
        [Required]
        [MinValue(5)]
        [Display(Name = "مقدار خریداری شده نهاده")]
        public decimal Remain { get; set; }
        
        

        [Hidden]
        public AnimalFood AnimalFood{get;set;}

        
        
        [TextArea]
        [Display(Name = "توضیحات ")]
        public string Description { get; set; }
        
        [Hidden]
        public string Fish { get; set; }
    
        
        [Hidden]
        public DateTime DateTime { get;  set; }=DateTime.Now;
        
        
                
        [Text]
        [Display(Name = "تاریخ خرید ")]
        [Required]
        public string BuyDateTime { get;  set; }

        [NotMapped]
        public string DateTimeIR { get{
            return MyGlobal.ToIranianDateWidthTime(DateTime);
        }  }

        
        [Hidden]
        public List<IssueFood> IssueFoods { get; set; }
    }
}