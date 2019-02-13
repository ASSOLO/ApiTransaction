using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TRCPT_BUS")]
    public class RecipientBusiness
    {
        public RecipientBusiness()
        {
            LGC_DEL_IND = "0";
            RCPT_EDT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Bénéficiaire Entreprise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RCPT_BUS_ID { get; set; }

        public int RCPT_ACCT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string RCPT_USR_NBR { get; set; }

        [Required]
        [StringLength(25)]
        public string RCPT_ACCT_NBR { get; set; }

        [Required]
        [StringLength(3)]
        public string RCPT_ACCT_CRCY_CD { get; set; }

        [Required]
        [StringLength(255)]
        public string RCPT_FUL_NM { get; set; }

        [Required]
        [StringLength(1)]
        public string RCPT_TCD { get; set; }

        public DateTime RCPT_EDT { get; set; }

        [Required]
        [StringLength(2)]
        public string ACTVT_TCD { get; set; }

        public int? BN { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual Account TACCT { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual User TUSR { get; set; }

        public virtual User TUSR1 { get; set; }

        private DalContext db = new DalContext();

        public RecipientBusiness getRecipientBusinessByRcptID(int rcptID)
        {
            try
            {
                var rcpt = db.TRCPT_BUS.Find(rcptID);
                if (rcpt == null)
                {
                    return null;
                }
                else
                {
                    return rcpt;
                }
            }
            catch
            {
                return null;
            }
        }

        public RecipientBusiness createRecipientBusiness(int ACCT_ID, string ACCT_NBR, 
                                                string RCPT_ACCT_NBR, string CRCY_CD, 
                                                string RCPT_FUL_NM, string RCPT_TCD,
                                                string ACTVT_TCD, int? BN, string USR_NBR)
        {
            try
            {
                var obj = new RecipientBusiness();

                obj.RCPT_ACCT_ID = ACCT_ID;
                obj.RCPT_USR_NBR = ACCT_NBR;
                obj.RCPT_ACCT_NBR = RCPT_ACCT_NBR;
                obj.RCPT_ACCT_CRCY_CD = CRCY_CD;
                obj.RCPT_FUL_NM = RCPT_FUL_NM;
                obj.RCPT_TCD = RCPT_TCD;
                obj.ACTVT_TCD = ACTVT_TCD;
                obj.BN = BN;
                obj.USR_NBR = USR_NBR;
                db.TRCPT_BUS.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}
