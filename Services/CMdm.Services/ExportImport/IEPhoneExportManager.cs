﻿using CMdm.Entities.Domain.CustomModule.Fcmb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMdm.Services.ExportImport
{
    /// <summary>
    /// Export manager interface
    /// </summary>
    public partial interface IEPhoneExportManager
    {
        /// <summary>
        /// Export documents list to XLSX
        /// </summary>
        /// <param name="documents">documents</param>
        byte[] ExportDocumentsToXlsx(IList<EmailPhone> documents);
    }
}
