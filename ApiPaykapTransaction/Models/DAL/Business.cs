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
    [Table("dbo.TBUS")]
    public class Business
    {
        public Business()
        {
            TBP_CTRCT = new HashSet<BusinessProcessContract>();
            TBUS_AGCY = new HashSet<BusinessAgency>();
            TBUS_CMSN = new HashSet<BusinessCommission>();
            TRCPT_USR_BUS = new HashSet<RecipientUserBusiness>();
            TFI_EXRL_ACCT = new HashSet<FinancialInstitutionExternalAccount>();
            TBPCS = new HashSet<BillPaymentCreditor>();
            TRCPT_EXRL_ACCT_FOR_BUS = new HashSet<RecipientExternalAccountForBusiness>();
            BUS_AREA = "d";
            BUS_SCD = "1";
            TAGNT = new HashSet<Agent>();
            TAGNT_CMSN = new HashSet<AgentCommission>();
            TRCPT_BUS = new HashSet<RecipientBusiness>();
            TBUS_TY = new HashSet<BusinessType>();
            //TCARD_CAT_TY = new HashSet<CardCategoryType>();
            //TCARD_NBR_FST_4DIGT = new HashSet<CardNumberFirstFourDigit>();
            //TBUS_OFR_CARD_CTRCT = new HashSet<BusinessOfferingCardContract>();
            //TBUS_OFR_CARD_CTRCT1 = new HashSet<BusinessOfferingCardContract>();
            //TBUS_OFR_CARD_CHNG_LOG = new HashSet<BusinessOfferingCardChangeLog>();
            //TTRANS_APVL_STNG = new HashSet<TransactionApprovalSetting>();
        }

        [Key]
        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [Display(Name = "ID Contact")]
        public int KTCT_ID { get; set; }

        [Display(Name = "ID Compte")]
        public int ACCT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(30, ErrorMessage = "Le {0} doit compter au maximum 30 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Court Entreprise")]
        public string BUS_SHORT_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(60, ErrorMessage = "Le {0} doit compter au maximum 60 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Domaine d'activité")]
        public string BUS_AREA { get; set; }

        public int? CARD_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_SCD { get; set; }

        [Required]
        [StringLength(1)]
        public string DFLT_BUS_DSPL_IND { get; set; }
        private DalContext db = new DalContext();
        private string lang = "FRA";
        public virtual ICollection<BusinessType> TBUS_TY { get; set; }
        public virtual Card TCARD { get; set; }        
        public virtual Account TACCT { get; set; }
        public virtual ICollection<BusinessProcessContract> TBP_CTRCT { get; set; }
        public virtual Contact TKTCT { get; set; }
        public virtual ICollection<BusinessAgency> TBUS_AGCY { get; set; }
        public virtual ICollection<BusinessCommission> TBUS_CMSN { get; set; }
        public virtual ICollection<RecipientUserBusiness> TRCPT_USR_BUS { get; set; }
        public virtual ICollection<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT { get; set; }
        public virtual ICollection<BillPaymentCreditor> TBPCS { get; set; }
        public virtual ICollection<RecipientExternalAccountForBusiness> TRCPT_EXRL_ACCT_FOR_BUS { get; set; }
        public virtual ICollection<Agent> TAGNT { get; set; }
        public virtual ICollection<AgentCommission> TAGNT_CMSN { get; set; }
        public virtual ICollection<RecipientBusiness> TRCPT_BUS { get; set; }
        //public virtual ICollection<CardCategoryType> TCARD_CAT_TY { get; set; }
        //public virtual ICollection<CardNumberFirstFourDigit> TCARD_NBR_FST_4DIGT { get; set; }
        //public virtual ICollection<BusinessOfferingCardContract> TBUS_OFR_CARD_CTRCT { get; set; }
        //public virtual ICollection<BusinessOfferingCardContract> TBUS_OFR_CARD_CTRCT1 { get; set; }
        //public virtual ICollection<BusinessOfferingCardChangeLog> TBUS_OFR_CARD_CHNG_LOG { get; set; }
        //public virtual ICollection<TransactionApprovalSetting> TTRANS_APVL_STNG { get; set; }

        public Business createBusiness(int KTCT_ID, int ACCT_ID, int CARD_ID,
                                       string busNM, string busShortNM, string busArea, string USR_NBR)
        {
            var newObj = new Business();

            newObj.KTCT_ID = KTCT_ID;
            newObj.ACCT_ID = ACCT_ID;
            newObj.BUS_NM = busNM;
            newObj.BUS_SHORT_NM = busShortNM.ToUpper();
            newObj.BUS_AREA = busArea;
            newObj.CARD_ID = CARD_ID;
            newObj.DFLT_BUS_DSPL_IND = "1";
            return newObj;
        }

        public Business getBusinessByBN(int? bn)
        {
            var busList = db.TBUS.Where(x => x.BN == bn && x.BUS_SCD == "1").ToList();
            return returnBusiness(busList);
        }

        public Business getBusinessByAcctID(int acctID)
        {
            var busList = db.TBUS.Where(x => x.ACCT_ID == acctID && x.BUS_SCD == "1").ToList();
            return returnBusiness(busList);
        }

        public Business getBusinessByCardID(int cardID)
        {
            var busList = db.TBUS.Where(x => x.CARD_ID == cardID && x.BUS_SCD == "1").ToList();
            return returnBusiness(busList);
        }

        private Business returnBusiness(List<Business> busList)
        {
            if (busList.Count() != 1)
            {
                return null;
            }

            var bus = busList[0];
            return bus;
        }

        public Business getDefaultBusinessByManagerUsrNbr(string USR_NBR)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == USR_NBR &&
                                                    x.BUS_USR_TCD == "04" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in busUsrList)
                {
                    var bus = getDefaultBusinessByBN(item.BN);
                    if (bus != null)
                    {
                        return bus;
                    }
                }
                return null;
            }
        }

        public Business getDefaultBusinessByBN(int BN)
        {
            var busList = db.TBUS.Where(x => x.BN == BN && x.BUS_SCD == "1" && x.DFLT_BUS_DSPL_IND == "1").ToList();
            return returnBusiness(busList);
        }

        public List<Business> getAllBusinessByManagerUsrNbr(string USR_NBR)
        {
            List<Business> items = new List<Business>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == USR_NBR && 
                                                    x.BUS_USR_TCD == "04" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }
            else
            {
                foreach (var item in busUsrList)
                {
                    var bus = getBusinessByBN(item.BN);
                    if(bus != null)
                    {
                        items.Add(bus);
                    }
                }
                return items;
            }
        }

        public List<SelectListItem> getAllBusinessByManagerUsrNbr(string USR_NBR, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busList = getAllBusinessByManagerUsrNbr(USR_NBR);

            if (busList.Count() == 0)
            {
                return items;
            }
            return new SelectList(busList, "BN", "BUS_NM", selectedValue).ToList();
        }

        public bool checkThisManagerHasDefaultBusiness(string USR_NBR)
        {
            var bus = getDefaultBusinessByManagerUsrNbr(USR_NBR);
            if (bus != null)
            {
                return true;
            }
            return false;
        }

        public string setDefaultBusiness(int BN)
        {
            var dfltBus = getDefaultBusinessByBN(BN);
            if(dfltBus != null)
            {
                return "already_default";
            }

            var bus = getBusinessByBN(BN);
            if (bus == null)
            {
                return null;
            }

            bus.DFLT_BUS_DSPL_IND = "1";
            db.Entry(bus).State = EntityState.Modified;
            db.SaveChanges();
            return "true";
        }

        public SelectList getAllBusiness(string selectedValue)
        {
            return new SelectList(db.TBUS.OrderBy(y => y.BUS_NM), "BN", "BUS_NM", selectedValue);
        }

        public SelectList getAllBusinessForAcctID(string selectedValue)
        {
            return new SelectList(db.TBUS.OrderBy(y => y.BUS_NM), "ACCT_ID", "BUS_NM", selectedValue);
        }
    }
}