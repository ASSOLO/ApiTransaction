using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TPYMT_PRTR")]
    public class PaymentPartner
    {
        public PaymentPartner()
        {
            PYMT_PRTR_EDT = DateTime.Now;
            PYMT_PRTR_XDT = Convert.ToDateTime("9999-12-31");
            PYMT_PRTR_DESC = "d";
        }

        [Key]
        [StringLength(10, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 10)]
        [Display(Name = "ID Parténaire")]
        public string PYMT_PRTR_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Nom Parténaire")]
        public string PYMT_PRTR_NM { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime PYMT_PRTR_EDT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime PYMT_PRTR_XDT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Description Parténaire")]
        public string PYMT_PRTR_DESC { get; set; }

        public virtual ICollection<ExternalTransaction> TEXRL_TRANS { get; set; }
    }
}