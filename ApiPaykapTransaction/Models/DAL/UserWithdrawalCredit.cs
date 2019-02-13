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
    [Table("dbo.TUSR_WHDRL_CRDT")]
    public class UserWithdrawalCredit
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Display(Name = "Nombre Credit")]
        public int USR_WHDRL_CRDT_NBR { get; set; }

        public virtual User TUSR { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public UserWithdrawalCredit getUserWithdrawalCredit(string TO_SRVC_IND, int TO_PKP_ACCT, int TO_BNK_ACCT)
        {
            try
            {
                string usrNbr;
                if(TO_SRVC_IND == "1")
                {
                    var newAcct = new Account();
                    var thisAcct = newAcct.getAccountByAcctID(TO_PKP_ACCT);
                    if (thisAcct == null)
                    {
                        return null;
                    }
                    usrNbr = thisAcct.USR_NBR;
                }
                else
                {
                    var fiExrlAcct = new FinancialInstitutionExternalAccount();
                    var thisRcptBnk = fiExrlAcct.getBankRecipientByRcptID(TO_BNK_ACCT);
                    if (thisRcptBnk == null)
                    {
                        return null;
                    }

                    if (thisRcptBnk.EXRL_ACCT_USR_BUS_TCD == "1")
                    {
                        usrNbr = thisRcptBnk.EXRL_ACCT_USR_NBR;
                    }
                    else
                    {
                        var busAcct = db.TACCT.Find(thisRcptBnk.EXRL_ACCT_ID);
                        if (busAcct == null)
                        {
                            return null;
                        }
                        usrNbr = busAcct.USR_NBR;
                    }
                }

                var obj = db.TUSR_WHDRL_CRDT.Find(usrNbr);
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

        public string geRecipientUsrNbr(string TO_SRVC_IND, int TO_PKP_ACCT, int TO_BNK_ACCT)
        {
            try
            {
                if (TO_SRVC_IND == "1")
                {
                    var newAcct = new Account();
                    var thisAcct = newAcct.getAccountByAcctID(TO_PKP_ACCT);
                    if (thisAcct == null)
                    {
                        return null;
                    }
                   return thisAcct.USR_NBR;
                }
                else
                {
                    var fiExrlAcct = new FinancialInstitutionExternalAccount();
                    var thisRcptBnk = fiExrlAcct.getBankRecipientByRcptID(TO_BNK_ACCT);
                    if (thisRcptBnk == null)
                    {
                        return null;
                    }

                    if (thisRcptBnk.EXRL_ACCT_USR_BUS_TCD == "1")
                    {
                        return thisRcptBnk.EXRL_ACCT_USR_NBR;
                    }
                    else
                    {
                        var busAcct = db.TACCT.Find(thisRcptBnk.EXRL_ACCT_ID);
                        if (busAcct == null)
                        {
                            return null;
                        }
                        return busAcct.USR_NBR;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public UserWithdrawalCredit getWithdrawalCreditByUsrNbr(string USR_NBR)
        {
            try
            {
                var obj = db.TUSR_WHDRL_CRDT.Find(USR_NBR);
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
    }
}
