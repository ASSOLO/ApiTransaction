using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TONBHLF_CLT_CMSN")]
    public class OnBehalfClientCommission
    {
        public OnBehalfClientCommission()
        {
            LGC_DEL_IND = "0";
        }

        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CMSN_ID { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [StringLength(3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

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
        
        [Required]
        [StringLength(3)]
        [Display(Name = "Devise")]
        public string CRCY_CD { get; set; }

        [Display(Name = "cmsn (pas)")]
        public decimal FIX_CMSN_AMT { get; set; }

        [Display(Name = "cmsn (Pas)(%)")]
        public decimal PRCNT_CMSN_RT { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string PRCNT_CMSN_RT_TXT
        {
            get
            {
                decimal percent = PRCNT_CMSN_RT * 100;
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
        public string LGC_DEL_IND { get; set; }

        [Display(Name = "Élement courant Texte")]
        [NotMapped]
        public string LGC_DEL_IND_TXT
        {
            get
            {
                if (LGC_DEL_IND == "1")
                {
                    return "Oui";
                }
                return "Non";
            }
        }

        public virtual User TUSR { get; set; }
        public virtual Country TCTRY { get; set; }
        public virtual Currency TCRCY { get; set; }
        private DalContext db = new DalContext();


        public OnBehalfClientCommission getOneOnBehalfClientCommissionByCltUsrNbr(string usrNbr,
                                                                   string ctryCD, string srvcTCD)
        {
            try
            {
                var objList = db.TONBHLF_CLT_CMSN.Where(x => x.USR_NBR == usrNbr && x.CTRY_CD == ctryCD &&
                                                             x.SRVC_TCD == srvcTCD && x.LGC_DEL_IND == "0").ToList();
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

        public decimal getOneOnBehalfClientCommissionAmount(string cltUsrNbr, string adminUsrNbr, 
                                           string ctryCD, string srvcTCD, decimal transFee, string crcyCD)
        {
            decimal errorAmt = -1.0m;
            try
            {
                var cmsn = getOneOnBehalfClientCommissionForTransaction(cltUsrNbr, adminUsrNbr, ctryCD, srvcTCD);
                if (cmsn == null)
                {
                    return errorAmt;
                }

                decimal cmsnAmt = errorAmt;
                if(cmsn.CMSN_TCD == "1")
                {
                    if(cmsn.CRCY_CD != crcyCD)
                    {
                        var newObj = new CurrencyExchangeRate();
                        decimal xchgRT = newObj.getExchangeRateByCurrency(cmsn.CRCY_CD, crcyCD);
                        if(xchgRT == 0.0m)
                        {
                            return errorAmt;
                        }
                        cmsnAmt = cmsn.FIX_CMSN_AMT * xchgRT;
                    }
                    else
                    {
                        cmsnAmt = cmsn.FIX_CMSN_AMT;
                    }
                }

                if (cmsn.CMSN_TCD == "2")
                {
                    cmsnAmt = transFee * cmsn.PRCNT_CMSN_RT;
                }
                return cmsnAmt;
            }
            catch
            {
                return errorAmt;
            }
        }


        public OnBehalfClientCommission getOneOnBehalfClientCommissionForTransaction(string cltUsrNbr,
                                                       string adminUsrNbr, string ctryCD, string srvcTCD)
        {
            try
            {
                var objList = db.TONBHLF_CLT_CMSN.Where(x => x.USR_NBR == cltUsrNbr && x.CTRY_CD == ctryCD &&
                                                             x.SRVC_TCD == srvcTCD && x.LGC_DEL_IND == "0").ToList();
                if (objList.Count() != 0)
                {
                    var obj = objList[0];
                    if (obj == null)
                    {
                        return null;
                    }
                    return obj;
                }

                var objList1 = db.TONBHLF_CLT_CMSN.Where(x => x.USR_NBR == adminUsrNbr && x.CTRY_CD == ctryCD &&
                                                             x.SRVC_TCD == srvcTCD && x.LGC_DEL_IND == "0").ToList();
                if (objList1.Count() != 0)
                {
                    var obj = objList1[0];
                    if (obj == null)
                    {
                        return null;
                    }
                    return obj;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<OnBehalfClientCommission> getAllOnBehalfClientCommissionByCltUsrNbr(string usrNbr, 
                                                                         string ctryCD, string srvcTCD)
        {
            return db.TONBHLF_CLT_CMSN.Where(x => x.USR_NBR == usrNbr && x.CTRY_CD == ctryCD &&
                                                             x.SRVC_TCD == srvcTCD && x.LGC_DEL_IND == "0").ToList();
        }
    }
}