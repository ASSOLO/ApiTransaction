using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TFI_CTRY")]
    public class FinancialInstitutionCountry
    {
        public FinancialInstitutionCountry()
        {
            TFI_EXRL_ACCT = new HashSet<FinancialInstitutionExternalAccount>();
        }

        [Key]
        [Display(Name = "ID Pays Institution Financière")]
        public int FI_CTRY_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FI_CTRY_FRA_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string FI_CTRY_ENG_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string FI_CTRY_SPA_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string FI_CTRY_ARB_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string FI_CTRY_POR_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string FI_CTRY_ZHO_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string FI_CTRY_RUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string FI_CTRY_DEU_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string FI_CTRY_ITA_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string FI_CTRY_CD { get; set; }

        [Display(Name = "Code Institution Financière")]
        public int FI_ID { get; set; }

        [Display(Name = "Type Institution Financière")]
        public int FI_TCD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual Country TCTRY { get; set; }
        
        public virtual ICollection<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT { get; set; }        

        public virtual FinancialInstitutionType TFI_TY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public FinancialInstitutionCountry getFinancialInstitutionCountryByID(int ID)
        {
            try
            {
                var fiCtry = db.TFI_CTRY.Find(ID);
                if (fiCtry != null)
                {
                    return fiCtry;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<FinancialInstitutionCountry> getAllFinancialInstitutionCountryByCtryCD(string ctryCD)
        {
            if (lang == "FRA")
            {
                return db.TFI_CTRY.Where(x => x.FI_CTRY_CD == ctryCD).ToList();
            }
            else
            {
                return null;
            }
        }

        public SelectList getAllFinancialInstitutionCountryByCtryCD(string ctryCD, string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TFI_CTRY.Where(x => x.FI_CTRY_CD == ctryCD), "FI_CTRY_ID", "FI_CTRY_FRA_NM", selectedValue));
            }
            else
            {
                return null;
            }

        }

    }
}
