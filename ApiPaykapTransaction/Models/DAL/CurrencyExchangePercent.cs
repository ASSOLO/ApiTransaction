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
    [Table("dbo.TCRCY_XCHG_PRCNT")]
    public class CurrencyExchangePercent
    {
        public CurrencyExchangePercent()
        {
            TTRANS_FEE = new HashSet<TransactionFee>();
            CRCY_XCHG_PRCNT_DT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID % Taux Change")]
        public int CRCY_XCHG_PRCNT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Taux Investisseur)")]
        public decimal IVSTR_CRCY_XCHG_PRCNT_RT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Taux Non-Investisseur)")]
        public decimal NIVSTR_CRCY_XCHG_PRCNT_RT { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime CRCY_XCHG_PRCNT_DT { get; set; }
        
        public virtual ICollection<TransactionFee> TTRANS_FEE { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public CurrencyExchangePercent getCurrencyExchangePercentByID(int ID)
        {
            try
            {
                var obj = db.TCRCY_XCHG_PRCNT.Find(ID);
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
