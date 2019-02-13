using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TKTCT")]
    public class Contact
    {
        public Contact()
        {
            ADDR_LN1_TXT = "d";
            ADDR_LN2_TXT = "d";
            PHN1_NBR = "d";
            PHN2_NBR = "d";
            WEBSITE_TXT = "d";
            CITY_NM = "d";
            EM_ADDR2_TXT = "admin@paykap.biz";
            TUSR = new HashSet<User>();
            TBUS = new HashSet<Business>();
            TBUS_AGCY = new HashSet<BusinessAgency>();
        }

        [Key]
        [Display(Name = "Contact Code")]
        public int KTCT_ID { get; set; }
                
        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(255, ErrorMessage = "L'adresse doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Adresse Ligne 1")]
        public string ADDR_LN1_TXT { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(255, ErrorMessage = "L'adresse doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Adresse Ligne 2")]
        public string ADDR_LN2_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le {0} doit compter au maximum 20 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Téléphone mobile")]
        public string PHN1_NBR { get; set; }

        //[Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le {0} doit compter au maximum 20 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Téléphone 2")]
        public string PHN2_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email 1")]
        public string EM_ADDR1_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email 2")]
        public string EM_ADDR2_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Site Web")]
        public string WEBSITE_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter au maximum 1 caractère.")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Contact")]
        public string KTCT_TCD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "La {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Ville")]
        public string CITY_NM { get; set; }

        //[Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(3, ErrorMessage = "Le {0} doit exactement avoir 3 caractères.", MinimumLength =3)]
        [DataType(DataType.Text)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Display(Name = "Code Ville")]
        public int? CITY_CD { get; set; }

        public virtual Country TCTRY { get; set; }
        public virtual City TCITY { get; set; }
        public virtual ICollection<User> TUSR { get; set; }
        public virtual ICollection<Business> TBUS { get; set; }
        public virtual ICollection<BusinessAgency> TBUS_AGCY { get; set; }
        private DalContext db = new DalContext();
        private string lang = "FRA";

        public Contact getContactByKtctID(int ktctID)
        {
            try
            {
                var ktct = db.TKTCT.Find(ktctID);
                if (ktct == null)
                {
                    return null;
                }
                else
                {
                    return ktct;
                }
            }
            catch
            {
                return null;
            }
        }

        public Contact createContact(string adr1, string adr2, string phn1, string phn2, string email1, string email2, 
                                     string wbst, string KTCT_TCD, string ctryCD, int cityCD)
        {
            try
            {
                var newObj = new Contact();
                var city = new City();

                newObj.ADDR_LN1_TXT = adr1;
                newObj.ADDR_LN2_TXT = adr2;
                newObj.PHN1_NBR = phn1;
                newObj.PHN2_NBR = phn2;
                newObj.EM_ADDR1_TXT = email1;
                newObj.EM_ADDR2_TXT = email2;
                newObj.WEBSITE_TXT = wbst;
                newObj.KTCT_TCD = KTCT_TCD;
                string cityNM = city.getCityNameByCityCode(cityCD);
                if(string.IsNullOrWhiteSpace(cityNM))
                {
                    newObj.CITY_NM = "d";
                }
                else
                {
                    newObj.CITY_NM = cityNM;
                }
                newObj.CTRY_CD = ctryCD;
                newObj.CITY_CD = cityCD;
                return newObj;
            }
            catch
            {
                return null;
            }
        }
    }
}