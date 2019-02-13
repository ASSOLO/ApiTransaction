using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TMNYT_RSN")]
    public class MoneyTransferRaison
    {
        public MoneyTransferRaison()
        {
            LGC_DEL_IND = "0";
        }

        [Key]
        [Display(Name = "Code Raison")]
        public int MNYT_RSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FRA_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string ENG_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SPA_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string ARB_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string POR_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string ZHO_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string RUS_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string DEU_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string ITA_MNYT_RSN_NM { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllMoneyTransferRaison()
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TMNYT_RSN, "MNYT_RSN_ID", "FRA_MNYT_RSN_NM"));
            }
            else
            {
                return null;
            }

        }

        public string getMoneyTransferRaisonByID(string ID)
        {
            if (lang == "FRA")
            {
                return db.TMNYT_RSN.Find(ID).FRA_MNYT_RSN_NM;
            }
            else
            {
                return null;
            }
        }
    }
}