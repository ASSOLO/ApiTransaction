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
    
    public partial class TFI_TY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFI_TY()
        {
            this.TFI_CTRY = new HashSet<TFI_CTRY>();
        }
    
        public int FI_TCD { get; set; }
        public string FI_TY_FRA_NM { get; set; }
        public string FI_TY_ENG_NM { get; set; }
        public string FI_TY_SPA_NM { get; set; }
        public string FI_TY_ARB_NM { get; set; }
        public string FI_TY_POR_NM { get; set; }
        public string FI_TY_ZHO_NM { get; set; }
        public string FI_TY_RUS_NM { get; set; }
        public string FI_TY_DEU_NM { get; set; }
        public string FI_TY_ITA_NM { get; set; }
        public string LGC_DEL_IND { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFI_CTRY> TFI_CTRY { get; set; }
    }
}
