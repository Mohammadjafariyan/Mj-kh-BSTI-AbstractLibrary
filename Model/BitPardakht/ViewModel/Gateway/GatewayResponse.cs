using System.ComponentModel.DataAnnotations;

namespace BigPardakht.ViewModel.Gateway
{
    /// <summary>
    /// ابجکت نتیجه درخواست تراکنش جدید
    /// </summary>
    public class NewTransactionResponse
    {
        
        /// <summary>
        /// وضعیت نتیجه
        /// </summary>
        public GatewayStatus GatewayStatus { get; set; }

        /// <summary>
        /// پیغام نتیجه
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// کلید منحصر به فرد تراکنش
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// لینک پرداخت برای انتقال خریدار به درگاه پرداخت
        /// </summary>
        public string Link { get; set; }
    }

    /// <summary>
    /// وضعیت نتیجه درخواست تراکنش جدید
    /// </summary>
    public enum GatewayStatus
    {
        
        [Display(Name = "درخواست تراکنش موفق")]
        Succeed=10,
        [Display(Name = "کاربر مسدود شده است")]
        UserBlocked=21,
        [Display(Name = "کلید دسترسی به وب سرویس یافت نشد")]
        API_Key_NotFound=22,
       
        [Display(Name = "سایت درخواست کننده شناسایی نشد")]
        RequesterIPNotFound=23,
      
        [Display(Name = "درگاه برای وب سایت شما تایید نشده است")]
        YourWebserverNotConfirmedOrInChecking=24,
       
        [Display(Name = "وب سرویس یافت نشد")]
        WebserviceNotFound=25,
      
        [Display(Name = "کد مخصوص سفارش یافت نشد")]
        OrderIdRequired=31,
       
        [Display(Name = "مقدار ارسال نشده است")]
        AmountRequired=32,
     
        [Display(Name = "مقدار ارسال شده از ماکزیمم قابل درخواست بیشتر است")]
        MaxAmountRequired=33,
       
        [Display(Name = "مقدار ارسال شده از مینیمم قابل درخواست کمتر است")]
        MinAmountRequired=34,
      
        [Display(Name = "آدرس بازگشت نتیجه تراکنش ارسال نشده است")]
        CallbackRequired=35,
      
        [Display(Name = "آدرس بازگشت نتیجه تراکنش صحیح نیست و یا وجود ندارد")]
        CallbackUrlInvalid=37,
      
        [Display(Name = "دامنه دیگری تشخیص داده شد")]
        AnotherDomainDetected=36,
       
        [Display(Name = "تراکنش ایجاد نشد")]
        TransactionNotCreated=40,


        [Display(Name = "درخواست خالی - در مواقع ارسال درخواست ناصحیح")]
        EmptyRequest=38,
      
        [Display(Name = "کلید دسترسی به وب سرویس ارسال نشده است")]
        B_API_KEY_NotSet=39,
    
        [Display(Name = "رمز ارز ارسالی صحیح نیست")]
        CoinWrong=51
    }
}