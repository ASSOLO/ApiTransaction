using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCNX_LOG")]
    public class ConnexionLog
    {
        public ConnexionLog ()
        {
            CNX_SCTY_QUES_SEQ_NBR = 0;
            CNX_SCTY_QUES_CHKED = "0";
            LAST_CNX_DTTM = DateTime.Now;
        }

        [Key]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "La question de sécurité 1 est obligatoire.")]
        [Display(Name = "Question Sécurité 1")]
        public int QUES1 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 1 est obligatoire.")]
        [StringLength(1000, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Réponse Question 1")]
        public string RESP1 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 1 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP1", ErrorMessage = "Les deux réponses de la question 1 ne correspondent pas.")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Réponse Question 1")]
        public string CONFIRM_RESP1 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 2 est obligatoire.")]
        [Display(Name = "Question Sécurité 2")]
        public int QUES2 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 2 est obligatoire.")]
        [StringLength(1000, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Réponse Question 2")]
        public string RESP2 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 2 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP2", ErrorMessage = "Les deux réponses de la question 2 ne correspondent pas.")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Réponse Question 2")]
        public string CONFIRM_RESP2 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 3 est obligatoire.")]
        [Display(Name = "Question Sécurité 3")]
        public int QUES3 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 3 est obligatoire.")]
        [StringLength(1000, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Réponse Question 3")]
        public string RESP3 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 3 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP3", ErrorMessage = "Les deux réponses de la question 3 ne correspondent pas.")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Réponse Question 3")]
        public string CONFIRM_RESP3 { get; set; }

        [Display(Name = "Numéro Séquence")]
        public int CNX_SCTY_QUES_SEQ_NBR { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Repondre Obligatoire?")]
        public string CNX_SCTY_QUES_CHKED { get; set; }

        [Required]
        [StringLength(39)]
        [Display(Name = "Adresse IP")]
        public string IP_ADDR_NBR { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Version Adresse IP")]
        public string IP_VERS_TCD { get; set; }

        [Display(Name = "Dernière Connexion")]
        public DateTime LAST_CNX_DTTM { get; set; }

        public virtual User TUSR { get; set; }

        public virtual SecurityQuestion TSCTY_QUES_LIST { get; set; }

        public virtual SecurityQuestion TSCTY_QUES_LIST1 { get; set; }

        public virtual SecurityQuestion TSCTY_QUES_LIST2 { get; set; }


        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllSecurityQuestion(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TSCTY_QUES_LIST, "SCTY_QUES_ID", "SCTY_QUES_FRA", selectedValue));
            }
            else
            {
                return null;
            }

        }
    }
}