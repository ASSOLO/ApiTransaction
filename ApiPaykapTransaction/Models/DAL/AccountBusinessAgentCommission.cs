using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TACCT_BUS_AGNT_CMSN")]
    public class AccountBusinessAgentCommission
    {
       /* public AccountBusinessAgentCommission()
        {
            TAGNT = new HashSet<Agent>();
        } */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACCT_ID { get; set; }

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
          

       /* [Display(Name = "Montant Min Texte")]
        [NotMapped]
        public decimal NOT_MAP_ACCT_BAL { get; set; } */

        [Required]
        [StringLength(5)]
        public string ACCT_CLTR_INFO { get; set; }

        [Required]
        [StringLength(2)]
        public string ACCT_SCD { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_AGNT_TCD { get; set; } // 1- For Agent (Individual & Business) 2- For Business

        [Required]
        [StringLength(1)]
        public string DPLY_ACCT_TO_SPNSR_IND { get; set; } // 0- no    1- display

        [Required]
        [StringLength(1)]
        public string SPNSR_CNTL_CMSN_ACCT_IND { get; set; } // 0- no   1- sponsor control

        public virtual Account TACCT { get; set; }

        public virtual ICollection<Agent> TAGNT { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public AccountBusinessAgentCommission getCommissionAccountByAcctIdByAcctNbr(string acctNbr, string acctTCD)
        {
            var acctList = db.TACCT_BUS_AGNT_CMSN.Where(x => x.ACCT_NBR == acctNbr && x.ACCT_TCD == acctTCD && x.ACCT_SCD == "01").ToList();
            if (acctList.Count() != 1)
            {
                return null;
            }
            var acct = acctList[0];
            return acct;
        }
        
        public AccountBusinessAgentCommission getCommissionAccountByAcctId(int acctID)
        {
            DalContext db = new DalContext();
            var acctList = db.TACCT_BUS_AGNT_CMSN.Where(x => x.ACCT_ID == acctID && x.ACCT_SCD == "01").ToList();
            if (acctList.Count() != 1)
            {
                return null;
            }
            var acct = acctList[0];
            return acct;
        }
        
        public decimal creditTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getCommissionAccountByAcctId(acctID);
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

        public decimal debitTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getCommissionAccountByAcctId(acctID);
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

        public AccountBusinessAgentCommission createAccountBusinessAgentCommission(Account acct, 
                                                            string BUS_AGNT_TCD, string displayAccountToSponsorIND,
                                                            string spnsorControlCommissionAccountIND)
        {
            try
            {
                /* var objAcct = new AccountBusinessAgentCommission();

                 objAcct.ACCT_ID = acct.ACCT_ID;
                 objAcct.ACCT_TCD = acct.ACCT_TCD;
                 objAcct.CRCY_CD = acct.CRCY_CD;
                 objAcct.ACCT_NBR = acct.ACCT_NBR + "2A";
                 objAcct.ACCT_BAL = 0.0m;               
                 objAcct.ACCT_CLTR_INFO = acct.ACCT_CLTR_INFO;
                 objAcct.ACCT_SCD = "01";
                 objAcct.BUS_AGNT_TCD = BUS_AGNT_TCD; // 1- For Agent (Individual & Business) 2- For Business
                 objAcct.DPLY_ACCT_TO_SPNSR_IND = displayAccountToSponsorIND;
                 objAcct.SPNSR_CNTL_CMSN_ACCT_IND = spnsorControlCommissionAccountIND;
                 db.TACCT_BUS_AGNT_CMSN.Add(objAcct);
                 db.SaveChanges();
                 return objAcct; */
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
