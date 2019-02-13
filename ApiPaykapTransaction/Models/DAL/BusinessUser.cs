using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBUS_USR")]
    public class BusinessUser
    {
        public BusinessUser()
        {
            BUS_USR_EDT = DateTime.Now;
            TBUS_CMSN_TRANS = new HashSet<BusinessCommissionTransaction>();
            TBUS_USR_EXCP_ROL = new HashSet<BusinessUserExceptionalRole>();
            TTRANS_ID_DOC = new HashSet<TransactionIdentificationDocument>();
            TBUS_INTRN_TRSF_TRANS = new HashSet<BusinessInternalTransferTransaction>();
            TBUS_INTRN_TRSF_TRANS1 = new HashSet<BusinessInternalTransferTransaction>();
            //TCARD_CAT = new HashSet<CardCategory>();
            //TCARD_DPST_WDRW_TRANS = new HashSet<CardDepositWithdrawalTransaction>();
            BUS_USR_SCD = "1";
        }

        [Key]
        [Display(Name = "ID Employé")]
        public int BUS_USR_NBR { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [StringLength(5, ErrorMessage = "Le numéro d'agence doit avoir 5 caractères.", MinimumLength = 5)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Agence")]
        public string BUS_AGCY_NBR { get; set; }

        [Display(Name = "ID Compte")]
        public int BUS_ACCT_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime BUS_USR_EDT { get; set; }

        [Required(ErrorMessage = "Le type d'employé est obligatoire.")]
        [StringLength(2, ErrorMessage = "Le type d'employé doit avoir 2 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Employé")]
        public string BUS_USR_TCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Crédit Disponible")]
        public decimal BUS_AV_CAMT { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string BUS_EMPE_USR_NBR { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_USR_SCD { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_EMPE_IS_PKP_CLT_IND { get; set; }

        [StringLength(255)]
        [Display(Name = "Nom Utilisateur")]
        [NotMapped]
        public string BUS_EMPE_USR_FUL_NM { get; set; }

        public virtual Account TACCT { get; set; }

        public virtual BusinessAgency TBUS_AGCY { get; set; }

        public virtual User TUSR { get; set; }
        public virtual ICollection<BusinessCommissionTransaction> TBUS_CMSN_TRANS { get; set; }
        public virtual ICollection<BusinessUserExceptionalRole> TBUS_USR_EXCP_ROL { get; set; }
        public virtual ICollection<TransactionIdentificationDocument> TTRANS_ID_DOC { get; set; }
        public virtual ICollection<BusinessInternalTransferTransaction> TBUS_INTRN_TRSF_TRANS { get; set; }
        public virtual ICollection<BusinessInternalTransferTransaction> TBUS_INTRN_TRSF_TRANS1 { get; set; }
        //public virtual ICollection<CardCategory> TCARD_CAT { get; set; }
        //public virtual ICollection<CardDepositWithdrawalTransaction> TCARD_DPST_WDRW_TRANS { get; set; }

        private DalContext db = new DalContext();
        private User usrObj = new User();
        private Business busObj = new Business();
        private BusinessAgency busAgcyObj = new BusinessAgency();
        private Account acctObj = new Account();

        public BusinessUser createBusinessUser(int BN, string BUS_AGCY_NBR, int BUS_ACCT_ID, string BUS_USR_TCD,
                                               decimal BUS_AV_CAMT, string USR_NBR,
                                               string BUS_EMPE_IS_PKP_CLT_IND)
        {
            var newObj = new BusinessUser();

            newObj.BN = BN;
            newObj.BUS_AGCY_NBR = BUS_AGCY_NBR;
            newObj.BUS_ACCT_ID = BUS_ACCT_ID;
            newObj.BUS_USR_TCD = BUS_USR_TCD;
            newObj.BUS_AV_CAMT = BUS_AV_CAMT;
            newObj.BUS_EMPE_USR_NBR = USR_NBR;
            newObj.BUS_EMPE_IS_PKP_CLT_IND = BUS_EMPE_IS_PKP_CLT_IND;
            return newObj;
        }

        public BusinessUser getBusinessUserByID(int busUsrID)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_USR_NBR == busUsrID && x.BUS_USR_SCD == "1").ToList();
            return returnBusinessUser(busUsrList);
        }

        public List<SelectListItem> getAllBusinessManager(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var list = db.TBUS_USR.Where(x => x.BUS_USR_TCD == "04" && x.BUS_USR_SCD == "1").ToList();

                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    foreach (var item in list)
                    {
                        var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                        if (usr == null)
                        {
                            return items;
                        }
                        item.BUS_EMPE_USR_FUL_NM = usr.USR_FUL_NM;
                    }
                    return new SelectList(list.Distinct(), "BUS_EMPE_USR_NBR", "BUS_EMPE_USR_FUL_NM", selectedValue).ToList();
                }
            }
            catch
            {
                return items;
            }
        }

        public BusinessUser getBusinessUserByUsrNbr(string usrNbr)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr &&
                                                    x.BUS_USR_TCD == "04" && x.BUS_USR_SCD == "1").ToList();
            //if the user is manager, get the default business profile
            //else it is a cashier
            if (busUsrList.Count() != 0)
            {
                var bus = busObj.getDefaultBusinessByManagerUsrNbr(usrNbr);
                if (bus != null)
                {
                    var busUsrList1 = db.TBUS_USR.Where(x => x.BN == bus.BN &&
                                                            x.BUS_EMPE_USR_NBR == usrNbr &&
                                                            x.BUS_USR_SCD == "1").ToList();
                    return returnBusinessUser(busUsrList1);
                }
                return null;
            }

            var busUsrList2 = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr &&
                                                    x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList2.Count() != 0)
            {
                return returnBusinessUser(busUsrList2);
            }
            return null;//the usrNbr is not enough to get busUsr in the BusinessDirector role
        }

        private BusinessUser returnBusinessUser(List<BusinessUser> busUsrList)
        {
            if (busUsrList.Count() != 1)
            {
                return null;
            }

            var busUsr = busUsrList[0];
            if (busUsr == null)
            {
                return null;
            }
            return busUsr;
        }

        public BusinessUser getBusinessUserByDirectorAndAgcyNbr(string usrNbr, string busAgcyNbr)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_AGCY_NBR == busAgcyNbr &&
                                                    x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
            return returnBusinessUser(busUsrList);
        }

        public BusinessUser getBusinessDirectorByCashier(string usrNbr)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "02" &&
                                                    x.BUS_USR_SCD == "1").ToList();

            var busUsr = returnBusinessUser(busUsrList);
            if (busUsr == null)
            {
                return null;
            }

            var busDirList = db.TBUS_USR.Where(x => x.BN == busUsr.BN && x.BUS_AGCY_NBR == busUsr.BUS_AGCY_NBR &&
                                                    x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
            return returnBusinessUser(busDirList);
        }
        
        public BusinessUser getBusinessManagerByUsrNbr(string usrNbr)
        {
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_SCD == "1").ToList();
            var busUsr = returnBusinessUser(busUsrList);
            if (busUsr == null)
            {
                return null;
            }
            
            var busMngList = db.TBUS_USR.Where(x => x.BN == busUsr.BN && x.BUS_USR_TCD == "04" && x.BUS_USR_SCD == "1").ToList();
            return returnBusinessUser(busMngList);
        }
        
        public User getUserByID(int busUsrID)
        {
            var busUsr = getBusinessUserByID(busUsrID);
            if (busUsr == null)
            {
                return null;
            }

            return usrObj.getUserByUsrNbr(busUsr.BUS_EMPE_USR_NBR);
        }

        public Business getBusinessByUsrNbr(string usrNbr)
        {
            //if the user is manager, get the default business, else get the business by cashier
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "04" &&
                                                    x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() > 0)
            {
                return busObj.getDefaultBusinessByManagerUsrNbr(usrNbr);
            }

            var busUsrList1 = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_SCD == "1").ToList();
            var busUsr = returnBusinessUser(busUsrList1);
            return busObj.getBusinessByBN(busUsr.BN);
        }

    /*    public List<BusinessUserViewModel> getAllBusinessUserByBNorAgcyNbr(int BN, string BUS_AGCY_NBR)
        {
            List<BusinessUserViewModel> items = new List<BusinessUserViewModel>();
            if (string.IsNullOrWhiteSpace(BUS_AGCY_NBR))
            {
                var query = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_USR_SCD == "1").ToList();
                addItemToList(items, query);
            }
            else
            {
                var query = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_AGCY_NBR == BUS_AGCY_NBR && x.BUS_USR_SCD == "1").ToList();
                addItemToList(items, query);
            }
            return items;
        }

        public void addItemToList(List<BusinessUserViewModel> items, List<BusinessUser> query)
        {
            foreach (var item in query)
            {
                var busUsrItem = new BusinessUserViewModel();
                busUsrItem.busUsr = item;
                busUsrItem.Id = item.BUS_USR_NBR;

                if (item.BUS_USR_TCD == "04")
                {
                    busUsrItem.BUS_USR_ROL_NM = "Gestionnaire";
                }
                else if (item.BUS_USR_TCD == "03")
                {
                    busUsrItem.BUS_USR_ROL_NM = "Directeur (trice)";
                }
                else if (item.BUS_USR_TCD == "02")
                {
                    busUsrItem.BUS_USR_ROL_NM = "Caissier (ère)";
                }

                var busAgcy = db.TBUS_AGCY.Find(item.BN, item.BUS_AGCY_NBR);
                if (busAgcy != null)
                {
                    busUsrItem.BUS_USR_AGCY_NM = busAgcy.BUS_AGCY_NM;
                }

                var busUsrAcct = db.TACCT.Find(item.BUS_ACCT_ID);
                if (busUsrAcct != null)
                {
                    busUsrItem.BUS_USR_BAL_TXT = CommonLibrary.displayFormattedCurrency(busUsrAcct.ACCT_BAL, busUsrAcct.CRCY_CD, busUsrAcct.ACCT_CLTR_INFO);
                }

                var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                if (usr != null)
                {
                    busUsrItem.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                }
                items.Add(busUsrItem);
            }
        }

        public List<BusinessUserViewModel> getAllBusinessCahsierByDirector(string usrNbr)
        {
            List<BusinessUserViewModel> items = new List<BusinessUserViewModel>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();

            foreach (var item in busUsrList)
            {
                var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == item.BN && x.BUS_AGCY_NBR == item.BUS_AGCY_NBR &&
                                                               x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();

                foreach (var itemCashier in busUsrCashierList)
                {
                    var busUsrItem = new BusinessUserViewModel();
                    busUsrItem.busUsr = itemCashier;
                    busUsrItem.Id = itemCashier.BUS_USR_NBR;
                    busUsrItem.BUS_USR_ROL_NM = "Caissier (ère)";

                    var busUsrAcct = acctObj.getAccountByAcctID(itemCashier.BUS_ACCT_ID);
                    if (busUsrAcct != null)
                    {
                        busUsrItem.BUS_USR_BAL_TXT = CommonLibrary.displayFormattedCurrency(busUsrAcct.ACCT_BAL, busUsrAcct.CRCY_CD, busUsrAcct.ACCT_CLTR_INFO);
                    }

                    var busAgcy = busAgcyObj.getOneBusinessAgencyByAgcyNbr(item.BN, item.BUS_AGCY_NBR);
                    if (busAgcy != null)
                    {
                        busUsrItem.BUS_USR_AGCY_NM = busAgcy.BUS_AGCY_NM;
                    }

                    var usr = usrObj.getUserByUsrNbr(itemCashier.BUS_EMPE_USR_NBR);
                    if (usr != null)
                    {
                        busUsrItem.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                    }
                    items.Add(busUsrItem);
                }
            }
            return items;
        }*/

        public List<SelectListItem> getAllAgencyByDirectorUsrNbr(string usrNbr, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }

            foreach (var item in busUsrList)
            {
                var busAgcy = db.TBUS_AGCY.Find(item.BN, item.BUS_AGCY_NBR);
                if (busAgcy != null)
                {
                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllAgencyAndBusinessCashierByDirector(string usrNbr, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }

            items.Add(new SelectListItem { Text = "-------Agence(s)----------------", Value = "" });
            foreach (var item in busUsrList)
            {
                var busAgcy = db.TBUS_AGCY.Find(item.BN, item.BUS_AGCY_NBR);
                if (busAgcy != null)
                {
                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }

            items.Add(new SelectListItem { Text = "", Value = "" });
            items.Add(new SelectListItem { Text = "-------Caisse(s)----------------", Value = "" });
            foreach (var item in busUsrList)
            {
                var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == item.BN && x.BUS_AGCY_NBR == item.BUS_AGCY_NBR &&
                                                               x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();

                foreach (var itemCashier in busUsrCashierList)
                {
                    var usr = usrObj.getUserByUsrNbr(itemCashier.BUS_EMPE_USR_NBR);
                    if (usr != null)
                    {
                        if (itemCashier.BUS_USR_NBR == selectedValue)
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = false });
                        }
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllBusinessCashierByDirector(string usrNbr, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03" &&
                                                    x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }

            foreach (var item in busUsrList)
            {
                var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == item.BN && x.BUS_AGCY_NBR == item.BUS_AGCY_NBR &&
                                                               x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
                foreach (var itemCashier in busUsrCashierList)
                {
                    var usr = usrObj.getUserByUsrNbr(itemCashier.BUS_EMPE_USR_NBR);
                    if (usr != null)
                    {
                        if (itemCashier.BUS_USR_NBR == selectedValue)
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = false });
                        }
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getOneBusinessCashierByUsrNbr(string usrNbr, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() != 1)
            {
                return items;
            }

            foreach (var item in busUsrList)
            {
                var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                if (usr != null)
                {
                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllBusinessCashierByBN_BusAgcyNbr(int BN, string BUS_AGCY_NBR, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_AGCY_NBR == BUS_AGCY_NBR && x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
            foreach (var itemCashier in busUsrCashierList)
            {
                var usr = usrObj.getUserByUsrNbr(itemCashier.BUS_EMPE_USR_NBR);
                if (usr != null)
                {
                    if (itemCashier.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(itemCashier.BUS_USR_NBR), Selected = false });
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllAgencyAndBusinessCashierByBN(int BN, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_USR_TCD == "03" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }

            items.Add(new SelectListItem { Text = "-------Agence(s)----------------", Value = "" });
            foreach (var item in busUsrList)
            {
                var busAgcy = db.TBUS_AGCY.Find(item.BN, item.BUS_AGCY_NBR);
                if (busAgcy != null)
                {
                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = busAgcy.BUS_AGCY_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }

            var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrCashierList.Count() != 0)
            {
                items.Add(new SelectListItem { Text = "", Value = "" });
                items.Add(new SelectListItem { Text = "-------Caisse(s)----------------", Value = "" });
            }

            foreach (var item in busUsrCashierList)
            {
                var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                if (usr != null)
                {
                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllBusinessCashierByBN(int BN, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var busUsrCashierList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_USR_TCD == "02" && x.BUS_USR_SCD == "1").ToList();
            if (busUsrCashierList.Count() != 0)
            {
                foreach (var item in busUsrCashierList)
                {
                    var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                    if (usr != null)
                    {
                        if (item.BUS_USR_NBR == selectedValue)
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = usr.USR_FUL_NM, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                        }
                    }
                }
            }
            return items;
        }

        public List<SelectListItem> getAllBusinessUserByBN(int BN, int selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var busUsrList = db.TBUS_USR.Where(x => x.BN == BN && x.BUS_USR_SCD == "1").ToList();
            foreach (var item in busUsrList)
            {
                var usr = usrObj.getUserByUsrNbr(item.BUS_EMPE_USR_NBR);
                if (usr != null)
                {
                    string text;
                    if (item.BUS_USR_TCD == "04")
                    {
                        text = usr.USR_FUL_NM + " - Manager";
                    }
                    else if (item.BUS_USR_TCD == "03")
                    {
                        var busAgcy = new BusinessAgency();
                        var obj = busAgcy.getOneBusinessAgencyByAgcyNbr(item.BN, item.BUS_AGCY_NBR);
                        if (obj == null)
                        {
                            text = usr.USR_FUL_NM + " - Director";
                        }
                        else
                        {
                            text = usr.USR_FUL_NM + " - Director - " + obj.BUS_AGCY_NM;
                        }
                    }
                    else if (item.BUS_USR_TCD == "02")
                    {
                        var busAgcy = new BusinessAgency();
                        var obj = busAgcy.getOneBusinessAgencyByAgcyNbr(item.BN, item.BUS_AGCY_NBR);
                        if (obj == null)
                        {
                            text = usr.USR_FUL_NM + " - Cashier";
                        }
                        else
                        {
                            text = usr.USR_FUL_NM + " - Cashier" + obj.BUS_AGCY_NM;
                        }
                    }
                    else
                    {
                        text = usr.USR_FUL_NM;
                    }

                    if (item.BUS_USR_NBR == selectedValue)
                    {
                        items.Add(new SelectListItem { Text = text, Value = Convert.ToString(item.BUS_USR_NBR), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = text, Value = Convert.ToString(item.BUS_USR_NBR), Selected = false });
                    }
                }
            }
            return items;
        }
    }
}
