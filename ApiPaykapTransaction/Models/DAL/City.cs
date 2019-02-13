using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCITY")]
    public class City
    {
        public City()
        {
            TKTCT = new HashSet<Contact>();
            LGC_DEL_IND = "0";
        }

        [Key]
        [Display(Name = "Code Ville")]
        public int CITY_CD { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FRA_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string ENG_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SPA_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string ARB_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string POR_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string ZHO_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string RUS_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string DEU_CITY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string ITA_CITY_NM { get; set; }

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
        public virtual ICollection<Contact> TKTCT { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public SelectList getAllCity(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TCITY, "CITY_CD", "FRA_CITY_NM", selectedValue));
            }
            else
            {
                return null;
            }

        }

        public SelectList getAllCityByCountryCD(string ctryCD)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TCITY.Where(x => x.CTRY_CD == ctryCD), "CITY_CD", "FRA_CITY_NM"));
            }
            else
            {
                return null;
            }
        }

        public List<City> getAllCityByCountryCD(string ctryCD, string selectedValue)
        {
            return db.TCITY.Where(x => x.CTRY_CD == ctryCD).ToList();
        }

        public SelectList getAllCityByCountryCityCode(string ctryCD, int? cityCD)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TCITY.Where(x => x.CTRY_CD == ctryCD), "CITY_CD", "FRA_CITY_NM", cityCD));
            }
            else
            {
                return null;
            }
        }
        
        public string getCityNameByCityCode(int cityCD)
        {
            if (lang == "FRA")
            {
                return db.TCITY.Find(cityCD).FRA_CITY_NM;
            }
            else
            {
                return null;
            }
        }
        
    }
}