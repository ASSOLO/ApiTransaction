using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBUS_CTRY_FEE")]
    public class BusinessFee
    {
        public BusinessFee()
        {
            BUS_FEE_DT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Frais Transaction")]
        public int BUS_FEE_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(2, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 2)]
        [Display(Name = "Type de Service")]
        public string SRVC_TCD { get; set; }

        [Display(Name = "Service Texte")]
        [NotMapped]
        public string SRVC_TCD_TXT
        {
            get
            {
                if (SRVC_TCD == "01")
                {
                    return "Transfert";
                }
                else if (SRVC_TCD == "02" || SRVC_TCD == "03")
                {
                    return "Paiement de facture";
                }
                else if (SRVC_TCD == "04")
                {
                    return "Paiement";
                }
                else if (SRVC_TCD == "05")
                {
                    return "Dépôt d'argent";
                }
                else if (SRVC_TCD == "06")
                {
                    return "Retrait d'argent";
                }
                return "Paiement";
            }
        }


        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Min")]
        public decimal FROM_AMT { get; set; }

        [Display(Name = "Montant Min Texte")]
        [NotMapped]
        public string FROM_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FROM_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Max")]
        public decimal TO_AMT { get; set; }

        [Display(Name = "Montant Max Texte")]
        [NotMapped]
        public string TO_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(TO_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais")]
        public decimal FIX_FEE_AMT { get; set; }

        [Display(Name = "Montant Max Texte")]
        [NotMapped]
        public string FIX_FEE_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FIX_FEE_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais (en % )")]
        public decimal PRCNT_FEE_RT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Type de Frais")]
        public string BUS_FEE_TCD { get; set; }

        [Display(Name = "Service Frais Texte")]
        [NotMapped]
        public string BUS_FEE_TCD_TXT
        {
            get
            {
                if (BUS_FEE_TCD == "1")
                {
                    return "Fixe";
                }
                else if (BUS_FEE_TCD == "2")
                {
                    return "%";
                }
                return BUS_FEE_TCD;
            }
        }


        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime BUS_FEE_DT { get; set; }

        public virtual Country TCTRY { get; set; }
        public virtual Currency TCRCY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public BusinessFee getBusinessFeeForCommission(decimal transAmt, string ctryCD, string crcyCD, string svrcTCD)
        {
            try
            {
                var feeList = db.TBUS_CTRY_FEE.Where(x => x.CTRY_CD == ctryCD && x.CRCY_CD == crcyCD && x.SRVC_TCD == svrcTCD &&
                                                          x.FROM_AMT <= transAmt && x.TO_AMT >= transAmt).ToList();
                if (feeList.Count() == 0)
                {
                    return null; // maybe transaction amount not supported
                }
                else
                {
                    var fee = feeList[0];
                    if (fee == null)
                    {
                        return null;
                    }
                    return fee;
                }
            }
            catch
            {
                return null;
            }
        }

        public decimal getBusinessFeeAmount(decimal transAmt, string ctryCD, string crcyCD, string svrcTCD)
        {
            try
            {
                var fee = getBusinessFeeForCommission(transAmt, ctryCD, crcyCD, svrcTCD);
                if (fee == null)
                {
                    return -1.0m; 
                }
                
                if(fee.BUS_FEE_TCD == "1")
                {
                    return fee.FIX_FEE_AMT;
                }

                if (fee.BUS_FEE_TCD == "2")
                {
                    return fee.PRCNT_FEE_RT * transAmt;
                }
                return -1.0m;
            }
            catch
            {
                return -0.0m;
            }
        }

        public decimal getWithdrawalBusinessFeeAmount(decimal transAmt, decimal feeAmt, string ctryCD, string crcyCD, string svrcTCD)
        {
            try
            {
                var fee = getBusinessFeeForCommission(transAmt, ctryCD, crcyCD, svrcTCD);
                if (fee == null)
                {
                    return -0.0m;
                }

                if (fee.BUS_FEE_TCD == "1")
                {
                    return fee.FIX_FEE_AMT;
                }

                if (fee.BUS_FEE_TCD == "2")
                {
                    return fee.PRCNT_FEE_RT * feeAmt;
                }
                return -0.0m;
            }
            catch
            {
                return -0.0m;
            }
        }

        public decimal getClientFeeAmount(decimal transAmt, string ctryCD, string crcyCD, string svrcTCD)
        {
            try
            {
                var fee = getBusinessFeeForCommission(transAmt, ctryCD, crcyCD, svrcTCD);
                if (fee == null)
                {
                    return -0.0m;
                }

                if (fee.BUS_FEE_TCD == "1")
                {
                    return fee.FIX_FEE_AMT;
                }
                else if (fee.BUS_FEE_TCD == "2")
                {
                    return fee.PRCNT_FEE_RT * transAmt;
                }
                return -0.0m;
            }
            catch
            {
                return -0.0m;
            }
        }

        public List<BusinessFee> getAllBusinessFeeByCtryCD(string ctryCD)
        {
            var list = new List<BusinessFee>();
            try
            {
                return db.TBUS_CTRY_FEE.Where(x => x.CTRY_CD == ctryCD).ToList();
            }
            catch
            {
                return list;
            }
        }
    }
}