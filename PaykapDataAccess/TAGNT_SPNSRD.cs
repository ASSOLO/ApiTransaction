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
    
    public partial class TAGNT_SPNSRD
    {
        public string SPNSRD_USR_NBR { get; set; }
        public System.DateTime SPNSRD_CRT_DT { get; set; }
        public string SPNSRD_FUL_NM { get; set; }
        public int AGNT_ID { get; set; }
    
        public virtual TAGNT TAGNT { get; set; }
        public virtual TUSR TUSR { get; set; }
    }
}
