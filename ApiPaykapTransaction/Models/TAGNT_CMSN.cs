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
    
    public partial class TAGNT_CMSN
    {
        public int AGNT_CMSN_ID { get; set; }
        public int AGNT_ID { get; set; }
        public string SRVC_TCD { get; set; }
        public string ONLN_AGCY_SRVC_TCD { get; set; }
        public string CTRY_CD { get; set; }
        public Nullable<int> PRTNSP_BN { get; set; }
        public string AGNT_CLT_PRTR_TCD { get; set; }
        public decimal AGNT_FIX_CMSN_AMT { get; set; }
        public decimal AGNT_PRCNT_CMSN_RT { get; set; }
        public decimal SPNSR_FIX_CMSN_AMT { get; set; }
        public decimal SPNSR_PRCNT_CMSN_RT { get; set; }
        public string CMSN_TCD { get; set; }
        public string CMSN_CUR_APBL_IND { get; set; }
        public System.DateTime CMSN_CUR_APBL_EDT { get; set; }
        public System.DateTime CMSN_CUR_APBL_XDT { get; set; }
        public string APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD { get; set; }
        public string APLY_SPNSR_CMSN_IND { get; set; }
    
        public virtual TAGNT TAGNT { get; set; }
        public virtual TBUS TBUS { get; set; }
        public virtual TCTRY TCTRY { get; set; }
    }
}
