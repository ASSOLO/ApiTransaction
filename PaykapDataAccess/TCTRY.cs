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
    
    public partial class TCTRY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TCTRY()
        {
            this.TAGNT_CMSN = new HashSet<TAGNT_CMSN>();
            this.TAGNT_PKP_CMSN = new HashSet<TAGNT_PKP_CMSN>();
            this.TBUS_CMSN = new HashSet<TBUS_CMSN>();
            this.TBUS_CTRY_FEE = new HashSet<TBUS_CTRY_FEE>();
            this.TCARD = new HashSet<TCARD>();
            this.TCITY = new HashSet<TCITY>();
            this.TUSR = new HashSet<TUSR>();
            this.TTAX_RT_CTRY = new HashSet<TTAX_RT_CTRY>();
            this.TKTCT = new HashSet<TKTCT>();
            this.TTRANS_TRSF_CRDT_DBT = new HashSet<TTRANS_TRSF_CRDT_DBT>();
            this.TTRANS_TRSF_CRDT_DBT1 = new HashSet<TTRANS_TRSF_CRDT_DBT>();
            this.TMNYT_AUTH_LMIT = new HashSet<TMNYT_AUTH_LMIT>();
            this.TPROV = new HashSet<TPROV>();
            this.TTRSF_SERV_CTRY = new HashSet<TTRSF_SERV_CTRY>();
            this.TFI_CTRY = new HashSet<TFI_CTRY>();
            this.TFI_EXRL_ACCT_DESC = new HashSet<TFI_EXRL_ACCT_DESC>();
            this.TTRSF_FEE_SERV_CTRY = new HashSet<TTRSF_FEE_SERV_CTRY>();
            this.TTRSF_FEE_SERV_CTRY1 = new HashSet<TTRSF_FEE_SERV_CTRY>();
            this.TCTRY_CRCY = new HashSet<TCTRY_CRCY>();
            this.TONBHLF_CLT_CMSN = new HashSet<TONBHLF_CLT_CMSN>();
        }
    
        public string CTRY_CD { get; set; }
        public string FRA_CTRY_NM { get; set; }
        public string ENG_CTRY_NM { get; set; }
        public string SPA_CTRY_NM { get; set; }
        public string ARB_CTRY_NM { get; set; }
        public string POR_CTRY_NM { get; set; }
        public string ZHO_CTRY_NM { get; set; }
        public string RUS_CTRY_NM { get; set; }
        public string DEU_CTRY_NM { get; set; }
        public string ITA_CTRY_NM { get; set; }
        public string LGC_DEL_IND { get; set; }
        public string CTRY_LTR_CD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAGNT_CMSN> TAGNT_CMSN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAGNT_PKP_CMSN> TAGNT_PKP_CMSN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBUS_CMSN> TBUS_CMSN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBUS_CTRY_FEE> TBUS_CTRY_FEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCARD> TCARD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCITY> TCITY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUSR> TUSR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTAX_RT_CTRY> TTAX_RT_CTRY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TKTCT> TKTCT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTRANS_TRSF_CRDT_DBT> TTRANS_TRSF_CRDT_DBT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTRANS_TRSF_CRDT_DBT> TTRANS_TRSF_CRDT_DBT1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMNYT_AUTH_LMIT> TMNYT_AUTH_LMIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TPROV> TPROV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTRSF_SERV_CTRY> TTRSF_SERV_CTRY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFI_CTRY> TFI_CTRY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFI_EXRL_ACCT_DESC> TFI_EXRL_ACCT_DESC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTRSF_FEE_SERV_CTRY> TTRSF_FEE_SERV_CTRY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTRSF_FEE_SERV_CTRY> TTRSF_FEE_SERV_CTRY1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCTRY_CRCY> TCTRY_CRCY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONBHLF_CLT_CMSN> TONBHLF_CLT_CMSN { get; set; }
    }
}