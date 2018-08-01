using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMdm.UI.Web.Models.CustomModule.Fcmb
{
    public class SameCifModel
    {
        public SameCifModel()
        {
            Branches = new List<SelectListItem>();
        }

        [DisplayName("Customer No")]
        public string CUSTOMER_ID { get; set; }
        [DisplayName("Customer Name")]
        public string CUST_NAME { get; set; }
        [DisplayName("Branch")]
        public string SOL_ID { get; set; }
        [DisplayName("Account No")]
        public string FORACID { get; set; }
        [DisplayName("Free Code")]
        public string FREE_CODE_10 { get; set; }
        [DisplayName("Description")]
        public string REF_DESC { get; set; }
        [DisplayName("Scheme Code")]
        public string SCHM_CODE { get; set; }
        [DisplayName("Branch Name")]
        public string BRANCH_NAME { get; set; }

        public Int64 Id
        {
            get; set;
        }

        public IList<SelectListItem> Branches { get; set; }
    }
}