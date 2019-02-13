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
    [Table("dbo.TACCT")]
    public class Account
    { 
        
        public Account()
        {
            TACCT_HIST = new HashSet<AccountHistory>();
            TBUS_USR = new HashSet<BusinessUser>();
            TBUS_AGCY = new HashSet<BusinessAgency>();
            TBUS = new HashSet<Business>();
            TRCPT_USR_BUS = new HashSet<RecipientUserBusiness>();
            TBPCS = new HashSet<BillPaymentCreditor>();
            TUSR_PHN_LGN = new HashSet<UserPhoneLogin>();
            TRCPT_BUS = new HashSet<RecipientBusiness>();
            //TCARD_CAT = new HashSet<CardCategory>();
            TACCT_BUS_SRVC = new HashSet<AccountBusinessService>();
            //PKP_ACCT_TRSF_TRANS = new HashSet<PayKapAccountTransferTransaction>();
            //PKP_ACCT_TRSF_TRANS1 = new HashSet<PayKapAccountTransferTransaction>();
        }

        [Key]
        [Display(Name = "Compte ID")]
        public int ACCT_ID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Compte")]
        public string ACCT_TCD { get; set; }  //1 = client, 2 = business, 3 = paykap

        [Required(ErrorMessage = "La dévise de compte est obligatoire.")]
        [StringLength(3)]
        [DataType(DataType.Text)]
        [Display(Name = "Dévise Compte")]
        public string CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le statut de compte est obligatoire.")]
        [StringLength(2)]
        [DataType(DataType.Text)]
        [Display(Name = "Statut Compte")]
        public string ACCT_SCD { get; set; }

        [Required(ErrorMessage = "Le numéro de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Le numéro de compte doit avoir entre 3 et 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Numéro Compte")]
        public string ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le nom de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Le nom de compte doit avoir entre 3 et 30 caractères.", MinimumLength = 3)]
        [Display(Name = "Nom Compte")]
        public string ACCT_NAME { get; set; }

        [Required(ErrorMessage = "Le solde de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Solde Compte")]
        public decimal ACCT_BAL { get; set; }

        [Required]
        [StringLength(5)]
        [DataType(DataType.Text)]
        [Display(Name = "CultureInfo Compte")]
        public string ACCT_CLTR_INFO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Création")]
        public DateTime ACCT_CDT { get; set; }

        [Required]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Compte Supprimé Logiquement?")]
        public string LGC_DEL_IND { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Propriétaire Compte")]
        public string USR_NBR { get; set; }

        [Display(Name = "Solde Compte Positif?")]
        public bool CHECK_ACCT_BAL
        {
            get
            {
                if (ACCT_BAL > 0.0m)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public virtual Currency TCRCY { get; set; }
        public virtual User TUSR { get; set; }
        public virtual ICollection<AccountHistory> TACCT_HIST { get; set; }
        public virtual ICollection<BusinessUser> TBUS_USR { get; set; }
        public virtual ICollection<BusinessAgency> TBUS_AGCY { get; set; }
        public virtual ICollection<Business> TBUS { get; set; }
        public virtual ICollection<RecipientUserBusiness> TRCPT_USR_BUS { get; set; }
        public virtual ICollection<BillPaymentCreditor> TBPCS { get; set; }
        public virtual AccountBusinessAgentCommission TACCT_BUS_AGNT_CMSN { get; set; }
        public virtual AccountCredit TACCT_CRDT { get; set; }
        public virtual ICollection<UserPhoneLogin> TUSR_PHN_LGN { get; set; }
        public virtual ICollection<RecipientBusiness> TRCPT_BUS { get; set; }
        public virtual ICollection<AccountBusinessService> TACCT_BUS_SRVC { get; set; }

        public Account getAccountByAcctID(int acctID)
        {
            var acctList = db.TACCT.Where(x => x.ACCT_ID == acctID && x.ACCT_SCD == "01").ToList();
            return returnAccount(acctList);
        }

        public Account createNewClientAccount(string usrNbr, string ctryCD, string crcyCD, string langCD, string clientTCD)
        {
            var newAcct = new Account();
            var ctryCrcy = new CountryCurrency();
            var newAcctIdent = new AccountIdentity();
            try
            {
                var acctIdent = newAcctIdent.generateLastPartAccountNumber();
                if ((clientTCD != "1" && clientTCD != "3") || acctIdent == null)
                {
                    return null;
                }

                //get param
                string acctNbr = null;
                string ACCT_TCD = null;
                string ACCT_NAME = null;
                string acctCrcyCD = null;
                string acctCulInfo = null;
                string lastPartAcctNbr = Convert.ToString(acctIdent.ACCT_ID);

                if (clientTCD == "1")
                {
                    ACCT_TCD = "1";
                    //currentLength = db.TACCT.Where(x => x.ACCT_TCD == ACCT_TCD && x.ACCT_NBR.StartsWith(ctryCD)).ToList().Count();
                    acctNbr = ctryCD + "C" + lastPartAcctNbr;
                    ACCT_NAME = "Compte Courant Particulier";

                    acctCrcyCD = ctryCrcy.getCurrencyByCountry(ctryCD);
                    acctCulInfo = ctryCrcy.getCultureInfoByCountryAndLanguage(ctryCD, langCD);
                }

                if (clientTCD == "3")
                {
                    ACCT_TCD = "3";
                    //currentLength = db.TACCT.Where(x => x.ACCT_TCD == ACCT_TCD && x.ACCT_NBR.StartsWith(ctryCD)).ToList().Count();
                    acctNbr = ctryCD + "X" + lastPartAcctNbr;
                    ACCT_NAME = "Compte Carte Particulier";

                    acctCrcyCD = crcyCD;
                    acctCulInfo = ctryCrcy.getCultureInfoByCurrencyCD(crcyCD, langCD);
                }

                if (string.IsNullOrWhiteSpace(acctNbr) || acctNbr.Length != 12 ||
                    string.IsNullOrWhiteSpace(acctCrcyCD) || string.IsNullOrWhiteSpace(acctCulInfo))
                { throw new Exception(); }

                newAcct.ACCT_TCD = ACCT_TCD;
                newAcct.CRCY_CD = acctCrcyCD;
                newAcct.ACCT_SCD = "01";
                newAcct.ACCT_NBR = acctNbr;
                newAcct.ACCT_NAME = ACCT_NAME;
                newAcct.ACCT_BAL = 0.0m;
                newAcct.ACCT_CLTR_INFO = acctCulInfo;
                newAcct.LGC_DEL_IND = "0";
                newAcct.USR_NBR = usrNbr;
                newAcct.ACCT_CDT = DateTime.Now;
                return newAcct;
            }
            catch
            {
                return null;
            }
        }

        public Account createNewBusinessAgencyAccount(int bn, string adminUserNBR, string langCD)
        {
            try
            {
                var newAcct = new Account();
                var bus = db.TBUS.Find(bn);
                if (bus == null)
                {
                    return null;
                }

                //get Account currency
                var acct = db.TACCT.Find(bus.ACCT_ID);
                if (acct == null)
                {
                    return null;
                }
                string crcyCD = acct.CRCY_CD;
                string busAcctNbr = acct.ACCT_NBR;
                string ctryCD = busAcctNbr.Substring(9, 3);
                string acctCulInfo = acct.ACCT_CLTR_INFO;
                //generate client account number
                int currentLength = db.TBUS_AGCY.Where(x => x.BN == bn).Count();

                string acctNbr = bn + "" + ctryCD + CommonLibrary.generateStringCode(5, currentLength);
                if (string.IsNullOrWhiteSpace(acctNbr) || acctNbr.Length != 17) { throw new Exception(); }

                newAcct.ACCT_TCD = "2";
                newAcct.CRCY_CD = crcyCD;
                newAcct.ACCT_SCD = "01";
                newAcct.ACCT_NBR = acctNbr;
                newAcct.ACCT_NAME = "Compte Courant Affaire";
                newAcct.ACCT_BAL = 0.0m;
                newAcct.ACCT_CLTR_INFO = acctCulInfo;
                newAcct.LGC_DEL_IND = "0";
                newAcct.USR_NBR = adminUserNBR;
                newAcct.ACCT_CDT = DateTime.Now;
                return newAcct;
            }
            catch
            {
                return null;
            }
        }

        public Account createNewBusinessAccount(string userNBR, string ctryCD, string langCD)
        {
            try
            {
                var newAcct = new Account();
                var ctryCrcy = new CountryCurrency();
                //get Account currency
                string crcyCD = ctryCrcy.getCurrencyByCountry(ctryCD);
                if (string.IsNullOrWhiteSpace(crcyCD)) { throw new Exception(); }

                //add the date and to avoid duplicate value of ACCT_NBR before updating
                int dtSecond = DateTime.Now.Second;
                int dtMillisecond = DateTime.Now.Millisecond;
                string acctNbr = string.Concat(ctryCD, "00000", dtSecond, dtMillisecond);

                //get Account Culture Info
                string acctCulInfo = ctryCrcy.getCultureInfoByCountryAndLanguage(ctryCD, langCD);
                if (string.IsNullOrWhiteSpace(acctCulInfo)) { throw new Exception(); }

                newAcct.ACCT_TCD = "2";
                newAcct.CRCY_CD = crcyCD;
                newAcct.ACCT_SCD = "01";
                newAcct.ACCT_NBR = acctNbr;
                newAcct.ACCT_NAME = "Compte Courant Affaire";
                newAcct.ACCT_BAL = 0.0m;
                newAcct.ACCT_CLTR_INFO = acctCulInfo;
                newAcct.LGC_DEL_IND = "0";
                newAcct.USR_NBR = userNBR;
                newAcct.ACCT_CDT = DateTime.Now;
                return newAcct;
            }
            catch
            {
                return null;
            }
        }

        //immediately update the new account number to add the bn number
        public Account updateNewBusinessAccount(int bn, int acctID)
        {
            try
            {
                var newAcct = db.TACCT.Find(acctID);
                if (newAcct == null)
                {
                    return null;
                }
                string acctNbr = newAcct.ACCT_NBR.Substring(0, 8);
                string strBN = Convert.ToString(bn);
                newAcct.ACCT_NBR = string.Concat(strBN, acctNbr);
                if (string.IsNullOrWhiteSpace(newAcct.ACCT_NBR) || newAcct.ACCT_NBR.Length != 17)
                {
                    return null;
                }

                db.Entry(newAcct).State = EntityState.Modified;
                db.SaveChanges();
                return newAcct;
            }
            catch
            {
                return null;
            }
        }

        public Account createNewBusinessUserAccount(int bn, string busAgcyNbr, string userNBR, string ctryCD, string langCD)
        {
            try
            {
                var newAcct = new Account();
                var ctryCrcy = new CountryCurrency();
                //get Account currency
                string crcyCD = ctryCrcy.getCurrencyByCountry(ctryCD);
                if (string.IsNullOrWhiteSpace(crcyCD)) { throw new Exception(); }

                //generate client account number
                var busAgcyList = db.TBUS_AGCY.Where(x => x.BN == bn && x.BUS_AGCY_NBR == busAgcyNbr).ToList();
                if (busAgcyList.Count() == 0)
                {
                    return null;
                }
                var busAgcy = busAgcyList[0];

                //find agency account
                var busAcct = db.TACCT.Find(busAgcy.BUS_AGCY_ACCT_ID);
                if (busAcct == null)
                {
                    return null;
                }

                int currentLength = db.TBUS_USR.Where(x => x.BN == bn && x.BUS_AGCY_NBR == busAgcyNbr).Count();
                if (busAgcyList.Count() == 0)
                {
                    return null;
                }

                string acctNbr = busAcct.ACCT_NBR + CommonLibrary.generateStringCode(3, currentLength);
                if (string.IsNullOrWhiteSpace(acctNbr) || acctNbr.Length != 20) { throw new Exception(); }

                //get Account Culture Info
                string acctCulInfo = ctryCrcy.getCultureInfoByCountryAndLanguage(ctryCD, langCD);
                if (string.IsNullOrWhiteSpace(acctCulInfo)) { throw new Exception(); }

                newAcct.ACCT_TCD = "2";
                newAcct.CRCY_CD = crcyCD;
                newAcct.ACCT_SCD = "01";
                newAcct.ACCT_NBR = acctNbr;
                newAcct.ACCT_NAME = "Compte Courant Affaire";
                newAcct.ACCT_BAL = 0.0m;
                newAcct.ACCT_CLTR_INFO = acctCulInfo;
                newAcct.LGC_DEL_IND = "0";
                newAcct.USR_NBR = userNBR;
                newAcct.ACCT_CDT = DateTime.Now;
                return newAcct;
            }
            catch
            {
                return null;
            }
        }

        public string generateCardCvvCD(int currentLength)
        {
            if (currentLength != 0)
            {
                currentLength += 1;
                int intModulo = (currentLength % 8999) + 1;
                string strLength = intModulo.ToString();
                if (strLength.Length == 1) { return "100" + strLength; }
                else if (strLength.Length == 2) { return "10" + strLength; }
                else if (strLength.Length == 3) { return "1" + strLength; }
                else
                {
                    int fourDigitLength = intModulo + 1000;
                    return Convert.ToString(fourDigitLength);
                }
            }
            else { return "1001"; }
        }

        public string formatAccountNumber(string acctNbr, string usrTCD)
        {
            if (usrTCD == "2")  // 2 = client
            {
                if (acctNbr.Length != 12)
                {
                    return null;
                }
                string part1, part2, part3;
                part1 = acctNbr.Substring(0, 3);
                part2 = acctNbr.Substring(3, 1);
                part3 = acctNbr.Substring(4, 8);
                return part1 + " " + part2.ToUpper() + " " + part3;
            }
            else if (usrTCD == "3" || usrTCD == "4" || usrTCD == "5")  // 3 = cashier // 4 = agence   5 = Company
            {
                if (acctNbr.Length == 20)
                {
                    string part1, part2, part3, part4;
                    part1 = acctNbr.Substring(0, 9);
                    part2 = acctNbr.Substring(9, 3);
                    part3 = acctNbr.Substring(12, 5);
                    part4 = acctNbr.Substring(17, 3);
                    return part1 + " " + part2 + " " + part3 + " " + part4;
                }
                else if (acctNbr.Length == 17)
                {
                    string part1, part2, part3;
                    part1 = acctNbr.Substring(0, 9);
                    part2 = acctNbr.Substring(9, 3);
                    part3 = acctNbr.Substring(12, 5);
                    return part1 + " " + part2 + " " + part3;
                }
            }
            return null;
        }

        public string formatAccountCommissionNumber(string acctNbr, string acctTCD)
        {
            if (acctTCD == "1")  // 1 = client
            {
                if (acctNbr.Length != 14)
                {
                    return null;
                }
                string part1, part2, part3, part4, part5;
                part1 = acctNbr.Substring(0, 3);
                part2 = acctNbr.Substring(3, 1);
                part3 = acctNbr.Substring(4, 8);
                part4 = acctNbr.Substring(12, 1);
                part5 = acctNbr.Substring(13, 1);
                return part1 + " " + part2.ToUpper() + " " + part3 + " " + part4 + "" + part5.ToUpper();
            }
            else if (acctTCD == "2")  // 2 = business
            {
                if (acctNbr.Length != 19)
                {
                    return null;
                }
                string part1, part2, part3, part4, part5;
                part1 = acctNbr.Substring(0, 9);
                part2 = acctNbr.Substring(9, 3);
                part3 = acctNbr.Substring(12, 5);
                part4 = acctNbr.Substring(17, 1);
                part5 = acctNbr.Substring(18, 1);
                return part1 + " " + part2.ToUpper() + " " + part3 + " " + part4 + "" + part5.ToUpper();
            }
            return null;
        }

        public string getCountryAccountCommissionNumber(string acctNbr, string acctTCD)
        {
            if (acctTCD == "1")  // 1 = client
            {
                if (acctNbr.Length != 14)
                {
                    return null;
                }
                return acctNbr.Substring(0, 3);
            }
            else if (acctTCD == "2")  // 2 = business
            {
                if (acctNbr.Length != 19)
                {
                    return null;
                }
                return acctNbr.Substring(9, 3);
            }
            return null;
        }

        public string getCountryAccountNumber(string acctNbr, string usrTCD)
        {
            if (usrTCD == "2")  // 2 = client
            {
                if (acctNbr.Length != 12)
                {
                    return null;
                }
                return acctNbr.Substring(0, 3);
            }
            if (usrTCD == "3" || usrTCD == "4" || usrTCD == "5")  // 3 = cashier   4 = agence   5 = Company
            {
                if (acctNbr.Length != 20 && acctNbr.Length != 17)
                {
                    return null;
                }
                return acctNbr.Substring(9, 3);
            }
            return null;
        }

        public List<SelectListItem> getUserAccountList(string usrNbr, string usrTCD, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr && x.ACCT_TCD == "1" && x.ACCT_SCD == "01").ToList();
            if (acctList.Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in acctList)
                {
                    string bal = CommonLibrary.displayFormattedCurrency(item.ACCT_BAL, item.ACCT_CLTR_INFO);
                    item.ACCT_NBR = formatAccountNumber(item.ACCT_NBR, usrTCD) + " - " + item.CRCY_CD.ToUpper() + " = " + bal;
                }

                var list = new SelectList(acctList, "ACCT_ID", "ACCT_NBR", selectedValue).ToList();
                return list;
            }
        }

        public List<SelectListItem> getUserPayKapBankAccountList(string usrNbr, string usrTCD, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr && x.ACCT_TCD == "1" && x.ACCT_SCD == "01").ToList();
            var myList = db.TFI_EXRL_ACCT.Where(x => x.USR_NBR == usrNbr && x.EXRL_ACCT_FOR_CURT_USR_IND == "1").ToList();

            if (acctList.Count() == 0 && myList.Count() == 0)
            {
                return items;
            }

            if (acctList.Count() != 0)
            {
                items.Add(new SelectListItem { Text = "-------Mon compte PayKap-----------------", Value = "" });
                foreach (var item in acctList)
                {
                    string bal = CommonLibrary.displayFormattedCurrency(item.ACCT_BAL, item.ACCT_CLTR_INFO);
                    item.ACCT_NBR = formatAccountNumber(item.ACCT_NBR, usrTCD) + " - " + item.CRCY_CD.ToUpper() + " = " + bal;
                    string strACCT_ID = "PKP" + Convert.ToString(item.ACCT_ID);
                    if (strACCT_ID == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = item.ACCT_NBR, Value = strACCT_ID, Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = item.ACCT_NBR, Value = strACCT_ID, Selected = false });
                    }
                }
                //var list = new SelectList(acctList, "ACCT_ID", "ACCT_NBR", selectedValue).ToList();
            }

            if (myList.Count() != 0)
            {
                items.Add(new SelectListItem { Text = "", Value = "" });
                items.Add(new SelectListItem { Text = "-------Mes comptes bancaires-------------", Value = "" });
                foreach (var item in myList)
                {
                    item.RCPT_USR_BUS_NM = item.EXRL_ACCT_NBR + " - " + item.CRCY_CD;
                    string strEXRL_ACCT_ID = Convert.ToString(item.EXRL_ACCT_ID);
                    if (strEXRL_ACCT_ID == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = item.RCPT_USR_BUS_NM, Value = strEXRL_ACCT_ID, Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = item.RCPT_USR_BUS_NM, Value = strEXRL_ACCT_ID, Selected = false });
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getBusinessOnlineBankAccountList(string usrNbr, string usrTCD, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr && x.ACCT_TCD == "2" && x.ACCT_SCD == "01").ToList();
            if (acctList.Count() == 0)
            {
                return items;
            }
            var acct = acctList[0];
            int bn = Convert.ToInt32(acct.ACCT_NBR.Substring(0, 9));

            var myList = from bankAcct in db.TFI_EXRL_ACCT
                         join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                         where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "1" &&
                                bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.USR_NBR == usrNbr)
                         select bankAcct;

            if (acctList.Count() != 0)
            {
                items.Add(new SelectListItem { Text = "-------Compte PayKap Affaire-----------------", Value = "" });
                foreach (var item in acctList)
                {
                    string bal = CommonLibrary.displayFormattedCurrency(item.ACCT_BAL, item.ACCT_CLTR_INFO);
                    item.ACCT_NBR = formatAccountNumber(item.ACCT_NBR, usrTCD) + " - " + item.CRCY_CD.ToUpper() + " = " + bal;
                    string strACCT_ID = "PKP" + Convert.ToString(item.ACCT_ID);
                    if (strACCT_ID == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = item.ACCT_NBR, Value = strACCT_ID, Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = item.ACCT_NBR, Value = strACCT_ID, Selected = false });
                    }
                }
                //var list = new SelectList(acctList, "ACCT_ID", "ACCT_NBR", selectedValue).ToList();
            }

            if (myList.Count() != 0)
            {
                items.Add(new SelectListItem { Text = "", Value = "" });
                items.Add(new SelectListItem { Text = "-------Comptes bancaires Affaire-------------", Value = "" });
                foreach (var item in myList)
                {
                    item.RCPT_USR_BUS_NM = item.EXRL_ACCT_NBR + " - " + item.CRCY_CD;
                    string strEXRL_ACCT_ID = Convert.ToString(item.EXRL_ACCT_ID);
                    if (strEXRL_ACCT_ID == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = item.RCPT_USR_BUS_NM, Value = strEXRL_ACCT_ID, Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = item.RCPT_USR_BUS_NM, Value = strEXRL_ACCT_ID, Selected = false });
                    }
                }
            }
            return items;
        }

        public Account getAccountByAcctNbr(string acctNbr, string acctTCD)
        {
            var acctList = db.TACCT.Where(x => x.ACCT_NBR == acctNbr && x.ACCT_TCD == acctTCD && x.ACCT_SCD == "01").ToList();
            return returnAccount(acctList);
        }

        public Account getAccountByUsrNbr(string usrNbr, string acctTCD)
        {
            var acctList = db.TACCT.Where(x => x.USR_NBR == usrNbr && x.ACCT_TCD == acctTCD && x.ACCT_SCD == "01").ToList();
            return returnAccount(acctList);
        }

        private Account returnAccount(List<Account> acctList)
        {
            if (acctList.Count() != 1)
            {
                return null;
            }

            var acct = acctList[0];
            return acct;
        }

        public User getUserByAccountId(int acctID)
        {
            var acct = getAccountByAcctID(acctID);
            if (acct == null)
            {
                return null;
            }
            var user = db.TUSR.Find(acct.USR_NBR);
            return user;
        }

        public Account getBusinessAccountManagerByUsrNbr(string usrNbr)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "04" && x.BUS_USR_TCD == "04").ToList();
            if (busUsrList.Count() == 0)
            {
                return null;
            }

            var busUsr = busUsrList[0];
            if (busUsr == null)
            {
                return null;
            }

            var busAcct = getAccountByAcctID(busUsr.BUS_ACCT_ID);
            return busAcct;
        }

        public decimal creditTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getAccountByAcctID(acctID);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }

            return acct.ACCT_BAL + amt;
        }

        public decimal debitTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getAccountByAcctID(acctID);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }

            decimal currentBal = acct.ACCT_BAL;
            decimal newBal = currentBal - amt;
            if (newBal < 0.0m)
            {
                return -2.0m;
            }
            return acct.ACCT_BAL - amt;
        }

        public decimal debitBusinessTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getAccountByAcctID(acctID);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }
            return acct.ACCT_BAL - amt;
        }

        public decimal getNegativeDifferenceBalanceForTransaction(int acctID, decimal amt, string crcyCD)
        {
            var acct = getAccountByAcctID(acctID);
            if (acct == null)
            {
                return -1.0m;
            }

            if (acct.CRCY_CD != crcyCD)
            {
                return -1.0m;
            }

            decimal currentBal = acct.ACCT_BAL;
            decimal negativeBal = currentBal - amt;
            return negativeBal;
        }


      /*  public CreditDebitTransactionViewModel debitCreditTransaction(int fromAcctID, decimal fromAmt, string fromCrcyCD,
                                                                      int toAcctID, decimal toAmt, string toCrcyCD)
        {
            var model = new CreditDebitTransactionViewModel();
            var fromAcct = getAccountByAcctID(fromAcctID);
            var toAcct = getAccountByAcctID(toAcctID);
            if (fromAcct == null || toAcct == null)
            {
                model.TRANS_ERROR_CD = "gen_error";
            }

            if (fromAcct.CRCY_CD != fromCrcyCD || toAcct.CRCY_CD != toCrcyCD)
            {
                model.TRANS_ERROR_CD = "crcy_error";
            }

            decimal fromCurrentBal = fromAcct.ACCT_BAL;
            decimal fromNewBal = fromCurrentBal - fromAmt;
            if (fromNewBal < 0.0m)
            {
                model.TRANS_ERROR_CD = "bal_error";
            }
            fromNewBal = fromAcct.ACCT_BAL - fromAmt;

            decimal toNewBal = toAcct.ACCT_BAL + toAmt;

            model.FROM_NEW_ACCT_BAL = fromNewBal;
            model.TO_NEW_ACCT_BAL = toNewBal;
            return model;
        }  */

        public Account updateAccountBal(int acctID, decimal newAcctBal)
        {
            var updAcct = getAccountByAcctID(acctID);
            if (updAcct == null)
            {
                return null;
            }
            updAcct.ACCT_BAL = newAcctBal;
            //db.Entry(updAcct).State = EntityState.Modified;
            return updAcct;
        }

        
    }
}