using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Data.Entity;
namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TEXCEPT_TRANS")]
    public class ExceptionalTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Raison Transaction Exceptionnelle")]
        public string EXCEPT_TRANS_RCD { get; set; }  //01- High Authorized Amount 02- High Unauthorized Amount 03- High Cash Amount

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Personne")]
        public string TRANS_AUTH_KTCT_CD { get; set; } //1- Sender     2- Employee      3- Others

        [Required]
        [StringLength(20)]
        [Display(Name = "Téléphone Personne")]
        public string TRANS_AUTH_KTCT_PHN { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Décision Prise")]
        public string ACTION_TAKEN_DESC { get; set; }

        [StringLength(10)]
        [Display(Name = "ID Utilisateur Ayant Autorisé")]
        public string USR_NBR { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }

        public virtual User TUSR { get; set; }
    }
}
