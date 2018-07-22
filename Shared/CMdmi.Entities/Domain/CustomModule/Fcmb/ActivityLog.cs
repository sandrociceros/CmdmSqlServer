using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMdm.Entities.Domain.CustomModule.Fcmb
{
    [Table("VW_ACTIVITY_LOG")]
    public partial class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }
        public Int64 ACTIVITY_ID { get; set; }
        public Int64 USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string FULLNAME { get; set; }
        public string ACTIVITY_DESC { get; set; }
        public DateTime? ACTIVITY_DATE { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
    }
}
