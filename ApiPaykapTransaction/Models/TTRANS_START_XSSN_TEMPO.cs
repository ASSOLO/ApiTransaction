//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiPaykapTransaction.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TTRANS_START_XSSN_TEMPO
    {
        public long TRANS_SSN_ID { get; set; }
        public string TRANS_SSN_SECR_ID { get; set; }
        public int FROM_SRVC_ID { get; set; }
        public int TO_SRVC_ID { get; set; }
        public string FROM_CTRY_CD { get; set; }
        public string TO_CTRY_CD { get; set; }
        public string FROM_CRCY_CD { get; set; }
        public string TO_CRCY_CD { get; set; }
        public string SEND_RCPT_CD { get; set; }
        public decimal FROM_TRANS_AMT { get; set; }
        public string FROM_TRANS_AMT_TXT { get; set; }
        public decimal TRANS_FEE_AMT { get; set; }
        public string TRANS_FEE_AMT_TXT { get; set; }
        public decimal TRANS_FEE_AMT_PROMO_CD { get; set; }
        public string TRANS_FEE_AMT_TXT_PROMO_CD { get; set; }
        public decimal TOT_TO_PAY_AMT { get; set; }
        public string TOT_TO_PAY_AMT_TXT { get; set; }
        public decimal TOT_TO_PAY_AMT_PROMO_CD { get; set; }
        public string TOT_TO_PAY_AMT_TXT_PROMO_CD { get; set; }
        public decimal TO_TRANS_AMT { get; set; }
        public string TO_TRANS_AMT_TXT { get; set; }
        public decimal CRCY_XCHG_RT { get; set; }
        public string CRCY_XCHG_RT_TXT { get; set; }
        public string DPLY_CRCY_XCHG_RT_IND { get; set; }
        public decimal ADJUST_XCHG_RT { get; set; }
        public System.DateTime TRANS_EDTTM { get; set; }
        public System.DateTime TRANS_XDTTM { get; set; }
        public string CLT_USR_NBR { get; set; }
        public string TRANS_OTH1_TXT { get; set; }
        public string TRANS_OTH2_TXT { get; set; }
        public string TRANS_OTH3_TXT { get; set; }
        public string TRANS_OTH4_TXT { get; set; }
        public string TRANS_OTH5_TXT { get; set; }
    }
}
