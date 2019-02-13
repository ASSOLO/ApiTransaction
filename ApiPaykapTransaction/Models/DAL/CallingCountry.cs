using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCAL_CTRY")]
    public class CallingCountry
    {
        public CallingCountry()
        {
            LGC_DEL_IND = "0";
            CTRY_PHN_NBR_LNGH_LST_UPD_DT = DateTime.Now;
            TUSR_PHN_LGN = new HashSet<UserPhoneLogin>();
        }

        [Key]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(5, ErrorMessage = "Le {0} doit compter au maximum 5 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code d'Appel Pays")]
        public string CAL_CTRY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Longueur Numéro Téléphone Pays")]
        public short CTRY_PHN_NBR_LNGH_CNT { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Mise À Jour")]
        public DateTime CTRY_PHN_NBR_LNGH_LST_UPD_DT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }
        public virtual ICollection<UserPhoneLogin> TUSR_PHN_LGN { get; set; }

        private DalContext db = new DalContext();

        public SelectList getAllCallingCountry(string selectedValue)
        {
            return (new SelectList(db.TCAL_CTRY, "CTRY_CD", "CAL_CTRY_CD", selectedValue));
        }

        public string getCallingCountryNameByCtryCD(string ctry)
        {
            return db.TCAL_CTRY.Find(ctry).CAL_CTRY_CD;
        }

        public CallingCountry getOneCallingCountryByCtryCD(string ctryCD)
        {
            try
            {
                var calCtry = db.TCAL_CTRY.Find(ctryCD);
                if (calCtry == null)
                {
                    return null;
                }
                return calCtry;
            }
            catch
            {
                return null;
            }
        }
    }
}