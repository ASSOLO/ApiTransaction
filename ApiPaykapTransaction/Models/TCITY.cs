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
    
    public partial class TCITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TCITY()
        {
            this.TUSR = new HashSet<TUSR>();
            this.TKTCT = new HashSet<TKTCT>();
        }
    
        public int CITY_CD { get; set; }
        public string FRA_CITY_NM { get; set; }
        public string ENG_CITY_NM { get; set; }
        public string SPA_CITY_NM { get; set; }
        public string ARB_CITY_NM { get; set; }
        public string POR_CITY_NM { get; set; }
        public string ZHO_CITY_NM { get; set; }
        public string RUS_CITY_NM { get; set; }
        public string DEU_CITY_NM { get; set; }
        public string ITA_CITY_NM { get; set; }
        public string CTRY_CD { get; set; }
        public string LGC_DEL_IND { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUSR> TUSR { get; set; }
        public virtual TCTRY TCTRY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TKTCT> TKTCT { get; set; }
    }
}
