using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRANS_SSN")]
    public class TransactionSession
    {
        public TransactionSession()
        {
            TRANS_SSN_EDTTM = DateTime.Now;
            TRANS_SSN_XDTTM = DateTime.Now.AddHours(1);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Session")]
        public long TRANS_SSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(32, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 32)]
        [Display(Name = "ID Securité")]
        public string TRANS_SSN_SECR_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(62, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 32)]
        [Display(Name = "ID Securité (transSsnID + secureID)")]
        public string TRANS_SSN_SECR_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_SSN_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(15, ErrorMessage = "Le {0} doit compter {2} caractères maximum", MinimumLength = 1)]
        [Display(Name = "Montant Texte Transaction")]
        public string TRANS_SSN_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string TRANS_SSN_CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter au maximum 1 caractère.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Montant Personnalisé ?")]
        public string TRANS_SSN_CUST_AMT_IND { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter {2} caractères maximum", MinimumLength = 1)]
        [Display(Name = "URL succès")]
        public string TRANS_SSN_SURL_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(2555, ErrorMessage = "Le {0} doit compter {2} caractères maximum", MinimumLength = 1)]
        [Display(Name = "URL Échec")]
        public string TRANS_SSN_FURL_TXT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime TRANS_SSN_EDTTM { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime TRANS_SSN_XDTTM { get; set; }

        [Display(Name = "Numéro Facture Créditeur")]
        public int BPCS_NBR { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ID Client")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Compte Client")]
        public string CLT_ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(2555, ErrorMessage = "Le {0} doit compter {2} caractères maximum", MinimumLength = 1)]
        [Display(Name = "Email client")]
        public string CLT_EMAIL_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Langue client")]
        public string CLT_LANG_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Pays client")]
        public string CLT_CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Facture client")]
        public string CLT_BIL_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(20, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Transaction (Final)")] // this field has default value at the creation, update when the transaction si completed
        public string TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 1")]
        public string TRANS_SSN_OTH1_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 2")]
        public string TRANS_SSN_OTH2_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 3")]
        public string TRANS_SSN_OTH3_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 4")]
        public string TRANS_SSN_OTH4_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre 5")]
        public string TRANS_SSN_OTH5_TXT { get; set; }

        public virtual BillPaymentCreditor TBPCS { get; set; }

        public virtual User TUSR { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public TransactionSession createTransactionSession(decimal TRANS_SSN_AMT, string TRANS_SSN_AMT_TXT,
                                                    string TRANS_SSN_CRCY_CD, string TRANS_SSN_CUST_AMT_IND,
                                                    string TRANS_SSN_SURL_TXT, string TRANS_SSN_FURL_TXT,
                                                    int BPCS_NBR, string CLT_USR_NBR, string CLT_ACCT_NBR,
                                                    string CLT_EMAIL_TXT, string CLT_LANG_CD, string CLT_CTRY_CD, string CLT_BIL_NBR,
                                                    string TRANS_ID,
                                                    string OTH1_TXT, string OTH2_TXT, string OTH3_TXT, string OTH4_TXT, string OTH5_TXT)
        {
            try
            {
                var obj = new TransactionSession();

                obj.TRANS_SSN_SECR_ID = Guid.NewGuid().ToString("N");
                obj.TRANS_SSN_SECR_ID_TXT = obj.TRANS_SSN_SECR_ID;
                obj.TRANS_SSN_AMT = TRANS_SSN_AMT;
                obj.TRANS_SSN_AMT_TXT = TRANS_SSN_AMT_TXT;
                obj.TRANS_SSN_CRCY_CD = TRANS_SSN_CRCY_CD;
                obj.TRANS_SSN_CUST_AMT_IND = TRANS_SSN_CUST_AMT_IND;
                obj.TRANS_SSN_SURL_TXT = TRANS_SSN_SURL_TXT;
                obj.TRANS_SSN_FURL_TXT = TRANS_SSN_FURL_TXT;
                obj.BPCS_NBR = BPCS_NBR;
                obj.CLT_USR_NBR = CLT_USR_NBR;
                obj.CLT_ACCT_NBR = CLT_ACCT_NBR;
                obj.CLT_EMAIL_TXT = CLT_EMAIL_TXT;
                obj.CLT_LANG_CD = CLT_LANG_CD;
                obj.CLT_CTRY_CD = CLT_CTRY_CD;
                obj.CLT_BIL_NBR = CLT_BIL_NBR;
                obj.TRANS_ID = TRANS_ID;
                obj.TRANS_SSN_OTH1_TXT = OTH1_TXT;
                obj.TRANS_SSN_OTH2_TXT = OTH2_TXT;
                obj.TRANS_SSN_OTH3_TXT = OTH3_TXT;
                obj.TRANS_SSN_OTH4_TXT = OTH4_TXT;
                obj.TRANS_SSN_OTH5_TXT = OTH5_TXT;
                db.TTRANS_SSN.Add(obj);
                db.SaveChanges();

                string secureID = TRANS_SSN_SECR_ID + "" + obj.TRANS_ID;
                obj.TRANS_SSN_SECR_ID_TXT = secureID;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();

                return obj;
            }
            catch
            {
                return null;
            }
        }

        public TransactionSession getOneTransactionSession(long TRANS_SSN_ID)
        {
            try
            {
                var obj = db.TTRANS_SSN.Find(TRANS_SSN_ID);
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

        public TransactionSession getOneTransactionSessionBySecureID(string SecureID)
        {
            try
            {
                var objList = db.TTRANS_SSN.Where(x => x.TRANS_SSN_SECR_ID_TXT == SecureID).ToList();
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
        
        public bool updateTransactionSessionBySecureID(string SecureID, string USR_NBR)
        {
            try
            {
                var obj = getOneTransactionSessionBySecureID(SecureID);
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

        public bool updateTransactionIdBySecureID(string SecureID, string transID)
        {
            try
            {
                var obj = getOneTransactionSessionBySecureID(SecureID);
                if (obj == null)
                {
                    return false;
                }

                obj.TRANS_ID = transID;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateTransactionSession(long transSsnID, string USR_NBR)
        {
            try
            {
                var obj = db.TTRANS_SSN.Find(transSsnID);
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

        public TransactionSession getOneTransactionSessionByCltUsrNbr(string currentUsrNbr, int RCPT_BUS_ID)
        {
            try
            {
                var rcptBUS = db.TRCPT_USR_BUS.Find(RCPT_BUS_ID);
                if (rcptBUS == null)
                {
                    return null;
                }

                var bpcsList = db.TBPCS.Where(x => x.BN == rcptBUS.RCPT_BUS_NBR && x.ACCT_ID == rcptBUS.ACCT_ID).ToList();
                if (bpcsList.Count() == 0)
                {
                    return null;
                }
                var bpcs = bpcsList[0];

                var transSsnList = db.TTRANS_SSN.Where(x => x.CLT_USR_NBR == currentUsrNbr && x.BPCS_NBR == bpcs.BPCS_NBR &&
                                                            x.TRANS_ID == "0").OrderByDescending(y => y.TRANS_SSN_EDTTM).ToList();
                if (transSsnList.Count() == 0)
                {
                    return null;
                }

                var transSSN = transSsnList[0];
                return transSSN;
            }
            catch
            {
                return null;
            }
        }


        public bool checkTransactionSessionExpiry(long transSsnID)
        {
            try
            {
                var obj = db.TTRANS_SSN.Find(transSsnID);
                if (obj == null)
                {
                    return true;
                }

                DateTime currentDate = DateTime.Now;
                int result = DateTime.Compare(obj.TRANS_SSN_XDTTM, currentDate);
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
    }
}
