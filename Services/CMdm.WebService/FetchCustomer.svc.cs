using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            model.Fields = new Dictionary<string, object>();
            model.RETCODE = 998;
            model.RESPONSEDESCRIPTION = "Customer has no critical data issues";

            string connString = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
            string schemaname = ConfigurationManager.AppSettings["SchemaName"].ToString();

            string[] critical_fields = { "SURNAME", "FIRSTNAME", "DATE_OF_BIRTH", "SEX", "MARITAL_STATUS", "STATE_OF_ORIGIN", "EMPLOYMENT_STATUS",
                "MOBILE_NO", "EMAIL_ADDRESS", "MAILING_ADDRESS" };
            string[] date_fields = { "DATE_OF_BIRTH" };

            AppDbContext db = new AppDbContext();
            
            var customer = db.CDMA_INDIVIDUAL_BIO_DATA.Where(x => x.CUSTOMER_NO == CUSTOMER_NO).FirstOrDefault();
            if(customer == null)
            {
                model = (new WebServiceModel
                {
                    RETCODE = 999,
                    RESPONSEDESCRIPTION = "Customer does not exist"
                });
            }
            else
            {
                var issuefileds = db.MdmDqRunExceptions.Where(a => a.CUST_ID == CUSTOMER_NO).ToList();

                if(issuefileds.Count == 0)
                {
                    model = (new WebServiceModel
                    {
                        RETCODE = 998,
                        RESPONSEDESCRIPTION = "Customer has no data issues"
                    });
                }
                else {
                    foreach (var column in issuefileds)
                    {
                        if (critical_fields.Contains(column.CATALOG_TAB_COL))
                        {
                            var query = "SELECT "+column.CATALOG_TAB_COL + " from "+column.CATALOG_TABLE_NAME+" WHERE CUSTOMER_NO = '"+CUSTOMER_NO+"' ";
                            using (SqlConnection connection = new SqlConnection(connString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(query, connection);
                                SqlDataReader rdr = command.ExecuteReader();
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        if (date_fields.Contains(column.CATALOG_TAB_COL))
                                        {
                                            model.RETCODE = 0;
                                            model.RESPONSEDESCRIPTION = "Success";
                                            model.Fields.Add(column.CATALOG_TAB_COL, rdr.GetDateTime(rdr.GetOrdinal("" + column.CATALOG_TAB_COL + "")));
                                        }                                                 
                                        else
                                        {
                                            model.RETCODE = 0;
                                            model.RESPONSEDESCRIPTION = "Success";
                                            model.Fields.Add(column.CATALOG_TAB_COL, rdr.GetString(rdr.GetOrdinal("" + column.CATALOG_TAB_COL + "")));
                                        }                                                
                                    }
                                }
                            }
                        }
                    }
                }

            }                
            return model;
        }
    }
}
