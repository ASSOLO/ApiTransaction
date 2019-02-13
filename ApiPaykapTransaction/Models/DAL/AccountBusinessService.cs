using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TACCT_BUS_SRVC")]
    public class AccountBusinessService
    {
        
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACCT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ACCT_BUS_SRVC_CD { get; set; }//TR = Transfer, Mobile Money Service, CD = Business Offering Card Service

        [Required]
        [StringLength(1)]
        public string ACCT_TCD { get; set; }

        [Required]
        [StringLength(3)]
        public string CRCY_CD { get; set; }

        [Required]
        [StringLength(25)]
        public string ACCT_NBR { get; set; }

        public decimal ACCT_BAL { get; set; }

        [Required]
        [StringLength(5)]
        public string ACCT_CLTR_INFO { get; set; }

        [Required]
        [StringLength(2)]
        public string ACCT_SCD { get; set; }

        [Required]
        [StringLength(1)]
        public string ACCT_OTH1_IND { get; set; }

        [Required]
        [StringLength(1)]
        public string ACCT_OTH2_IND { get; set; }

        public virtual Account TACCT { get; set; }

        private DalContext db = new DalContext();

        public AccountBusinessService getAccountBusinessServiceByAcctId(int acctID, string busSrvcCD)
        {
            var acctList = db.TACCT_BUS_SRVC.Where(x => x.ACCT_ID == acctID && x.ACCT_BUS_SRVC_CD == busSrvcCD && x.ACCT_SCD == "01").ToList();
            if (acctList.Count() != 1)
            {
                return null;
            }

            var acct = acctList[0];
            if (acct == null)
            {
                return null;
            }
            return acct;
        }

        public List<AccountBusinessService> getAllAccountBusinessServiceByAcctId(int acctID)
        {
            return db.TACCT_BUS_SRVC.Where(x => x.ACCT_ID == acctID && x.ACCT_SCD == "01").ToList();
        }

        public decimal creditTransaction(int acctID, string busSrvcCD, decimal amt, string crcyCD)
        {
            var acct = getAccountBusinessServiceByAcctId(acctID, busSrvcCD);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }

            return acct.ACCT_BAL + amt;
        }

        public decimal debitTransaction(int acctID, string busSrvcCD, decimal amt, string crcyCD)
        {
            var acct = getAccountBusinessServiceByAcctId(acctID, busSrvcCD);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }

            decimal currentBal = acct.ACCT_BAL;
            decimal newBal = currentBal - amt;
            if (newBal < 0.0m)
            {
                return -2.0m;
            }
            return acct.ACCT_BAL - amt;
        }

        public AccountBusinessService createAccountBusinessService(Account acct, string busSrvcCD,
                                                       string ACCT_OTH1_IND, string ACCT_OTH2_IND)
        {
            var objAcct = new AccountBusinessService();

            objAcct.ACCT_ID = acct.ACCT_ID;
            objAcct.ACCT_BUS_SRVC_CD = busSrvcCD;
            objAcct.ACCT_TCD = acct.ACCT_TCD;
            objAcct.ACCT_NBR = string.Concat(acct.ACCT_NBR, busSrvcCD);
            objAcct.ACCT_BAL = 0.0m;
            objAcct.CRCY_CD = acct.CRCY_CD;
            objAcct.ACCT_CLTR_INFO = acct.ACCT_CLTR_INFO;
            objAcct.ACCT_SCD = "01";
            objAcct.ACCT_OTH1_IND = ACCT_OTH1_IND;
            objAcct.ACCT_OTH2_IND = ACCT_OTH2_IND;
            //db.TACCT_BUS_SRVC.Add(objAcct);
            //db.SaveChanges();
            return objAcct;
        }

      /*  public List<AccountBusinessServiceModel> getAllAccountBusinessServiceModel(int acctID, string acctNbr, string crcyCD)
        {
            var list = new List<AccountBusinessServiceModel>();
            try
            {
                var acctBusAgntCmsnObj = new AccountBusinessAgentCommission();
                var ctryCrc = new CountryCurrency();
                var acctBusAgntCmsn = acctBusAgntCmsnObj.getCommissionAccountByAcctId(acctID);
                if (acctBusAgntCmsn != null)
                {
                    var acctBusSrvc = new AccountBusinessServiceModel();
                    acctBusSrvc.ACCT_ID = acctID;
                    acctBusSrvc.ACCT_NBR = string.Concat(acctNbr, " ", "2A");
                    acctBusSrvc.ACCT_NM = "Compte Commission Affaire";
                    acctBusSrvc.ACCT_BUS_SRVC_CD = "2A";
                    acctBusSrvc.ACCT_BAL = CommonLibrary.displayFormattedCurrency(acctBusAgntCmsn.ACCT_BAL,
                                                                crcyCD, acctBusAgntCmsn.ACCT_CLTR_INFO);
                    list.Add(acctBusSrvc);
                }

                var acctBusSrvcList = getAllAccountBusinessServiceByAcctId(acctID);
                if (acctBusSrvcList.Count() != 0)
                {
                    foreach (var acct in acctBusSrvcList)
                    {
                        var acctBusSrvc = new AccountBusinessServiceModel();
                        acctBusSrvc.ACCT_ID = acctID;
                        acctBusSrvc.ACCT_BUS_SRVC_CD = acct.ACCT_BUS_SRVC_CD.ToUpper();
                        acctBusSrvc.ACCT_NBR = string.Concat(acctNbr, " ", acctBusSrvc.ACCT_BUS_SRVC_CD);
                        if (acctBusSrvc.ACCT_BUS_SRVC_CD == "CD")
                        {
                            acctBusSrvc.ACCT_NM = "Compte Carte Affaire";
                        }
                        else if (acctBusSrvc.ACCT_BUS_SRVC_CD == "TR")
                        {
                            acctBusSrvc.ACCT_NM = "Compte Transfert Affaire";
                        }
                        acctBusSrvc.ACCT_BAL = CommonLibrary.displayFormattedCurrency(acct.ACCT_BAL,
                                                                             crcyCD, acct.ACCT_CLTR_INFO);
                        list.Add(acctBusSrvc);
                    }
                }

                return list;
            }
            catch
            {
                return list;
            }
        } */
        
    }
}