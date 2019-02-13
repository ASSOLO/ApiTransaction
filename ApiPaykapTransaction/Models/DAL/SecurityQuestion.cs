using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TSCTY_QUES_LIST")]
    public class SecurityQuestion
    {
        public SecurityQuestion()
        {
            TCNX_LOG = new HashSet<ConnexionLog>();
            TCNX_LOG1 = new HashSet<ConnexionLog>();
            TCNX_LOG2 = new HashSet<ConnexionLog>();
            LGC_DEL_IND = "0";
        }

        [Key]
        [Display(Name = "Code Question Securité")]
        public int SCTY_QUES_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string SCTY_QUES_FRA { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string SCTY_QUES_ENG { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SCTY_QUES_SPA { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string SCTY_QUES_ARB { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string SCTY_QUES_POR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string SCTY_QUES_ZHO { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string SCTY_QUES_RUS { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string SCTY_QUES_DEU { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string SCTY_QUES_ITA { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual ICollection<ConnexionLog> TCNX_LOG { get; set; }
        public virtual ICollection<ConnexionLog> TCNX_LOG1 { get; set; }
        public virtual ICollection<ConnexionLog> TCNX_LOG2 { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllSecurityQuestion()
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TSCTY_QUES_LIST, "SCTY_QUES_ID", "SCTY_QUES_FRA"));
            }
            else
            {
                return null;
            }
        }

        public string getSecurityQuestionByID(string ID)
        {
            if (lang == "FRA")
            {
                return db.TSCTY_QUES_LIST.Find(ID).SCTY_QUES_FRA;
            }
            else
            {
                return null;
            }
        }
    }
}