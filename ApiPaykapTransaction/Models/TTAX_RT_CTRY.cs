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
    
    public partial class TTAX_RT_CTRY
    {
        public int TAX_RT_CTRY_ID { get; set; }
        public string CTRY_CD { get; set; }
        public decimal TAX_RT { get; set; }
        public System.DateTime LAST_UPDT_DT { get; set; }
    
        public virtual TCTRY TCTRY { get; set; }
    }
}
