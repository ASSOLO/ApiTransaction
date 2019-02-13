using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRANS_TEMPO")]
    public class TransactionTemporary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Indicatif Compte PayKap Départ")]
        public string FROM_PKP_ACCT_IND { get; set; }

        [Display(Name = "Compte PayKap Départ")]
        public int FROM_PKP_ACCT_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Description Transaction Départ")]
        public string FROM_TRANS_DESC { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Indicatif Service Destination")]
        public string TO_SRVC_IND { get; set; }

        [Display(Name = "Compte PayKap Destination")]
        public int TO_PKP_ACCT_ID { get; set; }

        [Display(Name = "Compte Banque Destination")]
        public int TO_BNK_ACCT_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Description Transaction Destination")]
        public string TO_TRANS_DESC { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public TransactionTemporary insertTransactionTempo(int TRANS_ID, string FROM_PKP_ACCT_IND, int FROM_PKP_ACCT_ID, 
                                                           string FROM_TRANS_DESC,
                                                           string TO_SRVC_IND, int TO_PKP_ACCT_ID,
                                                           int TO_BNK_ACCT_ID, string TO_TRANS_DESC)
        {
            try
            {
                var obj = new TransactionTemporary();

                obj.TRANS_ID = TRANS_ID;
                obj.FROM_PKP_ACCT_IND = FROM_PKP_ACCT_IND;
                obj.FROM_PKP_ACCT_ID = FROM_PKP_ACCT_ID;
                obj.FROM_TRANS_DESC = FROM_TRANS_DESC;
                obj.TO_SRVC_IND = TO_SRVC_IND;
                obj.TO_PKP_ACCT_ID = TO_PKP_ACCT_ID;
                obj.TO_BNK_ACCT_ID = TO_BNK_ACCT_ID;
                obj.TO_TRANS_DESC = TO_TRANS_DESC;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public TransactionTemporary getTransactionTempo(int TRANS_ID)
        {
            try
            {
                var obj = db.TTRANS_TEMPO.Find(TRANS_ID);

                if(obj == null)
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