using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBPCS")]
    public class BillPaymentCreditor
    {
        public BillPaymentCreditor()
        {
            TTRANS_SSN = new HashSet<TransactionSession>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Numéro Facture Créditeur")]
        public int BPCS_NBR { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "ID Créditeur")]
        public string BPCS_BUS_ID { get; set; }
        
        [Required(ErrorMessage = "Le nom de l'entreprise est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le nom de l'entreprise doit avoir entre 2 et 30 caractères.", MinimumLength = 2)]
        [Display(Name = "Nom Entreprise")]
        public string BPCS_BUS_NM { get; set; }

        [Required(ErrorMessage = "La description du numéro de compte des clients de l'entreprise est obligatoire.")]
        [StringLength(500, ErrorMessage = "La description du numéro de compte des clients doit avoir maximum 500 caractères.", MinimumLength = 2)]
        [Display(Name = "Description Compte Client Entreprise")]
        public string BPCS_CLT_ACCT_DESC { get; set; }
        
        [Required(ErrorMessage = "L'Url de Retour de la transaction de l'entreprise est obligatoire.")]
        [StringLength(300, ErrorMessage = "L'Url de Retour de la transaction de l'entreprise doit avoir maximum 300 caractères.", MinimumLength = 2)]
        [Display(Name = "Url Retour Transaction")]
        public string BPCS_URL_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter au maximum 1 caractère.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Url Retour Exigé ?")]
        public string BPCS_URL_NEED_IND { get; set; }

        [Display(Name = "ID Compte")]
        public int ACCT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string ACCT_CRCY_CD { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        public virtual Account TACCT { get; set; }

        public virtual Business TBUS { get; set; }
        
        public virtual ICollection<TransactionSession> TTRANS_SSN { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public BillPaymentCreditor getBillPaymentCreditor(string BPCS_BUS_ID)
        {
            try
            {
                var objList = db.TBPCS.Where(x => x.BPCS_BUS_ID == BPCS_BUS_ID).ToList();
                if(objList.Count() != 1)
                {
                    return null;
                }
                var obj = objList[0];
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public BillPaymentCreditor getBillPaymentCreditorByID(int BPCS_NBR)
        {
            try
            {
                var obj = db.TBPCS.Find(BPCS_NBR);

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
