using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TMNYT_AUTH_LMIT")]
    public class MoneyTransferAuthorizedLimit
    {
        public MoneyTransferAuthorizedLimit()
        {
            LAST_UPDT_DT = DateTime.Now;
        }

        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Dévise")]
        public string CRCY_CD { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Type Transfert d'Argent")]
        public string MNYT_TCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro.")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Par Transaction")]
        public decimal TRANS_AUTH_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro.")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Quotidien")]
        public decimal DLY_AUTH_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro.")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Hebdo")]
        public decimal WKLY_AUTH_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro.")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Mensuel")]
        public decimal MTHLY_AUTH_AMT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Dernière Mise à jour")]
        public DateTime LAST_UPDT_DT { get; set; }

        public virtual Currency TCRCY { get; set; }
        public virtual Country TCTRY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public string checkAuthorizedAmount(decimal amt, string ctryCD, string crcyCD, string fromToTCD)
        {
            try
            {
                var chk = db.TMNYT_AUTH_LMIT.Find(ctryCD, crcyCD, fromToTCD);
                if (chk == null)
                {
                    return "no_paykap_service_in_selected_country";
                }
                if (chk.TRANS_AUTH_AMT < amt)
                {
                    return "unauthorized";
                }
                else
                {
                    return "authorized";
                }
            }
            catch
            {
                return null;
            }
        }

        public decimal getAuthorizedAmount(string ctryCD, string crcyCD, string fromToTCD)
        {
            try
            {
                var chk = db.TMNYT_AUTH_LMIT.Find(ctryCD, crcyCD, fromToTCD);
                if (chk == null)
                {
                    return -0.0m;
                }
                return chk.TRANS_AUTH_AMT;
            }
            catch
            {
                return -0.0m;
            }
        }

        public string checkAuthorizedLimitWithError(decimal amount, string FROM_CTRY_CD, 
                                                    string FROM_CRCY_CD, string MNYT_TCD, bool fromCheckIND)
        {
            string mnytTCD = MNYT_TCD;
            if (fromCheckIND)
            {
                mnytTCD = "1";
            }
            string checkTransAmt = checkAuthorizedAmount(amount, FROM_CTRY_CD, FROM_CRCY_CD, mnytTCD);
            if (string.IsNullOrWhiteSpace(checkTransAmt))
            {
                return CommonLibrary.displayGenericErrorMessage();
            }
            else if (checkTransAmt == "no_paykap_service_in_selected_country")
            {
                return "Il se pourrait que PayKap n'a pas de service de transfert dans le pays selectionné.";
            }
            else if (checkTransAmt == "unauthorized")
            {
                decimal maxAmtAuth = getAuthorizedAmount(FROM_CTRY_CD, FROM_CRCY_CD, MNYT_TCD);
                string strMaxAmtAuth = FROM_CRCY_CD.ToUpper() + " " + maxAmtAuth.ToString("N2");
                if (maxAmtAuth == -0.0m)
                {
                    return CommonLibrary.displayGenericErrorMessage();
                }

                return "Le montant de la transaction est supérieur à la limite autorisée (" + strMaxAmtAuth + ") dans votre pays.";
            }
            return "continue";
        }
    }
}