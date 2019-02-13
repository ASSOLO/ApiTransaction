using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_CMSN")]
    public class AgentCommission
    {
        public AgentCommission()
        {
            CMSN_CUR_APBL_EDT = DateTime.Now;
            CMSN_CUR_APBL_XDT = DateTime.Now.AddYears(1);
            CMSN_CUR_APBL_IND = "1";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Commission Agent")]
        public int AGNT_CMSN_ID { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Agent")]
        public int AGNT_ID { get; set; }
        
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
                else if (SRVC_TCD == "99")
                {
                    return "Tous les services";
                }
                return "Paiement";
            }
        }

        [StringLength(1)]
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
                else if (ONLN_AGCY_SRVC_TCD == "3")
                {
                    return "Les deux";
                }
                return "";
            }
        }

        [StringLength(3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Display(Name = "Entreprise")]
        public int? PRTNSP_BN { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Agent")]
        public string AGNT_CLT_PRTR_TCD { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string AGNT_CLT_PRTR_TCD_TXT
        {
            get
            {
                if (AGNT_CLT_PRTR_TCD == "1")
                {
                    return "Client";
                }
                return "Partenaire";
            }
        }

        [Display(Name = "CMSN Fixe")]
        public decimal AGNT_FIX_CMSN_AMT { get; set; }

        [Display(Name = "CMSN %")]
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

        [Display(Name = "CMSN Fixe Spnsor")]
        public decimal SPNSR_FIX_CMSN_AMT { get; set; }

        [Display(Name = "CMSN % Spnsor")]
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
        [Display(Name = "Type CMSN")]
        public string CMSN_TCD { get; set; }

        [Display(Name = "Type CMSN")]
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

        [Display(Name = "Date Eff.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CMSN_CUR_APBL_EDT { get; set; }

        [Display(Name = "Date Exp.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CMSN_CUR_APBL_XDT { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Code Frais ou Commission Partenaire")]
        public string APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD { get; set; } //1= Transaction Fee, 2= Partner commission

        [Required]
        [StringLength(1)]
        [Display(Name = "Appliquer la commission parrain?")]
        public string APLY_SPNSR_CMSN_IND { get; set; }//1= apply, 0= not apply


        private DalContext db = new DalContext();
        public virtual Agent TAGNT { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual Country TCTRY { get; set; }

        public AgentCommission createAgentCommission(int AGNT_ID, string SRVC_TCD, string ONLN_AGCY_SRVC_TCD,
                                            string CTRY_CD, int PRTNSP_BN, string AGNT_CLT_PRTR_TCD,
                                            decimal AGNT_FIX_CMSN_AMT, decimal AGNT_PRCNT_CMSN_RT,
                                            decimal SPNSR_FIX_CMSN_AMT, decimal SPNSR_PRCNT_CMSN_RT,
                                            string CMSN_TCD, string APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD,
                                            string APLY_SPNSR_CMSN_IND)
        {
            try
            {
                var obj = new AgentCommission();

                obj.AGNT_ID = AGNT_ID;
                obj.SRVC_TCD = SRVC_TCD;
                obj.ONLN_AGCY_SRVC_TCD = ONLN_AGCY_SRVC_TCD;
                obj.CTRY_CD = CTRY_CD;
                obj.PRTNSP_BN = PRTNSP_BN;
                obj.AGNT_CLT_PRTR_TCD = AGNT_CLT_PRTR_TCD;
                obj.AGNT_FIX_CMSN_AMT = AGNT_FIX_CMSN_AMT;
                obj.AGNT_PRCNT_CMSN_RT = AGNT_PRCNT_CMSN_RT;
                obj.SPNSR_FIX_CMSN_AMT = SPNSR_FIX_CMSN_AMT;
                obj.SPNSR_PRCNT_CMSN_RT = SPNSR_PRCNT_CMSN_RT;
                obj.CMSN_TCD = CMSN_TCD;
                obj.APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD = APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD;
                obj.APLY_SPNSR_CMSN_IND = APLY_SPNSR_CMSN_IND;
                db.TAGNT_CMSN.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }


        public List<AgentCommission> getAllAgentCommissionByAgentID(int agntID)
        {
            var list = new List<AgentCommission>();
            try
            {
                return db.TAGNT_CMSN.Where(x => x.AGNT_ID == agntID).ToList();
            }
            catch
            {
                return list;
            }
        }

        public AgentCommission getOneAgentCommission(int agntID, string ctryCD, string srvcTCD, string OnlineAgencySrvcTCD, int? BN, string busIND)
        {
            try
            {
                if(busIND == "1")
                {
                    var cmsnList = db.TAGNT_CMSN.Where(x => x.AGNT_ID == agntID && x.CTRY_CD == ctryCD && x.PRTNSP_BN == BN &&
                                                            (x.SRVC_TCD == srvcTCD || x.SRVC_TCD == "99") &&
                                                            x.ONLN_AGCY_SRVC_TCD == OnlineAgencySrvcTCD && x.CMSN_CUR_APBL_IND == "1").ToList();
                    if(cmsnList.Count() == 0)
                    {
                        return null;
                    }
                    var cmsn = cmsnList[0];
                    return cmsn;
                }
                else
                {
                    var cmsnList = db.TAGNT_CMSN.Where(x => x.AGNT_ID == agntID && x.CTRY_CD == ctryCD && 
                                                            (x.SRVC_TCD == srvcTCD || x.SRVC_TCD == "99") &&
                                                            x.ONLN_AGCY_SRVC_TCD == OnlineAgencySrvcTCD && x.CMSN_CUR_APBL_IND == "1").ToList();
                    if (cmsnList.Count() == 0)
                    {
                        return null;
                    }
                    var cmsn = cmsnList[0];
                    return cmsn;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<AgentCommission> getOneBusinessAgentCommission(string busCtryCD, string srvcTCD, string OnlineAgencySrvcTCD, int? BN)
        {
            var list = new List<AgentCommission>();
            try
            {
                return db.TAGNT_CMSN.Where(x => x.PRTNSP_BN == BN && x.CTRY_CD == busCtryCD &&
                                                (x.SRVC_TCD == srvcTCD || x.SRVC_TCD == "99") &&
                                                x.ONLN_AGCY_SRVC_TCD == OnlineAgencySrvcTCD && x.CMSN_CUR_APBL_IND == "1").ToList();
            }
            catch
            {
                return list;
            }
        }
    }
}