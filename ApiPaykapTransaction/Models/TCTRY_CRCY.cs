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
    
    public partial class TCTRY_CRCY
    {
        public int CTRY_CRCY_ID { get; set; }
        public string CTRY_CD { get; set; }
        public string LANG_CD { get; set; }
        public string CRCY_CD { get; set; }
        public string CRCY_CLTR_INFO { get; set; }
        public System.DateTime CTRY_CRCY_CDT { get; set; }
        public string LGC_DEL_IND { get; set; }
    
        public virtual TCRCY TCRCY { get; set; }
        public virtual TCTRY TCTRY { get; set; }
        public virtual TLANG TLANG { get; set; }
    }
}