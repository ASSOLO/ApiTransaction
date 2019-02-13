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
    [Table("dbo.TUSR_PHN_LGN")]
    public class UserPhoneLogin
    {
        public UserPhoneLogin()
        {
            LGC_DEL_IND = "0";
            USR_PHN_LGN_VRFT_IND = "0";
            USR_PHN_LGN_VRFT_DT = Convert.ToDateTime("2000-01-01");
        }

        [Key]
        [StringLength(25)]
        [Display(Name = "Numéro Téléphone")]
        public string USR_PHN_LGN_NBR { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Display(Name = "ID Compte")]
        public int ACCT_ID { get; set; }

        [Display(Name = "ID Carte")]
        public int CARD_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Mise À Jour ? ")]
        public string USR_PHN_LGN_VRFT_IND { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Mise À Jour")]
        public DateTime USR_PHN_LGN_VRFT_DT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Suppression Logique ?")]
        public string LGC_DEL_IND { get; set; }

        public virtual Account TACCT { get; set; }

        public virtual CallingCountry TCAL_CTRY { get; set; }

        public virtual Card TCARD { get; set; }

        public virtual User TUSR { get; set; }

        private DalContext db = new DalContext();

        public UserPhoneLogin createAgentToken(string LoginPhone, string USR_NBR, int ACCT_ID, int CARD_ID, string CTRY_CD)
        {
            try
            {
                var obj = new UserPhoneLogin();
                obj.USR_PHN_LGN_NBR = LoginPhone;
                obj.USR_NBR = USR_NBR;
                obj.ACCT_ID = ACCT_ID;
                obj.CARD_ID = CARD_ID;
                obj.CTRY_CD = CTRY_CD;
                //db.TUSR_PHN_LGN.Add(obj);
                //db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

     /*   public AgencyTransactionClientData getClientData(string cardNbr, string phnNbr, string acctNbr, string acctTCD, string cardPhnAcctTCD)
        {
            try
            {
                var model = new AgencyTransactionClientData();
                var objAcct = new Account();
                var objCard = new Card();
                var objUsr = new User();
                var objUsrPhn = new UserPhoneLogin();
                string ACCT_NBR = null;
                int ACCT_ID = 0;
                string CRCY_CD = null;
                string USR_FUL_NM = null;
                string USR_NBR = null;
                string UserId = null;

                if (cardPhnAcctTCD == "card")
                {
                    var cardOwner = getCardOwnerByCardNbr(cardNbr);
                    var acctOwner = getAccountCardOwnerByCardNbr(cardNbr);
                    var cltUser = db.TUSR.Find(cardOwner.USR_NBR);
                    if (cltUser == null)
                    {
                        return null;
                    }

                    ACCT_NBR = acctOwner.ACCT_NBR;
                    ACCT_ID = acctOwner.ACCT_ID;
                    CRCY_CD = acctOwner.CRCY_CD;
                    USR_FUL_NM = cltUser.USR_FUL_NM;
                    USR_NBR = acctOwner.USR_NBR;
                    UserId = cltUser.Id.TrimEnd();
                }
                else if (cardPhnAcctTCD == "phn")
                {
                    var getUserPhn = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
                    if (getUserPhn == null)
                    {
                        return null;
                    }

                    var getAcct = objAcct.getAccountByAcctID(getUserPhn.ACCT_ID);
                    var getUser = objUsr.getUserByUsrNbr(getUserPhn.USR_NBR);
                    if (getAcct == null || getUser == null)
                    {
                        return null;
                    }

                    ACCT_NBR = getAcct.ACCT_NBR;
                    ACCT_ID = getAcct.ACCT_ID;
                    CRCY_CD = getAcct.CRCY_CD;
                    USR_FUL_NM = getUser.USR_FUL_NM;
                    USR_NBR = getUser.USR_NBR;
                    UserId = getUser.Id.TrimEnd();
                }
                else if (cardPhnAcctTCD == "acct")
                {
                    var getAcct = objAcct.getAccountByAcctNbr(acctNbr, "1");
                    if (getAcct == null)
                    {
                        return null;
                    }

                    var getUser = objUsr.getUserByUsrNbr(getAcct.USR_NBR);
                    if (getAcct == null || getUser == null)
                    {
                        return null;
                    }

                    ACCT_NBR = getAcct.ACCT_NBR;
                    ACCT_ID = getAcct.ACCT_ID;
                    CRCY_CD = getAcct.CRCY_CD;
                    USR_FUL_NM = getUser.USR_FUL_NM;
                    USR_NBR = getUser.USR_NBR;
                    UserId = getUser.Id.TrimEnd();
                }
                else
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(ACCT_NBR) || ACCT_ID == 0 || string.IsNullOrWhiteSpace(CRCY_CD) ||
                    string.IsNullOrWhiteSpace(USR_FUL_NM) || string.IsNullOrWhiteSpace(USR_NBR) || string.IsNullOrWhiteSpace(UserId))
                {
                    return null;
                }

                model.CLT_CTRY_CD = ACCT_NBR.Substring(0, 3);
                model.CLT_ACCT_ID = ACCT_ID;
                model.CLT_CRCY_CD = CRCY_CD;
                model.CLT_FUL_NM = USR_FUL_NM.ToUpper();
                model.CLT_USR_NBR = USR_NBR;
                model.CLT_USR_ID = UserId;
                return model;
            }
            catch
            {
                return null;
            }
        } */

        public UserPhoneLogin getOneValidUserPhoneLoginByPhnNbr(string phnNbr)
        {
            if (!string.IsNullOrWhiteSpace(phnNbr))
            {
                phnNbr = CommonLibrary.replaceWhiteSpace(phnNbr);
            }

            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_PHN_LGN_NBR == phnNbr && x.LGC_DEL_IND == "0").ToList();
            if (usrPhnLoginList.Count() == 0)
            {
                return null;
            }
            else
            {
                var usrPhnLogin = usrPhnLoginList[0];
                if (usrPhnLogin == null)
                {
                    return null;
                }
                return usrPhnLogin;
            }
        }

        public UserPhoneLogin getOneValidUserPhoneLoginByUsrNbr(string usrNbr, int acctID)
        {
            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.ACCT_ID == acctID && x.LGC_DEL_IND == "0").ToList();
            if (usrPhnLoginList.Count() == 0)
            {
                return null;
            }
            else
            {
                var usrPhnLogin = usrPhnLoginList[0];
                if (usrPhnLogin == null)
                {
                    return null;
                }
                return usrPhnLogin;
            }
        }

        public UserPhoneLogin getOneValidUserPhoneLoginByUsrNbr(string usrNbr)
        {
            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.LGC_DEL_IND == "0").ToList();
            if (usrPhnLoginList.Count() == 0)
            {
                return null;
            }
            else
            {
                var usrPhnLogin = usrPhnLoginList[0];
                if (usrPhnLogin == null)
                {
                    return null;
                }
                return usrPhnLogin;
            }
        }

        public List<UserPhoneLogin> getAllValidUserPhoneLoginByUsrNbr(string usrNbr)
        {
            return db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.LGC_DEL_IND == "0").ToList(); ;
        }


        public bool verifyUserPhoneLoginByUserId(string phnNbr, string userId)
        {
            var usrList = db.TUSR.Where(x => x.Id == userId).ToList();
            if (usrList.Count() == 0)
            {
                return false;
            }
            else
            {
                var usr = usrList[0];
                if (usr == null)
                {
                    return false;
                }

                var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_PHN_LGN_NBR == phnNbr &&
                                                                 x.USR_NBR == usr.USR_NBR && x.LGC_DEL_IND == "0").ToList();
                if (usrPhnLoginList.Count() == 0)
                {
                    return false;
                }
                else
                {
                    var usrPhnLogin = usrPhnLoginList[0];
                    if (usrPhnLogin == null)
                    {
                        return false;
                    }

                    usrPhnLogin.USR_PHN_LGN_VRFT_IND = "1";// 1 = verify
                    usrPhnLogin.USR_PHN_LGN_VRFT_DT = DateTime.Now;
                    db.Entry(usrPhnLogin).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public string checkValidCountryPhoneLength(string ctryCD, string phn)
        {
            try
            {
                var calCtry = db.TCAL_CTRY.Find(ctryCD);
                if (calCtry == null)
                {
                    return null;
                }
                int phnLength = phn.Length;
                if (calCtry.CTRY_PHN_NBR_LNGH_CNT != phnLength)
                {
                    return "false";
                }
                else
                {
                    return "true";
                }
            }
            catch
            {
                return null;
            }
        }

        public Card getCardByPhnNbr(string phnNbr)
        {
            var getUserPhnLogin = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
            if (getUserPhnLogin == null)
            {
                return null;
            }

            var cardOwner = db.TCARD.Find(getUserPhnLogin.CARD_ID);
            if (cardOwner == null)
            {
                return null;
            }

            string cardNbr = Encryption.DecryptAes(cardOwner.CARD_NBR);
            if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16)
            {
                return null;
            }
            cardOwner.CARD_NBR = cardNbr;
            return cardOwner;
        }

        public Card getBusinessCardByPhnNbr(string phnNbr)
        {
            var getUserPhnLogin = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
            if (getUserPhnLogin == null)
            {
                return null;
            }

            var newCard = new Card();
            var cardOwner = newCard.getCardByUsrNbr(getUserPhnLogin.USR_NBR, "2");
            if (cardOwner == null)
            {
                return null;
            }
            return cardOwner;
        }

        public Card getCardOwnerByCardNbr(string cardNbr)
        {
            var cardNbrHash = Encryption.EncryptAes(cardNbr);
            var CardList = db.TCARD.Where(x => x.CARD_NBR == cardNbrHash).ToList();
            if (CardList.Count() == 0)
            {
                return null;
            }
            else
            {
                var card = CardList[0];
                if (card == null)
                {
                    return null;
                }
                return card;
            }
        }

        public User getUserCardOwnerByCardNbr(string cardNbr)
        {
            var cardOwner = getCardOwnerByCardNbr(cardNbr);
            if (cardOwner == null)
            {
                return null;
            }
            else
            {
                var user = db.TUSR.Find(cardOwner.USR_NBR);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
        }

        public Account getAccountCardOwnerByCardNbr(string cardNbr)
        {
            var cardOwner = getCardOwnerByCardNbr(cardNbr);
            if (cardOwner == null)
            {
                return null;
            }
            else
            {
                var userAcctList = db.TACCT.Where(x => x.USR_NBR == cardOwner.USR_NBR && x.ACCT_TCD == cardOwner.CARD_TCD).ToList();
                if (userAcctList.Count() == 0)
                {
                    return null;
                }

                var userAcct = userAcctList[0];
                if (userAcct == null)
                {
                    return null;
                }
                return userAcct;
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Web.Mvc;
//using System.Data.Entity;

//namespace pkpApp.Models.DAL
//{
//    [Table("dbo.TUSR_PHN_LGN")]
//    public class UserPhoneLogin
//    {
//        public UserPhoneLogin()
//        {
//            LGC_DEL_IND = "0";
//            USR_PHN_LGN_VRFT_IND = "0";
//            USR_PHN_LGN_VRFT_DT = Convert.ToDateTime("2000-01-01");
//        }

//        [Key]
//        [StringLength(25)]
//        [Display(Name = "Numéro Téléphone")]
//        public string USR_PHN_LGN_NBR { get; set; }

//        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [Display(Name = "ID Utilisateur")]
//        public string USR_NBR { get; set; }

//        [Display(Name = "ID Compte")]
//        public int ACCT_ID { get; set; }

//        [Display(Name = "ID Carte")]
//        public int CARD_ID { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [DataType(DataType.Text)]
//        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
//        [Display(Name = "Code Pays")]
//        public string CTRY_CD { get; set; }

//        [Required(ErrorMessage = "La {0} est obligatoire.")]
//        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
//        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
//        [Display(Name = "Mise À Jour ? ")]
//        public string USR_PHN_LGN_VRFT_IND { get; set; }

//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
//        [DataType(DataType.Date)]
//        [Display(Name = "Date Mise À Jour")]
//        public DateTime USR_PHN_LGN_VRFT_DT { get; set; }

//        [Required(ErrorMessage = "La {0} est obligatoire.")]
//        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
//        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
//        [Display(Name = "Suppression Logique ?")]
//        public string LGC_DEL_IND { get; set; }

//        public virtual Account TACCT { get; set; }

//        public virtual CallingCountry TCAL_CTRY { get; set; }

//        public virtual Card TCARD { get; set; }

//        public virtual User TUSR { get; set; }

//        private DalContext db = new DalContext();

//        public UserPhoneLogin createAgentToken(string LoginPhone, string USR_NBR, int ACCT_ID, int CARD_ID, string CTRY_CD)
//        {
//            try
//            {
//                var obj = new UserPhoneLogin();
//                obj.USR_PHN_LGN_NBR = LoginPhone;
//                obj.USR_NBR = USR_NBR;
//                obj.ACCT_ID = ACCT_ID;
//                obj.CARD_ID = CARD_ID;
//                obj.CTRY_CD = CTRY_CD;
//                //db.TUSR_PHN_LGN.Add(obj);
//                //db.SaveChanges();
//                return obj;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public AgencyTransactionClientData getClientData(string cardNbr, string phnNbr, string acctNbr, string acctTCD, string cardPhnAcctTCD)
//        {
//            try
//            {
//                var model = new AgencyTransactionClientData();
//                var objAcct = new Account();
//                var objCard = new Card();
//                var objUsr = new User();
//                var objUsrPhn = new UserPhoneLogin();
//                string ACCT_NBR = null;
//                int ACCT_ID = 0;
//                string CRCY_CD = null;
//                string USR_FUL_NM = null;
//                string USR_NBR = null;
//                string UserId = null;

//                if (cardPhnAcctTCD == "card")
//                {
//                    var cardOwner = getCardOwnerByCardNbr(cardNbr);
//                    var acctOwner = getAccountCardOwnerByCardNbr(cardNbr);
//                    var cltUser = db.TUSR.Find(cardOwner.USR_NBR);
//                    if (cltUser == null)
//                    {
//                        return null;
//                    }

//                    ACCT_NBR = acctOwner.ACCT_NBR;
//                    ACCT_ID = acctOwner.ACCT_ID;
//                    CRCY_CD = acctOwner.CRCY_CD;
//                    USR_FUL_NM = cltUser.USR_FUL_NM;
//                    USR_NBR = acctOwner.USR_NBR;
//                    UserId = cltUser.Id.TrimEnd();
//                }
//                else if (cardPhnAcctTCD == "phn")
//                {
//                    var getUserPhn = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
//                    if (getUserPhn == null)
//                    {
//                        return null;
//                    }

//                    var getAcct = objAcct.getAccountByAcctID(getUserPhn.ACCT_ID);
//                    var getUser = objUsr.getUserByUsrNbr(getUserPhn.USR_NBR);
//                    if (getAcct == null || getUser == null)
//                    {
//                        return null;
//                    }

//                    ACCT_NBR = getAcct.ACCT_NBR;
//                    ACCT_ID = getAcct.ACCT_ID;
//                    CRCY_CD = getAcct.CRCY_CD;
//                    USR_FUL_NM = getUser.USR_FUL_NM;
//                    USR_NBR = getUser.USR_NBR;
//                    UserId = getUser.Id.TrimEnd();
//                }
//                else if (cardPhnAcctTCD == "acct")
//                {
//                    var getAcct = objAcct.getAccountByAcctNbr(acctNbr, acctTCD);
//                    if (getAcct == null)
//                    {
//                        return null;
//                    }

//                    var getUser = objUsr.getUserByUsrNbr(getAcct.USR_NBR);
//                    if (getAcct == null || getUser == null)
//                    {
//                        return null;
//                    }

//                    ACCT_NBR = getAcct.ACCT_NBR;
//                    ACCT_ID = getAcct.ACCT_ID;
//                    CRCY_CD = getAcct.CRCY_CD;
//                    USR_FUL_NM = getUser.USR_FUL_NM;
//                    USR_NBR = getUser.USR_NBR;
//                    UserId = getUser.Id.TrimEnd();
//                }
//                else
//                {
//                    return null;
//                }

//                if(string.IsNullOrWhiteSpace(ACCT_NBR) || ACCT_ID == 0 || string.IsNullOrWhiteSpace(CRCY_CD) ||
//                    string.IsNullOrWhiteSpace(USR_FUL_NM) || string.IsNullOrWhiteSpace(USR_NBR) || string.IsNullOrWhiteSpace(UserId))
//                {
//                    return null;
//                }

//                model.CLT_CTRY_CD = ACCT_NBR.Substring(0, 3);
//                model.CLT_ACCT_ID = ACCT_ID;
//                model.CLT_CRCY_CD = CRCY_CD;
//                model.CLT_FUL_NM = USR_FUL_NM.ToUpper();
//                model.CLT_USR_NBR = USR_NBR;
//                model.CLT_USR_ID = UserId;
//                return model;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public UserPhoneLogin getOneValidUserPhoneLoginByPhnNbr(string phnNbr)
//        {
//            if (!string.IsNullOrWhiteSpace(phnNbr))
//            {
//                phnNbr = CommonLibrary.replaceWhiteSpace(phnNbr);
//            }

//            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_PHN_LGN_NBR == phnNbr && x.LGC_DEL_IND == "0").ToList();
//            if (usrPhnLoginList.Count() == 0)
//            {
//                return null;
//            }
//            else
//            {
//                var usrPhnLogin = usrPhnLoginList[0];
//                if (usrPhnLogin == null)
//                {
//                    return null;
//                }
//                return usrPhnLogin;
//            }
//        }

//        public UserPhoneLogin getOneValidUserPhoneLoginByUsrNbr(string usrNbr, int acctID)
//        {
//            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.ACCT_ID == acctID && x.LGC_DEL_IND == "0").ToList();
//            if (usrPhnLoginList.Count() == 0)
//            {
//                return null;
//            }
//            else
//            {
//                var usrPhnLogin = usrPhnLoginList[0];
//                if (usrPhnLogin == null)
//                {
//                    return null;
//                }
//                return usrPhnLogin;
//            }
//        }

//        public UserPhoneLogin getOneValidUserPhoneLoginByUsrNbr(string usrNbr)
//        {
//            var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.LGC_DEL_IND == "0").ToList();
//            if (usrPhnLoginList.Count() == 0)
//            {
//                return null;
//            }
//            else
//            {
//                var usrPhnLogin = usrPhnLoginList[0];
//                if (usrPhnLogin == null)
//                {
//                    return null;
//                }
//                return usrPhnLogin;
//            }
//        }

//        public List<UserPhoneLogin> getAllValidUserPhoneLoginByUsrNbr(string usrNbr)
//        {
//            return db.TUSR_PHN_LGN.Where(x => x.USR_NBR == usrNbr && x.LGC_DEL_IND == "0").ToList(); ;
//        }


//        public bool verifyUserPhoneLoginByUserId(string phnNbr, string userId)
//        {
//            var usrList = db.TUSR.Where(x => x.Id == userId).ToList();
//            if (usrList.Count() == 0)
//            {
//                return false;
//            }
//            else
//            {
//                var usr = usrList[0];
//                if (usr == null)
//                {
//                    return false;
//                }

//                var usrPhnLoginList = db.TUSR_PHN_LGN.Where(x => x.USR_PHN_LGN_NBR == phnNbr &&
//                                                                 x.USR_NBR == usr.USR_NBR &&  x.LGC_DEL_IND == "0").ToList();
//                if (usrPhnLoginList.Count() == 0)
//                {
//                    return false;
//                }
//                else
//                {
//                    var usrPhnLogin = usrPhnLoginList[0];
//                    if (usrPhnLogin == null)
//                    {
//                        return false;
//                    }

//                    usrPhnLogin.USR_PHN_LGN_VRFT_IND = "1";// 1 = verify
//                    usrPhnLogin.USR_PHN_LGN_VRFT_DT = DateTime.Now;
//                    db.Entry(usrPhnLogin).State = EntityState.Modified;
//                    db.SaveChanges();
//                    return true;
//                }
//            }
//        }

//        public string checkValidCountryPhoneLength(string ctryCD, string phn)
//        {
//            try
//            {
//                var calCtry = db.TCAL_CTRY.Find(ctryCD);
//                if (calCtry == null)
//                {
//                    return null;
//                }
//                int phnLength = phn.Length;
//                if (calCtry.CTRY_PHN_NBR_LNGH_CNT != phnLength)
//                {
//                    return "false";
//                }
//                else
//                {
//                    return "true";
//                }
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public Card getCardByPhnNbr(string phnNbr)
//        {
//            var getUserPhnLogin = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
//            if (getUserPhnLogin == null)
//            {
//                return null;
//            }

//            var cardOwner = db.TCARD.Find(getUserPhnLogin.CARD_ID);
//            if (cardOwner == null)
//            {
//                return null;
//            }

//            string cardNbr = Encryption.DecryptAes(cardOwner.CARD_NBR);
//            if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16)
//            {
//                return null;
//            }
//            cardOwner.CARD_NBR = cardNbr;
//            return cardOwner;
//        }

//        public Card getBusinessCardByPhnNbr(string phnNbr)
//        {
//            var getUserPhnLogin = getOneValidUserPhoneLoginByPhnNbr(phnNbr);
//            if (getUserPhnLogin == null)
//            {
//                return null;
//            }

//            var newCard = new Card();
//            var cardOwner = newCard.getCardByUsrNbr(getUserPhnLogin.USR_NBR, "2");
//            if (cardOwner == null)
//            {
//                return null;
//            }
//            return cardOwner;
//        }

//        public Card getCardOwnerByCardNbr(string cardNbr)
//        {
//            var cardNbrHash = Encryption.EncryptAes(cardNbr);
//            var CardList = db.TCARD.Where(x => x.CARD_NBR == cardNbrHash).ToList();
//            if (CardList.Count() == 0)
//            {
//                return null;
//            }
//            else
//            {
//                var card = CardList[0];
//                if (card == null)
//                {
//                    return null;
//                }
//                return card;
//            }
//        }

//        public User getUserCardOwnerByCardNbr(string cardNbr)
//        {
//            var cardOwner = getCardOwnerByCardNbr(cardNbr);
//            if (cardOwner == null)
//            {
//                return null;
//            }
//            else
//            {
//                var user = db.TUSR.Find(cardOwner.USR_NBR);
//                if (user == null)
//                {
//                    return null;
//                }
//                return user;
//            }
//        }

//        public Account getAccountCardOwnerByCardNbr(string cardNbr)
//        {
//            var cardOwner = getCardOwnerByCardNbr(cardNbr);
//            if (cardOwner == null)
//            {
//                return null;
//            }
//            else
//            {
//                var userAcctList = db.TACCT.Where(x => x.USR_NBR == cardOwner.USR_NBR && x.ACCT_TCD == cardOwner.CARD_TCD).ToList();
//                if (userAcctList.Count() == 0)
//                {
//                    return null;
//                }

//                var userAcct = userAcctList[0];
//                if (userAcct == null)
//                {
//                    return null;
//                }
//                return userAcct;
//            }
//        }
//    }
//}
