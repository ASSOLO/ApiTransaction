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
    [Table("dbo.TRCPT_EXRL_ACCT_FOR_BUS")]
    public class RecipientExternalAccountForBusiness
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Bénéficiaire-Compte Bancaire")]
        public int RCPT_EXRL_ACCT_FOR_BUS_ID { get; set; }

        [Display(Name = "ID Compte Bancaire")]
        public int? EXRL_ACCT_ID { get; set; }

        [Display(Name = "ID Personne Entreprise")]
        public int? RCPT_USR_BUS_ID { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [StringLength(1)]
        [Display(Name = "Type Bénéficiaire-Compte Bancaire")]
        public string RCPT_EXRL_ACCT_FOR_BUS_TCD { get; set; } //1- Own External Bank Account     2- External Recipient Bank Account 
                                                               //3- PayKap Recipient Account

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public virtual RecipientUserBusiness TRCPT_USR_BUS { get; set; }
        public virtual FinancialInstitutionExternalAccount TFI_EXRL_ACCT { get; set; }
        public virtual Business TBUS { get; set; }

        public int getBNbyManagerUsrNbr(string usrNbr)
        {
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr).ToList();
            if (acctList.Count() == 0)
            {
                return 0;
            }
            else
            {
                var acct = acctList[0];
                if (acct == null)
                {
                    return 0;
                }

                int acctID = acct.ACCT_ID;
                var busList = db.TBUS.Where(x => x.ACCT_ID == acctID).ToList();
                if (busList.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    var bus = busList[0];
                    if (bus == null)
                    {
                        return 0;
                    }
                    return bus.BN;
                }
            }
        }

        public List<FinancialInstitutionExternalAccount> getCurrentBusinessOnlineBankAccount(string usrNbr)
        {
            try
            {
                var list = new List<FinancialInstitutionExternalAccount>();
                int bn = getBNbyManagerUsrNbr(usrNbr);
                if(bn == 0)
                {
                    return list;
                }

                var query = from bankAcct in db.TFI_EXRL_ACCT
                            join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                            where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "1" &&
                                   bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.USR_NBR == usrNbr && bankAcct.LGC_DEL_IND == "0")
                            select bankAcct;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<FinancialInstitutionExternalAccount> getUserOrBusinessBankAccount(string usrNbr, string usrTCD)
        {
            try
            {
                var list = new List<FinancialInstitutionExternalAccount>();
                int bn = getBNbyManagerUsrNbr(usrNbr);
                if (bn == 0)
                {
                    return list;
                }
                
                var query = from bankAcct in db.TFI_EXRL_ACCT
                            join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                            where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "2" &&
                                   bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.EXRL_ACCT_USR_BUS_TCD == usrTCD && 
                                   bankAcct.USR_NBR == usrNbr && bankAcct.LGC_DEL_IND == "0")
                            select bankAcct;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        //public FinancialInstitutionExternalAccount getBankRecipientByRcptID(string usrNbr, int rcptID)
        //{
        //    try
        //    {
        //        int bn = getBNbyManagerUsrNbr(usrNbr);
        //        if (bn == 0)
        //        {
        //            return null;
        //        }

        //        var rcpt = db.TFI_EXRL_ACCT.Find(rcptID);
        //        if (rcpt == null)
        //        {
        //            return null;
        //        }

        //        var checkBusList = db.TRCPT_EXRL_ACCT_FOR_BUS.Where(x => x.BN == bn && x.EXRL_ACCT_ID == rcpt.EXRL_ACCT_ID).ToList();
        //        if (checkBusList.Count() == 0)
        //        {
        //            return null;
        //        }
        //        return rcpt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public bool createFinancialInstitutionExternalAccount(string AcctNm, string AcctTCD, string AcctNbr,
                                                    string part1, string part2, string part3, string part4, string part5,
                                                    int partNbr, string acctVldIND, int fiCtryID,
                                                    string ExrlAcctUsrNbr, int? ExrlAcctBusNbr, string UsrBusTCD,
                                                    string crcyCD, string usrNbr, string currentUserIND,
                                                    string RCPT_EXRL_ACCT_FOR_BUS_TCD)
        {
            int newInsertID = 0;
            try
            {
                int bn = getBNbyManagerUsrNbr(usrNbr);
                if (bn == 0)
                {
                    return false;
                }

                var newObj = new FinancialInstitutionExternalAccount();
                //just to handle error
                newObj.RCPT_EXRL_ACCT_USR_NBR = "0000000000";

                newObj.EXRL_ACCT_NM = AcctNm;
                newObj.EXRL_ACCT_TCD = AcctTCD;
                newObj.EXRL_ACCT_NBR = AcctNbr;
                newObj.EXRL_ACCT_PRT1_NBR = part1;
                newObj.EXRL_ACCT_PRT2_NBR = part2;
                newObj.EXRL_ACCT_PRT3_NBR = part3;
                newObj.EXRL_ACCT_PRT4_NBR = part4;
                newObj.EXRL_ACCT_PRT5_NBR = part5;
                newObj.EXRL_ACCT_PRT_NBR = partNbr;
                newObj.EXRL_ACCT_VLDT_IND = acctVldIND;
                newObj.FI_CTRY_ID = fiCtryID;
                newObj.CRCY_CD = crcyCD;
                newObj.EXRL_ACCT_USR_NBR = ExrlAcctUsrNbr;
                newObj.EXRL_ACCT_BUS_NBR = ExrlAcctBusNbr;
                newObj.EXRL_ACCT_USR_BUS_TCD = UsrBusTCD;
                newObj.USR_NBR = usrNbr;
                newObj.EXRL_ACCT_FOR_CURT_USR_IND = currentUserIND;
                db.TFI_EXRL_ACCT.Add(newObj);
                db.SaveChanges();

                newInsertID = newObj.EXRL_ACCT_ID;

                var newObj1 = new RecipientExternalAccountForBusiness();
                newObj1.EXRL_ACCT_ID = newInsertID;
                newObj1.RCPT_USR_BUS_ID = null;
                newObj1.BN = bn;
                newObj1.RCPT_EXRL_ACCT_FOR_BUS_TCD = RCPT_EXRL_ACCT_FOR_BUS_TCD; 
                db.TRCPT_EXRL_ACCT_FOR_BUS.Add(newObj1);
                db.SaveChanges();
                return true;
            }
            catch
            {
                if (newInsertID != 0)
                {
                    var newObj = db.TRCPT_EXRL_ACCT_FOR_BUS.Find(newInsertID);
                    if (newObj != null)
                    {
                        db.TRCPT_EXRL_ACCT_FOR_BUS.Remove(newObj);
                        db.SaveChanges();
                    }
                }
                return false;
            }
        }

        public bool updateFinancialInstitutionExternalAccount(int EXRL_ACCT_ID, string AcctNm, string AcctTCD, string AcctNbr,
                                                    string part1, string part2, string part3, string part4, string part5,
                                                    int partNbr, int fiCtryID, string crcyCD)
        {
            try
            {
                var obj = db.TFI_EXRL_ACCT.Find(EXRL_ACCT_ID);
                if (obj == null)
                {
                    return false;
                }
                //just to handle error
                obj.RCPT_EXRL_ACCT_USR_NBR = "0000000000";

                obj.EXRL_ACCT_NM = AcctNm;
                obj.EXRL_ACCT_TCD = AcctTCD;
                obj.EXRL_ACCT_NBR = AcctNbr;
                obj.EXRL_ACCT_PRT1_NBR = part1;
                obj.EXRL_ACCT_PRT2_NBR = part2;
                obj.EXRL_ACCT_PRT3_NBR = part3;
                obj.EXRL_ACCT_PRT4_NBR = part4;
                obj.EXRL_ACCT_PRT5_NBR = part5;
                obj.EXRL_ACCT_PRT_NBR = partNbr;
                //obj.EXRL_ACCT_VLDT_IND = acctVldIND;
                obj.FI_CTRY_ID = fiCtryID;
                obj.CRCY_CD = crcyCD;
                //obj.EXRL_ACCT_USR_NBR = ExrlAcctUsrNbr;
                //obj.EXRL_ACCT_BUS_NBR = ExrlAcctBusNbr;
                //obj.EXRL_ACCT_USR_BUS_TCD = UsrBusTCD;
                //obj.USR_NBR = usrNbr;
                //obj.EXRL_ACCT_FOR_CURT_USR_IND = currentUserIND;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validateFinancialInstitutionExternalAccount(int EXRL_ACCT_ID, string acctVldIND)
        {
            try
            {
                var obj = db.TFI_EXRL_ACCT.Find(EXRL_ACCT_ID);
                if (obj == null)
                {
                    return false;
                }

                obj.EXRL_ACCT_VLDT_IND = acctVldIND;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool checkIfFinancialInstitutionExternalAccountAlreadyExist(string currentUsrNbr, string acctNbr, 
                                                                           string RCPT_EXRL_ACCT_FOR_BUS_TCD,
                                                                           string ExrlAcctUsrNbr, int? ExrlAcctBusNbr, string UsrBusTCD)
        {
            try
            {
                int bn = getBNbyManagerUsrNbr(currentUsrNbr);
                if (bn == 0)
                {
                    return true;
                }

                if (UsrBusTCD == "1")
                {
                    var query = from bankAcct in db.TFI_EXRL_ACCT
                                join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                                where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == RCPT_EXRL_ACCT_FOR_BUS_TCD &&
                                       bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.EXRL_ACCT_NBR == acctNbr &&
                                       bankAcct.EXRL_ACCT_USR_NBR == ExrlAcctUsrNbr && bankAcct.USR_NBR == currentUsrNbr && bankAcct.LGC_DEL_IND == "0")
                                select bankAcct;
                    if (query.Count() == 0)
                    {
                        return false;
                    }
                    return true;
                }

                if (UsrBusTCD == "2")
                {
                    var query = from bankAcct in db.TFI_EXRL_ACCT
                                join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                                where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == RCPT_EXRL_ACCT_FOR_BUS_TCD &&
                                       bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.EXRL_ACCT_NBR == acctNbr &&
                                       bankAcct.EXRL_ACCT_BUS_NBR == ExrlAcctBusNbr && bankAcct.USR_NBR == currentUsrNbr && bankAcct.LGC_DEL_IND == "0")
                                select bankAcct;
                    if (query.Count() == 0)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        
        //=================================PAYKAP RECIPIENT============================================//
        public List<RecipientUserBusiness> getUserOrBusinessPayKapAccount(string usrNbr, string usrTCD)
        {
            try
            {
                var list = new List<RecipientUserBusiness>();
                int bn = getBNbyManagerUsrNbr(usrNbr);
                if (bn == 0)
                {
                    return list;
                }

                var query = from rcptAcct in db.TRCPT_USR_BUS
                            join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on rcptAcct.RCPT_USR_BUS_ID equals rcptBus.RCPT_USR_BUS_ID
                            where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "3" &&
                                   rcptAcct.RCPT_USR_BUS_TCD == usrTCD && rcptAcct.USR_NBR == usrNbr && rcptAcct.LGC_DEL_IND == "0")
                            select rcptAcct;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
                
        public bool addPayKapRecipientAccount(int ACCT_ID, string ACCT_NBR, string ExrlAcctNbr1, string ExrlAcctNbr2, string ExrlAcctNbr3,
                                                    string rcptUserBusinessNM, string RCPT_TCD, string RCPT_USR_NBR,
                                                    int? RCPT_BUS_NBR, string RCPT_USR_BUS_TCD, string USR_NBR)
        {
            int newInsertID = 0;
            try
            {
                int bn = getBNbyManagerUsrNbr(USR_NBR);
                if (bn == 0)
                {
                    return false;
                }

                var obj = new RecipientUserBusiness();

                obj.ACCT_ID = ACCT_ID;
                obj.ACCT_NBR = ACCT_NBR;
                obj.RCPT_USR_BUS1_UIN = ExrlAcctNbr1;
                obj.RCPT_USR_BUS2_UIN = ExrlAcctNbr2;
                obj.RCPT_USR_BUS3_UIN = ExrlAcctNbr3;
                obj.RCPT_USR_BUS_NM = rcptUserBusinessNM;
                obj.RCPT_TCD = RCPT_TCD;
                obj.RCPT_USR_NBR = RCPT_USR_NBR;
                obj.RCPT_BUS_NBR = RCPT_BUS_NBR;
                obj.RCPT_USR_BUS_TCD = RCPT_USR_BUS_TCD;
                obj.USR_NBR = USR_NBR;
                db.TRCPT_USR_BUS.Add(obj);
                db.SaveChanges();
                
                newInsertID = obj.RCPT_USR_BUS_ID;

                var newObj = new RecipientExternalAccountForBusiness();
                newObj.EXRL_ACCT_ID = null;
                newObj.RCPT_USR_BUS_ID = newInsertID;
                newObj.BN = bn;
                newObj.RCPT_EXRL_ACCT_FOR_BUS_TCD = "3";
                db.TRCPT_EXRL_ACCT_FOR_BUS.Add(newObj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                if (newInsertID != 0)
                {
                    var newObj = db.TRCPT_EXRL_ACCT_FOR_BUS.Find(newInsertID);
                    if (newObj != null)
                    {
                        db.TRCPT_EXRL_ACCT_FOR_BUS.Remove(newObj);
                        db.SaveChanges();
                    }
                }
                return false;
            }
        }
        
        public bool updatePayKapRecipientAccount(int RCPT_USR_BUS_ID, int ACCT_ID, string ACCT_NBR,
                                                    string ExrlAcctNbr1, string ExrlAcctNbr2, string ExrlAcctNbr3,
                                                    string rcptUserBusinessNM, string RCPT_TCD, string RCPT_USR_NBR,
                                                    int? RCPT_BUS_NBR, string RCPT_USR_BUS_TCD)
        {
            try
            {
                var obj = db.TRCPT_USR_BUS.Find(RCPT_USR_BUS_ID);
                if (obj == null)
                {
                    return false;
                }

                obj.ACCT_ID = ACCT_ID;
                obj.ACCT_NBR = ACCT_NBR;
                obj.RCPT_USR_BUS1_UIN = ExrlAcctNbr1;
                obj.RCPT_USR_BUS2_UIN = ExrlAcctNbr2;
                obj.RCPT_USR_BUS3_UIN = ExrlAcctNbr3;
                obj.RCPT_USR_BUS_NM = rcptUserBusinessNM;
                obj.RCPT_TCD = RCPT_TCD;
                obj.RCPT_USR_NBR = RCPT_USR_NBR;
                obj.RCPT_BUS_NBR = RCPT_BUS_NBR;
                obj.RCPT_USR_BUS_TCD = RCPT_USR_BUS_TCD;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool checkIfPayKapAccountAlreadyExist(string currentUsrNbr, string acctNbr,
                                                     string ExrlAcctUsrNbr, int? ExrlAcctBusNbr, string UsrBusTCD)
        {
            try
            {
                int bn = getBNbyManagerUsrNbr(currentUsrNbr);
                if (bn == 0)
                {
                    return true;
                }

                if (UsrBusTCD == "1")
                {
                    var query = from rcptAcct in db.TRCPT_USR_BUS
                                join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on rcptAcct.RCPT_USR_BUS_ID equals rcptBus.RCPT_USR_BUS_ID
                                where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "3" &&
                                      rcptAcct.ACCT_NBR == acctNbr && rcptAcct.RCPT_USR_NBR == ExrlAcctUsrNbr && 
                                      rcptAcct.USR_NBR == currentUsrNbr && rcptAcct.LGC_DEL_IND == "0")
                                select rcptAcct;
                    if (query.Count() == 0)
                    {
                        return false;
                    }
                    return true;
                }
                if (UsrBusTCD == "2")
                {
                    var query = from rcptAcct in db.TRCPT_USR_BUS
                                join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on rcptAcct.RCPT_USR_BUS_ID equals rcptBus.RCPT_USR_BUS_ID
                                where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "3" &&
                                      rcptAcct.ACCT_NBR == acctNbr && rcptAcct.RCPT_BUS_NBR == ExrlAcctBusNbr && 
                                      rcptAcct.USR_NBR == currentUsrNbr && rcptAcct.LGC_DEL_IND == "0")
                                select rcptAcct;
                    if (query.Count() == 0)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        
    }
}