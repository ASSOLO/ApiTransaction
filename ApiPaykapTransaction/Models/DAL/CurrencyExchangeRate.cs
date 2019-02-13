using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCRCY_XCHG_RT")]
    public class CurrencyExchangeRate
    {
        public CurrencyExchangeRate()
        {
            CRCY_XCHG_RT_UPD_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Code Taux Change")]
        public int CRCY_XCHG_RT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Envoi")]
        public string FROM_CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Reception")]
        public string TO_CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Dernière Mise à jour")]
        public DateTime CRCY_XCHG_RT_UPD_DT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        public virtual Currency TCRCY { get; set; }
        public virtual Currency TCRCY1 { get; set; }
        public virtual User TUSR { get; set; }
        private DalContext db = new DalContext();
        private string lang = "FRA";

        public decimal getExchangeRateByCurrency(string fromCrcyCD, string toCrcyCD)
        {
            if(fromCrcyCD == toCrcyCD)
            {
                return 1.0m;
            }

            var xchgRT = db.TCRCY_XCHG_RT.Where(x => x.FROM_CRCY_CD == fromCrcyCD && x.TO_CRCY_CD == toCrcyCD).ToList();
            if (xchgRT.Count() == 0)
            {
                return 0.0m;
            }
            else
            {
                return (xchgRT.First().CRCY_XCHG_RT);
            }
        }

    }
}