using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CMdm.WebService.Models
{
    //[DataContract]
    //[KnownType(typeof(IDictionary))]
    public class WebServiceModel
    {
        //public string CUSTOMER_NO { get; set; }
        //public string SURNAME { get; set; }
        //public string FIRST_NAME { get; set; }
        //public DateTime? DATE_OF_BIRTH { get; set; }
        //public string SEX { get; set; }
        //public string MARITAL_STATUS { get; set; }
        //public string STATE_OF_ORIGIN { get; set; }
        //public string RESIDENTIAL_ADDRESS { get; set; }
        //public string MOBILE_NO { get; set; }
        //public string EMAIL_ADDRESS { get; set; }
        //public string EMPLOYMENT_STATUS { get; set; }
        public int RETCODE { get; set; }
        public string RESPONSEDESCRIPTION { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }
}