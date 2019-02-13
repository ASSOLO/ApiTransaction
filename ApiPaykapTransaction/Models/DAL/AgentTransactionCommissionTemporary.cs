using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_TRANS_CMSN_TEMPO")]
    public class AgentTransactionCommissionTemporary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Indicatif De Nouveau Client")]
        public string NEW_TO_TRSF_SRVC_IND { get; set; }
        
        [Display(Name = "Code Promo")]
        public string AGNT_TKN_CD { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }


        private DalContext db = new DalContext();

        public bool insertTransactionTempo(int TRANS_ID, string NEW_TO_TRSF_SRVC_IND, string AGNT_TKN_CD)
        {
            try
            {
                var obj = new AgentTransactionCommissionTemporary();

                obj.TRANS_ID = TRANS_ID;
                obj.NEW_TO_TRSF_SRVC_IND = NEW_TO_TRSF_SRVC_IND;
                obj.AGNT_TKN_CD = AGNT_TKN_CD;
                db.TAGNT_TRANS_CMSN_TEMPO.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AgentTransactionCommissionTemporary getOneAgentTransactionCommissionTemporary(int transID)
        {
            try
            {
                var temp = db.TAGNT_TRANS_CMSN_TEMPO.Find(transID);
                if (temp == null)
                {
                    return null;
                }
                return temp;
            }
            catch
            {
                return null;
            }
        }
    }
}