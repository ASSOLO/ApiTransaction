using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TCTRY")]
    public class Country
    {
        public Country()
        {
            TPROV = new HashSet<Province>();
            TCITY = new HashSet<City>();
            TTRSF_SERV_CTRY = new HashSet<TransferServiceCountry>();
            TMNYT_AUTH_LMIT = new HashSet<MoneyTransferAuthorizedLimit>();
            TTAX_RT_CTRY = new HashSet<TaxRateCountry>();
            TKTCT = new HashSet<Contact>();
            TCARD = new HashSet<Card>();
            TFI_CTRY = new HashSet<FinancialInstitutionCountry>();
            TFI_EXRL_ACCT_DESC = new HashSet<FinancialInstitutionExternalAccountDescription>();
            TBUS_CMSN = new HashSet<BusinessCommission>();
            TTRANS_TRSF_CRDT_DBT = new HashSet<TransactionTransferCreditDebit>();
            TTRANS_TRSF_CRDT_DBT1 = new HashSet<TransactionTransferCreditDebit>();
            TTRSF_FEE_SERV_CTRY = new HashSet<TransferFeeServiceCountry>();
            TTRSF_FEE_SERV_CTRY1 = new HashSet<TransferFeeServiceCountry>();
            TCTRY_CRCY = new HashSet<CountryCurrency>();
            TBUS_CTRY_FEE = new HashSet<BusinessFee>();
            LGC_DEL_IND = "0";
            TAGNT_CMSN = new HashSet<AgentCommission>();
            TAGNT_PKP_CMSN = new HashSet<AgentPayKapCommission>();
            TONBHLF_CLT_CMSN = new HashSet<OnBehalfClientCommission>();
        }
        
        [Key]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Français")]
        public string FRA_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string ENG_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string SPA_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string ARB_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string POR_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string ZHO_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string RUS_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string DEU_CTRY_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string ITA_CTRY_NM { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0,1,ErrorMessage ="La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Trois Lettres Pays")]
        public string CTRY_LTR_CD { get; set; }

        public virtual ICollection<Province> TPROV { get; set; }
        public virtual ICollection<City> TCITY { get; set; }
        public virtual ICollection<MoneyTransferAuthorizedLimit> TMNYT_AUTH_LMIT { get; set; }
        public virtual ICollection<TransferServiceCountry> TTRSF_SERV_CTRY { get; set; }
        public virtual ICollection<TaxRateCountry> TTAX_RT_CTRY { get; set; }
        public virtual ICollection<Contact> TKTCT { get; set; }
        public virtual ICollection<Card> TCARD { get; set; }
        public virtual ICollection<FinancialInstitutionCountry> TFI_CTRY { get; set; }
        public virtual ICollection<FinancialInstitutionExternalAccountDescription> TFI_EXRL_ACCT_DESC { get; set; }
        public virtual ICollection<BusinessCommission> TBUS_CMSN { get; set; }
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT1 { get; set; }
        public virtual ICollection<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY { get; set; }
        public virtual ICollection<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY1 { get; set; }
        public virtual ICollection<CountryCurrency> TCTRY_CRCY { get; set; }
        public virtual ICollection<BusinessFee> TBUS_CTRY_FEE { get; set; }
        public virtual ICollection<AgentCommission> TAGNT_CMSN { get; set; }
        public virtual ICollection<AgentPayKapCommission> TAGNT_PKP_CMSN { get; set; }
        public virtual ICollection<OnBehalfClientCommission> TONBHLF_CLT_CMSN { get; set; }

        private DalContext db = new DalContext(); 

        private string lang = "FRA";

        public SelectList getAllCountry(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TCTRY, "CTRY_CD", "FRA_CTRY_NM", selectedValue));
            }
            else
            {
                return null;
            }
        }

        public string getCountryNameByCode(string ctry)
        {
            if (lang == "FRA")
            {
                return db.TCTRY.Find(ctry).FRA_CTRY_NM;
            }
            else
            {
                return null;
            }
        }

        public string getCountryThreeLetterByCode(string ctry)
        {
            return db.TCTRY.Find(ctry).CTRY_LTR_CD;
        }
    }
}