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
    [Table("dbo.TBNK_TRANS")]
    public class BankTransaction
    {
        public BankTransaction()
        {
            BNK_TRANS_DT = DateTime.Now;
            EXRL_BNK_TRANS_DT = Convert.ToDateTime("2000-01-01");
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        [Display(Name = "Type Utilisateur")]   //1 = sender 2=recipient
        public string FROM_TO_USR_CD { get; set; }

        [Display(Name = "ID Compte Externe")]
        public int EXRL_ACCT_ID { get; set; }

        [StringLength(2)]
        [Display(Name = "Type Transaction")]   //01- Transfer    02- Bill Payment Registered Recipient,   
                                               //03-Bill Payment No Registered Recipient   04- Deposit   05- Withdrawal
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime BNK_TRANS_DT { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "ID Transaction Bancaire Externe")]
        public string EXRL_BNK_TRANS_ID { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Transaction Bancaire Externe")]
        public DateTime EXRL_BNK_TRANS_DT { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(200, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Description Transaction Bancaire Externe")]
        public string EXRL_BNK_TRANS_DESC { get; set; }

        public virtual FinancialInstitutionExternalAccount TFI_EXRL_ACCT { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";
        public BankTransaction createBankTransaction(int TRANS_ID, string FROM_TO_USR_CD,
                                     int EXRL_ACCT_ID, string TRANS_TCD,
                                     string EXRL_BNK_TRANS_ID, DateTime EXRL_BNK_TRANS_DT,
                                     bool defaultBankTransDtIND, string EXRL_BNK_TRANS_DESC)
        {
            try
            {
                var obj = new BankTransaction();

                obj.TRANS_ID = TRANS_ID;
                obj.FROM_TO_USR_CD = FROM_TO_USR_CD;
                obj.EXRL_ACCT_ID = EXRL_ACCT_ID;
                obj.TRANS_TRSF_CRDT_DBT_TCD = TRANS_TCD;
                obj.EXRL_BNK_TRANS_ID = EXRL_BNK_TRANS_ID;
                obj.EXRL_BNK_TRANS_DESC = EXRL_BNK_TRANS_DESC;
                if (!defaultBankTransDtIND)
                {
                    obj.EXRL_BNK_TRANS_DT = EXRL_BNK_TRANS_DT;
                }
                //db.TTRANS_TRSF_CRDT_DBT.Add(obj);
                //db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public BankTransaction getBankTransactionByTransID(int transID, string senderReceiverTCD)
        {
            try
            {
                var obj = db.TBNK_TRANS.Find(transID, senderReceiverTCD);
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
