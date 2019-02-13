using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTAX_RT_CTRY")]
    public class TaxRateCountry
    {
        public TaxRateCountry()
        {
            LAST_UPDT_DT = DateTime.Now;
        }

        [Key]
        [Display(Name = "Code Taxe")]
        public int TAX_RT_CTRY_ID { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1, ErrorMessage = "Le montant doit être entre 0 et 1.")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Taux Taxe Pays")]
        public decimal TAX_RT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Dernière Mise à jour")]
        public DateTime LAST_UPDT_DT { get; set; }

        public virtual Country TCTRY { get; set; }
    }
}