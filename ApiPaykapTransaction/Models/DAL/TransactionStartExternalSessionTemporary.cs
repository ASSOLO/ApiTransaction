using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRANS_START_XSSN_TEMPO")]
    public class TransactionStartExternalSessionTemporary
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // TRANS_OTH1_TXT:                                                             //
        // stores the SENSER_USR_UBR When the transaction is on behalf of the client   //

        public TransactionStartExternalSessionTemporary()
        {
            TRANS_EDTTM = DateTime.Now;
            TRANS_XDTTM = DateTime.Now.AddHours(1);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Session")]
        public long TRANS_SSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(64, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 64)]
        [Display(Name = "ID Securité")]
        public string TRANS_SSN_SECR_ID { get; set; }

        public int FROM_SRVC_ID { get; set; }

        public int TO_SRVC_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string FROM_CTRY_CD { get; set; }

        [Required]
        [StringLength(3)]
        public string TO_CTRY_CD { get; set; }

        [Required]
        [StringLength(3)]
        public string FROM_CRCY_CD { get; set; }

        [Required]
        [StringLength(3)]
        public string TO_CRCY_CD { get; set; }

        [Required]
        [StringLength(1)]
        public string SEND_RCPT_CD { get; set; } // send = 1, reception = 2

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal FROM_TRANS_AMT { get; set; }

        [Required]
        [StringLength(50)]
        public string FROM_TRANS_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_FEE_AMT { get; set; }

        [Required]
        [StringLength(50)]
        public string TRANS_FEE_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_FEE_AMT_PROMO_CD { get; set; }

        [Required]
        [StringLength(50)]
        public string TRANS_FEE_AMT_TXT_PROMO_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TOT_TO_PAY_AMT { get; set; }

        [Required]
        [StringLength(50)]
        public string TOT_TO_PAY_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TOT_TO_PAY_AMT_PROMO_CD { get; set; }

        [Required]
        [StringLength(50)]
        public string TOT_TO_PAY_AMT_TXT_PROMO_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TO_TRANS_AMT { get; set; }

        [Required]
        [StringLength(50)]
        public string TO_TRANS_AMT_TXT { get; set; }
        
        [Display(Name = "Taux de change)")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Required]
        [StringLength(50)]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Required]
        [StringLength(1)] //DISPLAY CRCY XCHG RATE INDICATOR
        public string DPLY_CRCY_XCHG_RT_IND { get; set; } // 0 = false, 1 = true

        [Display(Name = "Taux de change)")]
        public decimal ADJUST_XCHG_RT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime TRANS_EDTTM { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime TRANS_XDTTM { get; set; }

        [Required]
        [StringLength(10)]
        public string CLT_USR_NBR { get; set; }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // TRANS_OTH1_TXT:                                                             //
        // stores the SENSER_USR_UBR When the transaction is on behalf of the client   //
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 1")]
        public string TRANS_OTH1_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 2")]
        public string TRANS_OTH2_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 3")]
        public string TRANS_OTH3_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 4")]
        public string TRANS_OTH4_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 5")]
        public string TRANS_OTH5_TXT { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public TransactionStartExternalSessionTemporary createTransactionSession(int FROM_SRVC_ID, int TO_SRVC_ID, string FROM_CTRY_CD, string TO_CTRY_CD,
                                                        string FROM_CRCY_CD, string TO_CRCY_CD, string SEND_RCPT_CD, 
                                                        decimal FROM_TRANS_AMT, string FROM_TRANS_AMT_TXT,
                                                        decimal TRANS_FEE_AMT, string TRANS_FEE_AMT_TXT,
                                                        decimal TRANS_FEE_AMT_PROMO_CD, string TRANS_FEE_AMT_TXT_PROMO_CD,
                                                        decimal TOT_TO_PAY_AMT, string TOT_TO_PAY_AMT_TXT,
                                                         decimal TOT_TO_PAY_AMT_PROMO_CD, string TOT_TO_PAY_AMT_TXT_PROMO_CD,
                                                        decimal TO_TRANS_AMT, string TO_TRANS_AMT_TXT,
                                                        decimal CRCY_XCHG_RT, string CRCY_XCHG_RT_TXT,
                                                        string DPLY_CRCY_XCHG_RT_IND, decimal ADJUST_XCHG_RT,
                                                        string CLT_USR_NBR,
                                                        string OTH1_TXT, string OTH2_TXT, string OTH3_TXT, string OTH4_TXT, string OTH5_TXT)
        {
                var obj = new TransactionStartExternalSessionTemporary();
                
                string part1 = Guid.NewGuid().ToString("N");
                string part2 = Guid.NewGuid().ToString("N");
                string TRANS_SSN_SECR_ID =  string.Concat(part1, part2);
                obj.TRANS_SSN_SECR_ID = TRANS_SSN_SECR_ID;
                obj.FROM_SRVC_ID = FROM_SRVC_ID;
                obj.TO_SRVC_ID = TO_SRVC_ID;
                obj.FROM_CTRY_CD = FROM_CTRY_CD;
                obj.TO_CTRY_CD = TO_CTRY_CD;
                obj.FROM_CRCY_CD = FROM_CRCY_CD;
                obj.TO_CRCY_CD = TO_CRCY_CD;
                obj.SEND_RCPT_CD = SEND_RCPT_CD;
                obj.FROM_TRANS_AMT = FROM_TRANS_AMT;
                obj.FROM_TRANS_AMT_TXT = FROM_TRANS_AMT_TXT;
                obj.TRANS_FEE_AMT = TRANS_FEE_AMT;
                obj.TRANS_FEE_AMT_TXT = TRANS_FEE_AMT_TXT;
                obj.TRANS_FEE_AMT_PROMO_CD = TRANS_FEE_AMT_PROMO_CD;
                obj.TRANS_FEE_AMT_TXT_PROMO_CD = TRANS_FEE_AMT_TXT_PROMO_CD;
                obj.TOT_TO_PAY_AMT = TOT_TO_PAY_AMT;
                obj.TOT_TO_PAY_AMT_TXT = TOT_TO_PAY_AMT_TXT;
                obj.TOT_TO_PAY_AMT_PROMO_CD = TOT_TO_PAY_AMT_PROMO_CD;
                obj.TOT_TO_PAY_AMT_TXT_PROMO_CD = TOT_TO_PAY_AMT_TXT_PROMO_CD;
                obj.TO_TRANS_AMT = TO_TRANS_AMT;
                obj.TO_TRANS_AMT_TXT = TO_TRANS_AMT_TXT;
                obj.CRCY_XCHG_RT = CRCY_XCHG_RT;
                obj.CRCY_XCHG_RT_TXT = CRCY_XCHG_RT_TXT;
                obj.DPLY_CRCY_XCHG_RT_IND = DPLY_CRCY_XCHG_RT_IND; //DISPLAY CRCY XCHG RATE INDICATOR
                obj.ADJUST_XCHG_RT = ADJUST_XCHG_RT;
                obj.CLT_USR_NBR = CLT_USR_NBR;
                obj.TRANS_OTH1_TXT = OTH1_TXT;
                obj.TRANS_OTH2_TXT = OTH2_TXT;
                obj.TRANS_OTH3_TXT = OTH3_TXT;
                obj.TRANS_OTH4_TXT = OTH4_TXT;
                obj.TRANS_OTH5_TXT = OTH5_TXT;
                db.TTRANS_START_XSSN_TEMPO.Add(obj);
                db.SaveChanges();
                return obj;
        }

        public TransactionStartExternalSessionTemporary getOneTransactionSession(long TRANS_SSN_ID)
        {
            try
            {
                var obj = db.TTRANS_START_XSSN_TEMPO.Find(TRANS_SSN_ID);
                if (obj == null)
                {
                    return null;
                }
                return obj;
            }
            catch
            {
                return null;
            }
        }
        
        public bool checkTransactionSessionExpiryByTransSsnID(long transSsnID)
        {
            try
            {
                var obj = db.TTRANS_START_XSSN_TEMPO.Find(transSsnID);
                if (obj == null)
                {
                    return true;
                }

                DateTime currentDate = DateTime.Now;
                int result = DateTime.Compare(obj.TRANS_XDTTM, currentDate);
                if (result < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool checkTransactionSessionExpiry(TransactionStartExternalSessionTemporary model)
        {
            try
            {
                if (model == null)
                {
                    return true;
                }

                DateTime currentDate = DateTime.Now;
                int result = DateTime.Compare(model.TRANS_XDTTM, currentDate);
                if (result < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool updateTransactionSession(long transSsnID, string USR_NBR)
        {
            try
            {
                var obj = db.TTRANS_START_XSSN_TEMPO.Find(transSsnID);
                if (obj == null)
                {
                    return false;
                }

                obj.CLT_USR_NBR = USR_NBR;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateTransactionSessionToAddSenderUsrNbr(string securedID, string SENDER_USR_NBR)
        {
            try
            {
                var obj = getOneTempoTransactionSessionBySecureID(securedID);
                if (obj == null)
                {
                    return false;
                }

                obj.TRANS_OTH1_TXT = SENDER_USR_NBR;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TransactionStartExternalSessionTemporary getOneTempoTransactionSessionBySecureID(string SecureID)
        {
            try
            {
                var objList = db.TTRANS_START_XSSN_TEMPO.Where(x => x.TRANS_SSN_SECR_ID == SecureID).ToList();
                if (objList.Count() == 0)
                {
                    return null;
                }

                var obj = objList[0];
                if (obj == null)
                {
                    return null;
                }
                return obj;
            }
            catch
            {
                return null;
            }
        }
        
        public TransactionStartExternalSessionTemporary updateTempoTransactionSessionBySecureID(string secureID, string CLT_USR_NBR)
        {
            try
            {
                var obj = getOneTempoTransactionSessionBySecureID(secureID);
                if (obj == null)
                {
                    return null;
                }

                obj.CLT_USR_NBR = CLT_USR_NBR;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}