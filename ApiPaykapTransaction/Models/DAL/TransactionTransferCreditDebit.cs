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
    [Table("dbo.TTRANS_TRSF_CRDT_DBT")]
    public class TransactionTransferCreditDebit
    {
        public TransactionTransferCreditDebit()
        {
            TBNK_TRANS = new HashSet<BankTransaction>();
            TBUS_CMSN_TRANS = new HashSet<BusinessCommissionTransaction>();
            TRANS_XDT = Convert.ToDateTime("9999-12-31");
            TRANS_PAID_DPST_DT = Convert.ToDateTime("2000-01-01");
            TRANS_CDT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Transaction")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le numéro de la transaction est obligatoire")]
        [Display(Name = "ID Transaction")]
        [NotMapped]
        public string TRANS_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le service d'envoi est requis")]
        [Display(Name = "Comment Envoyer ?")]
        public int FROM_TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le service de reception est requis")]
        [Display(Name = "Comment Recevoir ?")]
        public int TO_TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 3)]
        [Display(Name = "Pays Envoi")]
        public string FROM_CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 3)]
        [Display(Name = "Pays Reception")]
        public string TO_CTRY_CD { get; set; }

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

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Départ")]
        public decimal FROM_TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Frais Départ")]
        public decimal FROM_FEE_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Total Départ")]
        public decimal FROM_TOT_AMT { get; set; }
        
        [Display(Name = "Montant Total Départ Texte")]
        [NotMapped]
        public string FROM_TOT_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(FROM_CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FROM_TOT_AMT, FROM_CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Destinataire")]
        public decimal TO_TRANS_AMT { get; set; }

        [Display(Name = "Montant Total Départ Texte")]
        [NotMapped]
        public string TO_TRANS_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(TO_CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(TO_TRANS_AMT, TO_CRCY_CD, cultureInfo);
            }
        }

        [Required]
        [StringLength(2)]
        [Display(Name = "Statut Transaction")] //01- Create but pending to pay the transfer
        public string TRANS_SCD { get; set; }  //02- Sent but need authorisation 
                                               //03- Sent but need exceptional authorisation due to high amount
                                               //04- Blocked      05- Expired       06- Closed

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TRANS_CDT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Paiement Dépôt")]
        public DateTime TRANS_PAID_DPST_DT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime TRANS_XDT { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ID Envoyeur")]
        public string FROM_USR_NBR { get; set; }

        [Display(Name = "ID Bénéficiaire")]   
        public int RCPT_USR_BUS_ID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Type Transaction")]  //01-Transfer    02-Bill Payment Registered Recipient   
                                              //03-Bill Payment No Registered Recipient      
                                              //04- Remote Payment To Registered Recipient 05-    Deposit    06- Withdrawal
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Description Transaction")]
        public string TRANS_DESC { get; set; }

        public virtual ICollection<BankTransaction> TBNK_TRANS { get; set; }
        
        public virtual ICollection<BusinessCommissionTransaction> TBUS_CMSN_TRANS { get; set; }
        public virtual TransactionIdentificationDocument TTRANS_ID_DOC { get; set; }
        
        public virtual Currency TCRCY { get; set; }

        public virtual Currency TCRCY1 { get; set; }

        public virtual Country TCTRY { get; set; }

        public virtual Country TCTRY1 { get; set; }

        public virtual ExceptionalTransaction TEXCEPT_TRANS { get; set; }

        public virtual RecipientUserBusiness TRCPT_USR_BUS { get; set; }

        public virtual User TUSR { get; set; }
        public virtual BillPaymentTransaction TBIL_PYMT_TRANS { get; set; }
        public virtual TransactionTemporary TTRANS_TEMPO { get; set; }
        public virtual AgentTransactionCommissionTemporary TAGNT_TRANS_CMSN_TEMPO { get; set; }
        public virtual OnBehalfClientTransaction TONBHLF_CLT_TRANS { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public TransactionTransferCreditDebit getTransactionByTransID(int transID)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Find(transID);
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

        public TransactionTransferCreditDebit createTransaction(int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID, 
                                      string FROM_CTRY_CD, string TO_CTRY_CD, 
                                      string FROM_CRCY_CD, string TO_CRCY_CD, 
                                      decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                      decimal FROM_TOT_AMT, decimal TO_TRANS_AMT,
                                      string TRANS_SCD, DateTime TRANS_XDT, bool transXdtIND, string FROM_USR_NBR,
                                      int RCPT_USR_BUS_ID, string TRANS_TCD, string TRANS_DESC)
        {
            try
            {
                var obj = new TransactionTransferCreditDebit();

                obj.FROM_TRSF_SERV_ID = FROM_TRSF_SERV_ID;
                obj.TO_TRSF_SERV_ID = TO_TRSF_SERV_ID;
                obj.FROM_CTRY_CD = FROM_CTRY_CD;
                obj.TO_CTRY_CD = TO_CTRY_CD;
                obj.FROM_CRCY_CD = FROM_CRCY_CD;
                obj.TO_CRCY_CD = TO_CRCY_CD;
                obj.CRCY_XCHG_RT = CRCY_XCHG_RT;
                obj.FROM_TRANS_AMT = FROM_TRANS_AMT;
                obj.FROM_FEE_AMT = FROM_FEE_AMT;
                obj.FROM_TOT_AMT = FROM_TOT_AMT;
                obj.TO_TRANS_AMT = TO_TRANS_AMT;
                obj.TRANS_SCD = TRANS_SCD;
                if (!transXdtIND)
                {
                    obj.TRANS_XDT = TRANS_XDT;
                }
                obj.FROM_USR_NBR = FROM_USR_NBR;
                obj.RCPT_USR_BUS_ID = RCPT_USR_BUS_ID;
                obj.TRANS_TRSF_CRDT_DBT_TCD = TRANS_TCD;
                obj.TRANS_DESC = TRANS_DESC;
                //db.TTRANS_TRSF_CRDT_DBT.Add(obj);
                //db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public bool updateTransaction(int transID, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                      string FROM_CTRY_CD, string TO_CTRY_CD,
                                      string FROM_CRCY_CD, string TO_CRCY_CD,
                                      decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                      decimal FROM_TOT_AMT, decimal TO_TRANS_AMT,
                                      string TRANS_SCD, DateTime TRANS_XDT, string FROM_USR_NBR,
                                      int RCPT_USR_BUS_ID, string TRANS_TCD)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Find(transID);
                if (obj == null)
                {
                    return false;
                }

                obj.FROM_TRSF_SERV_ID = FROM_TRSF_SERV_ID;
                obj.TO_TRSF_SERV_ID = TO_TRSF_SERV_ID;
                obj.FROM_CTRY_CD = FROM_CTRY_CD;
                obj.TO_CTRY_CD = TO_CTRY_CD;
                obj.FROM_CRCY_CD = FROM_CRCY_CD;
                obj.TO_CRCY_CD = TO_CRCY_CD;
                obj.CRCY_XCHG_RT = CRCY_XCHG_RT;
                obj.FROM_TRANS_AMT = FROM_TRANS_AMT;
                obj.FROM_FEE_AMT = FROM_FEE_AMT;
                obj.FROM_TOT_AMT = FROM_TOT_AMT;
                obj.TO_TRANS_AMT = TO_TRANS_AMT;
                obj.TRANS_SCD = TRANS_SCD;
                obj.TRANS_XDT = TRANS_XDT;
                obj.FROM_USR_NBR = FROM_USR_NBR;
                obj.RCPT_USR_BUS_ID = RCPT_USR_BUS_ID;
                obj.TRANS_TRSF_CRDT_DBT_TCD = TRANS_TCD;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateTransactionStatus(int transID, string TRANS_SCD)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Find(transID);
                if (obj == null)
                {
                    return false;
                }

                obj.TRANS_SCD = TRANS_SCD;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateTransactionExpiryDate(int transID, DateTime TRANS_XDT)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Find(transID);
                if (obj == null)
                {
                    return false;
                }

                obj.TRANS_XDT = TRANS_XDT;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteTransaction(int transID)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Find(transID);
                if (obj == null)
                {
                    return false;
                }

                db.TTRANS_TRSF_CRDT_DBT.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

     /*   public List<BillPaymentTransactionForBusinessViewModel> getBillPaymentTransactionForBusiness(int BN, string ACCT_CLTR_INFO)
        {
            try
            {
                var list = new List<BillPaymentTransactionForBusinessViewModel>();

                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join rcpt in db.TRCPT_USR_BUS on trans.RCPT_USR_BUS_ID equals rcpt.RCPT_USR_BUS_ID
                            where (rcpt.RCPT_BUS_NBR == BN && trans.TRANS_SCD == "06")
                            orderby trans.TRANS_ID descending
                            select trans;
                //IEnumerable<TransactionTransferCreditDebit> transObjList = query.AsQueryable().OrderByDescending(x => x.TRANS_ID);

                foreach (var trans in query)
                {
                    var transBusRow = new BillPaymentTransactionForBusinessViewModel();
                    //transBusRow.TO_CRCY_CD = trans.TO_CRCY_CD;
                    //transBusRow.CRCY_XCHG_RT = trans.CRCY_XCHG_RT;
                    //transBusRow.FROM_TRANS_AMT = trans.FROM_TRANS_AMT;
                    //transBusRow.FROM_FEE_AMT = trans.FROM_FEE_AMT;
                    //transBusRow.FROM_TOT_AMT = trans.FROM_TOT_AMT;
                    transBusRow.TRANS_ID = trans.TRANS_ID;
                    transBusRow.TO_TRANS_AMT = trans.TO_TRANS_AMT;
                    transBusRow.TO_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(trans.TO_TRANS_AMT, ACCT_CLTR_INFO);
                    transBusRow.TRANS_SCD = trans.TRANS_SCD;
                    transBusRow.TRANS_CDT = trans.TRANS_CDT;
                    //transBusRow.TRANS_PAID_DPST_DT = trans.TRANS_PAID_DPST_DT;
                    //transBusRow.TRANS_XDT = trans.TRANS_XDT;
                    transBusRow.FROM_USR_NBR = trans.FROM_USR_NBR;

                    string USR_FUL_NM = db.TUSR.Find(trans.FROM_USR_NBR).USR_FUL_NM;
                    transBusRow.USR_FUL_NM = USR_FUL_NM;
                    transBusRow.RCPT_USR_BUS_ID = trans.RCPT_USR_BUS_ID;
                    transBusRow.TRANS_TRSF_CRDT_DBT_TCD = trans.TRANS_TRSF_CRDT_DBT_TCD;

                    // recipient
                    var rcptBus = db.TRCPT_USR_BUS.Find(trans.RCPT_USR_BUS_ID);
                    if (rcptBus != null)
                    {
                        transBusRow.ACCT_NBR = rcptBus.ACCT_NBR;
                        transBusRow.RCPT_USR_BUS1_UIN = rcptBus.RCPT_USR_BUS1_UIN;
                        transBusRow.RCPT_USR_BUS2_UIN = rcptBus.RCPT_USR_BUS2_UIN;
                        transBusRow.RCPT_USR_BUS_NM = rcptBus.RCPT_USR_BUS_NM;
                        transBusRow.RCPT_TCD = rcptBus.RCPT_TCD;

                    }

                    // bill number
                    var billPymnt = db.TBIL_PYMT_TRANS.Find(trans.TRANS_ID);
                    if(billPymnt != null)
                    {
                        transBusRow.BIL_NBR = billPymnt.BIL_NBR;
                    }

                    //add the new object in the list
                    list.Add(transBusRow);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<BillPaymentTransactionForBusinessViewModel> getCurrentMonthBillPaymentTransactionForBusiness(int BN, string ACCT_CLTR_INFO)
        {
            try
            {
                var list = new List<BillPaymentTransactionForBusinessViewModel>();
                DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join rcpt in db.TRCPT_USR_BUS on trans.RCPT_USR_BUS_ID equals rcpt.RCPT_USR_BUS_ID
                            where (rcpt.RCPT_BUS_NBR == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= startDT)
                            orderby trans.TRANS_ID descending
                            select trans;
                //IEnumerable<TransactionTransferCreditDebit> transObjList = query.AsQueryable().OrderByDescending(x => x.TRANS_ID);

                foreach (var trans in query)
                {
                    var transBusRow = new BillPaymentTransactionForBusinessViewModel();
                    //transBusRow.TO_CRCY_CD = trans.TO_CRCY_CD;
                    //transBusRow.CRCY_XCHG_RT = trans.CRCY_XCHG_RT;
                    //transBusRow.FROM_TRANS_AMT = trans.FROM_TRANS_AMT;
                    //transBusRow.FROM_FEE_AMT = trans.FROM_FEE_AMT;
                    //transBusRow.FROM_TOT_AMT = trans.FROM_TOT_AMT;
                    transBusRow.TRANS_ID = trans.TRANS_ID;
                    transBusRow.TO_TRANS_AMT = trans.TO_TRANS_AMT;
                    transBusRow.TO_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(trans.TO_TRANS_AMT, ACCT_CLTR_INFO);
                    transBusRow.TRANS_SCD = trans.TRANS_SCD;
                    transBusRow.TRANS_CDT = trans.TRANS_CDT;
                    //transBusRow.TRANS_PAID_DPST_DT = trans.TRANS_PAID_DPST_DT;
                    //transBusRow.TRANS_XDT = trans.TRANS_XDT;
                    transBusRow.FROM_USR_NBR = trans.FROM_USR_NBR;

                    string USR_FUL_NM = db.TUSR.Find(trans.FROM_USR_NBR).USR_FUL_NM;
                    transBusRow.USR_FUL_NM = USR_FUL_NM;
                    transBusRow.RCPT_USR_BUS_ID = trans.RCPT_USR_BUS_ID;
                    transBusRow.TRANS_TRSF_CRDT_DBT_TCD = trans.TRANS_TRSF_CRDT_DBT_TCD;

                    // recipient
                    var rcptBus = db.TRCPT_USR_BUS.Find(trans.RCPT_USR_BUS_ID);
                    if (rcptBus != null)
                    {
                        transBusRow.ACCT_NBR = rcptBus.ACCT_NBR;
                        transBusRow.RCPT_USR_BUS1_UIN = rcptBus.RCPT_USR_BUS1_UIN;
                        transBusRow.RCPT_USR_BUS2_UIN = rcptBus.RCPT_USR_BUS2_UIN;
                        transBusRow.RCPT_USR_BUS_NM = rcptBus.RCPT_USR_BUS_NM;
                        transBusRow.RCPT_TCD = rcptBus.RCPT_TCD;

                    }

                    // bill number
                    var billPymnt = db.TBIL_PYMT_TRANS.Find(trans.TRANS_ID);
                    if (billPymnt != null)
                    {
                        transBusRow.BIL_NBR = billPymnt.BIL_NBR;
                    }

                    //add the new object in the list
                    list.Add(transBusRow);
                }

                return list;
            }
            catch
            {
                return null;
            }
        } 

        public List<BillPaymentTransactionForBusinessViewModel> getSelectedMonthBillPaymentTransactionForBusiness(int BN, string ACCT_CLTR_INFO, string month, string year)
        {
            try
            {
                var list = new List<BillPaymentTransactionForBusinessViewModel>();
                int intMonth = Convert.ToInt32(month);
                int intYear = Convert.ToInt32(year);
                DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
                DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join rcpt in db.TRCPT_USR_BUS on trans.RCPT_USR_BUS_ID equals rcpt.RCPT_USR_BUS_ID
                            where (rcpt.RCPT_BUS_NBR == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= firstDate && trans.TRANS_CDT <= lastDate)
                            orderby trans.TRANS_ID descending
                            select trans;
                //IEnumerable<TransactionTransferCreditDebit> transObjList = query.AsQueryable().OrderByDescending(x => x.TRANS_ID);

                foreach (var trans in query)
                {
                    var transBusRow = new BillPaymentTransactionForBusinessViewModel();
                    //transBusRow.TO_CRCY_CD = trans.TO_CRCY_CD;
                    //transBusRow.CRCY_XCHG_RT = trans.CRCY_XCHG_RT;
                    //transBusRow.FROM_TRANS_AMT = trans.FROM_TRANS_AMT;
                    //transBusRow.FROM_FEE_AMT = trans.FROM_FEE_AMT;
                    //transBusRow.FROM_TOT_AMT = trans.FROM_TOT_AMT;
                    transBusRow.TRANS_ID = trans.TRANS_ID;
                    transBusRow.TO_TRANS_AMT = trans.TO_TRANS_AMT;
                    transBusRow.TO_TRANS_AMT_TXT = CommonLibrary.displayFormattedCurrency(trans.TO_TRANS_AMT, ACCT_CLTR_INFO);
                    transBusRow.TRANS_SCD = trans.TRANS_SCD;
                    transBusRow.TRANS_CDT = trans.TRANS_CDT;
                    //transBusRow.TRANS_PAID_DPST_DT = trans.TRANS_PAID_DPST_DT;
                    //transBusRow.TRANS_XDT = trans.TRANS_XDT;
                    transBusRow.FROM_USR_NBR = trans.FROM_USR_NBR;

                    string USR_FUL_NM = db.TUSR.Find(trans.FROM_USR_NBR).USR_FUL_NM;
                    transBusRow.USR_FUL_NM = USR_FUL_NM;
                    transBusRow.RCPT_USR_BUS_ID = trans.RCPT_USR_BUS_ID;
                    transBusRow.TRANS_TRSF_CRDT_DBT_TCD = trans.TRANS_TRSF_CRDT_DBT_TCD;

                    // recipient
                    var rcptBus = db.TRCPT_USR_BUS.Find(trans.RCPT_USR_BUS_ID);
                    if (rcptBus != null)
                    {
                        transBusRow.ACCT_NBR = rcptBus.ACCT_NBR;
                        transBusRow.RCPT_USR_BUS1_UIN = rcptBus.RCPT_USR_BUS1_UIN;
                        transBusRow.RCPT_USR_BUS2_UIN = rcptBus.RCPT_USR_BUS2_UIN;
                        transBusRow.RCPT_USR_BUS_NM = rcptBus.RCPT_USR_BUS_NM;
                        transBusRow.RCPT_TCD = rcptBus.RCPT_TCD;

                    }

                    // bill number
                    var billPymnt = db.TBIL_PYMT_TRANS.Find(trans.TRANS_ID);
                    if (billPymnt != null)
                    {
                        transBusRow.BIL_NBR = billPymnt.BIL_NBR;
                    }

                    //add the new object in the list
                    list.Add(transBusRow);
                }

                return list;
            }
            catch
            {
                return null;
            }
        } */


        public List<TransactionTransferCreditDebit> getFromBusinessTransaction(string usrNbr, string ACCT_CLTR_INFO)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebit>();

                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join usr in db.TUSR on trans.FROM_USR_NBR equals usr.USR_NBR
                            where (usr.USR_NBR == usrNbr && usr.USR_TCD == "4")
                            orderby trans.TRANS_ID descending
                            select trans;

                foreach (var trans in query)
                {
                    list.Add(trans);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public bool checkIfFirstTransaction(string usrNbr)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == usrNbr).ToList();
                if (obj.Count() == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<TransactionTransferCreditDebit> getIndividualTransactionByUsrNbr(string usrNbr)
        {
            var list = new List<TransactionTransferCreditDebit>();
            try
            {
                list = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == usrNbr).OrderByDescending(y => y.TRANS_ID).ToList();
                return list;
            }
            catch
            {
                return list;
            }
        }

        public List<TransactionTransferCreditDebit> getAllTransaction()
        {
            var list = new List<TransactionTransferCreditDebit>();
            try
            {
                list = db.TTRANS_TRSF_CRDT_DBT.OrderByDescending(y => y.TRANS_ID).ToList();
                return list;
            }
            catch
            {
                return list;
            }
        }


     /*   public List<TransactionTransferCreditDebitViewModel> getAllTransactionByBusUsrNbr(int BUS_USR_NBR)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebitViewModel>();
                var busUsr = db.TBUS_USR.Find(BUS_USR_NBR);
                if (busUsr == null)
                {
                    return list;
                }

                var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                if (usr == null)
                {
                    return list;
                }
                string usrFulNM = usr.USR_FUL_NM;

                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            where (busTrans.BUS_USR_NBR == BUS_USR_NBR && trans.TRANS_SCD == "06")
                            orderby trans.TRANS_ID descending
                            select trans;
                foreach (var trans in query)
                {
                    var listTrans = new TransactionTransferCreditDebitViewModel();
                    listTrans.trans = trans;
                    listTrans.BUS_USR_FUL_NM = usrFulNM;
                    list.Add(listTrans);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionTransferCreditDebitViewModel> getAllLast24HoursTransactionByBusUsrNbr(int BUS_USR_NBR)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebitViewModel>();
                DateTime startDT = CommonLibrary.Last24Hours(DateTime.Now);
                var busUsr = db.TBUS_USR.Find(BUS_USR_NBR);
                if (busUsr == null)
                {
                    return list;
                }

                var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                if (usr == null)
                {
                    return list;
                }
                string usrFulNM = usr.USR_FUL_NM;

                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            where (busTrans.BUS_USR_NBR == BUS_USR_NBR &&
                                   trans.TRANS_SCD == "06" && trans.TRANS_CDT >= startDT)
                            orderby trans.TRANS_ID descending
                            select trans;

                foreach (var trans in query)
                {
                    var listTrans = new TransactionTransferCreditDebitViewModel();
                    listTrans.trans = trans;
                    listTrans.BUS_USR_FUL_NM = usrFulNM;
                    list.Add(listTrans);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionTransferCreditDebitViewModel> getAllAgencyAndCashierTransaction(int BN, string BUS_AGCY_NBR)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebitViewModel>();
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && busUsr.BUS_AGCY_NBR == BUS_AGCY_NBR && trans.TRANS_SCD == "06")
                            orderby trans.TRANS_ID descending
                            select new { trans, busUsr.BUS_USR_NBR };

                foreach (var item in query)
                {
                    var listTrans = new TransactionTransferCreditDebitViewModel();
                    listTrans.trans = item.trans;                    
                    var busUsr = db.TBUS_USR.Find(item.BUS_USR_NBR);
                    if (busUsr != null)
                    {
                        var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                        if (usr != null)
                        {
                            listTrans.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                        }
                    }
                    list.Add(listTrans);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionTransferCreditDebitViewModel> getAllAgencyAndCashierTransactionByDirector(string usrNbr)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebitViewModel>();
                var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03").ToList();

                if (busUsrList.Count() == 0)
                {
                    return list;
                }
                
                foreach(var dir in busUsrList)
                {
                    var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                                join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                                join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                                where (busUsr.BN == dir.BN && busUsr.BUS_AGCY_NBR == dir.BUS_AGCY_NBR && trans.TRANS_SCD == "06")
                                orderby trans.TRANS_ID descending
                                select new { trans, busUsr.BUS_USR_NBR };

                    foreach (var item in query)
                    {
                        var listTrans = new TransactionTransferCreditDebitViewModel();
                        listTrans.trans = item.trans;
                        var busUsr = db.TBUS_USR.Find(item.BUS_USR_NBR);
                        if (busUsr != null)
                        {
                            var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                            if (usr != null)
                            {
                                listTrans.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                            }
                        }
                        list.Add(listTrans);
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionTransferCreditDebitViewModel> getAllBusinessTransactionByBN(int BN)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebitViewModel>();
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06")
                            orderby trans.TRANS_ID descending
                            select new { trans, busUsr.BUS_USR_NBR };

                foreach (var item in query)
                {
                    var listTrans = new TransactionTransferCreditDebitViewModel();
                    listTrans.trans = item.trans;
                    var busUsr = db.TBUS_USR.Find(item.BUS_USR_NBR);
                    if (busUsr != null)
                    {
                        var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                        if (usr != null)
                        {
                            listTrans.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                        }
                    }
                    list.Add(listTrans);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public int getBNByUserId(string usrNbr)
        {
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr && x.ACCT_TCD == "2").ToList();
            if (acctList.Count() == 0)
            {
                return 0;
            }

            var acct = acctList[0];
            if (acct == null)
            {
                return 0;
            }

            var busList = db.TBUS.Where(x => x.ACCT_ID == acct.ACCT_ID).ToList();
            if (busList.Count() == 0)
            {
                return 0;
            }

            var bus = busList[0];
            if (bus == null)
            {
                return 0;
            }
            return bus.BN;
        }

        public bool checkIfFirstTransferTransaction(string usrNbr, string SRVC_TCD)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == usrNbr && x.TRANS_TRSF_CRDT_DBT_TCD == SRVC_TCD).ToList();
                if (obj.Count() == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool checkIfFirstTransaction(string usrNbr)
        {
            try
            {
                var obj = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == usrNbr).ToList();
                if (obj.Count() == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public TransactionTransferCreditDebitCountViewModel getAllAgencyAndCashierTransactionByDirectorCount(string usrNbr)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebit>();
                var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03").ToList();

                if (busUsrList.Count() == 0)
                {
                    return null;
                }

                foreach (var dir in busUsrList)
                {
                    var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                                join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                                join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                                where (busUsr.BN == dir.BN && busUsr.BUS_AGCY_NBR == dir.BUS_AGCY_NBR && trans.TRANS_SCD == "06")
                                select trans;

                    foreach (var item in query)
                    {
                        list.Add(item);
                    }
                }
                return getTransactionVolume(list);
            }
            catch
            {
                return null;
            }
        }

        public TransactionTransferCreditDebitCountViewModel getAllBusinessTransactionByBNCount(int BN)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebit>();
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06")
                            select trans;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return getTransactionVolume(list);
            }
            catch
            {
                return null;
            }
        }

        public TransactionTransferCreditDebitCountViewModel getAllTransactionByBusUsrNbrCount(int BUS_USR_NBR)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebit>();
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            where (busTrans.BUS_USR_NBR == BUS_USR_NBR && trans.TRANS_SCD == "06")
                            select trans;

                foreach (var trans in query)
                {
                    list.Add(trans);
                }
                return getTransactionVolume(list);
            }
            catch
            {
                return null;
            }
        }

        public TransactionTransferCreditDebitCountViewModel getAllAgencyAndCashierTransactionCount(int BN, string BUS_AGCY_NBR)
        {
            try
            {
                var list = new List<TransactionTransferCreditDebit>();
                var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                            join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && busUsr.BUS_AGCY_NBR == BUS_AGCY_NBR && trans.TRANS_SCD == "06")
                            select trans;

                foreach (var trans in query)
                {
                    list.Add(trans);
                }
                return getTransactionVolume(list);
            }
            catch
            {
                return null;
            }
        }


        public TransactionTransferCreditDebitCountViewModel getTransactionVolume(List<TransactionTransferCreditDebit> list)
        {
            var newObj = new TransactionTransferCreditDebitCountViewModel();

            List<decimal> depositAmtList = new List<decimal>();
            List<decimal> withdrawAmtList = new List<decimal>();
            List<string> depositCrcyList = new List<string>();
            List<string> withdrawCrcyList = new List<string>();
            foreach (var x in list)
            {
                if (x.TRANS_TRSF_CRDT_DBT_TCD == "01" || x.TRANS_TRSF_CRDT_DBT_TCD == "05") // 01 TRANSFER - 05 DEPOSIT
                {
                    depositAmtList.Add(x.FROM_TOT_AMT);
                    depositCrcyList.Add(x.FROM_CRCY_CD);
                }
                if (x.TRANS_TRSF_CRDT_DBT_TCD == "06") // 06 Withdraw
                {
                    withdrawAmtList.Add(x.TO_TRANS_AMT);
                    withdrawCrcyList.Add(x.TO_CRCY_CD);
                }
            }
            decimal depositTotAmt = depositAmtList.Sum();
            decimal withdrawTotAmt = withdrawAmtList.Sum();
            var ctryCrcy = new CountryCurrency();

            if (depositCrcyList.Count() != 0)
            {
                newObj.DEPOSIT_CRCY_CD = depositCrcyList[0].ToUpper();
                string depositCulInfo = ctryCrcy.getCultureInfoByCurrencyCD(newObj.DEPOSIT_CRCY_CD, "FRA");
                newObj.DEPOSIT_TOT_AMT_TXT = CommonLibrary.displayFormattedCurrency(depositTotAmt, depositCulInfo);
            }
            else
            {
                newObj.DEPOSIT_CRCY_CD = "";
                newObj.DEPOSIT_TOT_AMT_TXT = depositTotAmt.ToString("N2");
            }

            if (withdrawCrcyList.Count() != 0)
            {
                newObj.WITHDRAW_CRCY_CD = withdrawCrcyList[0].ToUpper();
                string withdrawCulInfo = ctryCrcy.getCultureInfoByCurrencyCD(newObj.WITHDRAW_CRCY_CD, "FRA");
                newObj.WITHDRAW_TOT_AMT_TXT = CommonLibrary.displayFormattedCurrency(withdrawTotAmt, withdrawCulInfo);
            }
            else
            {
                newObj.WITHDRAW_CRCY_CD = "";
                newObj.WITHDRAW_TOT_AMT_TXT = withdrawTotAmt.ToString("N2");
            }
            
            newObj.DEPOSIT_TRANS_NBR = depositAmtList.Count();
            newObj.WITHDRAW_TRANS_NBR = withdrawAmtList.Count();
            return newObj;
        } */
    }
}
