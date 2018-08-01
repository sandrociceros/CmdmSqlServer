using CMdm.Core;
using CMdm.Entities.Domain.CustomModule.Fcmb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMdm.Services.CustomModule.Fcmb
{
    public interface ISameCifService
    {
        #region SameCif
        /// <summary>
        /// Gets a queitem by item identifiers
        /// </summary>
        /// <param name="recordId">recordId identifier</param>
        /// <returns>Vendor</returns>
        IList<SameCif> GetSameCifbyIds(Int64[] recordIds);
        /// <summary>
        /// Gets a Queitem by item reference identifier
        /// </summary>
        /// <param name="recordId">que identifier</param>
        /// <returns>Vendor</returns>
        SameCif GetSameCifbyId(Int64 recordId);
        /// <summary>
        /// Gets all items
        /// </summary>
        /// <param name="name"> name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortExpression">A value indicating whether to show hidden records</param>
        /// <returns>Vendors</returns>
        IPagedList<SameCif> GetAllSameCifs(string name = "", string custid = "", string branchcode = "", string accountnum = "",
            int pageIndex = 0, int pageSize = int.MaxValue, string sortExpression = "");
        #endregion SameCif

        #region DistinctSameCif
        /// <summary>
        /// Gets a queitem by item identifiers
        /// </summary>
        /// <param name="recordId">recordId identifier</param>
        /// <returns>Vendor</returns>
        IList<DistinctSameCif> GetDistinctSameCifbyIds(Int64[] recordIds);
        /// <summary>
        /// Gets a Queitem by item reference identifier
        /// </summary>
        /// <param name="recordId">que identifier</param>
        /// <returns>Vendor</returns>
        DistinctSameCif GetDistSameCifbyId(Int64 recordId);
        /// <summary>
        /// Gets all items
        /// </summary>
        /// <param name="name"> name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortExpression">A value indicating whether to show hidden records</param>
        /// <returns>Vendors</returns>
        IPagedList<DistinctSameCif> GetAllDistinctSameCifs(string cust_name = "", string cust_id = "",
            int pageIndex = 0, int pageSize = int.MaxValue, string sortExpression = "");
        #endregion DistinctSameCif
    }
}
