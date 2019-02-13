using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TFI_EXRL_ACCT_DESC")]
    public class FinancialInstitutionExternalAccountDescription
    {
        public FinancialInstitutionExternalAccountDescription()
        {
            EXRL_ACCT_DESC_DT = DateTime.Now;
            EXRL_ACCT_PRT3_DESC = "d";
            EXRL_ACCT_PRT4_DESC = "d";
            EXRL_ACCT_PRT5_DESC = "d";
        }

        [Key]
        [Display(Name = "ID Description Compte Externe")]
        public int EXRL_ACCT_DESC_ID { get; set; }
        
        [StringLength(255, ErrorMessage = "La {0} doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 1 Description Compte Externe")]
        public string EXRL_ACCT_PRT1_DESC { get; set; }

        [StringLength(255, ErrorMessage = "La {0} doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 2 Description Compte Externe")]
        public string EXRL_ACCT_PRT2_DESC { get; set; }

        [StringLength(255, ErrorMessage = "La {0} doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 3 Description Compte Externe")]
        public string EXRL_ACCT_PRT3_DESC { get; set; }

        [StringLength(255, ErrorMessage = "La {0} doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 4 Description Compte Externe")]
        public string EXRL_ACCT_PRT4_DESC { get; set; }

        [StringLength(255, ErrorMessage = "La {0} doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 1 Description Compte Externe")]
        public string EXRL_ACCT_PRT5_DESC { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Description Compte Externe")]
        public DateTime EXRL_ACCT_DESC_DT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        public virtual Country TCTRY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";
                
        public FinancialInstitutionExternalAccountDescription getExternalAccountDescriptionByCtryCD(string ctryCD)
        {
            if (lang == "FRA")
            {
                var fiExrlAcctDescList = db.TFI_EXRL_ACCT_DESC.Where(x => x.CTRY_CD == ctryCD).ToList();
                if(fiExrlAcctDescList.Count() == 0)
                {
                    return null;
                }
                else
                {
                    return fiExrlAcctDescList[0];
                }
            }
            else
            {
                return null;
            }
        }
    }
}
