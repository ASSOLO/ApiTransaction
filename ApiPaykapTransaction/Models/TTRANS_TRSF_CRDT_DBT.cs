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
    
    public partial class TTRANS_TRSF_CRDT_DBT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TTRANS_TRSF_CRDT_DBT()
        {
            this.TBNK_TRANS = new HashSet<TBNK_TRANS>();
            this.TBUS_CMSN_TRANS = new HashSet<TBUS_CMSN_TRANS>();
        }
    
        public int TRANS_ID { get; set; }
        public int FROM_TRSF_SERV_ID { get; set; }
        public int TO_TRSF_SERV_ID { get; set; }
        public string FROM_CTRY_CD { get; set; }
        public string TO_CTRY_CD { get; set; }
        public string FROM_CRCY_CD { get; set; }
        public string TO_CRCY_CD { get; set; }
        public decimal CRCY_XCHG_RT { get; set; }
        public decimal FROM_TRANS_AMT { get; set; }
        public decimal FROM_FEE_AMT { get; set; }
        public decimal FROM_TOT_AMT { get; set; }
        public decimal TO_TRANS_AMT { get; set; }
        public string TRANS_SCD { get; set; }
        public System.DateTime TRANS_CDT { get; set; }
        public System.DateTime TRANS_PAID_DPST_DT { get; set; }
        public System.DateTime TRANS_XDT { get; set; }
        public string FROM_USR_NBR { get; set; }
        public int RCPT_USR_BUS_ID { get; set; }
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }
        public string TRANS_DESC { get; set; }
    
        public virtual TAGNT_TRANS_CMSN_TEMPO TAGNT_TRANS_CMSN_TEMPO { get; set; }
        public virtual TBIL_PYMT_TRANS TBIL_PYMT_TRANS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBNK_TRANS> TBNK_TRANS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBUS_CMSN_TRANS> TBUS_CMSN_TRANS { get; set; }
        public virtual TCRCY TCRCY { get; set; }
        public virtual TCRCY TCRCY1 { get; set; }
        public virtual TCTRY TCTRY { get; set; }
        public virtual TCTRY TCTRY1 { get; set; }
        public virtual TEXCEPT_TRANS TEXCEPT_TRANS { get; set; }
        public virtual TONBHLF_CLT_TRANS TONBHLF_CLT_TRANS { get; set; }
        public virtual TRCPT_USR_BUS TRCPT_USR_BUS { get; set; }
        public virtual TTRANS_ID_DOC TTRANS_ID_DOC { get; set; }
        public virtual TTRANS_TEMPO TTRANS_TEMPO { get; set; }
        public virtual TUSR TUSR { get; set; }
    }
}
