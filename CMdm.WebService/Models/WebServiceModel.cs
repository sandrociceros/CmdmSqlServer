using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMdm.WebService.Models
{
    public class WebServiceModel
    {
        public string CUSTOMER_NO { get; set; }
        public string TITLE { get; set; }
        public string SURNAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string OTHER_NAME { get; set; }
        public DateTime? DATE_OF_BIRTH { get; set; }
        public string COUNTRY_OF_BIRTH { get; set; }
        public string SEX { get; set; }
        public string MARITAL_STATUS { get; set; }

        public string LGAOFORIGIN { get; set; }
        public string RESIDENCE_COUNTRY { get; set; }
        public string TIN { get; set; }
        public string BVN { get; set; }
        public DateTime? RESIDENCEPERMIT_ISSDATE { get; set; }
        public DateTime? RESIDENCEPERMIT_EXPDATE { get; set; }
        public string PURPOSEOFACCOUNT { get; set; }
        public string RESIDENCEPERMITNO { get; set; }

        public string NATIONALITY { get; set; }
        public string STATE_OF_ORIGIN { get; set; }
        public string MOTHER_MAIDEN_NAME { get; set; }
        public string RELIGION { get; set; }
        public string BRANCH_CODE { get; set; }
        public string RESIDENTIAL_ADDRESS { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public int RETCODE { get; set; }
        public string RESPONSEDESCRIPTION { get; set; }
    }
}