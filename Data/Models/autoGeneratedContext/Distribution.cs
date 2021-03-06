using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;
using my_webapp.Model;

namespace AbstractLibrary.Data.Models.autoGeneratedContext
{
    [Table("Distribution")]
    public partial class Distribution:SafeDeleteEntity
    {

        [StringLength(255)]
        [Text]
        [Display(Name = "نام و نام خانوادگی")]
        public string NamVaNameKhanevadegi { get; set; }
        
        

        [Text]
        [Display(Name = "کد ملی")]
        public string CodeMelli { get; set; }
        
        [Text]
        [Display(Name = "تعداد بز و گوسفند")]
        public double? TotalMal { get; set; }

        [Text]
        [Display(Name = "تعداد گاو و گاومیش")]
        public double? TotalCow { get; set; }
        
   
        
        [Hidden]
        public List<IssueAssignment> IssueAssignments { get; set; }

        [Hidden]
        [StringLength(255)]
        public string Etehadie { get; set; }

        [Text]
        [Display(Name = "تعاونی")]
        [StringLength(255)]
        public string Taavoni { get; set; }

        [StringLength(255)]
        [Text]
        [Display(Name = "شهرستان")]
        public string Shahrestan { get; set; }

 

        [StringLength(255)]
        [Text]
        [Display(Name = "آدرس و نام روستا")]
        public string AddressVaNameRusta { get; set; }

        [Text]
        [Display(Name = "تلفن")]
        public string Telephone { get; set; }

        [Text]
        [Display(Name = "شماره عضویت تعاونی")]
        public double? ShomareOzviateTaavoni { get; set; }

        [StringLength(255)]
        [Text]
        [Display(Name = "نوع فعالیت")]
        public string NoeFaaliat { get; set; }
        
        [Text]
        [Display(Name = "ظرفیت و تعداد دام و طیور")]
        public double? ZarfiatYaTedadeDamoTiur { get; set; }

        [StringLength(255)]

      [Hidden]
        public string NodeNahade { get; set; }

        [StringLength(255)]
        [Hidden]
        public string MeqdareTahviliKG { get; set; }

        [StringLength(255)]
        [Hidden]
        public string QeymateHarKGbeRIAL { get; set; }

        [StringLength(255)]
        [Hidden]
        public string MaheSahmie { get; set; }

        [StringLength(255)]
        [Hidden]
        public string F16 { get; set; }

        
        [Text]
                [Display(Name = "تلفن منزل")]
        public string HomeTelephone { get; set; }
        
        
        
    }
}
