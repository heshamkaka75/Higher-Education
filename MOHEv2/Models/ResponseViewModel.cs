using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOHEv2.Models
{
        public class ResponseViewModel
            {
                public long sourceTransactionId { get; set; }
                public string serviceCode { get; set; }
                public string customerBillerRef { get; set; }
                public double transactionPaidAmount { get; set; }
                public int responseCode { get; set; }
                public long bpgTransactionId { get; set; }
                public ResponseAdditionalData additionalData { get; set; }
            }

            public class ResponseAdditionalData
            {
                public string Student_Acad_Type { get; set; }
                public string FormKind { get; set; }
                public string MOHEAmount { get; set; }
                public string stName { get; set; }
                public string StNo { get; set; }
                public string E15 { get; set; }
                public string ErrorCode { get; set; }
                public string PaymentFlag { get; set; }

                public string FormNo { get; set; }
            }

        }