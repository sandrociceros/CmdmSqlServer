﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CMdm.Entities.Domain.Dqi
{
    [Table("MDM_DQ_PRIORITY")]
    public partial class MdmDQPriority
    {
        public MdmDQPriority()
        {
            MdmDQQues = new HashSet<MdmDQQue>();
            MdmDqRules = new HashSet<MdmDqRule>();
            MdmDqRunExceptions = new HashSet<MdmDqRunException>();
            MdmCorpRunExceptions = new HashSet<MdmCorpRunExceptions>();
            MdmUnauthExceptions = new HashSet<MdmUnauthException>();
            MdmUnauthCorpExceptions = new HashSet<MdmUnauthCorpExceptions>();
        }
        [Key]
        public int PRIORITY_CODE { get; set; }
        [DisplayName("Priority")]
        public string PRIORITY_DESCRIPTION { get; set; }
        public virtual ICollection<MdmDQQue> MdmDQQues { get; set; }
        public virtual ICollection<MdmDqRule> MdmDqRules { get; set; }
        public virtual ICollection<MdmDqRunException> MdmDqRunExceptions { get; set; }
        public virtual ICollection<MdmCorpRunExceptions> MdmCorpRunExceptions { get; set; }
        public virtual  ICollection<MdmUnauthException> MdmUnauthExceptions { get; set; }
        public virtual ICollection<MdmUnauthCorpExceptions> MdmUnauthCorpExceptions { get; set; }
    }
}

