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
    
    public partial class TLANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TLANG()
        {
            this.TCTRY_CRCY = new HashSet<TCTRY_CRCY>();
            this.TUSR = new HashSet<TUSR>();
        }
    
        public string LANG_CD { get; set; }
        public string FRA_NM { get; set; }
        public string ENG_NM { get; set; }
        public string SPA_NM { get; set; }
        public string ARB_NM { get; set; }
        public string POR_NM { get; set; }
        public string ZHO_NM { get; set; }
        public string RUS_NM { get; set; }
        public string DEU_NM { get; set; }
        public string ITA_NM { get; set; }
        public string LGC_DEL_IND { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCTRY_CRCY> TCTRY_CRCY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUSR> TUSR { get; set; }
    }
}
