namespace ApiPaykapTransaction.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("dbo.TCRCY")]
    public partial class Currency
    {
        public Currency()
        {
            TCRCY_XCHG_RT = new HashSet<CurrencyExchangeRate>();
            TCRCY_XCHG_RT1 = new HashSet<CurrencyExchangeRate>();
            TMNYT_AUTH_LMIT = new HashSet<MoneyTransferAuthorizedLimit>();
            TACCT = new HashSet<Account>();
            TBUS_CMSN = new HashSet<BusinessCommission>();
            TBUS_CMSN_TRANS = new HashSet<BusinessCommissionTransaction>();
            TTRANS_TRSF_CRDT_DBT = new HashSet<TransactionTransferCreditDebit>();
            TTRANS_TRSF_CRDT_DBT1 = new HashSet<TransactionTransferCreditDebit>();
            TFI_EXRL_ACCT = new HashSet<FinancialInstitutionExternalAccount>();
            TTRANS_FEE = new HashSet<TransactionFee>();
            TTRANS_FEE1 = new HashSet<TransactionFee>();
            TCTRY_CRCY = new HashSet<CountryCurrency>();
            TBUS_CTRY_FEE = new HashSet<BusinessFee>();
            TAGNT_PKP_CMSN = new HashSet<AgentPayKapCommission>();
            TONBHLF_CLT_TRANS = new HashSet<OnBehalfClientTransaction>();
            TONBHLF_CLT_CMSN = new HashSet<OnBehalfClientCommission>();
        }
        
        [Key]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caract�res.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Fran�ais")]
        public string CRCY_FRA_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Anglais")]
        public string CRCY_ENG_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Espagnol")]
        public string CRCY_SPA_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Arabe")]
        public string CRCY_ARB_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Portugais")]
        public string CRCY_POR_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Chinois")]
        public string CRCY_ZHO_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Russe")]
        public string CRCY_RUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Allemand")]
        public string CRCY_DEU_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au maximum 100 caract�res.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Italien")]
        public string CRCY_ITA_NM { get; set; }
        
        public virtual ICollection<CurrencyExchangeRate> TCRCY_XCHG_RT { get; set; }
        public virtual ICollection<CurrencyExchangeRate> TCRCY_XCHG_RT1 { get; set; }
        public virtual ICollection<MoneyTransferAuthorizedLimit> TMNYT_AUTH_LMIT { get; set; }
        public virtual ICollection<Account> TACCT { get; set; }
        public virtual ICollection<BusinessCommission> TBUS_CMSN { get; set; }
        public virtual ICollection<BusinessCommissionTransaction> TBUS_CMSN_TRANS { get; set; }
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT1 { get; set; }
        public virtual ICollection<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT { get; set; }
        public virtual ICollection<TransactionFee> TTRANS_FEE { get; set; }
        public virtual ICollection<TransactionFee> TTRANS_FEE1 { get; set; }
        public virtual ICollection<CountryCurrency> TCTRY_CRCY { get; set; }
        public virtual ICollection<BusinessFee> TBUS_CTRY_FEE { get; set; }
        public virtual ICollection<AgentPayKapCommission> TAGNT_PKP_CMSN { get; set; }
        public virtual ICollection<OnBehalfClientTransaction> TONBHLF_CLT_TRANS { get; set; }
        public virtual ICollection<OnBehalfClientCommission> TONBHLF_CLT_CMSN { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";

        public SelectList getAllCurrency(string selectedValue)
        {
            if (lang == "FRA")
            {
                return (new SelectList(db.TCRCY, "CRCY_CD", "CRCY_FRA_NM", selectedValue));
            }
            else
            {
                return null;
            }
        }

        public string getCurrencyNameByCode(string crcy)
        {
            if (lang == "FRA")
            {
                return db.TCRCY.Find(crcy).CRCY_FRA_NM;
            }
            else
            {
                return null;
            }
        }
    }
}
