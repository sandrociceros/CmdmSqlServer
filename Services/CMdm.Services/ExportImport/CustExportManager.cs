﻿using CMdm.Entities.Domain.CustomModule.Fcmb;
using CMdm.Services.ExportImport.Help;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CMdm.Services.ExportImport
{
    public partial class CustExportManager : ICustExportManager
    {
        #region Ctor

        public CustExportManager()
        {

        }
        #endregion
        protected virtual void SetCaptionStyle(ExcelStyle style)
        {
            style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
            style.Font.Bold = true;
        }
        /// <summary>
        /// Export documents list to XLSX
        /// </summary>
        /// <param name="documents">documents</param>
        public virtual byte[] ExportDocumentsToXlsx(IList<CustSegment> documents)
        {
            //property array
            var properties = new[]
            {

                new PropertyByName<CustSegment>("Customer ID", p => p.ORGKEY),
                new PropertyByName<CustSegment>("Account Number", p => p.ACCOUNT_NO),
                new PropertyByName<CustSegment>("Customer Type", p => p.CUSTOMER_TYPE),
                new PropertyByName<CustSegment>("Scheme Code", p => p.SCHEME_CODE),
                new PropertyByName<CustSegment>("First Name", p => p.CUST_FIRST_NAME),
                new PropertyByName<CustSegment>("Middle Name", p => p.CUST_MIDDLE_NAME),
                new PropertyByName<CustSegment>("Last Name", p => p.CUST_LAST_NAME),
                new PropertyByName<CustSegment>("Gender", p => p.GENDER),
                new PropertyByName<CustSegment>("Date Of Birth", p => p.CUST_DOB.ToString()),
                new PropertyByName<CustSegment>("Customer Minor", p => p.CUSTOMERMINOR),
                new PropertyByName<CustSegment>("Maiden Name of Mother", p => p.MAIDENNAMEOFMOTHER),
                new PropertyByName<CustSegment>("Nickname", p => p.NICK_NAME),
                new PropertyByName<CustSegment>("Place of Birth", p => p.PLACEOFBIRTH),
                new PropertyByName<CustSegment>("Branch Code", p => p.PRIMARY_SOL_ID),
                new PropertyByName<CustSegment>("Segmentation Class", p => p.SEGMENTATION_CLASS),
                new PropertyByName<CustSegment>("Sector", p => p.SECTOR),
                new PropertyByName<CustSegment>("Sector Name", p => p.SECTORNAME),
                new PropertyByName<CustSegment>("Sub Sector", p => p.SUBSECTOR),
                new PropertyByName<CustSegment>("Sub Sector Name", p => p.SUBSECTORNAME),
                new PropertyByName<CustSegment>("Sub Segment", p => p.SUBSEGMENT),
                new PropertyByName<CustSegment>("Corp ID", p => p.CORP_ID),
                new PropertyByName<CustSegment>("Reason", p => p.REASON),
            };

            return ExportToXlsx(properties, documents);
        }
        /// <summary>
        /// Export objects to XLSX
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="properties">Class access to the object through its properties</param>
        /// <param name="itemsToExport">The objects to export</param>
        /// <returns></returns>
        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, IEnumerable<T> itemsToExport)
        {
            using (var stream = new MemoryStream())
            {
                // ok, we can run the real code of the sample now
                using (var xlPackage = new ExcelPackage(stream))
                {
                    // uncomment this line if you want the XML written out to the outputDir
                    //xlPackage.DebugMode = true; 

                    // get handles to the worksheets
                    var worksheet = xlPackage.Workbook.Worksheets.Add(typeof(T).Name);
                    var worksheet2 = xlPackage.Workbook.Worksheets.Add(typeof(T).Name + "2");
                    var fWorksheet = xlPackage.Workbook.Worksheets.Add("DataForFilters");
                    fWorksheet.Hidden = eWorkSheetHidden.VeryHidden;

                    //create Headers and format them 
                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore));
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    var row2 = 2;
                    int progress = 0;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        if (progress >= 1000000)
                        {
                            manager.WriteToXlsx(worksheet2, row2++, false, fWorksheet: fWorksheet);
                        }
                        else
                            manager.WriteToXlsx(worksheet, row++, false, fWorksheet: fWorksheet);

                        progress++;
                    }

                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }
    }
}
