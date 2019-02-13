using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_TRANS_CMSN")]
    public class AgentTransactionCommission
    {
        public AgentTransactionCommission()
        {
            TRANS_CMSN_DT = DateTime.Now;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AGNT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string AGNT_SPNSR_TCD { get; set; } 

        [Display(Name = "Type SPNSOR")]
        [NotMapped]
        public string AGNT_SPNSR_TCD_TXT
        {
            get
            {
                if (AGNT_SPNSR_TCD == "1")
                {
                    return "Parrain Direct";
                }
                return "Parrain Indirect";
            }
        }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string TRANS_ID { get; set; }

        public decimal TRANS_CMSN_AMT { get; set; }

        [Display(Name = "Montant Min Texte")]
        [NotMapped]
        public string TRANS_CMSN_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(TRANS_CMSN_CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(TRANS_CMSN_AMT, TRANS_CMSN_CRCY_CD, cultureInfo);
            }
        }

        public DateTime TRANS_CMSN_DT { get; set; }

        [Required]
        [StringLength(3)]
        public string TRANS_CMSN_CRCY_CD { get; set; }

        [Required]
        [StringLength(100)]
        public string TRANS_CMSN_DESC { get; set; }

        [Required]
        [StringLength(20)]
        public string TRANS_SPNSRD_NBR { get; set; }

        [Required]
        [StringLength(255)]
        public string TRANS_SPNSRD_NM { get; set; }

        [Required]
        [StringLength(1)]
        public string TRANS_SPNSRD_TCD { get; set; }

        [Display(Name = "Type SPNSOR")]
        [NotMapped]
        public string TRANS_SPNSRD_TCD_TXT
        {
            get
            {
                if (TRANS_SPNSRD_TCD == "1")
                {
                    return "Client";
                }
                return "Entreprise";
            }
        }

        [Required]
        [StringLength(2)]
        public string SRVC_TCD { get; set; }

        [Display(Name = "Service Texte")]
        [NotMapped]
        public string SRVC_TCD_TXT
        {
            get
            {
                if (SRVC_TCD == "01")
                {
                    return "Transfert";
                }
                else if (SRVC_TCD == "02" || SRVC_TCD == "03")
                {
                    return "Paiement de facture";
                }
                else if (SRVC_TCD == "04")
                {
                    return "Paiement";
                }
                else if (SRVC_TCD == "05")
                {
                    return "Dépôt d'argent";
                }
                else if (SRVC_TCD == "06")
                {
                    return "Retrait d'argent";
                }
                return "Paiement";
            }
        }

        public virtual Agent TAGNT { get; set; }

        private DalContext db = new DalContext();

        public AgentTransactionCommission insertAgentTransactionCommission(int agntID, string AGNT_SPNSR_TCD, string TRANS_ID,
                                                    decimal TRANS_CMSN_AMT, string CRCY_CD, string TRANS_DESC,
                                                    string SPNSRD_NBR, string SPNSRD_NM, string SPNSRD_TCD, string SRVC_TCD)
        {
            try
            {
                var obj = new AgentTransactionCommission();
                obj.AGNT_ID = agntID;
                obj.AGNT_SPNSR_TCD = AGNT_SPNSR_TCD;
                obj.TRANS_ID = TRANS_ID;
                obj.TRANS_CMSN_AMT = TRANS_CMSN_AMT;
                obj.TRANS_CMSN_CRCY_CD = CRCY_CD;
                obj.TRANS_CMSN_DESC = TRANS_DESC;
                obj.TRANS_SPNSRD_NBR = SPNSRD_NBR;
                obj.TRANS_SPNSRD_NM = SPNSRD_NM;
                obj.TRANS_SPNSRD_TCD = SPNSRD_TCD;
                obj.SRVC_TCD = SRVC_TCD;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public List<AgentTransactionCommission> getAllCurrentMonthAgentTransactionCommissionByAgentID(int agntID)
        {
            var list = new List<AgentTransactionCommission>();
            try
            {
                DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
                return db.TAGNT_TRANS_CMSN.Where(x => x.AGNT_ID == agntID && x.TRANS_CMSN_DT >= startDT).OrderByDescending(x => x.TRANS_CMSN_DT).ToList();
            }
            catch
            {
                return list;
            }
        }

        public List<AgentTransactionCommission> getAllSelectedMonthAgentTransactionCommissionByAgentID(int agntID, string month, string year)
        {
            var list = new List<AgentTransactionCommission>();
            try
            {
                int intMonth = Convert.ToInt32(month);
                int intYear = Convert.ToInt32(year);
                DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
                DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);
                return db.TAGNT_TRANS_CMSN.Where(x => x.AGNT_ID == agntID && x.TRANS_CMSN_DT >= firstDate && x.TRANS_CMSN_DT <= lastDate).OrderByDescending(x => x.TRANS_CMSN_DT).ToList();
            }
            catch
            {
                return list;
            }
        }
    }
}
