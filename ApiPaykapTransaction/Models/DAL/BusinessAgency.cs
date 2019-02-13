using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBUS_AGCY")]
    public class BusinessAgency
    {
        public BusinessAgency()
        {
            TIP_ADDR = new HashSet<InternetProtocolAddress>();
            TBUS_USR = new HashSet<BusinessUser>();
            TBUS_USR_EXCP_ROL = new HashSet<BusinessUserExceptionalRole>();
            BUS_AGCY_HDQRTR_IND = "0";
            BUS_AGCY_INTRNT_CHK_IND = "1";
            BUS_AGCY_MXAMT_TO_WDRW_AMT = 0.0m;
            BUS_AGCY_AV_AMT = 0.0m;
            TBUS_AGCY_SRVC = new HashSet<BusinessAgencyService>();
        }

        [Key]
        [Column(Order = 0)]
        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5, ErrorMessage = "Le numéro d'agence doit avoir 5 caractères.", MinimumLength = 5)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Agence")]
        public string BUS_AGCY_NBR { get; set; }

        [StringLength(200, ErrorMessage = "Le nom d'agence doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Nom Agence")]
        public string BUS_AGCY_NM { get; set; }

        [Display(Name = "Contact Code")]
        public int BUS_AGCY_KTCT_ID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Agence Siège Social?")]
        public string BUS_AGCY_HDQRTR_IND { get; set; }

        [Display(Name = "ID Compte")]
        public int BUS_AGCY_ACCT_ID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Agence Internet?")]
        public string BUS_AGCY_INTRNT_CHK_IND { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Max à Retirer")]
        public decimal BUS_AGCY_MXAMT_TO_WDRW_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Disponible")]
        public decimal BUS_AGCY_AV_AMT { get; set; }

        [StringLength(500, ErrorMessage = "La description des heures d'ouverture nom d'agence doit avoir 500 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La description des heures d'ouverture est obligatoire.")]
        [Display(Name = "Description Heures Ouverture")]
        public string BUS_AGCY_OPNNG_HR { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_AGCY_NO_SRVC_AV_IND { get; set; }

        public virtual Account TACCT { get; set; }
        public virtual Business TBUS { get; set; }
        public virtual Contact TKTCT { get; set; }
        public virtual ICollection<InternetProtocolAddress> TIP_ADDR { get; set; }
        public virtual ICollection<BusinessUser> TBUS_USR { get; set; }
        public virtual ICollection<BusinessUserExceptionalRole> TBUS_USR_EXCP_ROL { get; set; }
        public virtual ICollection<BusinessAgencyService> TBUS_AGCY_SRVC { get; set; }
        private DalContext db = new DalContext();

        public BusinessAgency createBusinessAgency(int BN, int KTCT_ID, int ACCT_ID, string busAgcyNM, string headQrtr,
                                             string hasInternetIND, decimal maxToWD, decimal maxAV, string hourDESC,
                                             string BUS_AGCY_NO_SRVC_AV_IND)
        {
            var newObj = new BusinessAgency();

            newObj.BN = BN;
            newObj.BUS_AGCY_NBR = generateBusinessAgencyCode(BN);
            newObj.BUS_AGCY_NM = busAgcyNM;
            newObj.BUS_AGCY_KTCT_ID = KTCT_ID;
            newObj.BUS_AGCY_HDQRTR_IND = headQrtr;
            newObj.BUS_AGCY_ACCT_ID = ACCT_ID;
            newObj.BUS_AGCY_INTRNT_CHK_IND = hasInternetIND;
            newObj.BUS_AGCY_MXAMT_TO_WDRW_AMT = maxToWD;
            newObj.BUS_AGCY_AV_AMT = maxAV;
            newObj.BUS_AGCY_OPNNG_HR = hourDESC;
            newObj.BUS_AGCY_NO_SRVC_AV_IND = BUS_AGCY_NO_SRVC_AV_IND;
            return newObj;
        }

        public string generateBusinessAgencyCode(int BN)
        {
            var bus = db.TBUS.Find(BN);
            if (bus == null)
            {
                return null;
            }

            int currentLength = db.TBUS_AGCY.Where(x => x.BN == BN).Count();
            if (currentLength != 0)
            {
                currentLength += 1;
                string strLength = currentLength.ToString();
                if (strLength.Length == 1) { return "0000" + strLength; }
                else if (strLength.Length == 2) { return "000" + strLength; }
                else if (strLength.Length == 3) { return "00" + strLength; }
                else if (strLength.Length == 4) { return "0" + strLength; }
                else { return strLength; }
            }
            else { return "00001"; }
        }

        public BusinessAgency getOneBusinessAgencyByAgcyNbr(int BN, string busAgcyNbr)
        {
            var busAgcy = db.TBUS_AGCY.Find(BN, busAgcyNbr);
            if (busAgcy == null)
            {
                return null;
            }
            return busAgcy;
        }

        public BusinessUser getBusinessAgencyDirectorByAgcyNbr(int BN, string busAgcyNbr)
        {
            try
            {
                var busUsrList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_AGCY_NBR == busAgcyNbr && 
                                                        x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
                if (busUsrList.Count() == 0)
                {
                    return null;
                }

                var busUsr = busUsrList[0];
                if (busUsrList == null)
                {
                    return null;
                }
                return busUsr;
            }
            catch
            {
                return null;
            }
        }

        public string getBusinessAgencyDirectorNameByAgcyNbr(int BN, string busAgcyNbr)
        {
            try
            {
                var busUsr = getBusinessAgencyDirectorByAgcyNbr(BN, busAgcyNbr); ;
                if (busUsr == null)
                {
                    return null;
                }

                var dirUsr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                if (dirUsr == null)
                {
                    return null;
                }
                return dirUsr.USR_FUL_NM;
            }
            catch
            {
                return null;
            }
        }

        public Contact getBusinessAgencyContactByBusUsrNbr(int BUS_USR_NBR)
        {
            try
            {
                var busUsrObj = new BusinessUser();
                var busUsr = busUsrObj.getBusinessUserByID(BUS_USR_NBR);
                if (busUsr == null)
                {
                    return null;
                }
                int BN = busUsr.BN;
                string busAgcyNbr = busUsr.BUS_AGCY_NBR;

                var busAgcy = db.TBUS_AGCY.Find(BN, busAgcyNbr);
                if (busAgcy == null)
                {
                    return null;
                }

                var busAgcyKtctObj = new Contact();
                return busAgcyKtctObj.getContactByKtctID(busAgcy.BUS_AGCY_KTCT_ID);
            }
            catch
            {
                return null;
            }
        }

        public SelectList getAllBusinessAgency(int BN, string selectedValue)
        {
            return (new SelectList(db.TBUS_AGCY.Where(x => x.BN == BN && x.BUS_AGCY_NO_SRVC_AV_IND == "0"), "BUS_AGCY_NBR", "BUS_AGCY_NM", selectedValue));
        }

        public List<BusinessAgency> getAllBusinessAgency(int BN)
        {
            return db.TBUS_AGCY.Where(x => x.BN == BN && x.BUS_AGCY_NO_SRVC_AV_IND == "0").ToList();
        }

     /*   public List<BusinessAgencyViewModel> getAllBusinessAgencyViewModel(int BN)
        {
            List<BusinessAgencyViewModel> items = new List<BusinessAgencyViewModel>();
            var query = db.TBUS_AGCY.Where(x => x.BN == BN && x.BUS_AGCY_NO_SRVC_AV_IND == "0").ToList();

            foreach (var item in query)
            {
                var busAgcyItem = new BusinessAgencyViewModel();
                busAgcyItem.busAgcy = item;

                var busAgcyAcct = db.TACCT.Find(item.BUS_AGCY_ACCT_ID);
                if (busAgcyAcct != null)
                {
                    busAgcyItem.BUS_AGCY_BAL_TXT = CommonLibrary.displayFormattedCurrency(busAgcyAcct.ACCT_BAL, busAgcyAcct.CRCY_CD, busAgcyAcct.ACCT_CLTR_INFO);
                }

                var busAgcyCity = db.TKTCT.Find(item.BUS_AGCY_KTCT_ID);
                if (busAgcyCity != null)
                {
                    busAgcyItem.BUS_AGCY_CITY_NM = busAgcyCity.CITY_NM;
                }

                items.Add(busAgcyItem);
            }
            return items;
        }

        public List<BusinessAgencyViewModel> getAllBusinessAgencyByDirector(string usrNbr)
        {
            List<BusinessAgencyViewModel> items = new List<BusinessAgencyViewModel>();
            var query = from busAgcy in db.TBUS_AGCY
                        join busUsr in db.TBUS_USR on new { busAgcy.BN, busAgcy.BUS_AGCY_NBR } equals new { busUsr.BN, busUsr.BUS_AGCY_NBR }
                        where busUsr.BUS_EMPE_USR_NBR == usrNbr && 
                              busAgcy.BUS_AGCY_NO_SRVC_AV_IND == "0" && busUsr.BUS_USR_SCD == "1"
                        select new { busAgcy = busAgcy, busUsrNbr = busUsr.BUS_USR_NBR };

            foreach (var item in query)
            {
                var busAgcyItem = new BusinessAgencyViewModel();
                busAgcyItem.busAgcy = item.busAgcy;
                busAgcyItem.Id = item.busUsrNbr;

                var busAgcyAcct = db.TACCT.Find(item.busAgcy.BUS_AGCY_ACCT_ID);
                if (busAgcyAcct != null)
                {
                    busAgcyItem.BUS_AGCY_BAL_TXT = CommonLibrary.displayFormattedCurrency(busAgcyAcct.ACCT_BAL, busAgcyAcct.CRCY_CD, busAgcyAcct.ACCT_CLTR_INFO);
                }

                var busAgcyCity = db.TKTCT.Find(item.busAgcy.BUS_AGCY_KTCT_ID);
                if (busAgcyCity != null)
                {
                    busAgcyItem.BUS_AGCY_CITY_NM = busAgcyCity.CITY_NM;
                }

                items.Add(busAgcyItem);
            }
            return items;
        }

        public SelectList getAllBusinessAgencyByDirector(string usrNbr, string selectedValue)
        {
            var query = from busAgcy in db.TBUS_AGCY
                        join busUsr in db.TBUS_USR on new { busAgcy.BN, busAgcy.BUS_AGCY_NBR } equals new { busUsr.BN, busUsr.BUS_AGCY_NBR }
                        where busUsr.BUS_EMPE_USR_NBR == usrNbr && 
                              busAgcy.BUS_AGCY_NO_SRVC_AV_IND == "0" && busUsr.BUS_USR_SCD == "1"
                        select busAgcy;

            return (new SelectList(query, "BUS_AGCY_NBR", "BUS_AGCY_NM", selectedValue));
        }

        public List<BusinessUserViewModel> getAllBusinessAgencyCashierByAgcyNbr(int BN, string busAgcyNbr)
        {
            try
            {
                List<BusinessUserViewModel> items = new List<BusinessUserViewModel>();
                var busAgcyList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_AGCY_NBR == busAgcyNbr && 
                                                         x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
                if (busAgcyList.Count() == 0)
                {
                    return items;
                }

                foreach (var item in busAgcyList)
                {
                    var busUsrItem = new BusinessUserViewModel();
                    busUsrItem.busUsr = item;
                    busUsrItem.Id = item.BUS_USR_NBR;

                    if (item != null)
                    {
                        var busAcct = new Account();
                        var acctCashier = busAcct.getAccountByUsrNbr(item.BUS_EMPE_USR_NBR, "2"); // 2 = business
                        if (acctCashier != null)
                        {
                            busUsrItem.BUS_USR_ACCT = busAcct.formatAccountNumber(acctCashier.ACCT_NBR, "3");    //3 = cashier
                            busUsrItem.BUS_USR_BAL_TXT = CommonLibrary.displayFormattedCurrency(acctCashier.ACCT_BAL, acctCashier.CRCY_CD, acctCashier.ACCT_CLTR_INFO);
                            busUsrItem.BUS_USR_ACCT = busUsrItem.BUS_USR_ACCT + "=" + busUsrItem.BUS_USR_BAL_TXT;
                        }
                    }

                    var cashier = db.TUSR.Find(item.BUS_EMPE_USR_NBR);
                    if (cashier != null)
                    {
                        busUsrItem.BUS_USR_FUL_NM = cashier.USR_FUL_NM;
                    }

                    items.Add(busUsrItem);
                }
                return items;
            }
            catch
            {
                return null;
            }
        }

        public List<WithdrawalLocationListViewModel> getAllWithdrawalLocationByCtryCD(string ctryCD)
        {
            var listError = new List<WithdrawalLocationListViewModel>();
            try
            {
                var list = new List<WithdrawalLocationListViewModel>();
                var query = from busAgcy in db.TBUS_AGCY
                            join ktct in db.TKTCT on busAgcy.BUS_AGCY_KTCT_ID equals ktct.KTCT_ID
                            join city in db.TCITY on ktct.CITY_CD equals city.CITY_CD
                            where ktct.CTRY_CD == ctryCD && busAgcy.BUS_AGCY_NO_SRVC_AV_IND == "0"
                            orderby city.FRA_CITY_NM ascending
                            select new
                            {
                                BN = busAgcy.BN,
                                BUS_AGCY_NBR = busAgcy.BUS_AGCY_NBR,
                                BUS_AGCY_NM = busAgcy.BUS_AGCY_NM,
                                CITY_NM = city.FRA_CITY_NM,
                                BUS_AGCY_OPNNG_HR = busAgcy.BUS_AGCY_OPNNG_HR,
                                ADDR = ktct.ADDR_LN1_TXT,
                                CITY_CD = ktct.CITY_CD,
                                PHN1_NBR = ktct.PHN1_NBR,
                                PHN2_NBR = ktct.PHN2_NBR
                            };

                foreach (var row in query)
                {
                    var obj = new WithdrawalLocationListViewModel();
                    obj.BN = row.BN;
                    obj.BUS_AGCY_NBR = row.BUS_AGCY_NBR;

                    //get the business name
                    var bus = db.TBUS.Find(row.BN);
                    if (bus == null)
                    {
                        return listError;
                    }
                    obj.BUS_NM = bus.BUS_NM + " - " + bus.BUS_SHORT_NM;

                    //get the business agency name
                    var busAgcy = db.TBUS_AGCY.Find(row.BN, row.BUS_AGCY_NBR);
                    if (busAgcy == null)
                    {
                        return listError;
                    }
                    obj.BUS_AGCY_NM = busAgcy.BUS_AGCY_NM;
                    obj.CITY_NM = row.CITY_NM;
                    obj.BUS_AGCY_OPNNG_HR = row.BUS_AGCY_OPNNG_HR;
                    obj.BUS_AGCY_ADDR = row.ADDR;

                    if ((row.PHN1_NBR != "d" && row.PHN2_NBR == "d"))
                    {
                        obj.PHN_NBR = row.PHN1_NBR;
                    }
                    else if ((row.PHN1_NBR != "d" && row.PHN2_NBR != "d"))
                    {
                        obj.PHN_NBR = row.PHN1_NBR + " - " + row.PHN2_NBR;
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return listError;
            }
        }*/
    }
}
