using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_PKP_CMSN")]
    public class AgentPayKapCommission
    {
        public AgentPayKapCommission()
        {
            CMSN_CUR_APBL_EDT = DateTime.Now;
            CMSN_CUR_APBL_XDT = Convert.ToDateTime("9999-12-31");
            CMSN_CUR_APBL_IND = "1";
        }

        [Key]
        [Display(Name = "ID")]
        public int CMSN_ID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Service")]
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
                else if (SRVC_TCD == "99")
                {
                    return "Tous les services";
                }
                return "Paiement";
            }
        }

        [StringLength(1)]
        [Display(Name = "En ligne ou agence")]
        public string ONLN_AGCY_SRVC_TCD { get; set; }

        [Display(Name = "Service En ligne ou agence")]
        [NotMapped]
        public string ONLN_AGCY_SRVC_TCD_TXT
        {
            get
            {
                if (ONLN_AGCY_SRVC_TCD == "1")
                {
                    return "En Ligne";
                }
                else if (ONLN_AGCY_SRVC_TCD == "2")
                {
                    return "En agence";
                }
                return "";
            }
        }

        [StringLength(3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }
        
        [Required]
        [StringLength(3)]
        [Display(Name = "Devise")]
        public string CRCY_CD { get; set; }

        [Display(Name = "cmsn (pas)")]
        public decimal AGNT_FIX_CMSN_AMT { get; set; }

        [Display(Name = "cmsn (Pas)(%)")]
        public decimal AGNT_PRCNT_CMSN_RT { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string AGNT_PRCNT_CMSN_RT_TXT
        {
            get
            {
                decimal percent = AGNT_PRCNT_CMSN_RT * 100;
                return percent.ToString("N2") + "%";
            }
        }

        [Display(Name = "cmsn (parrain)")]
        public decimal SPNSR_FIX_CMSN_AMT { get; set; }

        [Display(Name = "cmsn (parrain)(%)")]
        public decimal SPNSR_PRCNT_CMSN_RT { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string SPNSR_PRCNT_CMSN_RT_TXT
        {
            get
            {
                decimal percent = SPNSR_PRCNT_CMSN_RT * 100;
                return percent.ToString("N2") + "%";
            }
        }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type cmsn")]
        public string CMSN_TCD { get; set; }

        [Display(Name = "Élement courant Texte")]
        [NotMapped]
        public string CMSN_TCD_TXT
        {
            get
            {
                if (CMSN_TCD == "1")
                {
                    return "Fixe";
                }
                return "%";
            }
        }

        [Required]
        [StringLength(1)]
        [Display(Name = "Élement courant")]
        public string CMSN_CUR_APBL_IND { get; set; }

        [Display(Name = "Élement courant Texte")]
        [NotMapped]
        public string CMSN_CUR_APBL_IND_TXT
        {
            get
            {
                if (CMSN_CUR_APBL_IND == "1")
                {
                    return "Oui";
                }
                return "Non";
            }
        }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime CMSN_CUR_APBL_EDT { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime CMSN_CUR_APBL_XDT { get; set; }

        public virtual Country TCTRY { get; set; }

        public virtual Currency TCRCY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public AgentPayKapCommission getOneAgentPayKapCommission(string ctryCD, string srvcTCD, string OnlineAgencySrvcTCD)
        {
            try
            {
                var objList = db.TAGNT_PKP_CMSN.Where(x => x.CTRY_CD == ctryCD && x.SRVC_TCD == srvcTCD && 
                                                           x.ONLN_AGCY_SRVC_TCD == OnlineAgencySrvcTCD && x.CMSN_CUR_APBL_IND == "1").ToList();
                if (objList.Count() == 0)
                {
                    return null;
                }

                var obj = objList[0];
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

        public List<AgentPayKapCommission> getAllAgentPayKapCommission(int agntID)
        {
            var list = new List<AgentPayKapCommission>();
            try
            {
                var objList = db.TAGNT_PKP_CMSN.ToList();
                if (objList.Count() == 0)
                {
                    return list;
                }

                var newAgnt = new Agent();
                var getAgnt = newAgnt.getOneAgent(agntID);
                if(getAgnt.ERR == "valid" && getAgnt.agent != null)
                {
                    DateTime agntEDT = getAgnt.agent.AGNT_EDT;
                    foreach(var item in objList)
                    {
                        if (item.CMSN_CUR_APBL_EDT <= agntEDT && item.CMSN_CUR_APBL_XDT > agntEDT)
                        {
                            list.Add(item);
                        }
                    }
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch
            {
                return list;
            }
        }
    }
}