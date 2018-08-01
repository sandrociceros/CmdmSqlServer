using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMdm.Entities.Domain.CustomModule.Fcmb
{
    [Table("VW_DISTINCT_SAME_CIF")]
    public partial class DistinctSameCif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUST_NAME { get; set; }
    }
}
