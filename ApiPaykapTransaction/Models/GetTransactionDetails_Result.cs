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
    
    public partial class GetTransactionDetails_Result
    {
        public string USR_FNM { get; set; }
        public string USR_LNM { get; set; }
        public string FROM_USR_NBR { get; set; }
        public string RCPT_USR_BUS_NM { get; set; }
        public int TRANS_ID { get; set; }
        public decimal TO_TRANS_AMT { get; set; }
        public string TRANS_DESC { get; set; }
        public string FRA_TRSF_SERV_NM { get; set; }
        public string TRANS_SCD { get; set; }
        public string CITY_NM { get; set; }
        public string ADDR_LN1_TXT { get; set; }
    }
}
