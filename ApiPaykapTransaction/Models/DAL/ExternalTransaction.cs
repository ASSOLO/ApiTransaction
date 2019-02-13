using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TEXRL_TRANS")]
    public class ExternalTransaction
    {
        public ExternalTransaction()
        {
            EXRL_TRANS_DT = DateTime.Now;
            EXRL_TRANS_NSS_ID = "d";
            EXRL_TRANS_OTH_DTL_TXT = "d";
            PYMT_PRTR_ID = "d";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Transaction Externe")]
        public int EXRL_TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "ID Transaction PKP")]
        public string PKP_TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "ID Transaction Parténaire")]
        public string PRTR_TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Code Return Transaction Parténaire")]
        public string PRTR_TRANS_RCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Nouvelle Session Transaction Parténaire")]
        public string EXRL_TRANS_NSS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Autre Détail Transaction Parténaire")]
        public string EXRL_TRANS_OTH_DTL_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Display(Name = "ID Parténaire Paiement")]
        public string PYMT_PRTR_ID { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime EXRL_TRANS_DT { get; set; }

        public virtual PaymentPartner TPYMT_PRTR { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public bool createExternalTransaction(string PKP_TRANS_ID, string PRTR_TRANS_ID, string PRTR_TRANS_RCD, 
                                              string EXRL_TRANS_NSS_ID, string EXRL_TRANS_OTH_DTL_TXT, string PYMT_PRTR_ID)
        {
            try
            {
                var obj = new ExternalTransaction();

                obj.PKP_TRANS_ID = PKP_TRANS_ID;
                obj.PRTR_TRANS_ID = PRTR_TRANS_ID;
                obj.PRTR_TRANS_RCD = PRTR_TRANS_RCD;
                obj.EXRL_TRANS_NSS_ID = EXRL_TRANS_NSS_ID;
                obj.EXRL_TRANS_OTH_DTL_TXT = EXRL_TRANS_OTH_DTL_TXT;
                obj.PYMT_PRTR_ID = PYMT_PRTR_ID;
                db.TEXRL_TRANS.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateExternalTransaction(int EXRL_TRANS_ID, string returnCode, string PRTR_TRANS_ID)
        {
            try
            {
                var obj = db.TEXRL_TRANS.Find(EXRL_TRANS_ID);
                if (obj == null)
                {
                    return false;
                }
               
                obj.PRTR_TRANS_RCD = returnCode;
                obj.PRTR_TRANS_ID = PRTR_TRANS_ID;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ExternalTransaction getOneExternalTransactionByCTPaiementSecureID(string secureID)
        {
            try
            {
                var exrlTransList = db.TEXRL_TRANS.Where(x => x.EXRL_TRANS_NSS_ID == secureID && x.PYMT_PRTR_ID == "CTPAIEMENT")
                                                               .OrderByDescending(y => y.EXRL_TRANS_DT).ToList();
                if (exrlTransList.Count() == 0)
                {
                    return null;
                }
                var exrlTrans = exrlTransList[0];
                return exrlTrans;

            }
            catch
            {
                return null;
            }
        }
    }
}