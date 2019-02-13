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
    [Table("dbo.TFI_EXRL_ACCT")]
    public class FinancialInstitutionExternalAccount
    {
        public FinancialInstitutionExternalAccount()
        {
            LGC_DEL_IND = "0";
            EXRL_ACCT_VLDT_IND =  "0";
            EXRL_ACCT_DT = DateTime.Now;
            TBNK_TRANS = new HashSet<BankTransaction>();
            TRCPT_EXRL_ACCT_FOR_BUS = new HashSet<RecipientExternalAccountForBusiness>();
        }

        [Key]
        [Display(Name = "ID Compte Bancaire")]
        public int EXRL_ACCT_ID { get; set; }

        [StringLength(100, ErrorMessage = "Le {0} doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Nom Compte Bancaire")]
        public string EXRL_ACCT_NM { get; set; }

        [StringLength(100, ErrorMessage = "Le {0} doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Numéro Compte Bancaire")]
        public string EXRL_ACCT_NBR { get; set; }

        [StringLength(2, ErrorMessage = "Le {0} doit avoir 2 caractères maximum.", MinimumLength = 2)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Type Compte Bancaire")]
        public string EXRL_ACCT_TCD { get; set; }

        [StringLength(20, ErrorMessage = "La {0} doit avoir 20 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 1 Compte Bancaire")]
        public string EXRL_ACCT_PRT1_NBR { get; set; }

        [StringLength(20, ErrorMessage = "La {0} doit avoir 20 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 2 Compte Bancaire")]
        public string EXRL_ACCT_PRT2_NBR { get; set; }

        [StringLength(20, ErrorMessage = "La {0} doit avoir 20 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 3 Compte Bancaire")]
        public string EXRL_ACCT_PRT3_NBR { get; set; }

        [StringLength(20, ErrorMessage = "La {0} doit avoir 20 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 4 Compte Bancaire")]
        public string EXRL_ACCT_PRT4_NBR { get; set; }

        [StringLength(20, ErrorMessage = "La {0} doit avoir 20 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [Display(Name = "Partie 5 Compte Bancaire")]
        public string EXRL_ACCT_PRT5_NBR { get; set; }

        [Display(Name = "Number de Partie Compte Bancaire")]
        public int EXRL_ACCT_PRT_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Compte Bancaire Validé ?")]
        public string EXRL_ACCT_VLDT_IND { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Compte Bancaire")]
        public DateTime EXRL_ACCT_DT { get; set; }

        [Display(Name = "ID Pays Institution Financière")]
        public int FI_CTRY_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Dévise")]
        public string CRCY_CD { get; set; }
           
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 10)]
        [Display(Name = "ID Personne Compte Bancaire")]
        public string EXRL_ACCT_USR_NBR { get; set; }
        
        [Display(Name = "ID Entreprise Compte Bancaire")]
        public int? EXRL_ACCT_BUS_NBR { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Propriétaire Compte Bancaire")] //1= personne   2=entreprise
        public string EXRL_ACCT_USR_BUS_TCD { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Indicateur Utilisateur Courant Propriétaire Compte Bancaire")] 
        public string EXRL_ACCT_FOR_CURT_USR_IND { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        [StringLength(10, ErrorMessage = "Le ID du propriétaire du compte bancaire doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le ID du propriétaire du compte bancaire est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        [NotMapped]
        public string RCPT_EXRL_ACCT_USR_NBR { get; set; }

        [Display(Name = "Nom Bénéficiaire")]
        [NotMapped]
        public string RCPT_USR_BUS_NM { get; set; }

        [Display(Name = "Nom Bénéficiaire")]
        [NotMapped]
        public string TO_USR_BUS_NM
        {
            get
            {
                if (EXRL_ACCT_USR_BUS_TCD == "1")
                {
                    var usr = db.TUSR.Find(EXRL_ACCT_USR_NBR);
                    if(usr == null)
                    {
                        return null;
                    }
                    return usr.USR_FUL_NM;
                }
                else
                {
                    var bus = db.TBUS.Find(EXRL_ACCT_BUS_NBR);
                    if (bus == null)
                    {
                        return null;
                    }
                    return bus.BUS_SHORT_NM;
                }
            }
        }

        public virtual ICollection<BankTransaction> TBNK_TRANS { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual Currency TCRCY { get; set; }

        public virtual FinancialInstitutionCountry TFI_CTRY { get; set; }

        public virtual User TUSR { get; set; }

        public virtual User TUSR1 { get; set; }
        public virtual ICollection<RecipientExternalAccountForBusiness> TRCPT_EXRL_ACCT_FOR_BUS { get; set; }
        private DalContext db = new DalContext();
        private string lang = "FRA";

        public FinancialInstitutionExternalAccount getBankRecipientByRcptID(int rcptID)
        {
            try
            {
                var rcpt = db.TFI_EXRL_ACCT.Find(rcptID);
                if (rcpt == null)
                {
                    return null;
                }
                else
                {
                    return rcpt;
                }
            }
            catch
            {
                return null;
            }
        }

        public string getBankRecipientNameByRcptID(int rcptID)
        {
            try
            {
                var rcpt = db.TFI_EXRL_ACCT.Find(rcptID);
                if (rcpt == null)
                {
                    return null;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(rcpt.TO_USR_BUS_NM))
                    {
                        // business online
                        if (rcpt.EXRL_ACCT_USR_NBR == rcpt.USR_NBR && rcpt.EXRL_ACCT_FOR_CURT_USR_IND == "0" && rcpt.EXRL_ACCT_BUS_NBR == null)
                        {
                            var thisBusOnlineList = db.TRCPT_EXRL_ACCT_FOR_BUS.Where(x => x.EXRL_ACCT_ID == rcpt.EXRL_ACCT_ID && x.RCPT_EXRL_ACCT_FOR_BUS_TCD == "1").ToList();
                            if (thisBusOnlineList.Count() != 0)
                            {
                                var thisBusOnline = thisBusOnlineList[0];
                                var bus = db.TBUS.Find(thisBusOnline.BN);
                                return bus.BUS_SHORT_NM;
                            }
                        }

                        //the current client usr
                        if (rcpt.EXRL_ACCT_USR_NBR == rcpt.USR_NBR && rcpt.EXRL_ACCT_FOR_CURT_USR_IND == "1" && rcpt.EXRL_ACCT_BUS_NBR == null)
                        {
                            var usr = db.TUSR.Find(rcpt.USR_NBR);
                            if (usr != null)
                            {
                                return usr.USR_FUL_NM;
                            }
                        }

                        //business other than online
                        if (rcpt.EXRL_ACCT_FOR_CURT_USR_IND == "0" && rcpt.EXRL_ACCT_BUS_NBR != null)
                        {
                            var bus = db.TBUS.Find(rcpt.EXRL_ACCT_BUS_NBR);
                            if (bus != null)
                            {
                                return bus.BUS_SHORT_NM;
                            }
                        }
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool createFinancialInstitutionExternalAccount(string AcctNm, string AcctTCD, string AcctNbr, 
                                                    string part1, string part2, string part3, string part4, string part5, 
                                                    int partNbr, string acctVldIND, int fiCtryID,
                                                    string ExrlAcctUsrNbr, int? ExrlAcctBusNbr, string UsrBusTCD,
                                                    string crcyCD, string usrNbr, string currentUserIND)
        {
            try
            {
                var newObj = new FinancialInstitutionExternalAccount();
                //just to handle error
                newObj.RCPT_EXRL_ACCT_USR_NBR = "0000000000";

                newObj.EXRL_ACCT_NM = AcctNm;
                newObj.EXRL_ACCT_TCD = AcctTCD;
                newObj.EXRL_ACCT_NBR = AcctNbr;
                newObj.EXRL_ACCT_PRT1_NBR = part1;
                newObj.EXRL_ACCT_PRT2_NBR = part2;
                newObj.EXRL_ACCT_PRT3_NBR = part3;
                newObj.EXRL_ACCT_PRT4_NBR = part4;
                newObj.EXRL_ACCT_PRT5_NBR = part5;
                newObj.EXRL_ACCT_PRT_NBR = partNbr;
                newObj.EXRL_ACCT_VLDT_IND = acctVldIND;
                newObj.FI_CTRY_ID = fiCtryID;
                newObj.CRCY_CD = crcyCD;
                newObj.EXRL_ACCT_USR_NBR = ExrlAcctUsrNbr;
                newObj.EXRL_ACCT_BUS_NBR = ExrlAcctBusNbr;
                newObj.EXRL_ACCT_USR_BUS_TCD = UsrBusTCD;
                newObj.USR_NBR = usrNbr;
                newObj.EXRL_ACCT_FOR_CURT_USR_IND = currentUserIND;
                db.TFI_EXRL_ACCT.Add(newObj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateFinancialInstitutionExternalAccount(int EXRL_ACCT_ID, string AcctNm, string AcctTCD, string AcctNbr,
                                                    string part1, string part2, string part3, string part4, string part5,
                                                    int partNbr, int fiCtryID, string crcyCD)
        {
            try
            {
                var obj = db.TFI_EXRL_ACCT.Find(EXRL_ACCT_ID);
                if(obj == null)
                {
                    return false;
                }
                //just to handle error
                obj.RCPT_EXRL_ACCT_USR_NBR = "0000000000";

                obj.EXRL_ACCT_NM = AcctNm;
                obj.EXRL_ACCT_TCD = AcctTCD;
                obj.EXRL_ACCT_NBR = AcctNbr;
                obj.EXRL_ACCT_PRT1_NBR = part1;
                obj.EXRL_ACCT_PRT2_NBR = part2;
                obj.EXRL_ACCT_PRT3_NBR = part3;
                obj.EXRL_ACCT_PRT4_NBR = part4;
                obj.EXRL_ACCT_PRT5_NBR = part5;
                obj.EXRL_ACCT_PRT_NBR = partNbr;
                //obj.EXRL_ACCT_VLDT_IND = acctVldIND;
                obj.FI_CTRY_ID = fiCtryID;
                obj.CRCY_CD = crcyCD;
                //obj.EXRL_ACCT_USR_NBR = ExrlAcctUsrNbr;
                //obj.EXRL_ACCT_BUS_NBR = ExrlAcctBusNbr;
                //obj.EXRL_ACCT_USR_BUS_TCD = UsrBusTCD;
                //obj.USR_NBR = usrNbr;
                //obj.EXRL_ACCT_FOR_CURT_USR_IND = currentUserIND;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validateFinancialInstitutionExternalAccount(int EXRL_ACCT_ID, string acctVldIND)
        {
            try
            {
                var obj = db.TFI_EXRL_ACCT.Find(EXRL_ACCT_ID);
                if (obj == null)
                {
                    return false;
                }
                
                obj.EXRL_ACCT_VLDT_IND = acctVldIND;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteFinancialInstitutionExternalAccount(int EXRL_ACCT_ID)
        {
            try
            {
                var obj = db.TFI_EXRL_ACCT.Find(EXRL_ACCT_ID);
                if (obj == null)
                {
                    return false;
                }

                db.TFI_EXRL_ACCT.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public bool checkIfFinancialInstitutionExternalAccountAlreadyExist(string currentUsrNbr, string acctNbr, 
                                                    string ExrlAcctUsrNbr, int? ExrlAcctBusNbr, string UsrBusTCD)
        {
            try
            {
                if (UsrBusTCD == "1")
                {
                    var list = db.TFI_EXRL_ACCT.Where(x => x.EXRL_ACCT_NBR == acctNbr && 
                                                           x.EXRL_ACCT_USR_NBR == ExrlAcctUsrNbr && 
                                                           x.USR_NBR == currentUsrNbr && x.LGC_DEL_IND == "0").ToList();
                    if (list.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                if (UsrBusTCD == "2")
                {
                    var list = db.TFI_EXRL_ACCT.Where(x => x.EXRL_ACCT_NBR == acctNbr &&
                                                           x.EXRL_ACCT_BUS_NBR == ExrlAcctBusNbr &&
                                                           x.USR_NBR == currentUsrNbr && x.LGC_DEL_IND == "0").ToList();
                    if(list.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<SelectListItem> getAllBankRecipientByUsrNbr(string currentUsrNbr, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var ctryObj = new Country();
                var list = db.TFI_EXRL_ACCT.Where(x => x.USR_NBR == currentUsrNbr && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    var myList = db.TFI_EXRL_ACCT.Where(x => x.USR_NBR == currentUsrNbr && 
                                                             x.EXRL_ACCT_FOR_CURT_USR_IND == "1" && x.LGC_DEL_IND == "0").ToList();
                    if (myList.Count() != 0)
                    {
                        items.Add(new SelectListItem { Text = "-------Mes comptes bancaires----------------", Value = "" });
                        foreach (var item in myList)
                        {
                            string ctry3ltrCD = ctryObj.getCountryThreeLetterByCode(item.TFI_CTRY.FI_CTRY_CD);
                            //string rcptNM = string.Empty;
                            //if (item.EXRL_ACCT_USR_BUS_TCD == "1")
                            //{
                            //    rcptNM = db.TUSR.Find(item.EXRL_ACCT_USR_NBR).USR_FUL_NM;
                            //}
                            //if (item.EXRL_ACCT_USR_BUS_TCD == "2")
                            //{
                            //    rcptNM = db.TBUS.Find(item.EXRL_ACCT_BUS_NBR).BUS_SHORT_NM;
                            //}
                            item.RCPT_USR_BUS_NM = item.EXRL_ACCT_NBR + " - " + ctry3ltrCD + " - " + item.CRCY_CD;
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
                        items.Add(new SelectListItem { Text = "", Value = "" });
                    }

                    var rcptList = db.TFI_EXRL_ACCT.Where(x => x.USR_NBR == currentUsrNbr && 
                                                               x.EXRL_ACCT_FOR_CURT_USR_IND == "0" && x.LGC_DEL_IND == "0").ToList();
                    if (rcptList.Count() != 0)
                    {
                        items.Add(new SelectListItem { Text = "-------Comptes Bancaires Bénéficiaires-------", Value = "" });
                        foreach (var item in rcptList)
                        {
                            string ctry3ltrCD = ctryObj.getCountryThreeLetterByCode(item.TFI_CTRY.FI_CTRY_CD);
                            string rcptNM = string.Empty;
                            if (item.EXRL_ACCT_USR_BUS_TCD == "1")
                            {
                                rcptNM = db.TUSR.Find(item.EXRL_ACCT_USR_NBR).USR_FUL_NM;
                            }
                            if (item.EXRL_ACCT_USR_BUS_TCD == "2")
                            {
                                rcptNM = db.TBUS.Find(item.EXRL_ACCT_BUS_NBR).BUS_SHORT_NM;
                            }
                            item.RCPT_USR_BUS_NM = rcptNM.ToUpper() + " - " + ctry3ltrCD + " - " + item.CRCY_CD;
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
                }
                return items;
            }
            catch
            {
                return items;
            }
        }

        public List<SelectListItem> getAllUserBusinessBankAccountByUsrNbr(string currentUsrNbr, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var ctryObj = new Country();
                var list = db.TFI_EXRL_ACCT.Where(x => x.USR_NBR == currentUsrNbr && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    var acctList = db.TACCT.Where(x => x.USR_NBR == currentUsrNbr && x.ACCT_TCD == "2").ToList();
                    if (acctList.Count() == 0)
                    {
                        return items;
                    }
                    var acct = acctList[0];
                    int bn = Convert.ToInt32(acct.ACCT_NBR.Substring(0, 9));

                    var myList = from bankAcct in db.TFI_EXRL_ACCT
                                 join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                                 where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "1" &&
                                        bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.USR_NBR == currentUsrNbr && bankAcct.LGC_DEL_IND == "0")
                                 select bankAcct;
                    if (myList.Count() != 0)
                    {
                        items.Add(new SelectListItem { Text = "-------Comptes bancaires de votre entreprise--------", Value = "" });
                        foreach (var item in myList)
                        {
                            string ctry3ltrCD = ctryObj.getCountryThreeLetterByCode(item.TFI_CTRY.FI_CTRY_CD);
                            //string rcptNM = string.Empty;
                            //if (item.EXRL_ACCT_USR_BUS_TCD == "1")
                            //{
                            //    rcptNM = db.TUSR.Find(item.EXRL_ACCT_USR_NBR).USR_FUL_NM;
                            //}
                            //if (item.EXRL_ACCT_USR_BUS_TCD == "2")
                            //{
                            //    rcptNM = db.TBUS.Find(item.EXRL_ACCT_BUS_NBR).BUS_SHORT_NM;
                            //}
                            item.RCPT_USR_BUS_NM = item.EXRL_ACCT_NBR + " - " + ctry3ltrCD + " - " + item.CRCY_CD;
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
                        items.Add(new SelectListItem { Text = "", Value = "" });
                    }
                    
                    var rcptList = from bankAcct in db.TFI_EXRL_ACCT
                                 join rcptBus in db.TRCPT_EXRL_ACCT_FOR_BUS on bankAcct.EXRL_ACCT_ID equals rcptBus.EXRL_ACCT_ID
                                 where (rcptBus.BN == bn && rcptBus.RCPT_EXRL_ACCT_FOR_BUS_TCD == "2" &&
                                        bankAcct.EXRL_ACCT_FOR_CURT_USR_IND == "0" && bankAcct.USR_NBR == currentUsrNbr && bankAcct.LGC_DEL_IND == "0")
                                 select bankAcct;
                    if (rcptList.Count() != 0)
                    {
                        items.Add(new SelectListItem { Text = "-------Comptes Bancaires De Vos Bénéficiaires-------", Value = "" });
                        foreach (var item in rcptList)
                        {
                            string ctry3ltrCD = ctryObj.getCountryThreeLetterByCode(item.TFI_CTRY.FI_CTRY_CD);
                            string rcptNM = string.Empty;
                            if (item.EXRL_ACCT_USR_BUS_TCD == "1")
                            {
                                rcptNM = db.TUSR.Find(item.EXRL_ACCT_USR_NBR).USR_FUL_NM;
                            }
                            if (item.EXRL_ACCT_USR_BUS_TCD == "2")
                            {
                                rcptNM = db.TBUS.Find(item.EXRL_ACCT_BUS_NBR).BUS_SHORT_NM;
                            }
                            item.RCPT_USR_BUS_NM = rcptNM.ToUpper() + " - " + ctry3ltrCD + " - " + item.CRCY_CD;
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
                }
                return items;
            }
            catch
            {
                return items;
            }
        }
    }
}
