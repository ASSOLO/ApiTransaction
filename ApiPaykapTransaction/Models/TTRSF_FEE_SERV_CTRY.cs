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
    
    public partial class TTRSF_FEE_SERV_CTRY
    {
        public int TRSF_FEE_SERV_CTRY_ID { get; set; }
        public int TRANS_FEE_ID { get; set; }
        public int FROM_TRSF_SERV_ID { get; set; }
        public int TO_TRSF_SERV_ID { get; set; }
        public string FROM_CTRY_CD { get; set; }
        public string TO_CTRY_CD { get; set; }
    
        public virtual TCTRY TCTRY { get; set; }
        public virtual TCTRY TCTRY1 { get; set; }
        public virtual TTRANS_FEE TTRANS_FEE { get; set; }
        public virtual TTRSF_SERV TTRSF_SERV { get; set; }
        public virtual TTRSF_SERV TTRSF_SERV1 { get; set; }
    }
}
