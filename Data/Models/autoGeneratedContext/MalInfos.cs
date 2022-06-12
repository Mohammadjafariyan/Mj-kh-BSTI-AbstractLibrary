using BigPardakht.Model;

namespace SignalRMVCChat.Models.autoGeneratedContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MalInfos")]
    public partial class MalInfos:SafeDeleteEntity
    {

        [StringLength(255)]
        public string NameDamdar { get; set; }

        [StringLength(255)]
        public string Rusta { get; set; }

        public double? TotalMal { get; set; }

        public double? TotalCow { get; set; }

        public double? TotalGowMish { get; set; }

        [StringLength(255)]
        public string Marhale1 { get; set; }

        public double? Marhale2 { get; set; }

        [StringLength(255)]
        public string PKFrom { get; set; }

        [StringLength(255)]
        public string PKTo { get; set; }

        public int? DistributionId { get; set; }
    }
}