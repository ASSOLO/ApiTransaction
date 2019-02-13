using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TONBHLF_CLT_TRANS")]
    public class OnBehalfClientTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Commission")]
        public decimal CMSN_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "Le valeur doit être soit 0 soit 1")]
        [Display(Name = "Status Transaction")]
        public string TRANS_SCD { get; set; } //0 created, 1=trans closed

        public virtual User TUSR { get; set; }
        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual Currency TCRCY { get; set; }

        private DalContext db = new DalContext();

        public OnBehalfClientTransaction insertOnBehalfClientTransaction(int TRANS_ID, 
                                               string CURRENT_USR_NBR, Account CURRENT_USR_ACCT,
                                               string ADMIN_USR_NBR, string CTRY_CD, string CRCY_CD,  
                                               decimal TRANS_FEE_AMT, string SRVC_TCD, string TRANS_SCD)
        {
            try
            {
                var newCmsn = new OnBehalfClientCommission();
                decimal CMSN_AMT = newCmsn.getOneOnBehalfClientCommissionAmount(CURRENT_USR_NBR, ADMIN_USR_NBR,
                                                          CTRY_CD, SRVC_TCD, TRANS_FEE_AMT, CRCY_CD);
               if(CMSN_AMT == -1.0m)
                {
                    return null;
                }

                decimal convertCMSN_AMT;
                if (CRCY_CD != CURRENT_USR_ACCT.CRCY_CD)
                {
                    var getXchgRT = new CurrencyExchangeRate();
                    decimal xchgRT = getXchgRT.getExchangeRateByCurrency(CRCY_CD, CURRENT_USR_ACCT.CRCY_CD);
                    if (xchgRT == 0.0m)
                    {
                        return null;
                    }
                    convertCMSN_AMT = CMSN_AMT * xchgRT;
                }
                else
                {
                    convertCMSN_AMT = CMSN_AMT;
                }

                var obj = new OnBehalfClientTransaction();
                obj.TRANS_ID = TRANS_ID;
                obj.USR_NBR = CURRENT_USR_NBR;
                obj.CMSN_AMT = convertCMSN_AMT;
                obj.CRCY_CD = CRCY_CD;
                obj.TRANS_SCD = TRANS_SCD;
                db.TONBHLF_CLT_TRANS.Add(obj);

                //update the current user account balance if the status is 1, closed
                if(TRANS_SCD == "1")
                {
                    CURRENT_USR_ACCT.ACCT_BAL = CURRENT_USR_ACCT.ACCT_BAL + convertCMSN_AMT;
                    db.Entry(CURRENT_USR_ACCT).State = EntityState.Modified;
                }

                //save all
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public bool closeOnBehalfClientTransaction(int TRANS_ID, int CURRENT_USR_ACCT_IND)
        {
            try
            {
                var getTrans = getOnBehalfClientTransaction(TRANS_ID);
                var getAcct = db.TACCT.Find(CURRENT_USR_ACCT_IND);
                if(getTrans == null || getAcct == null)
                {
                    return false;
                }

                getTrans.TRANS_SCD = "1";
                db.Entry(getTrans).State = EntityState.Modified;

                decimal newBal = getAcct.ACCT_BAL + getTrans.CMSN_AMT;
                getAcct.ACCT_BAL = newBal;
                db.Entry(getAcct).State = EntityState.Modified;

                var acctHist = new AccountHistory();
                string TRANS_PAY_SRC_CD = "2";
                string TRANS_SRVC_TCD = "01";
                string fromTRANS_DESC = "ThirdParty Transfer/Transfert Tiers Commission";
                var acctHistory = acctHist.insertAccountHistory(getAcct.ACCT_ID, "1", TRANS_PAY_SRC_CD, 
                                            TRANS_SRVC_TCD, newBal, getTrans.CMSN_AMT, fromTRANS_DESC);
                db.TACCT_HIST.Add(acctHistory);
                //save all
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public OnBehalfClientTransaction getOnBehalfClientTransaction(int TRANS_ID)
        {
            var obj = db.TONBHLF_CLT_TRANS.Find(TRANS_ID);

            if (obj == null)
            {
                return null;
            }
            return obj;
        }
    }
}