using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRANS_FEE")]
    public class TransactionFee
    {
        public TransactionFee()
        {
            TRANS_FEE_DT = DateTime.Now;
            TTRSF_FEE_SERV_CTRY = new HashSet<TransferFeeServiceCountry>();
        }

        [Key]
        [Display(Name = "ID Frais Transaction")]
        public int TRANS_FEE_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [Display(Name = "Province")]
        public int? PROV_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Envoi")]
        public string FROM_CRCY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Reception")]
        public string TO_CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Min")]
        public decimal FROM_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Max")]
        public decimal TO_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais (Montant Investisseur)")]
        public decimal IVSTR_FIX_FEE_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais (en % investisseur)")]
        public decimal IVSTR_PRCNT_FEE_RT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais (Montant Non Investisseur)")]
        public decimal NIVSTR_FIX_FEE_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais (en % Non Investisseur)")]
        public decimal NIVSTR_PRCNT_FEE_RT { get; set; }

        [Display(Name = "% Taux Change)")]
        public int CRCY_XCHG_PRCNT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Type de Frais")]
        public string TRANS_FEE_TCD { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TRANS_FEE_DT { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Nom Groupe Frais")]
        public string TRANS_FEE_GRP_NM { get; set; }

        [Display(Name = "ID Groupe Frais")]
        public int TRANS_FEE_GRP_ID { get; set; }
        
        [Required(ErrorMessage = "L'indicateur du groupe des frais est obligatoire.")]
        [StringLength(1, ErrorMessage = "L'indicateur du groupe des frais doit compter au maximum 1 caractère.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Indicateur Groupe Frais")]
        public string TRANS_FEE_GRP_IND { get; set; }

        public virtual Currency TCRCY { get; set; }

        public virtual Currency TCRCY1 { get; set; }

        public virtual CurrencyExchangePercent TCRCY_XCHG_PRCNT { get; set; }

        public virtual Province TPROV { get; set; }
        
        public virtual ICollection<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public TransactionFee getTransactionFee(decimal transAmt, int fromTransServCtryID, int toTransServCtryID,
                                         string fromCtryCD, string toCtryCD, string fromCrcyCD, string toCrcyCD)
        {
            try
            {
                var feeList = db.TTRSF_FEE_SERV_CTRY.Where(x => x.FROM_TRSF_SERV_ID == fromTransServCtryID &&
                                                                x.TO_TRSF_SERV_ID == toTransServCtryID &&
                                                                x.FROM_CTRY_CD == fromCtryCD && x.TO_CTRY_CD == toCtryCD).ToList();
                if (feeList.Count() == 0)
                {
                    return null;
                }
                else
                {
                    var fee = feeList[0];
                    if (fee == null)
                    {
                        return null;
                    }

                    var transFeeList = db.TTRANS_FEE.Where(x => x.TRANS_FEE_GRP_ID == fee.TRANS_FEE_ID &&
                                                             x.FROM_CRCY_CD == fromCrcyCD && x.TO_CRCY_CD == toCrcyCD &&
                                                             x.FROM_AMT <= transAmt && x.TO_AMT >= transAmt).ToList();
                    if (transFeeList.Count() == 0)
                    {
                        return null; // maybe transaction amount not supported
                    }
                    else
                    {
                        var transFee = transFeeList[0];
                        if (transFee == null)
                        {
                            return null;
                        }
                        return transFee;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public decimal getCurrencyExchangePercent(decimal TRANS_AMT, decimal xchgRate, string SEND_RCPT_CD)
        {
            decimal CONVERT_TRANS_AMT = 0.0m;
            if (SEND_RCPT_CD == "1")
            {
                CONVERT_TRANS_AMT = xchgRate * TRANS_AMT;
            }
            else if (SEND_RCPT_CD == "2")
            {
                CONVERT_TRANS_AMT = TRANS_AMT / xchgRate;
            }
            return CONVERT_TRANS_AMT;
        }

        public TransactionFeeViewModel getTransactionFee(int FROM_SRVC_ID, int TO_SRVC_ID,
                                                     string FROM_CTRY_CD, string TO_CTRY_CD,
                                                     string FROM_CRCY_CD, string TO_CRCY_CD,
                                                     decimal TRANS_AMT, decimal crcyXchgPercent,
                                                     string SEND_RCPT_CD, string SRVC_TCD,
                                                     string CLT_ON_CLT_BHLF_TCD)
        {
            try
            {
                var model = new TransactionFeeViewModel();
                var crcyXchgRt = new CurrencyExchangeRate();
                decimal adjustXchgRate = 0.0m;
                decimal fromXchgRt = 1.0m;
                string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(FROM_CRCY_CD);

                if (FROM_CTRY_CD != TO_CTRY_CD) // DIFFRENT COUNTRIES
                {
                    decimal FROM_TRANS_AMT = 0.0M;
                    decimal TO_TRANS_AMT = 0.0M;
                    if (FROM_CRCY_CD != TO_CRCY_CD) // DIFFRENT CURRENCIES
                    {
                        //GET the crcy exchange rate
                        decimal xchgRate = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, TO_CRCY_CD);
                        if (xchgRate == 0.0m)
                        {
                            model.ERROR_TXT = CommonLibrary.displayGenericErrorMessage();
                            return model;
                        }

                        //GET THE ADJUSTMENT CURRENCY PERCENT RATE
                        if (crcyXchgPercent == 0.0m)
                        {
                            FROM_TRANS_AMT = TRANS_AMT;
                            if (SEND_RCPT_CD == "2")
                            {
                                FROM_TRANS_AMT = TRANS_AMT / xchgRate;
                            }

                            //this first query is to get the approximative sent amount, to get the adjustment
                            var transFeeObj = getTransactionFee(FROM_TRANS_AMT, FROM_SRVC_ID, TO_SRVC_ID,
                                                                FROM_CTRY_CD, TO_CTRY_CD, FROM_CRCY_CD, TO_CRCY_CD);
                            if (transFeeObj != null)
                            {
                                var crcyXchgPercentObj = new CurrencyExchangePercent();
                                var getCcrcyXchgPercentObj = crcyXchgPercentObj.getCurrencyExchangePercentByID(transFeeObj.CRCY_XCHG_PRCNT_ID);
                                if (crcyXchgPercentObj != null)
                                {
                                    crcyXchgPercent = getCcrcyXchgPercentObj.IVSTR_CRCY_XCHG_PRCNT_RT;
                                }
                                else
                                {
                                    crcyXchgPercent = 0.980m;
                                }
                            }
                        }

                        //adjust the currency exchange rate
                        adjustXchgRate = xchgRate;
                        if (xchgRate == 1.0m)
                        {
                            adjustXchgRate = xchgRate;
                        }
                        else if (crcyXchgPercent != 0.0m)
                        {
                            adjustXchgRate = xchgRate * crcyXchgPercent;
                        }

                        if (SEND_RCPT_CD == "1")
                        {
                            FROM_TRANS_AMT = TRANS_AMT;
                            TO_TRANS_AMT = TRANS_AMT * adjustXchgRate;
                        }
                        if (SEND_RCPT_CD == "2")
                        {
                            FROM_TRANS_AMT = TRANS_AMT / adjustXchgRate;
                            TO_TRANS_AMT = TRANS_AMT;
                        }
                    }
                    else
                    {
                        adjustXchgRate = 1.0m;
                        FROM_TRANS_AMT = TRANS_AMT;
                        TO_TRANS_AMT = TRANS_AMT;
                    }

                    model.FROM_TRANS_AMT = FROM_TRANS_AMT;
                    model.TO_TRANS_AMT = TO_TRANS_AMT;

                    // calculate transaction fee
                    var transFeeObj1 = getTransactionFee(model.FROM_TRANS_AMT, FROM_SRVC_ID, TO_SRVC_ID,
                                                        FROM_CTRY_CD, TO_CTRY_CD, FROM_CRCY_CD, TO_CRCY_CD);
                    if (transFeeObj1 == null)
                    {
                        model.ERROR_TXT = "Il se peut que le type de transaction que vous effectuez n'est pas encore autorisé par PayKap. Contactez nous si vous croyez être une erreur.";
                        return model;
                    }

                    if (transFeeObj1.TRANS_FEE_TCD == "1")
                    {
                        model.FEE_AMT = transFeeObj1.IVSTR_FIX_FEE_AMT;
                    }
                    else
                    {
                        model.FEE_AMT = transFeeObj1.IVSTR_PRCNT_FEE_RT * model.FROM_TRANS_AMT;
                    }

                    model.CRCY_XCHG_RT_IND = true;
                    model.CRCY_XCHG_RT_TXT = fromXchgRt.ToString("N2") + " " + FROM_CRCY_CD + " = " + adjustXchgRate.ToString(formatString) + " " + TO_CRCY_CD;
                    model.CRCY_XCHG_RT = adjustXchgRate;
                    model.ADJUST_XCHG_RT = crcyXchgPercent;
                }
                else // SAME COUNTRIES
                {
                    if (FROM_CRCY_CD != TO_CRCY_CD) // DIFFRENT CURRENCIES
                    {
                        model.ERROR_TXT = "Les devises des transactions intra nationales ne peuvent pas être differentes";
                        return model;
                    }

                    //when the fromCtry and toCtry are the same contries, 
                    //the fee comes from the BusinessFee class, the class name will be updating in the future
                    var newBusFee = new BusinessFee();
                    decimal getBusFee;
                    if (FROM_CTRY_CD == TO_CTRY_CD)
                    {
                        //if it is the same country but the transaction on behalf of the client, apply fee
                        if (CLT_ON_CLT_BHLF_TCD == "1")
                        {
                            getBusFee = 0.0m;
                        }
                        else
                        {
                            //getBusFee IS 0.0 because PayKap does not apply the transFee when it is the same country online.

                            //getBusFee = newBusFee.getClientFeeAmount(TRANS_AMT, FROM_CTRY_CD, FROM_CRCY_CD, SRVC_TCD);

                            //if (getBusFee == 0.0m)
                            //{
                            //    model.ERROR_TXT = "Il se peut que le type de transaction que vous effectuez n'est pas encore autorisé par PayKap. Contactez nous si vous croyez être une erreur.";
                            //    return model;
                            //}
                            //decimal getBehalfFeeAmt = getBusFee * 1.3m;
                            //getBusFee = CommonLibrary.roundAmountToCeiling(getBehalfFeeAmt);
                            getBusFee = 0.0m;
                        }
                    }
                    else
                    {
                        getBusFee = newBusFee.getClientFeeAmount(TRANS_AMT, FROM_CTRY_CD, FROM_CRCY_CD, SRVC_TCD);

                        if (getBusFee == 0.0m)
                        {
                            model.ERROR_TXT = "Il se peut que le type de transaction que vous effectuez n'est pas encore autorisé par PayKap. Contactez nous si vous croyez être une erreur.";
                            return model;
                        }
                    }

                    model.FEE_AMT = getBusFee;
                    model.CRCY_XCHG_RT_IND = false;
                    model.CRCY_XCHG_RT_TXT = "";
                    model.CRCY_XCHG_RT = 0.0M;
                    model.ADJUST_XCHG_RT = crcyXchgPercent;
                    model.FROM_TRANS_AMT = TRANS_AMT;
                    model.TO_TRANS_AMT = TRANS_AMT;
                }

                if (CLT_ON_CLT_BHLF_TCD == "1")
                {
                    model.TOT_TO_PAY_AMT = model.FROM_TRANS_AMT + model.FEE_AMT;
                }
                else
                {
                    decimal getBehalfFeeAmt = model.FEE_AMT * 1.3m;
                    model.FEE_AMT = CommonLibrary.roundAmountToCeiling(getBehalfFeeAmt);
                    model.TOT_TO_PAY_AMT = model.FROM_TRANS_AMT + model.FEE_AMT;
                }

                var newObjCultureInfo = new CountryCurrency();
                string cultureInfo = newObjCultureInfo.getCultureInfoByCurrencyCD(FROM_CRCY_CD, "FRA");
                string cultureInfo1 = newObjCultureInfo.getCultureInfoByCurrencyCD(TO_CRCY_CD, "FRA");
                model.FROM_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.FROM_TRANS_AMT, FROM_CRCY_CD, cultureInfo);
                model.FEE_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.FEE_AMT, FROM_CRCY_CD, cultureInfo);
                model.TOT_TO_PAY_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.TOT_TO_PAY_AMT, FROM_CRCY_CD, cultureInfo);
                model.TO_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.TO_TRANS_AMT, TO_CRCY_CD, cultureInfo1);

                model.SEND_RCPT_CD = SEND_RCPT_CD;
                model.FROM_CTRY_CD = FROM_CTRY_CD;
                model.TO_CTRY_CD = TO_CTRY_CD;
                model.FROM_CRCY_CD = FROM_CRCY_CD;
                model.TO_CRCY_CD = TO_CRCY_CD;
                model.FROM_SRVC_ID = FROM_SRVC_ID;
                model.TO_SRVC_ID = TO_SRVC_ID;

                //handle the promo code 
                if (model.FROM_CTRY_CD == "124") // Canada
                {
                    model.FEE_AMT_PROMO_CD = 0.0m;
                }
                if (model.FROM_CTRY_CD == "120" && model.TO_CTRY_CD == "120") // Cameroun
                {
                    model.FEE_AMT_PROMO_CD = model.FEE_AMT - 1000;
                    if (model.FEE_AMT_PROMO_CD < 0.0m)
                    {
                        model.FEE_AMT_PROMO_CD = 0.0m;
                    }
                }

                model.TOT_TO_PAY_AMT_PROMO_CD = model.FROM_TRANS_AMT + model.FEE_AMT_PROMO_CD;
                model.FEE_AMT_TXT_PROMO_CD = CommonLibrary.displayFormattedCurrency(model.FEE_AMT_PROMO_CD, FROM_CRCY_CD, cultureInfo);
                model.TOT_TO_PAY_AMT_TXT_PROMO_CD = CommonLibrary.displayFormattedCurrency(model.TOT_TO_PAY_AMT_PROMO_CD, FROM_CRCY_CD, cultureInfo);
                model.ERROR_TXT = "ok";
                return model;
            }
            catch
            {
                return null;
            }
        }

        //public TransactionFeeViewModel getTransactionFee(int FROM_SRVC_ID, int TO_SRVC_ID,
        //                                             string FROM_CTRY_CD, string TO_CTRY_CD,
        //                                             string FROM_CRCY_CD, string TO_CRCY_CD,
        //                                             decimal TRANS_AMT, decimal crcyXchgPercent, 
        //                                             string SEND_RCPT_CD, string SRVC_TCD)
        //{
        //    try
        //    {
        //        var model = new TransactionFeeViewModel();
        //        var crcyXchgRt = new CurrencyExchangeRate();
        //        decimal adjustXchgRate = 0.0m;
        //        decimal fromXchgRt = 1.0m;
        //        string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(FROM_CRCY_CD);

        //        if (FROM_CTRY_CD != TO_CTRY_CD) // DIFFRENT COUNTRIES
        //        {
        //            decimal FROM_TRANS_AMT = 0.0M;
        //            decimal TO_TRANS_AMT = 0.0M;
        //            if (FROM_CRCY_CD != TO_CRCY_CD) // DIFFRENT CURRENCIES
        //            {
        //                //GET the crcy exchange rate
        //                decimal xchgRate = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, TO_CRCY_CD);
        //                if (xchgRate == 0.0m)
        //                {
        //                    model.ERROR_TXT = CommonLibrary.displayGenericErrorMessage();
        //                    return model;
        //                }

        //                //GET THE ADJUSTMENT CURRENCY PERCENT RATE
        //                if (crcyXchgPercent == 0.0m)
        //                {
        //                    FROM_TRANS_AMT = TRANS_AMT;
        //                    if (SEND_RCPT_CD == "2")
        //                    {
        //                        FROM_TRANS_AMT = TRANS_AMT / xchgRate;
        //                    }

        //                    //this first query is to get the approximative sent amount, to get the adjustment
        //                    var transFeeObj = getTransactionFee(FROM_TRANS_AMT, FROM_SRVC_ID, TO_SRVC_ID,
        //                                                        FROM_CTRY_CD, TO_CTRY_CD, FROM_CRCY_CD, TO_CRCY_CD);
        //                    if (transFeeObj != null)
        //                    {
        //                        var crcyXchgPercentObj = new CurrencyExchangePercent();
        //                        var getCcrcyXchgPercentObj = crcyXchgPercentObj.getCurrencyExchangePercentByID(transFeeObj.CRCY_XCHG_PRCNT_ID);
        //                        if (crcyXchgPercentObj != null)
        //                        {
        //                            crcyXchgPercent = getCcrcyXchgPercentObj.IVSTR_CRCY_XCHG_PRCNT_RT;
        //                        }
        //                        else
        //                        {
        //                            crcyXchgPercent = 0.980m;
        //                        }
        //                    }
        //                }

        //                //adjust the currency exchange rate
        //                adjustXchgRate = xchgRate;
        //                if (xchgRate == 1.0m)
        //                {
        //                    adjustXchgRate = xchgRate;
        //                }
        //                else if (crcyXchgPercent != 0.0m)
        //                {
        //                    adjustXchgRate = xchgRate * crcyXchgPercent;
        //                }

        //                if (SEND_RCPT_CD == "1")
        //                {
        //                    FROM_TRANS_AMT = TRANS_AMT;
        //                    TO_TRANS_AMT = TRANS_AMT * adjustXchgRate;
        //                }
        //                if (SEND_RCPT_CD == "2")
        //                {
        //                    FROM_TRANS_AMT = TRANS_AMT / adjustXchgRate;
        //                    TO_TRANS_AMT = TRANS_AMT;
        //                }
        //            }
        //            else
        //            {
        //                adjustXchgRate = 1.0m;
        //                FROM_TRANS_AMT = TRANS_AMT;
        //                TO_TRANS_AMT = TRANS_AMT;
        //            }

        //            model.FROM_TRANS_AMT = FROM_TRANS_AMT;
        //            model.TO_TRANS_AMT = TO_TRANS_AMT;

        //            // calculate transaction fee
        //            var transFeeObj1 = getTransactionFee(model.FROM_TRANS_AMT, FROM_SRVC_ID, TO_SRVC_ID,
        //                                                FROM_CTRY_CD, TO_CTRY_CD, FROM_CRCY_CD, TO_CRCY_CD);
        //            if (transFeeObj1 == null)
        //            {
        //                model.ERROR_TXT = "Il se peut que le type de transaction que vous effectuez n'est pas encore autorisé par PayKap. Contactez nous si vous croyez être une erreur.";
        //                return model;
        //            }

        //            if(transFeeObj1.TRANS_FEE_TCD == "1")
        //            {
        //                model.FEE_AMT = transFeeObj1.IVSTR_FIX_FEE_AMT;
        //            }
        //            else
        //            {
        //                model.FEE_AMT = transFeeObj1.IVSTR_PRCNT_FEE_RT * model.FROM_TRANS_AMT;
        //            }

        //            model.CRCY_XCHG_RT_IND = true;
        //            model.CRCY_XCHG_RT_TXT = fromXchgRt.ToString("N2") + " " + FROM_CRCY_CD + " = " + adjustXchgRate.ToString(formatString) + " " + TO_CRCY_CD;
        //            model.CRCY_XCHG_RT = adjustXchgRate;
        //            model.ADJUST_XCHG_RT = crcyXchgPercent;
        //        }
        //        else // SAME COUNTRIES
        //        {
        //            if(FROM_CRCY_CD != TO_CRCY_CD) // DIFFRENT CURRENCIES
        //            {
        //                model.ERROR_TXT = "Les devises des transactions intra nationales ne peuvent pas être differentes";
        //                return model;
        //            }

        //            //when the fromCtry and toCtry are the same contries, 
        //            //the fee comes from the BusinessFee class, the class name will be updating in the future
        //            var newBusFee = new BusinessFee();
        //            decimal getBusFee;
        //            if (FROM_CTRY_CD == TO_CTRY_CD) 
        //            {
        //                getBusFee = 0.0m;
        //            }
        //            else
        //            {
        //                getBusFee = newBusFee.getClientFeeAmount(TRANS_AMT, FROM_CTRY_CD, FROM_CRCY_CD, SRVC_TCD);

        //                if (getBusFee == 0.0m)
        //                {
        //                    model.ERROR_TXT = "Il se peut que le type de transaction que vous effectuez n'est pas encore autorisé par PayKap. Contactez nous si vous croyez être une erreur.";
        //                    return model;
        //                }
        //            }

        //            model.FEE_AMT = getBusFee;
        //            model.CRCY_XCHG_RT_IND = false;
        //            model.CRCY_XCHG_RT_TXT = "";
        //            model.CRCY_XCHG_RT = 0.0M;
        //            model.ADJUST_XCHG_RT = crcyXchgPercent;
        //            model.FROM_TRANS_AMT = TRANS_AMT;
        //            model.TO_TRANS_AMT = TRANS_AMT;
        //        }

        //        model.TOT_TO_PAY_AMT = model.FROM_TRANS_AMT + model.FEE_AMT;

        //        var newObjCultureInfo = new CountryCurrency();
        //        string cultureInfo = newObjCultureInfo.getCultureInfoByCurrencyCD(FROM_CRCY_CD, "FRA");
        //        string cultureInfo1 = newObjCultureInfo.getCultureInfoByCurrencyCD(TO_CRCY_CD, "FRA");
        //        model.FROM_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.FROM_TRANS_AMT, FROM_CRCY_CD, cultureInfo);
        //        model.FEE_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.FEE_AMT, FROM_CRCY_CD, cultureInfo);
        //        model.TOT_TO_PAY_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.TOT_TO_PAY_AMT, FROM_CRCY_CD, cultureInfo);
        //        model.TO_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(model.TO_TRANS_AMT, TO_CRCY_CD, cultureInfo1);

        //        model.SEND_RCPT_CD = SEND_RCPT_CD;
        //        model.FROM_CTRY_CD = FROM_CTRY_CD;
        //        model.TO_CTRY_CD = TO_CTRY_CD;
        //        model.FROM_CRCY_CD = FROM_CRCY_CD;
        //        model.TO_CRCY_CD = TO_CRCY_CD;
        //        model.FROM_SRVC_ID = FROM_SRVC_ID;
        //        model.TO_SRVC_ID = TO_SRVC_ID;

        //        //handle the promo code 
        //        if (model.FROM_CTRY_CD == "124") // Canada
        //        {
        //            model.FEE_AMT_PROMO_CD = 0.0m;
        //        }
        //        if (model.FROM_CTRY_CD == "120" && model.TO_CTRY_CD == "120") // Cameroun
        //        {
        //            model.FEE_AMT_PROMO_CD = model.FEE_AMT - 1000;
        //            if (model.FEE_AMT_PROMO_CD < 0.0m)
        //            {
        //                model.FEE_AMT_PROMO_CD = 0.0m;
        //            }
        //        }

        //        model.TOT_TO_PAY_AMT_PROMO_CD = model.FROM_TRANS_AMT + model.FEE_AMT_PROMO_CD;
        //        model.FEE_AMT_TXT_PROMO_CD = CommonLibrary.displayFormattedCurrency(model.FEE_AMT_PROMO_CD, FROM_CRCY_CD, cultureInfo);
        //        model.TOT_TO_PAY_AMT_TXT_PROMO_CD = CommonLibrary.displayFormattedCurrency(model.TOT_TO_PAY_AMT_PROMO_CD, FROM_CRCY_CD, cultureInfo);
        //        model.ERROR_TXT = "ok";
        //        return model;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public TransactionFeeViewModel convertAmount(int FROM_SRVC_ID, int TO_SRVC_ID, 
                                                     string FROM_CTRY_CD, string TO_CTRY_CD,
                                                     string FROM_CRCY_CD, string TO_CRCY_CD,
                                                     decimal TRANS_AMT, decimal crcyXchgPercent, string SEND_RCPT_CD)
        {
            try
            {
                var model = new TransactionFeeViewModel();
                var crcyXchgRt = new CurrencyExchangeRate();

                //GET the crcy exchange rate
                decimal xchgRate = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, TO_CRCY_CD);
                if (xchgRate == 0.0m)
                {
                    return null;
                }

                //GET THE ADJUSTMENT CURRENCY PERCENT RATE
                if(crcyXchgPercent == 0.0m)
                {
                    decimal CONVERT_TRANS_AMT = 0.0m; ;
                    if (SEND_RCPT_CD == "1")
                    {
                        CONVERT_TRANS_AMT = xchgRate * TRANS_AMT;
                    }
                    else if (SEND_RCPT_CD == "2")
                    {
                        CONVERT_TRANS_AMT = TRANS_AMT / xchgRate;
                    }

                    var transFeeObj = getTransactionFee(CONVERT_TRANS_AMT, FROM_SRVC_ID, TO_SRVC_ID,
                                                                FROM_CTRY_CD, TO_CTRY_CD, FROM_CRCY_CD, TO_CRCY_CD);
                    if (transFeeObj != null)
                    {
                        var crcyXchgPercentObj = new CurrencyExchangePercent();
                        var getCcrcyXchgPercentObj = crcyXchgPercentObj.getCurrencyExchangePercentByID(crcyXchgPercentObj.CRCY_XCHG_PRCNT_ID);
                        if (crcyXchgPercentObj != null)
                        {
                            crcyXchgPercent = getCcrcyXchgPercentObj.IVSTR_CRCY_XCHG_PRCNT_RT;
                        }
                    }
                }                

                //adjust the currency exchange rate
                decimal adjustXchgRate = xchgRate;
                if (xchgRate == 1.0m)
                {
                    adjustXchgRate = xchgRate;
                }
                else if (crcyXchgPercent != 0.0m)
                {
                    adjustXchgRate = xchgRate * crcyXchgPercent;
                }

                decimal fromXchgRt = 1.0m;
                string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(FROM_CRCY_CD);

                if(SEND_RCPT_CD == "1")
                {
                    model.TO_TRANS_AMT = adjustXchgRate * TRANS_AMT;
                }
                else if (SEND_RCPT_CD == "2")
                {
                    model.FROM_TRANS_AMT = TRANS_AMT / adjustXchgRate;
                }
                model.CRCY_XCHG_RT_TXT = fromXchgRt.ToString("N2") + " " + FROM_CRCY_CD + " = " + adjustXchgRate.ToString(formatString) + " " + TO_CRCY_CD;
                model.CRCY_XCHG_RT = adjustXchgRate;
                model.CRCY_XCHG_RT_IND = true;
                model.ADJUST_XCHG_RT = crcyXchgPercent;
                return model;
            }
            catch
            {
                return null;
            }
        }

    }
}
