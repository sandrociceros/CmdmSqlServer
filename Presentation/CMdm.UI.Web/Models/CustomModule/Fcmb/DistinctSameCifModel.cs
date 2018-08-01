using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CMdm.UI.Web.Models.CustomModule.Fcmb
{
    public class DistinctSameCifModel
    {
        public Int64 ID { get; set; }
        [DisplayName("Customer No")]
        public string CUSTOMER_ID { get; set; }
        [DisplayName("Customer Name")]
        public string CUST_NAME { get; set; }
    }
}