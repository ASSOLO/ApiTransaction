//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaykapDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TCRCY_XCHG_RT
    {
        public int CRCY_XCHG_RT_ID { get; set; }
        public string FROM_CRCY_CD { get; set; }
        public string TO_CRCY_CD { get; set; }
        public decimal CRCY_XCHG_RT { get; set; }
        public System.DateTime CRCY_XCHG_RT_UPD_DT { get; set; }
        public string USR_NBR { get; set; }
    
        public virtual TCRCY TCRCY { get; set; }
        public virtual TCRCY TCRCY1 { get; set; }
        public virtual TUSR TUSR { get; set; }
    }
}
