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
    
    public partial class TONBHLF_CLT_TRANS
    {
        public int TRANS_ID { get; set; }
        public string USR_NBR { get; set; }
        public decimal CMSN_AMT { get; set; }
        public string CRCY_CD { get; set; }
        public string TRANS_SCD { get; set; }
    
        public virtual TCRCY TCRCY { get; set; }
        public virtual TTRANS_TRSF_CRDT_DBT TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual TUSR TUSR { get; set; }
    }
}
