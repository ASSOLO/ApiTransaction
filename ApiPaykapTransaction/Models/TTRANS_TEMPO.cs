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
    
    public partial class TTRANS_TEMPO
    {
        public int TRANS_ID { get; set; }
        public string FROM_PKP_ACCT_IND { get; set; }
        public int FROM_PKP_ACCT_ID { get; set; }
        public string FROM_TRANS_DESC { get; set; }
        public string TO_SRVC_IND { get; set; }
        public int TO_PKP_ACCT_ID { get; set; }
        public int TO_BNK_ACCT_ID { get; set; }
        public string TO_TRANS_DESC { get; set; }
    
        public virtual TTRANS_TRSF_CRDT_DBT TTRANS_TRSF_CRDT_DBT { get; set; }
    }
}