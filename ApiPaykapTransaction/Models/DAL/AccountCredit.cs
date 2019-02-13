using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TACCT_CRDT")]
    public class AccountCredit
    {
        [Key]
        [Display(Name = "ID Compte")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACCT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Crédit")]
        public decimal ACCT_CRDT_AMT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date de Création")]
        public DateTime ACCT_CRDT_DT { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Vérifier Credit Compte ?")]
        public string ACCT_CRDT_NO_CHCK_IND { get; set; }

        public virtual Account TACCT { get; set; }
    }
}
