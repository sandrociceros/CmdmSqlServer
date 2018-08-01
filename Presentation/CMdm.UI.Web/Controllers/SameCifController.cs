using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMdm.Data;
using CMdm.Entities.Domain.CustomModule.Fcmb;
using CMdm.Entities.Domain.Customer;
using CMdm.Framework.Kendoui;
using CMdm.UI.Web.Helpers.CrossCutting.Security;
using CMdm.Services.CustomModule.Fcmb;
using CMdm.UI.Web.Models.CustomModule.Fcmb;
using CMdm.Framework.Controllers;
using CMdm.Core;
using CMdm.Services.ExportImport;
using CMdm.Services.Security;
using CMdm.Services.Messaging;

namespace CMdm.UI.Web.Controllers
{
    public class SameCifController : BaseController
    {
        private AppDbContext db = new AppDbContext();
        private ISameCifService _dqQueService;
        private ISameCifExportManager _exportManager;
        private IPermissionsService _permissionservice;
        private CustomIdentity identity;
        private IMessagingService _messagingService;

        #region Constructors
        public SameCifController()
        {
            //bizrule = new DQQueBiz();
            _dqQueService = new SameCifService();
            _exportManager = new SameCifExportManager();
            _messagingService = new MessagingService();

            _permissionservice = new PermissionsService();
        }
        #endregion Constructors

        // GET: AccountOfficer
        public ActionResult Index()
        {
            return RedirectToAction("List");
            //return View(db.AccountOfficers.ToList());
        }

        public ActionResult List()
        {
            var model = new DistinctSameCifModel();
            if (!User.Identity.IsAuthenticated)
                return AccessDeniedView();

            identity = ((CustomPrincipal)User).CustomIdentity;
            _permissionservice = new PermissionsService(identity.Name, identity.UserRoleId);

            _messagingService.SaveUserActivity(identity.ProfileId, "Viewed Customers With Same CIF Report", DateTime.Now);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult DistinctSameCifsList(DataSourceRequest command, DistinctSameCifModel model, string sort, string sortDir)
        {

            var items = _dqQueService.GetAllDistinctSameCifs(model.CUST_NAME, model.CUSTOMER_ID, command.Page - 1, command.PageSize, string.Format("{0} {1}", sort, sortDir));
            //var logItems = _logger.GetAllLogs(createdOnFromValue, createdToFromValue, model.Message,
            //    logLevel, command.Page - 1, command.PageSize);
            DateTime _today = DateTime.Now.Date;
            var gridModel = new DataSourceResult
            {
                Data = items.Select(x => new DistinctSameCifModel
                {
                    ID = x.ID,
                    CUST_NAME = x.CUST_NAME,
                    CUSTOMER_ID = x.CUSTOMER_ID,
                }),
                Total = items.TotalCount
            };

            return Json(gridModel);
        }


        [HttpPost]
        public virtual ActionResult SameCifsList(DataSourceRequest command, SameCifModel model, string sort, string sortDir)
        {

            var items = _dqQueService.GetAllSameCifs(model.CUST_NAME, model.CUSTOMER_ID, model.SOL_ID, model.FORACID, command.Page - 1, command.PageSize, string.Format("{0} {1}", sort, sortDir));
            //var logItems = _logger.GetAllLogs(createdOnFromValue, createdToFromValue, model.Message,
            //    logLevel, command.Page - 1, command.PageSize);
            DateTime _today = DateTime.Now.Date;
            var gridModel = new DataSourceResult
            {
                Data = items.Select(x => new SameCifModel
                {
                    Id = x.ID,
                    CUSTOMER_ID = x.CUSTOMER_ID,
                    FORACID = x.FORACID,
                    CUST_NAME = x.CUST_NAME,
                    FREE_CODE_10 = x.FREE_CODE_10,
                    REF_DESC = x.REF_DESC,
                    SCHM_CODE = x.SCHM_CODE,
                    BRANCH_NAME = x.BRANCH_NAME,
                    SOL_ID = x.SOL_ID,
                }),
                Total = items.TotalCount
            };

            return Json(gridModel);
        }

        public ActionResult AuthList(string id)
        {
            if (!User.Identity.IsAuthenticated)
                return AccessDeniedView();
            var identity = ((CustomPrincipal)User).CustomIdentity;

            var model = new SameCifModel();
            model.CUSTOMER_ID = id;

            var curBranchList = db.CM_BRANCH.Where(a => a.BRANCH_ID == identity.BranchId);
            model.Branches = new SelectList(curBranchList, "BRANCH_ID", "BRANCH_NAME").ToList();

            model.Branches.Add(new SelectListItem
            {
                Value = "0",
                Text = "All",
                Selected = true
            });

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult AuthList(DataSourceRequest command, SameCifModel model, string sort, string sortDir)
        {
            var identity = ((CustomPrincipal)User).CustomIdentity;
            var routeValues = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values;
            //RouteValueDictionary routeValues;

            string goldenRecord = "";
            if (routeValues.ContainsKey("id"))
                goldenRecord = (string)routeValues["id"];

            var items = _dqQueService.GetAllSameCifs(model.CUST_NAME, goldenRecord, model.SOL_ID, model.FORACID, command.Page - 1, command.PageSize, string.Format("{0} {1}", sort, sortDir));
            var gridModel = new DataSourceResult
            {
                Data = items.Select(x => new SameCifModel
                {
                    Id = x.ID,
                    CUSTOMER_ID = x.CUSTOMER_ID,
                    FORACID = x.FORACID,
                    CUST_NAME = x.CUST_NAME,
                    FREE_CODE_10 = x.FREE_CODE_10,
                    REF_DESC = x.REF_DESC,
                    SCHM_CODE = x.SCHM_CODE,
                    BRANCH_NAME = x.BRANCH_NAME,
                    SOL_ID = x.SOL_ID,
                }),
                Total = items.TotalCount
            };

            return Json(gridModel);
        }

        [HttpPost, ActionName("List")]
        [FormValueRequired("exportexcel-all")]
        public virtual ActionResult ExportExcelAll(SameCifModel model)
        {

            if (!User.Identity.IsAuthenticated)
                return AccessDeniedView();
            var items = _dqQueService.GetAllDistinctSameCifs(model.CUST_NAME, model.CUSTOMER_ID);

            try
            {
                byte[] bytes = _exportManager.ExportDocumentsToXlsx(items);
                return File(bytes, MimeTypes.TextXlsx, "sameCifs.xlsx");
            }
            catch (Exception exc)
            {
                ErrorNotification(exc);
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public virtual ActionResult ExportExcelSelected(string selectedIds)
        {
            if (!User.Identity.IsAuthenticated)
                return AccessDeniedView();

            var docs = new List<DistinctSameCif>();
            if (selectedIds != null)
            {
                var ids = selectedIds
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt64(x))
                    .ToArray();
                docs.AddRange(_dqQueService.GetDistinctSameCifbyIds(ids));
            }

            try
            {
                byte[] bytes = _exportManager.ExportDocumentsToXlsx(docs);
                identity = ((CustomPrincipal)User).CustomIdentity;
                _messagingService.SaveUserActivity(identity.ProfileId, "Downloaded Customers with same CIF Report", DateTime.Now);
                return File(bytes, MimeTypes.TextXlsx, "sameCifs.xlsx");
            }
            catch (Exception exc)
            {
                ErrorNotification(exc);
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public virtual ActionResult ExportSameCifExcelSelected(string selectedIds)
        {
            if (!User.Identity.IsAuthenticated)
                return AccessDeniedView();

            var docs = new List<SameCif>();
            if (selectedIds != null)
            {
                var ids = selectedIds
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt64(x))
                    .ToArray();
                docs.AddRange(_dqQueService.GetSameCifbyIds(ids));
            }

            try
            {
                byte[] bytes = _exportManager.ExportScifToXlsx(docs);
                identity = ((CustomPrincipal)User).CustomIdentity;
                _messagingService.SaveUserActivity(identity.ProfileId, "Downloaded Customers with same CIF Report", DateTime.Now);
                return File(bytes, MimeTypes.TextXlsx, "sameCifs.xlsx");
            }
            catch (Exception exc)
            {
                ErrorNotification(exc);
                return RedirectToAction("List");
            }
        }
    }
}