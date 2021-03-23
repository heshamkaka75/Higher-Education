﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOHEv2.Models
{
    public class SudaniViewModel
    {
        public string applicationId { get; set; }
        public long sourceTransactionId { get; set; }
        public long billerId { get; set; }
        public string serviceCode { get; set; }
        [Display(Name = "رقم الجلوس")]
        [Required]
        public string customerBillerRef { get; set; }
        [Display(Name = "المبلغ")]
        [Required]
        public double transactionPaidAmount { get; set; }
        public int serviceRequsetType { get; set; }
        public string currency { get; set; }
        public SudaniAdditionalData additionalData { get; set; }

    }

    public class SudaniAdditionalData
    {
        [Display(Name = "المساق")]
        public string Student_Acad_Type { get; set; }
        [Display(Name = "نوع القبول")]
        public string FormKind { get; set; }
        [Display(Name = "اعد المبلغ")]
        public string MOHEAmount { get; set; }
        
    }


}