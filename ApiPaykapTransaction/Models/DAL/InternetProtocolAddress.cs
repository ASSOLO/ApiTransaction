using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TIP_ADDR")]
    public class InternetProtocolAddress
    {
        [Key]
        [StringLength(39, ErrorMessage = "L'adresse IP doit avoir 39 caractères.", MinimumLength = 5)]
        [Required(ErrorMessage = "L'adresse IP est obligatoire.")]
        [Display(Name = "Adresse IP")]
        public string IP_ADDR_NBR { get; set; }

        [StringLength(2, ErrorMessage = "Le type adresse IP doit avoir 2 caractères.", MinimumLength = 2)]
        [Required(ErrorMessage = "Le type adresse IP est obligatoire.")]
        [Display(Name = "Type Adresse IP")]
        public string IP_VERS_TCD { get; set; }

        [Required(ErrorMessage = "La description du prorpiétaire de l'adresse IP est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Description Propriétaire Adresse IP")]
        public string IP_ADDR_DESC { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int? BN { get; set; }

        [StringLength(5, ErrorMessage = "Le code d'agence doit avoir 5 caractères.", MinimumLength = 5)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Agence")]
        public string BUS_AGCY_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de Création")]
        public DateTime IP_ADDR_CRT_DT { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string IP_ADDR_CRT_UPD_USR_NBR { get; set; }

        public virtual BusinessAgency TBUS_AGCY { get; set; }

        public virtual User TUSR { get; set; }
    }
}