using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using BigPardakht.DynamicForm;
using BigPardakht.Model;

namespace SignalRMVCChat.Service
{
    public class Setting : Entity
    {

        public Setting()
        {
            WaterMark = " قدرت گرفته از گپچت";
            TrivialDays = 7;
            IsStartWithTrivialPlan = true;

            
            MinAmount = 100000;
            MaxAmount = 500000000;

   

            OperatorBotToken = "1431377672:AAH0sXB1kc4VvuaAFU_is7JP3_YmW5eQXRo";

        }

        
        /*
        /// <summary>
        /// کد مخصوص ایدی پی پرداخت
        /// </summary>
        public string IdPayApiKey { get; set; }*/

        
        [Display(Name = "WaterMark")]
        [Text]
        public string WaterMark { get; set; }

[Hidden]
        public bool IsSystemInitialized { get; set; }
        [Hidden]
        public bool IsSettingFormSubmitted { get; set; }
        
        
        
        [Hidden]
        public int TrivialDays { get; set; }
        [Hidden]
        public bool IsStartWithTrivialPlan { get; set; }
        
        
        
       
      
        [Hidden]
        public string BaseUrl { get; set; }


        [Hidden]
        /// <summary>
        /// توکن اوپراتور ها
        /// </summary>
        public string OperatorBotToken { get; set; }
     
        
        [Display(Name = "WebsiteName")]
        [Text(Help = "عنوان سایت در سراسر اپلیکیشن نمایش داده خواهد شد")]
        public override string Name { get; set; } = "بیت پرداخت";



        [Display(Name = "MinAmount Allowed to Payment")]
        [Text]
        public long MinAmount { get; set; }
       
        [Display(Name = "MaxAmount Allowed to Payment")]
        [Text]
        public long MaxAmount { get; set; }


        [Display(Name = "AdminRegisterDisabled")]
        [Input(Type = InputType.Checkbox)]
        public bool AdminRegisterDisabled { get; set; }


        #region Socialnetowrks
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }
        public string Instagram { get; set; }
        public string Linkedlin { get; set; }
        public string Youtube { get; set; }
        public string Google { get; set; }
        public string BitCoin { get; set; }
        public string Whatsapp { get; set; }
        public string GooglePlus { get; set; }
        
        [Display(Name = "PerYearReserve")]
        [Text]
        public decimal PerYearReserve { get; set; } = 1500000 * 12;
        [Display(Name = "PerMonthReserve")]
        [Text]
        public decimal PerMonthReserve { get; set; } = 1500000 ;

        #endregion

        /*
        #region email setting

        /*----------------------------- email setting : ----------------------#1#
        public string FromMailAddress { get; set; }
        public string Host { get; set; }
        public string FromMailAddressPassword { get; set; }
        public string OperatorsBotName { get;  set; }
        public string EmailTemplate_ForgetPassword { get;  set; }

        #endregion*/


    }
}