using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRSF_SERV")]
    public class TransferService
    {
        public TransferService()
        {
            TTRSF_SERV_CTRY = new HashSet<TransferServiceCountry>();
            TTRSF_FEE_SERV_CTRY = new HashSet<TransferFeeServiceCountry>();
            TTRSF_FEE_SERV_CTRY1 = new HashSet<TransferFeeServiceCountry>();
            LGC_DEL_IND = "0";
        }

        [Key]
        [Display(Name = "Code Service")]
        public int TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FRA_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string ENG_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SPA_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string ARB_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string POR_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string ZHO_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string RUS_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string DEU_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string ITA_TRSF_SERV_NM { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }
        
        public virtual ICollection<TransferServiceCountry> TTRSF_SERV_CTRY { get; set; }
        public virtual ICollection<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY { get; set; }
        public virtual ICollection<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY1 { get; set; }
        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllMoneyTransferService(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TTRSF_SERV, "TRSF_SERV_ID", "FRA_TRSF_SERV_NM", selectedValue));
            }
            else
            {
                return null;
            }

        }
        
        public string getTransferServiceByID(int ID)
        {
            if (lang == "FRA")
            {
                return db.TTRSF_SERV.Find(ID).FRA_TRSF_SERV_NM;
            }
            else
            {
                return null;
            }
        }
    }
}