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
    [Table("dbo.TRCPT_USR_BUS")]
    public class RecipientUserBusiness
    {
        public RecipientUserBusiness()
        {
            LGC_DEL_IND = "0";
            TTRANS_TRSF_CRDT_DBT = new HashSet<TransactionTransferCreditDebit>();
            TRCPT_EXRL_ACCT_FOR_BUS = new HashSet<RecipientExternalAccountForBusiness>();
            RCPT_USR_BUS_EDT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Personne Entreprise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RCPT_USR_BUS_ID { get; set; }

        [Display(Name = "Compte ID")]
        public int ACCT_ID { get; set; }

        [Required(ErrorMessage = "Le numéro de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Le numéro de compte doit avoir entre 3 et 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Numéro Compte")]
        public string ACCT_NBR { get; set; }
        
        [Required(ErrorMessage = "Le numéro matricule 1 est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le numéro  matricule 1 doit avoir entre 3 et 20 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Matricule 1")]
        public string RCPT_USR_BUS1_UIN { get; set; }

        [Required(ErrorMessage = "Le numéro matricule 2 est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le numéro  matricule 2 doit avoir entre 3 et 20 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Matricule 2")]
        public string RCPT_USR_BUS2_UIN { get; set; }

        [Required(ErrorMessage = "Le numéro matricule 3 est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le numéro  matricule 3 doit avoir entre 3 et 20 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Matricule 3")]
        public string RCPT_USR_BUS3_UIN { get; set; }
        
        [Required(ErrorMessage = "Le nom du bénéficiaire est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Le nom du bénéficiaire doit avoir entre 2 et 30 caractères.", MinimumLength = 2)]
        [Display(Name = "Nom Bénéficiaire (Personne-Entreprise)")]
        public string RCPT_USR_BUS_NM { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Nom Bénéficiaire (Personne-Entreprise)")] //1- Client Without External ID  2- Business Without External ID 
        public string RCPT_TCD { get; set; }                       //3- Client With External ID 4- Business With External ID
        
        [StringLength(10)]
        [Display(Name = "Nom Bénéficiaire Personne")]
        public string RCPT_USR_NBR { get; set; }

        [Display(Name = "Nom Bénéficiaire Entreprise")]
        public int? RCPT_BUS_NBR { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Bénéficiaire (Personne-Entreprise)")]
        public string RCPT_USR_BUS_TCD { get; set; } //1= user, 2= business, 3= both (Client In Business)

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime RCPT_USR_BUS_EDT { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }
        [Required]
        [StringLength(2)]                                           //00- Normal RCPT, from client side
        [Display(Name = "Nom Bénéficiaire (Personne-Entreprise)")]  //01- Internal Transfer BUS,
        public string ACTVT_TCD { get; set; }                       //02 = Internal Transfer CLT IN BUS

        public virtual Account TACCT { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual User TUSR { get; set; }

        public virtual User TUSR1 { get; set; }
        
        public virtual ICollection<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual ICollection<RecipientExternalAccountForBusiness> TRCPT_EXRL_ACCT_FOR_BUS { get; set; }

        private DalContext db = new DalContext();

        public RecipientUserBusiness getRecipientUserBusinessByRcptID(int rcptID)
        {
            try
            {
                var rcpt = db.TRCPT_USR_BUS.Find(rcptID);
                if (rcpt == null)
                {
                    return null;
                }
                return rcpt;
            }
            catch
            {
                return null;
            }
        }

        public List<SelectListItem> getAllRecipientByUsrNbr(string currentUsrNbr, string actvtTCD, 
                                                            string usrBusTCD, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var acctObj = new Account();
                var ctryObj = new Country();
                var list = db.TRCPT_USR_BUS.Where(x => x.USR_NBR == currentUsrNbr && x.ACTVT_TCD == actvtTCD &&
                                          x.RCPT_USR_BUS_TCD == usrBusTCD && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    foreach (var item in list)
                    {
                        var acct = new Account();
                        var rcptAcct = acct.getAccountByAcctID(item.ACCT_ID);
                        if (rcptAcct == null)
                        {
                            return null;
                        }
                        string acctNbr = item.ACCT_NBR;
                        string ctryCD = string.Empty;
                        if (acctNbr.Length < 17)
                        {
                            ctryCD = acctObj.getCountryAccountNumber(item.ACCT_NBR, "2");
                        }
                        else
                        {
                            ctryCD = acctObj.getCountryAccountNumber(item.ACCT_NBR, "3");
                        }
                        string ctry3ltrCD = ctryObj.getCountryThreeLetterByCode(ctryCD);
                        string rcptNM = string.Empty;
                        item.RCPT_USR_BUS_NM = item.RCPT_USR_BUS_NM + " - " + ctry3ltrCD + " - " + rcptAcct.CRCY_CD;
                    }
                    return new SelectList(list, "RCPT_USR_BUS_ID", "RCPT_USR_BUS_NM", selectedValue).ToList();
                }
            }
            catch
            {
                return items;
            }
        }

        public RecipientUserBusiness addPayKapRecipientAccount(int ACCT_ID, string ACCT_NBR, 
                                                    string ExrlAcctNbr1, string ExrlAcctNbr2, string ExrlAcctNbr3,
                                                    string rcptUserBusinessNM, string RCPT_TCD, string RCPT_USR_NBR,
                                                    int? RCPT_BUS_NBR, string RCPT_USR_BUS_TCD, 
                                                    string USR_NBR, string ACTVT_TCD)
        {
            //try
            //{
                var obj = new RecipientUserBusiness();

                obj.ACCT_ID = ACCT_ID;
                obj.ACCT_NBR = ACCT_NBR;
                obj.RCPT_USR_BUS1_UIN = ExrlAcctNbr1;
                obj.RCPT_USR_BUS2_UIN = ExrlAcctNbr2;
                obj.RCPT_USR_BUS3_UIN = ExrlAcctNbr3;
                obj.RCPT_USR_BUS_NM = rcptUserBusinessNM;
                obj.RCPT_TCD = RCPT_TCD;
                obj.RCPT_USR_NBR = RCPT_USR_NBR;
                obj.RCPT_BUS_NBR = RCPT_BUS_NBR;
                obj.RCPT_USR_BUS_TCD = RCPT_USR_BUS_TCD;
                obj.USR_NBR = USR_NBR;
                obj.ACTVT_TCD = ACTVT_TCD;
                db.TRCPT_USR_BUS.Add(obj);
                db.SaveChanges();
                return obj;
            //}
            //catch
            //{
            //    return null;
            //}
        }
        
        public bool updatePayKapRecipientAccount(int RCPT_USR_BUS_ID, int ACCT_ID, string ACCT_NBR, 
                                                    string ExrlAcctNbr1, string ExrlAcctNbr2, string ExrlAcctNbr3,
                                                    string rcptUserBusinessNM, string RCPT_TCD, string RCPT_USR_NBR,
                                                    int? RCPT_BUS_NBR, string RCPT_USR_BUS_TCD, string ACTVT_TCD)
        {
            try
            {
                var obj = db.TRCPT_USR_BUS.Find(RCPT_USR_BUS_ID);
                if (obj == null)
                {
                    return false;
                }

                obj.ACCT_ID = ACCT_ID;
                obj.ACCT_NBR = ACCT_NBR;
                obj.RCPT_USR_BUS1_UIN = ExrlAcctNbr1;
                obj.RCPT_USR_BUS2_UIN = ExrlAcctNbr2;
                obj.RCPT_USR_BUS3_UIN = ExrlAcctNbr3;
                obj.RCPT_USR_BUS_NM = rcptUserBusinessNM;
                obj.RCPT_TCD = RCPT_TCD;
                obj.RCPT_USR_NBR = RCPT_USR_NBR;
                obj.RCPT_BUS_NBR = RCPT_BUS_NBR;
                obj.RCPT_USR_BUS_TCD = RCPT_USR_BUS_TCD;
                obj.ACTVT_TCD = ACTVT_TCD;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool deletePayKapRecipientAccount(int RCPT_USR_BUS_ID)
        //{
        //    try
        //    {
        //        var obj = db.TRCPT_USR_BUS.Find(RCPT_USR_BUS_ID);
        //        if (obj == null)
        //        {
        //            return false;
        //        }

        //        db.TRCPT_USR_BUS.Remove(obj);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        
        public RecipientUserBusiness getOnePayKapRecipientAccount(string currentUsrNbr, string acctNbr,
                                                        string rcptUsrNbr, int? rcptBN, string usrBusTCD, string actvtTCD)
        {
            if (usrBusTCD == "1")
            {
                var list = db.TRCPT_USR_BUS.Where(x => x.ACCT_NBR == acctNbr && x.RCPT_USR_NBR == rcptUsrNbr &&
                                                       x.USR_NBR == currentUsrNbr && x.ACTVT_TCD == actvtTCD &&
                                                       x.RCPT_USR_BUS_TCD == usrBusTCD && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() != 0)
                {
                    var busRcpt = list[0];
                    return busRcpt;
                }
            }
            else if (usrBusTCD == "2")
            {
                var list = db.TRCPT_USR_BUS.Where(x => x.ACCT_NBR == acctNbr && x.RCPT_BUS_NBR == rcptBN &&
                                                       x.USR_NBR == currentUsrNbr && x.ACTVT_TCD == actvtTCD &&
                                                       x.RCPT_USR_BUS_TCD == usrBusTCD && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() != 0)
                {
                    var busRcpt = list[0];
                    return busRcpt;
                }
            }
            else if (usrBusTCD == "3")
            {
                var list = db.TRCPT_USR_BUS.Where(x => x.ACCT_NBR == acctNbr &&
                                                       x.RCPT_BUS_NBR == rcptBN && x.RCPT_USR_NBR == rcptUsrNbr &&
                                                       x.USR_NBR == currentUsrNbr && x.ACTVT_TCD == actvtTCD &&
                                                       x.RCPT_USR_BUS_TCD == usrBusTCD && x.LGC_DEL_IND == "0").ToList();
                if (list.Count() != 0)
                {
                    var busRcpt = list[0];
                    return busRcpt;
                }
            }
            return null;
        }

        public bool checkIfPayKapAccountAlreadyExist(string currentUsrNbr, string acctNbr, string rcptUsrNbr,
                                                     int? rcptBN, string usrBusTCD, string actvtTCD)
        {
            var obj = getOnePayKapRecipientAccount(currentUsrNbr, acctNbr, rcptUsrNbr, rcptBN, usrBusTCD, actvtTCD);
            if (obj == null)
            {
                return false;
            }
            return true;
        }

        public RecipientUserBusiness getOrRegisterPayKapRecipientUserBusiness(string currentUsrNbr,
                                                        string acctNbr, string rcptUsrNbr, int? rcptBN,
                                                        string usrBusTCD, int ACCT_ID, string USR_BUS_NM,
                                                        string actvtTCD)
        {
            var getRcptBus = getOnePayKapRecipientAccount(currentUsrNbr, acctNbr, rcptUsrNbr, rcptBN, usrBusTCD, actvtTCD);
            if (getRcptBus == null)
            {
                string rcptTCD = usrBusTCD;
                var newOjb = addPayKapRecipientAccount(ACCT_ID, acctNbr, "d", "d", "d", USR_BUS_NM, rcptTCD,
                                                       rcptUsrNbr, rcptBN, usrBusTCD, currentUsrNbr, actvtTCD);
                if (newOjb != null)
                {
                    var getRcptBus1 = getOnePayKapRecipientAccount(currentUsrNbr, acctNbr, rcptUsrNbr, rcptBN, usrBusTCD, actvtTCD);
                    if (getRcptBus1 != null)
                    {
                        return getRcptBus1;
                    }
                }
                return null;
            }
            else
            {
                return getRcptBus;
            }
        }

        public string getAccountNumberByRcptID(string rcptID)
        {
            int rcptPkpID = Convert.ToInt32(rcptID);
            var thisPkpRcpt = getRecipientUserBusinessByRcptID(rcptPkpID);
            if (thisPkpRcpt == null)
            {
                return null;
            }

            //get the recipient account number
            var acct = new Account();
            var rcptAcct = acct.getAccountByAcctID(thisPkpRcpt.ACCT_ID);
            if (rcptAcct == null)
            {
                return null;
            }
            return rcptAcct.ACCT_NBR;
        }

        public RecipientUserBusiness getDefaultRecipientUserBusinessByAdminUsrNbr(string adminUsrNbr)
        {
            try
            {
                var getRcptAdmin = db.TRCPT_USR_BUS.Where(x => x.RCPT_USR_NBR == adminUsrNbr && x.USR_NBR == adminUsrNbr &&
                                                                   x.RCPT_USR_BUS_TCD == "0").ToList();
                if (getRcptAdmin.Count() != 1)
                {
                    return null;
                }

                var rcpt = getRcptAdmin[0];
                if (rcpt == null)
                {
                    return null;
                }
                return rcpt;
            }
            catch
            {
                return null;
            }
        }
    }
}
