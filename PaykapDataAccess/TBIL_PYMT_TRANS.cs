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
    
    public partial class TBIL_PYMT_TRANS
    {
        public int TRANS_ID { get; set; }
        public string CLT_ACCT_NBR { get; set; }
        public string BIL_NBR { get; set; }
        public System.DateTime BIL_PYMT_TRANS_DT { get; set; }
    
        public virtual TTRANS_TRSF_CRDT_DBT TTRANS_TRSF_CRDT_DBT { get; set; }
    }
}
