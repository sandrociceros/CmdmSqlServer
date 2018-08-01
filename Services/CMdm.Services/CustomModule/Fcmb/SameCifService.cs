using CMdm.Core;
using CMdm.Data.DAC;
using CMdm.Entities.Domain.CustomModule.Fcmb;
using CMdm.Entities.Domain.Dqi;
using CMdm.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMdm.Services.CustomModule.Fcmb
{
    public class SameCifService : ISameCifService
    {
        #region Fields

        //private readonly IRepository<MdmDQQue> _dqqueRepository;
        private SameCifDAC _scDAC;
        private DistinctSameCifDAC _dscDAC;
        #endregion
        #region Ctor
        public SameCifService()
        {
            _scDAC = new SameCifDAC();
            _dscDAC = new DistinctSameCifDAC();
        }

        #endregion
        #region SameCif
        /// <summary>
        /// Updates the queitem
        /// </summary>
        /// <param name="queitem">queitem</param>
        public virtual void UpdateSameCifs(SameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _scDAC.UpdateSameCif(queitem);

            //event notification
            //_eventPublisher.EntityUpdated(vendor);
        }
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="queitem">QueItem</param>
        public virtual void DeleteQueItem(SameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            UpdateSameCifs(queitem);

            //event notification
            //_eventPublisher.EntityDeleted(vendor);
        }
        /// <summary>
        /// Inserts a queitem
        /// </summary>
        /// <param name="queitem">Queitem</param>
        public virtual void InsertSameCif(SameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _scDAC.InsertSameCif(queitem);

            //event notification
            //_eventPublisher.EntityInserted(vendor);
        }

        /// <summary>
        /// Updates the queitem
        /// </summary>
        /// <param name="queitem">queitem</param>
        public virtual void UpdateSameCif(SameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _scDAC.UpdateSameCif(queitem);

            //event notification
            //_eventPublisher.EntityUpdated(vendor);
        }
        /// <summary>
        /// Gets a queitem by item identifiers
        /// </summary>
        /// <param name="recordId">recordId identifier</param>
        /// <returns>Vendor</returns>
        public virtual IList<SameCif> GetSameCifbyIds(Int64[] recordIds)
        {
            if (recordIds == null || recordIds.Length == 0)
                return null;

            return _scDAC.SelectByIds(recordIds);
        }
        /// <summary>
        /// Gets a queitem by item identifier
        /// </summary>
        /// <param name="recordId">MdmDQQue identifier</param>
        /// <returns>Vendor</returns>
        public virtual SameCif GetSameCifbyId(Int64 recordId)
        {
            if (recordId == 0)
                return null;

            return _scDAC.SelectSameCifById(recordId);
        }
        /// <summary>
        /// Gets all queitems
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Queitems</returns>
        public virtual IPagedList<SameCif> GetAllSameCifs(string name = "", string custid = "", string branchCode = "", string accountnum = "",
            int pageIndex = 0, int pageSize = int.MaxValue, string sortExpression = "")
        {
            List<SameCif> result = default(List<SameCif>);

            if (string.IsNullOrWhiteSpace(sortExpression))
                sortExpression = "FORACID DESC";
            // Step 1 - Calling Select on the DAC.
            result = _scDAC.SelectSameCif(name, custid, branchCode, accountnum, pageIndex, pageSize, sortExpression);

            var queitems = new PagedList<SameCif>(result, pageIndex, pageSize);
            return queitems;
        }
        #endregion MultipleRefCode

        #region DistinctSameCif
        /// <summary>
        /// Updates the queitem
        /// </summary>
        /// <param name="queitem">queitem</param>
        public virtual void UpdateDistinctSameCifs(DistinctSameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _dscDAC.UpdateDistinctSameCif(queitem);

            //event notification
            //_eventPublisher.EntityUpdated(vendor);
        }
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="queitem">QueItem</param>
        public virtual void _DeleteQueItem(DistinctSameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            UpdateDistinctSameCifs(queitem);

            //event notification
            //_eventPublisher.EntityDeleted(vendor);
        }
        /// <summary>
        /// Inserts a queitem
        /// </summary>
        /// <param name="queitem">Queitem</param>
        public virtual void InsertDistinctSameCif(DistinctSameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _dscDAC.InsertDistinctSameCif(queitem);

            //event notification
            //_eventPublisher.EntityInserted(vendor);
        }

        /// <summary>
        /// Updates the queitem
        /// </summary>
        /// <param name="queitem">queitem</param>
        public virtual void UpdateDistinctSameCif(DistinctSameCif queitem)
        {
            if (queitem == null)
                throw new ArgumentNullException("queitem");

            _dscDAC.UpdateDistinctSameCif(queitem);

            //event notification
            //_eventPublisher.EntityUpdated(vendor);
        }
        /// <summary>
        /// Gets a queitem by item identifiers
        /// </summary>
        /// <param name="recordId">recordId identifier</param>
        /// <returns>Vendor</returns>
        public virtual IList<DistinctSameCif> GetDistinctSameCifbyIds(Int64[] recordIds)
        {
            if (recordIds == null || recordIds.Length == 0)
                return null;

            return _dscDAC.SelectByIds(recordIds);
        }
        /// <summary>
        /// Gets a queitem by item identifier
        /// </summary>
        /// <param name="recordId">MdmDQQue identifier</param>
        /// <returns>Vendor</returns>
        public virtual DistinctSameCif GetDistSameCifbyId(Int64 recordId)
        {
            if (recordId == 0)
                return null;

            return _dscDAC.SelectDistinctSameCifById(recordId);
        }
        /// <summary>
        /// Gets all queitems
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Queitems</returns>
        public virtual IPagedList<DistinctSameCif> GetAllDistinctSameCifs(string name = "", string custid = "",
            int pageIndex = 0, int pageSize = int.MaxValue, string sortExpression = "")
        {
            List<DistinctSameCif> result = default(List<DistinctSameCif>);

            if (string.IsNullOrWhiteSpace(sortExpression))
                sortExpression = "CUSTOMER_ID ASC";
            // Step 1 - Calling Select on the DAC.
            result = _dscDAC.SelectDistinctSameCif(name, custid, pageIndex, pageSize, sortExpression);

            // Step 2 - Get count.
            //totalRowCount = _dqqueDAC.Count(name); i dont need this cos i can do items.totalcount

            //return result;

            //var query = _dqqueRepository.Table;
            //if (!String.IsNullOrWhiteSpace(name))
            //    query = query.Where(v => v.ERROR_DESC.Contains(name));
            //// if (!showHidden)
            ////    query = query.Where(v => v.Active);
            ////query = query.Where(v => !v.Deleted);
            //query = query.OrderBy(v => v.CREATED_DATE).ThenBy(v => v.ERROR_DESC);

            var queitems = new PagedList<DistinctSameCif>(result, pageIndex, pageSize);
            return queitems;
        }
        #endregion DistinctSameCif
    }
}
