using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMdm.Entities.Domain.CustomModule.Fcmb
{
    [Table("VW_SAME_CIF")]
    public partial class SameCif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUST_NAME { get; set; }
        public string SOL_ID { get; set; }
        public string FORACID { get; set; }
        public string FREE_CODE_10 { get; set; }
        public string REF_DESC { get; set; }
        public string SCHM_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
    }
}
