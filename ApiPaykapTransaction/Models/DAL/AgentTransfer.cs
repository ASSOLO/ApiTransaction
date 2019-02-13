using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_TRSF")]
    public class AgentTransfer
    {
        public AgentTransfer()
        {
            AGNT_TRSF_DT = DateTime.Now;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AGNT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AGNT_TRSF_ID { get; set; }

        public decimal AGNT_TRSF_AMT { get; set; }

        [Display(Name = "Montant Min Texte")]
        [NotMapped]
        public string AGNT_TRSF_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(AGNT_TRSF_AMT, CRCY_CD, cultureInfo);
            }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime AGNT_TRSF_DT { get; set; }

        [Required]
        [StringLength(3)]
        public string CRCY_CD { get; set; }

        public virtual Agent TAGNT { get; set; }

        private DalContext db = new DalContext();
        
        public AgentTransfer insertAgentTransfer(int agntID, decimal AGNT_TRSF_AMT, string CRCY_CD)
        {
            try
            {
                var obj = new AgentTransfer();
                obj.AGNT_ID = agntID;
                obj.AGNT_TRSF_AMT = AGNT_TRSF_AMT;
                obj.CRCY_CD = CRCY_CD;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public List<AgentTransfer> getAllCurrentMonthAgentTransferByAgentID(int agntID)
        {
            var list = new List<AgentTransfer>();
            try
            {
                DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
                return db.TAGNT_TRSF.Where(x => x.AGNT_ID == agntID && x.AGNT_TRSF_DT >= startDT).OrderByDescending(x => x.AGNT_TRSF_DT).ToList();
            }
            catch
            {
                return list;
            }
        }

        public List<AgentTransfer> getAllSelectedMonthAgentTransferByAgentID(int agntID, string month, string year)
        {
            var list = new List<AgentTransfer>();
            try
            {
                int intMonth = Convert.ToInt32(month);
                int intYear = Convert.ToInt32(year);
                DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
                DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);
                return db.TAGNT_TRSF.Where(x => x.AGNT_ID == agntID && x.AGNT_TRSF_DT >= firstDate && x.AGNT_TRSF_DT <= lastDate).OrderByDescending(x => x.AGNT_TRSF_DT).ToList();
            }
            catch
            {
                return list;
            }
        }
    }
}
