using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CMdm.Data;
using CMdm.WebService.Models;

namespace CMdm.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FetchCustomer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FetchCustomer.svc or FetchCustomer.svc.cs at the Solution Explorer and start debugging.
    public class FetchCustomer : IFetchCustomer
    {
        public string DoWork()
        {
            return "Hello World!";
        }

        WebServiceModel IFetchCustomer.GetCustomerDetails(string CUSTOMER_NO)
        {
            var model = new WebServiceModel();
            using (AppDbContext db = new AppDbContext())
            {
                model = (
                    from c in db.CDMA_INDIVIDUAL_BIO_DATA
                    join d in db.CDMA_INDIVIDUAL_CONTACT_DETAIL on c.CUSTOMER_NO equals d.CUSTOMER_NO
                    where c.CUSTOMER_NO == CUSTOMER_NO
                    select new WebServiceModel
                    {
                        CUSTOMER_NO = c.CUSTOMER_NO,
                        TITLE = c.TITLE,
                        SURNAME = c.SURNAME,
                        DATE_OF_BIRTH = c.DATE_OF_BIRTH,
                        FIRST_NAME = c.FIRST_NAME,
                        OTHER_NAME = c.OTHER_NAME,
                        COUNTRY_OF_BIRTH = c.COUNTRY_OF_BIRTH,
                        SEX = c.SEX,
                        MARITAL_STATUS = c.MARITAL_STATUS,
                        NATIONALITY = c.NATIONALITY,
                        STATE_OF_ORIGIN = c.STATE_OF_ORIGIN,
                        MOTHER_MAIDEN_NAME = c.MOTHER_MAIDEN_NAME,
                        RELIGION = c.RELIGION,
                        BRANCH_CODE = c.BRANCH_CODE,
                        RESIDENTIAL_ADDRESS = d.MAILING_ADDRESS,
                        MOBILE_NO = d.MOBILE_NO,
                        EMAIL_ADDRESS = d.EMAIL_ADDRESS,
                        LGAOFORIGIN = c.LGAOFORIGIN,
                        RESIDENCE_COUNTRY = c.RESIDENCE_COUNTRY,
                        TIN = c.TIN,
                        BVN = c.BVN,
                        RESIDENCEPERMIT_ISSDATE = c.RESIDENCEPERMIT_ISSDATE,
                        RESIDENCEPERMIT_EXPDATE = c.RESIDENCEPERMIT_EXPDATE,
                        PURPOSEOFACCOUNT = c.PURPOSEOFACCOUNT,
                        RESIDENCEPERMITNO = c.RESIDENCEPERMITNO,
                        RETCODE = 0,
                        RESPONSEDESCRIPTION = "Success"
                    }
                    ).FirstOrDefault();
                if (model == null)
                {
                    model = (new WebServiceModel
                    {
                        RETCODE = 999,
                        RESPONSEDESCRIPTION = "Customer does not exist"
                    });
                }
            }
                
            return model;
        }
    }
}
