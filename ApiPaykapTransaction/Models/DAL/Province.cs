using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TPROV")]
    public class Province
    {
        public Province()
        {
            TTRSF_SERV_CTRY = new HashSet<TransferServiceCountry>();
            LGC_DEL_IND = "0";
        }

        [Key]
        public int PROV_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FRA_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string ENG_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SPA_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string ARB_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string POR_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string ZHO_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string RUS_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string DEU_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string ITA_PROV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual Country TCTRY { get; set; }
        public virtual ICollection<TransferServiceCountry> TTRSF_SERV_CTRY { get; set; }
        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllProvince(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TPROV, "PROV_CD", "FRA_PROV_NM", selectedValue));
            }
            else
            {
                return null;
            }

        }

        public SelectList getOneProvinceByID(int provCD)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TPROV.Where(x => x.PROV_CD == provCD), "PROV_CD", "FRA_PROV_NM" , provCD));
            }
            else
            {
                return null;
            }

        }

        public SelectList getAllProvinceByCountryCD(string ctryCD)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TPROV.Where(x => x.CTRY_CD == ctryCD), "PROV_CD", "FRA_PROV_NM"));
            }
            else
            {
                return null;
            }
        }

        public string getProvinceNameByCode(string ctryCD, string provCD)
        {
            if (lang == "FRA")
            {
                return db.TPROV.Find(ctryCD, provCD).FRA_PROV_NM;
            }
            else
            {
                return null;
            }
        }
    }
}