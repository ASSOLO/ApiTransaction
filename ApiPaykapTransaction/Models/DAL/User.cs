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
    [Table("dbo.TUSR")]
    public partial class User
    {
        public User()
        {
            TACCT = new HashSet<Account>();
            TCARD = new HashSet<Card>();
            TCRCY_XCHG_RT = new HashSet<CurrencyExchangeRate>();
            TBP_CTRCT = new HashSet<BusinessProcessContract>();
            TBUS_USR = new HashSet<BusinessUser>();
            TIP_ADDR = new HashSet<InternetProtocolAddress>();
            //TUSER_MBRSHP_FEE_PYMNT_TRANS = new HashSet<TUSER_MBRSHP_FEE_PYMNT_TRANS>();
            
            TEXCEPT_TRANS = new HashSet<ExceptionalTransaction>();
            TFI_EXRL_ACCT = new HashSet<FinancialInstitutionExternalAccount>();
            TFI_EXRL_ACCT1 = new HashSet<FinancialInstitutionExternalAccount>();
            TRCPT_USR_BUS = new HashSet<RecipientUserBusiness>();
            TRCPT_USR_BUS1 = new HashSet<RecipientUserBusiness>();
            TTRANS_TRSF_CRDT_DBT = new HashSet<TransactionTransferCreditDebit>();
            TTRANS_SSN = new HashSet<TransactionSession>();
            TTRANS_ID_DOC = new HashSet<TransactionIdentificationDocument>();
            TRCPT_BUS = new HashSet<RecipientBusiness>();
            TRCPT_BUS1 = new HashSet<RecipientBusiness>();
            TONBHLF_CLT_TRANS = new HashSet<OnBehalfClientTransaction>();
            TONBHLF_CLT_CMSN = new HashSet<OnBehalfClientCommission>();
            USR_MBRSHP_EDT = DateTime.Now;
            USR_VERIF_IND = "0";
            USR_99P_FRC_IND = "0";
            USR_BRDAY = Convert.ToDateTime("2000-01-01");
            USR_GNDR = "d";
            TAGNT = new HashSet<Agent>();
            TUSR_PHN_LGN = new HashSet<UserPhoneLogin>(); 
            USR_EMAIL_VRFT_IND = "0";
            USR_EMAIL_VRFT_DT = Convert.ToDateTime("2000-01-01");
        }
        
        public User(string userId)
        {
            USR_NBR = userId;
        }

        [Key]
        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Type Utilisateur")]
        public string USR_TCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(2, ErrorMessage = "Le {0} doit compter {2} caractères.")]
        [Display(Name = "Statut Utilisateur")]
        public string USR_SCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit être compris entre 1 et 100 caractères.", MinimumLength = 1)]
        [Display(Name = "Prénom")]
        public string USR_FNM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit être compris entre 1 et 100 caractères.", MinimumLength = 1)]
        [Display(Name = "Nom de famille")]
        public string USR_LNM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Genre")]
        public string USR_GNDR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Naissance")]
        public DateTime USR_BRDAY { get; set; }

        //[Required(ErrorMessage = "La {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Langue Préférée")]
        public string USR_PREF_LCD { get; set; }

        [Display(Name = "Contact Code")]
        public int USR_KTCT_ID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Utilisateur Univestisseur?")]
        public string USR_99P_FRC_IND { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Utilisateur Vérifié?")]
        public string USR_VERIF_IND { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date d'Adhésion")]
        public DateTime USR_MBRSHP_EDT { get; set; }

        [StringLength(128)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Utilisateur")]
        public string Id { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Defaut Mot de passe?")]
        public string USR_DFLT_PWD_IND { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Defaut email?")]
        public string USR_DFLT_EMAIL_IND { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Email Vérifié?")]
        public string USR_EMAIL_VRFT_IND { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Mise À Jour")]
        public DateTime USR_EMAIL_VRFT_DT { get; set; }

        //[Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le {0} doit être compris entre 1 et 100 caractères.", MinimumLength = 1)]
        [Display(Name = "Téléphone")]
        public string PHN1_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Prénom & Nom")]
        public string USR_FUL_NM
        { get
            {
                return USR_FNM + " " + USR_LNM;
            }
        }

        //public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Language TLANG { get; set; }
        public virtual Contact TKTCT { get; set; }
        public virtual ICollection<Account> TACCT { get; set; }
        public virtual ICollection<Card> TCARD { get; set; }
        public virtual ICollection<CurrencyExchangeRate> TCRCY_XCHG_RT { get; set; }
        public virtual ConnexionLog TCNX_LOG { get; set; }  
        public virtual ICollection<BusinessProcessContract> TBP_CTRCT { get; set; }
        public virtual ICollection<BusinessUser> TBUS_USR { get; set; }
        public virtual ICollection<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT { get; set; }
        public virtual ICollection<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT1 { get; set; }
        public virtual ICollection<InternetProtocolAddress> TIP_ADDR { get; set; }
        public virtual ICollection<ExceptionalTransaction> TEXCEPT_TRANS { get; set; }
        public virtual ICollection<RecipientUserBusiness> TRCPT_USR_BUS { get; set; }
        public virtual ICollection<RecipientUserBusiness> TRCPT_USR_BUS1 { get; set; }
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual UserWithdrawalCredit TUSR_WHDRL_CRDT { get; set; }
        public virtual ICollection<TransactionSession> TTRANS_SSN { get; set; }
        public virtual ICollection<TransactionIdentificationDocument> TTRANS_ID_DOC { get; set; }
        public virtual ICollection<Agent> TAGNT { get; set; }
        public virtual AgentSponsored TAGNT_SPNSRD { get; set; }
        public virtual ICollection<UserPhoneLogin> TUSR_PHN_LGN { get; set; }
        public virtual ICollection<RecipientBusiness> TRCPT_BUS { get; set; }
        public virtual ICollection<RecipientBusiness> TRCPT_BUS1 { get; set; }
        public virtual ICollection<OnBehalfClientTransaction> TONBHLF_CLT_TRANS { get; set; }
        public virtual ICollection<OnBehalfClientCommission> TONBHLF_CLT_CMSN { get; set; }

        private DalContext db = new DalContext();

        private string lang = "FRA";
        
        public User getUserByUsrNbr(string usrNbr)
        {
            try
            {
                var user = db.TUSR.Find(usrNbr);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        public User getUserByUserId(string userID)
        {
            try
            {
                var userList = db.TUSR.Where(x => x.Id == userID).ToList();
                if(userList.Count() != 1)
                {
                    return null;
                }
                var user = userList[0];
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        public bool checkIfUserAlreadyInvestorByUsrNbr(string usrNbr)
        {
            try
            {
                var user = db.TUSR.Find(usrNbr);
                if (user == null)
                {
                    return false;
                }
                if (user.USR_99P_FRC_IND == "0")
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateUserDefaultPasswordIndicator(string usrNbr)
        {
            try
            {
                var user = db.TUSR.Find(usrNbr);
                if (user == null)
                {
                    return false;
                }

                if (user.USR_DFLT_PWD_IND == "1")
                {
                    user.USR_DFLT_PWD_IND = "0";
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateUserDefaultEmailIndicator(string usrNbr)
        {
            try
            {
                var user = db.TUSR.Find(usrNbr);
                if (user == null)
                {
                    return false;
                }

                if (user.USR_DFLT_EMAIL_IND == "1")
                {
                    user.USR_DFLT_EMAIL_IND = "0";
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public SelectList getAllUser(string selectedValue)
        {
            return (new SelectList(db.TUSR, "USR_NBR", "USR_FUL_NM", selectedValue));
        }

        public string generateUserNumber()
        {
            var newUsrIdent = new UserIdentity();
            var usrIdent = newUsrIdent.generateLastPartUserNumber();
            if (usrIdent != null)
            {
                string usrNbr;
                if (usrIdent.USR_ID <= 999999999)
                {
                    usrNbr = "0" + Convert.ToString(usrIdent.USR_ID);
                    return usrNbr;
                }
                usrNbr = Convert.ToString(usrIdent.USR_ID);
                return usrNbr;
            }
            return null;
        }

        //public string generateUserNumber()
        //{
        //    int currentLength = db.TUSR.Count();
        //    if (currentLength != 0)
        //    {
        //        currentLength = currentLength + 1;
        //        string usrNbr = "0" + Convert.ToString(150705165 + currentLength);
        //        return usrNbr;
        //    }
        //    else { return "0150705165"; }
        //}

        public User createUser(string USR_NBR, string USR_TCD, string USR_SCD,
                                            string USR_FNM, string USR_LNM, string USR_GNDR, string USR_PREF_LCD,
                                            int KTCT_ID, string userId,
                                            string USR_VERIF_IND, string defaultPwdIND, string defaultEmailIND)
        {
            try
            {
                var newObj = new User();

                newObj.USR_NBR = USR_NBR;
                newObj.USR_TCD = USR_TCD;
                newObj.USR_SCD = USR_SCD;
                newObj.USR_FNM = USR_FNM;
                newObj.USR_LNM = USR_LNM;
                newObj.USR_GNDR = USR_GNDR;
                newObj.USR_PREF_LCD = USR_PREF_LCD;
                newObj.USR_KTCT_ID = KTCT_ID;
                newObj.USR_VERIF_IND = USR_VERIF_IND;
                newObj.Id = userId;
                newObj.USR_DFLT_PWD_IND = defaultPwdIND;
                newObj.USR_DFLT_EMAIL_IND = defaultEmailIND;
                return newObj;
            }
            catch
            {
                return null;
            }
        }
    }
}
