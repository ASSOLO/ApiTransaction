using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRANS_ID_DOC")]
    public class TransactionIdentificationDocument
    {
        public TransactionIdentificationDocument()
        {
            TRANS_ID_DOC_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le type du document est obligatoire")]
        [Display(Name = "Type Document")]
        public int ID_DOC_ID { get; set; }

        [Required(ErrorMessage = "Le numéro du document est obligatoire")]
        [StringLength(50, ErrorMessage = "Le numéro du document doit être compris entre 2 et 50 caractères.", MinimumLength = 2)]
        [Display(Name = "Numéro Document")]
        public string ID_DOC_NBR { get; set; }

        [Required(ErrorMessage = "La date d'expiration du document est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime ID_DOC_XDT { get; set; }
        
        [Display(Name = "ID Employé")]
        public int BUS_USR_NBR { get; set; }

        [StringLength(10)]
        [Display(Name = "ID Client")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "La date de naissance du propriétaire du compte est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Naissance")]
        public DateTime CLT_ID_DOC_BRDAY { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Creation")]
        public DateTime TRANS_ID_DOC_DT { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual BusinessUser TBUS_USR { get; set; }
        public virtual User TUSR { get; set; }
        public virtual IdentificationDocument TID_DOC { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public TransactionIdentificationDocument createTransactionIdentificationDocument(int TRANS_ID, int ID_DOC_ID,
                                     string ID_DOC_NBR, DateTime ID_DOC_XDT, DateTime CLT_ID_DOC_BRDAY, int BUS_USR_NBR, string CLT_USR_NBR)
        {
            try
            {
                var obj = new TransactionIdentificationDocument();
                if(TRANS_ID == 0 || ID_DOC_ID == 0 || string.IsNullOrWhiteSpace(ID_DOC_NBR) || string.IsNullOrWhiteSpace(CLT_USR_NBR))
                {
                    return null;
                }

                obj.TRANS_ID = TRANS_ID;
                obj.ID_DOC_ID = ID_DOC_ID;
                obj.ID_DOC_NBR = ID_DOC_NBR;
                obj.ID_DOC_XDT = ID_DOC_XDT;
                obj.BUS_USR_NBR = BUS_USR_NBR;
                obj.CLT_USR_NBR = CLT_USR_NBR;
                obj.CLT_ID_DOC_BRDAY = CLT_ID_DOC_BRDAY;
                db.TTRANS_ID_DOC.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionIdentificationDocument> getTransactionIDByClientUsrNbr(string usrNbr)
        {
            var list = new List<TransactionIdentificationDocument>();
            try
            {
                list = db.TTRANS_ID_DOC.Where(x => x.CLT_USR_NBR == usrNbr).OrderByDescending(y => y.TRANS_ID).ToList();
                return list;
            }
            catch
            {
                return list;
            }
        }
    }
}