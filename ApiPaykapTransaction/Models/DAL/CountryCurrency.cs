using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCTRY_CRCY")]
    public class CountryCurrency
    {
        public CountryCurrency()
        {
            LGC_DEL_IND = "0";
            CTRY_CRCY_CDT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CTRY_CRCY_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Langue")]
        public string LANG_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string CRCY_CD { get; set; }

        [Required]
        [StringLength(5)]
        [DataType(DataType.Text)]
        [Display(Name = "CultureInfo Devise")]
        public string CRCY_CLTR_INFO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Création")]
        public DateTime CTRY_CRCY_CDT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual Currency TCRCY { get; set; }

        public virtual Country TCTRY { get; set; }
        public virtual Language TLANG { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public string getCurrencyByCountry(string ctryCD)
        {
            var list = db.TCTRY_CRCY.Where(x => x.CTRY_CD == ctryCD).ToList();
            if(list.Count() == 0)
            {
                return null;
            }
            var obj = list[0];

            if (obj == null)
            {
                return null;
            }
            return obj.CRCY_CD;
        }

        public string getCultureInfoByCountryAndLanguage(string ctryCD, string langCD)
        {
            string CRCY_CLTR_INFO1;
            var list = db.TCTRY_CRCY.Where(x => x.CTRY_CD == ctryCD && x.LANG_CD == langCD).ToList();
            if (list.Count() != 0)
            {
                var obj = list[0];

                if (obj == null)
                {
                    return null;
                }
                CRCY_CLTR_INFO1 = obj.CRCY_CLTR_INFO;
            }
            else
            {
                var list1 = db.TCTRY_CRCY.Where(x => x.CTRY_CD == ctryCD).ToList();
                if (list1.Count() == 0)
                {
                    return null;
                }

                var obj = list1[0];
                if (obj == null)
                {
                    return null;
                }
                CRCY_CLTR_INFO1 = obj.CRCY_CLTR_INFO;
            }
            return CRCY_CLTR_INFO1;
        }

        public string getCultureInfoByCurrencyCD(string crcyCD, string langCD)
        {
            string CRCY_CLTR_INFO1;
            var list = db.TCTRY_CRCY.Where(x => x.CRCY_CD == crcyCD && x.LANG_CD == langCD).ToList();
            if (list.Count() != 0)
            {
                var obj = list[0];

                if (obj == null)
                {
                    return null;
                }
                CRCY_CLTR_INFO1 = obj.CRCY_CLTR_INFO;
            }
            else
            {
                var list1 = db.TCTRY_CRCY.Where(x => x.CRCY_CD == crcyCD).ToList();
                if (list1.Count() == 0)
                {
                    return null;
                }

                var obj = list1[0];
                if (obj == null)
                {
                    return null;
                }
                CRCY_CLTR_INFO1 = obj.CRCY_CLTR_INFO;
            }
            return CRCY_CLTR_INFO1;
        }
    }
}
