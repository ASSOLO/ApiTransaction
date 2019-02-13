using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBIL_PYMT_TRANS")]
    public class BillPaymentTransaction
    {
        public BillPaymentTransaction()
        {
            CLT_ACCT_NBR = "d";
            BIL_NBR = "d";
            BIL_PYMT_TRANS_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Compte Client")]
        public string CLT_ACCT_NBR { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Facture")]
        public string BIL_NBR { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime BIL_PYMT_TRANS_DT { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public BillPaymentTransaction getBillPaymentTransactionyTransID(int transID)
        {
            try
            {
                var obj = db.TBIL_PYMT_TRANS.Find(transID);
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

        public BillPaymentTransaction insertBillPaymentTransaction(int TRANS_ID, 
                                            string currentUsrNbr, string rcptUsrNbr, int? rcptBusNbr, string usrBusTCD,
                                            string BIL_NBR, bool DEFAULT_BIL_NBR)
        {
            try
            {
                var obj = new BillPaymentTransaction();

                obj.TRANS_ID = TRANS_ID;
                if(usrBusTCD == "1")
                {
                    var dbObjList = db.TRCPT_USR_BUS.Where(x => x.USR_NBR == currentUsrNbr && x.RCPT_USR_NBR == rcptUsrNbr && x.RCPT_USR_BUS_TCD == "1").ToList();
                    if(dbObjList != null)
                    {
                        var dbObj = dbObjList[0];
                        if(dbObj.RCPT_USR_BUS1_UIN != "d")
                        {
                            obj.CLT_ACCT_NBR = dbObj.RCPT_USR_BUS1_UIN;
                        }
                    }
                }
                if (usrBusTCD == "2")
                {
                    var dbObjList = db.TRCPT_USR_BUS.Where(x => x.USR_NBR == currentUsrNbr && x.RCPT_BUS_NBR == rcptBusNbr && x.RCPT_USR_BUS_TCD == "2").ToList();
                    if (dbObjList != null)
                    {
                        var dbObj = dbObjList[0];
                        if (dbObj.RCPT_USR_BUS1_UIN != "d")
                        {
                            obj.CLT_ACCT_NBR = dbObj.RCPT_USR_BUS1_UIN;
                        }
                    }
                }
                if (!DEFAULT_BIL_NBR)
                {
                    obj.BIL_NBR = BIL_NBR;
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
