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
    [Table("dbo.TCARD")]
    public class Card
    {
        public Card()
        {
            TUSR_PHN_LGN = new HashSet<UserPhoneLogin>();
            TBUS = new HashSet<Business>();
            //TCARD_TRANS = new HashSet<CardTransaction>();
            //TCARD_CHNG_LOG = new HashSet<CardChangeLog>();
            //TCARD_OTH_FI_EXRL_ACCT = new HashSet<CardOtherFinancialInstitutionExternalAccount>();
            //TCARD_DPST_WDRW_TRANS = new HashSet<CardDepositWithdrawalTransaction>();
            PHYS_CARD_SCD = "1"; //1 = Card is electronically created
        }

        [Key]
        [Display(Name = "Carte ID")]
        public int CARD_ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Propiétaire Carte")]
        public string CARD_OWNR_FNM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Numéro Carte")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [StringLength(4, ErrorMessage = "Le code de vérification doit avoir 4 chiffres.", MinimumLength = 4)]
        [Display(Name = "Code Verification")]
        public string CARD_CVV_CD { get; set; }

        [Required(ErrorMessage = "Le code secret ou NIP est obligatoire.")]
        [StringLength(4, ErrorMessage = "Le code secret ou  NIP doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le code secret ou NIP doit avoir des chiffres et de longueur 4.")]
        [DataType(DataType.Password)]
        [Display(Name = "NIP")]
        public string CARD_PIN { get; set; }

        [Required(ErrorMessage = "Confirmer le NIP est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer NIP")]
        [System.ComponentModel.DataAnnotations.Compare("CARD_PIN", ErrorMessage = "Les deux NIP ne correspondent pas.")]
        [NotMapped]
        public string CONFIRM_CARD_PIN { get; set; }

        [Required(ErrorMessage = "Le NIP actuel est obligatoire.")]
        [StringLength(4, ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
        //[RegularExpression(@"((?=.*\d).{4})", ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.")]
        [DataType(DataType.Password)]
        [Display(Name = "NIP Actuel")]
        [NotMapped]
        public string CURRENT_CARD_PIN { get; set; }

        [Required(ErrorMessage = "Le nouveau NIP est obligatoire.")]
        [StringLength(4, ErrorMessage = "Le nouveau NIP doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP doit avoir des chiffres et de longueur 4.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau NIP")]
        [NotMapped]
        public string NEW_CARD_PIN { get; set; }

        [Required(ErrorMessage = "Confirmer le nouveau NIP est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Nouveau NIP")]
        [System.ComponentModel.DataAnnotations.Compare("NEW_CARD_PIN", ErrorMessage = "Les deux NIP ne correspondent pas.")]
        [NotMapped]
        public string CONFIRM_NEW_CARD_PIN { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime CARD_EDT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'Expiration")]
        public DateTime CARD_XDT { get; set; }

        [Required(ErrorMessage = "Le Type de carte est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le Type de carte  doit avoir 1 caractères.", MinimumLength = 1)]
        [Display(Name = "Type Carte")]
        public string CARD_TCD { get; set; }

        [Required(ErrorMessage = "Le statut de carte est obligatoire.")]
        [StringLength(2, ErrorMessage = "Le statut de carte  doit avoir au trop 2 caractères.")]
        [Display(Name = "Statut Carte")]
        public string CARD_SCD { get; set; }

        [Required(ErrorMessage = "Le pays de carte est obligatoire.")]
        [StringLength(3, ErrorMessage = "Le pays de carte  doit avoir 3 caractères.", MinimumLength = 3)]
        [Display(Name = "Pays Carte")]
        public string CARD_CTRY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de Création")]
        public DateTime CARD_CDT { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [StringLength(1, ErrorMessage = "Le code secret doit avoir 1 caractère.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Pin Defaut")]
        public string DFLT_PIN_IND { get; set; }

        [StringLength(1, ErrorMessage = "Le {0} doit avoir 1 caractère.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Statut Card Physique")]
        public string PHYS_CARD_SCD { get; set; }

        [Required(ErrorMessage = "Declarer que vous avez noté le numéro de carte PayKap dans un endroit sécuritaire est obligatoire")]
        [Display(Name = "Déclaration")]
        [NotMapped]
        public bool MustNoteCardNumberAcceptance { get; set; }

        [Display(Name = "Nom Pays Carte")]
        [NotMapped]
        public string CARD_CTRY_NM { get; set; }

        [Display(Name = "Code Devise Carte")]
        [NotMapped]
        public string CARD_CRCY_CD { get; set; }

        [Display(Name = "Texte Date Expiration")]
        [NotMapped]
        public string CARD_XDT_TXT { get; set; }

        public virtual Country TCTRY { get; set; }
        public virtual User TUSR { get; set; }
        public virtual ICollection<UserPhoneLogin> TUSR_PHN_LGN { get; set; }
        public virtual ICollection<Business> TBUS { get; set; }
        //public virtual ICollection<CardTransaction> TCARD_TRANS { get; set; }
        //public virtual CardCategory TCARD_CAT { get; set; }
        //public virtual ICollection<CardChangeLog> TCARD_CHNG_LOG { get; set; }
        //public virtual ICollection<CardOtherFinancialInstitutionExternalAccount> TCARD_OTH_FI_EXRL_ACCT { get; set; }
        //public virtual ICollection<CardDepositWithdrawalTransaction> TCARD_DPST_WDRW_TRANS { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public Card createNewCardNumber(string userID, string userNBR, string userTCD, string userFulNm,
                                        string ctryCD, string cardPIN, string CARD_SCD,
                                        string defaultCardPinIND, bool pkpCardIND,
                                        int bnForBusOfferingCard, int CARD_CAT_TY_ID)
        {
            try
            {
                var newCard = new Card();

                string cardNbr = "";
                string cardCvvCD = "";

                //get the number of yeat to get the card expiry
                //var cardCatTY = new CardCategoryType();
                int yearNbrToExpiry = 4;
                //if (pkpCardIND)
                //{
                //    var pkpCat = cardCatTY.getOneCardCategoryTypeForPKP();
                //    if (pkpCat == null)
                //    {
                //        return null;
                //    }
                //    yearNbrToExpiry = pkpCat.CARD_CAT_EXP_YR_NBR;
                //}
                //else
                //{
                //    var busCat = cardCatTY.getOneCardCategoryTypeByID(CARD_CAT_TY_ID);
                //    if (busCat == null)
                //    {
                //        return null;
                //    }
                //    yearNbrToExpiry = busCat.CARD_CAT_EXP_YR_NBR;
                //}

                //if (yearNbrToExpiry == 0)
                //{
                //    return null;
                //}

                DateTime CARD_XDT = DateTime.Now.AddYears(yearNbrToExpiry).Date;

                cardNbr = generateCardNumber(userTCD, ctryCD, pkpCardIND, bnForBusOfferingCard);
                cardCvvCD = generateCardCvvCD(db.TCARD.ToList().Count());

                if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16 ||
                    string.IsNullOrWhiteSpace(cardCvvCD) || cardCvvCD.Length != 4)
                {
                    return null;
                }

                newCard.CARD_OWNR_FNM = userFulNm;
                newCard.USR_NBR = userNBR;
                newCard.CARD_CTRY_CD = ctryCD;
                newCard.CARD_EDT = DateTime.Now.Date;
                newCard.CARD_XDT = CARD_XDT;
                newCard.CARD_NBR = cardNbr;
                newCard.CARD_CVV_CD = cardCvvCD;
                newCard.CARD_PIN = cardPIN;
                newCard.CARD_CDT = DateTime.Now;
                newCard.CARD_TCD = "1";
                newCard.CARD_SCD = CARD_SCD;
                newCard.DFLT_PIN_IND = defaultCardPinIND; //1= yes, 0 = no
                return newCard;
            }
            catch
            {
                return null;
            }
        }

        public bool updateDefaultCardPinIndicator(int cardID)
        {
            try
            {
                var card = db.TCARD.Find(cardID);
                if (card == null)
                {
                    return false;
                }

                if (card.DFLT_PIN_IND == "1")
                {
                    card.DFLT_PIN_IND = "0";
                    db.Entry(card).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Card getCardNumber(string userID, string cardTCD)
        {
            try
            {
                var userList = db.TUSR.Where(x => x.Id == userID).ToList();
                if (userList.Count() == 0) { return null; }

                var Tuser = userList[0];
                if (Tuser == null) { return null; }

                string userNbr = Tuser.USR_NBR;
                if (string.IsNullOrWhiteSpace(userNbr)) { return null; }

                var CardList = db.TCARD.Where(x => x.USR_NBR == userNbr && x.CARD_TCD == cardTCD).ToList();
                if (CardList.Count() == 0) { return null; }

                var card = CardList[0];
                if (card == null) { return null; }

                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
                return card;
            }
            catch
            {
                return null;
            }
        }

        public Card getCardByCardID(int cardID)
        {
            try
            {
                var card = db.TCARD.Find(cardID);
                if (card == null) { return null; }

                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
                return card;
            }
            catch
            {
                return null;
            }
        }

        public Card getCardByUsrNbr(string usrNbr, string cardTCD)
        {
            try
            {
                var cardList = db.TCARD.Where(x => x.USR_NBR == usrNbr && x.CARD_TCD == cardTCD).ToList();
                if (cardList.Count() != 1) { return null; }

                var card = cardList[0];
                if (card == null) { return null; }

                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
                return card;
            }
            catch
            {
                return null;
            }
        }

        public Card getCardByCardNbr(string cardNbr)
        {
            try
            {
                var cardNbrHash = Encryption.EncryptAes(cardNbr);
                var CardList = db.TCARD.Where(x => x.CARD_NBR == cardNbrHash).ToList();
                if (CardList.Count() != 1)
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

                    card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
                    card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
                    card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
                    return card;
                }
            }
            catch
            {
                return null;
            }
        }

        public string generateCardNumber(string usrTCD, string ctryCD, bool pkpCardIND, int BN)
        {
            try
            {
                string sevenNineChar;
                if (usrTCD == "2") { sevenNineChar = "1"; }  //PKP employee
                else if (usrTCD == "3" || usrTCD == "4" || usrTCD == "5") { sevenNineChar = "9"; }  //3 transfer business, 4 bill creditor business
                else if (usrTCD == "1") { sevenNineChar = "7"; }  //client
                else { sevenNineChar = "0"; }  //admin

                //var new4DigitObj = new CardNumberFirstFourDigit();
                //string first4Digit = new4DigitObj.getOneCardNumberFirstFourDigit(ctryCD, pkpCardIND, BN);
                string first4Digit = "9183";
                if (string.IsNullOrWhiteSpace(first4Digit))
                {
                    return null;
                }

                string lastPart = generateCardLastPartNumber();
                string cardNbr = string.Concat(first4Digit, ctryCD, sevenNineChar, lastPart);
                if (cardNbr.Length != 16)
                {
                    return null;
                }
                return cardNbr;
            }
            catch
            {
                return null;
            }
        }

        //public string generateCardLastPartNumber(string ctryCD)
        //{
        //    var getCardList = db.TCARD.Where(x => x.CARD_CTRY_CD == ctryCD).ToList();
        //    int currentLength = getCardList.Count();
        //    if (currentLength != 0)
        //    {
        //        int lastPart = 153796 + currentLength;
        //        string strlastPart = lastPart.ToString();
        //        if (strlastPart.Length == 6) { return "00" + strlastPart; }
        //        else if (strlastPart.Length == 7) { return "0" + strlastPart; }
        //        else { return strlastPart; }
        //    }
        //    else { return "00153796"; } //00153713
        //}

        public string generateCardLastPartNumber()
        {
            var newCardIdent = new CardIdentity();
            var cardIdent = newCardIdent.generateLastPartCardNumber();
            if (cardIdent != null)
            {
                string lastPartNbr;
                if (cardIdent.CARD_ID <= 999999)
                {
                    lastPartNbr = "00" + Convert.ToString(cardIdent.CARD_ID);
                    return lastPartNbr;
                }
                else if (cardIdent.CARD_ID <= 9999999)
                {
                    lastPartNbr = "0" + Convert.ToString(cardIdent.CARD_ID);
                    return lastPartNbr;
                }
                lastPartNbr = Convert.ToString(cardIdent.CARD_ID);
                return lastPartNbr;
            }
            return null;
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

        public string formatCardNumber(string cardNbr)
        {
            string part1, part2, part3, part4;
            part1 = cardNbr.Substring(0, 4);
            part2 = cardNbr.Substring(4, 4);
            part3 = cardNbr.Substring(8, 4);
            part4 = cardNbr.Substring(12, 4);
            return part1 + " " + part2 + " " + part3 + " " + part4;
        }

        public Card createBusinessCardNumber(string userNBR, string userTCD, string userFulNm,
                                            string ctryCD, string defaultCardPinIND,
                                            bool pkpCardIND, int bnForBusOfferingCard)
        {
            try
            {
                var newCard = new Card();

                string cardNbr = "";
                string cardCvvCD = "";

                cardNbr = generateCardNumber(userTCD, ctryCD, pkpCardIND, bnForBusOfferingCard);
                cardCvvCD = generateCardCvvCD(db.TCARD.ToList().Count());

                if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16 ||
                    string.IsNullOrWhiteSpace(cardCvvCD) || cardCvvCD.Length != 4)
                {
                    return null;
                }
                newCard.CARD_OWNR_FNM = userFulNm;
                newCard.USR_NBR = userNBR;
                newCard.CARD_CTRY_CD = ctryCD;
                newCard.CARD_EDT = DateTime.Now.Date;
                newCard.CARD_XDT = DateTime.Now.AddYears(4).Date;
                newCard.CARD_NBR = cardNbr;
                newCard.CARD_CVV_CD = cardCvvCD;
                newCard.CARD_PIN = "0000";     //default value
                newCard.CARD_CDT = DateTime.Now;
                newCard.CARD_TCD = "2"; //business
                newCard.CARD_SCD = "01";
                newCard.DFLT_PIN_IND = defaultCardPinIND; //1= yes, 0 = no
                return newCard;
            }
            catch
            {
                return null;
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
//    [Table("dbo.TCARD")]
//    public class Card
//    {
//        public Card()
//        {
//            TUSR_PHN_LGN = new HashSet<UserPhoneLogin>();
//            TCLT_IN_BUS = new HashSet<ClientInBusiness>();
//        }

//        [Key]
//        [Display(Name = "Carte ID")]
//        public int CARD_ID { get; set; }

//        [StringLength(255)]
//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [Display(Name = "Propiétaire Carte")]
//        public string CARD_OWNR_FNM { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [Display(Name = "Numéro Carte")]
//        public string CARD_NBR { get; set; }

//        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
//        [StringLength(4, ErrorMessage = "Le code de vérification doit avoir 4 chiffres.", MinimumLength = 4)]
//        [Display(Name = "Code Verification")]
//        public string CARD_CVV_CD { get; set; }

//        [Required(ErrorMessage = "Le code secret ou NIP est obligatoire.")]
//        [StringLength(4, ErrorMessage = "Le code secret ou  NIP doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
//        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le code secret ou NIP doit avoir des chiffres et de longueur 4.")]
//        [DataType(DataType.Password)]
//        [Display(Name = "NIP")]
//        public string CARD_PIN { get; set; }

//        [Required(ErrorMessage = "Confirmer le NIP est obligatoire.")]
//        [DataType(DataType.Password)]
//        [Display(Name = "Confirmer NIP")]
//        [System.ComponentModel.DataAnnotations.Compare("CARD_PIN", ErrorMessage = "Les deux NIP ne correspondent pas.")]
//        [NotMapped]
//        public string CONFIRM_CARD_PIN { get; set; }

//        [Required(ErrorMessage = "Le NIP actuel est obligatoire.")]
//        [StringLength(4, ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
//        //[RegularExpression(@"((?=.*\d).{4})", ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.")]
//        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP actuel doit avoir des chiffres et de longueur 4.")]
//        [DataType(DataType.Password)]
//        [Display(Name = "NIP Actuel")]
//        [NotMapped]
//        public string CURRENT_CARD_PIN { get; set; }

//        [Required(ErrorMessage = "Le nouveau NIP est obligatoire.")]
//        [StringLength(4, ErrorMessage = "Le nouveau NIP doit avoir des chiffres et de longueur 4.", MinimumLength = 4)]
//        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP doit avoir des chiffres et de longueur 4.")]
//        [DataType(DataType.Password)]
//        [Display(Name = "Nouveau NIP")]
//        [NotMapped]
//        public string NEW_CARD_PIN { get; set; }

//        [Required(ErrorMessage = "Confirmer le nouveau NIP est obligatoire.")]
//        [DataType(DataType.Password)]
//        [Display(Name = "Confirmer Nouveau NIP")]
//        [System.ComponentModel.DataAnnotations.Compare("NEW_CARD_PIN", ErrorMessage = "Les deux NIP ne correspondent pas.")]
//        [NotMapped]
//        public string CONFIRM_NEW_CARD_PIN { get; set; }

//        [Required(ErrorMessage = "La {0} est obligatoire.")]
//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
//        [DataType(DataType.Date)]
//        [Display(Name = "Date Effective")]
//        public DateTime CARD_EDT { get; set; }

//        [Required(ErrorMessage = "La {0} est obligatoire.")]
//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
//        [DataType(DataType.Date)]
//        [Display(Name = "Date d'Expiration")]
//        public DateTime CARD_XDT { get; set; }

//        [Required(ErrorMessage = "Le Type de carte est obligatoire.")]
//        [StringLength(1, ErrorMessage = "Le Type de carte  doit avoir 1 caractères.", MinimumLength = 1)]
//        [Display(Name = "Type Carte")]
//        public string CARD_TCD { get; set; }

//        [Required(ErrorMessage = "Le statut de carte est obligatoire.")]
//        [StringLength(2, ErrorMessage = "Le statut de carte  doit avoir au trop 2 caractères.")]
//        [Display(Name = "Statut Carte")]
//        public string CARD_SCD { get; set; }

//        [Required(ErrorMessage = "Le pays de carte est obligatoire.")]
//        [StringLength(3, ErrorMessage = "Le pays de carte  doit avoir 3 caractères.", MinimumLength =3)]
//        [Display(Name = "Pays Carte")]
//        public string CARD_CTRY_CD { get; set; }

//        [Required(ErrorMessage = "La {0} est obligatoire.")]
//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
//        [DataType(DataType.Date)]
//        [Display(Name = "Date de Création")]
//        public DateTime CARD_CDT { get; set; }

//        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [Display(Name = "ID Utilisateur")]
//        public string USR_NBR { get; set; }

//        [StringLength(1, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 1)]
//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [Display(Name = "Code Pin Defaut")]
//        public string DFLT_PIN_IND { get; set; }

//        [Required(ErrorMessage = "Declarer que vous avez noté le numéro de carte PayKap dans un endroit sécuritaire est obligatoire")]
//        [Display(Name = "Déclaration")]
//        [NotMapped]
//        public bool MustNoteCardNumberAcceptance { get; set; }

//        [Display(Name = "Nom Pays Carte")]
//        [NotMapped]
//        public string CARD_CTRY_NM { get; set; }

//        [Display(Name = "Code Devise Carte")]
//        [NotMapped]
//        public string CARD_CRCY_CD { get; set; }

//        [Display(Name = "Texte Date Expiration")]
//        [NotMapped]
//        public string CARD_XDT_TXT { get; set; }

//        public virtual Country TCTRY { get; set; }
//        public virtual User TUSR { get; set; }
//        public virtual ICollection<UserPhoneLogin> TUSR_PHN_LGN { get; set; }
//        public virtual ICollection<ClientInBusiness> TCLT_IN_BUS { get; set; }
//        private DalContext db = new DalContext();

//        private string lang = "FRA";

//        public Card createNewCardNumber(string userID, string userNBR, string userTCD, string userFulNm, 
//                                        string ctryCD, string cardPIN, string CARD_SCD, string defaultCardPinIND)
//        {
//            try
//            {
//                var newCard = new Card();

//                string cardNbr = "";
//                string cardCvvCD = "";

//                cardNbr = generateCardNumber(userTCD, ctryCD);
//                cardCvvCD = generateCardCvvCD(db.TCARD.ToList().Count());

//                if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16 ||
//                    string.IsNullOrWhiteSpace(cardCvvCD) || cardCvvCD.Length != 4)
//                {
//                    return null;
//                }
//                newCard.CARD_OWNR_FNM = userFulNm;
//                newCard.USR_NBR = userNBR;
//                newCard.CARD_CTRY_CD = ctryCD;
//                newCard.CARD_EDT = DateTime.Now.Date;
//                newCard.CARD_XDT = DateTime.Now.AddYears(4).Date;
//                newCard.CARD_NBR = cardNbr;
//                newCard.CARD_CVV_CD = cardCvvCD;
//                newCard.CARD_PIN = cardPIN; 
//                newCard.CARD_CDT = DateTime.Now;
//                newCard.CARD_TCD = "1";
//                newCard.CARD_SCD = CARD_SCD;
//                newCard.DFLT_PIN_IND = defaultCardPinIND; //1= yes, 0 = no
//                return newCard;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool updateDefaultCardPinIndicator(int cardID)
//        {
//            try
//            {
//                var card = db.TCARD.Find(cardID);
//                if (card == null)
//                {
//                    return false;
//                }

//                if (card.DFLT_PIN_IND == "1")
//                {
//                    card.DFLT_PIN_IND = "0";
//                    db.Entry(card).State = EntityState.Modified;
//                    db.SaveChanges();
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public Card getCardNumber(string userID, string cardTCD)
//        {
//            try
//            {
//                var userList = db.TUSR.Where(x => x.Id == userID).ToList();
//                if (userList.Count() == 0) { return null; }

//                var Tuser = userList[0];
//                if (Tuser == null) { return null; }

//                string userNbr = Tuser.USR_NBR;
//                if (string.IsNullOrWhiteSpace(userNbr)) { return null; }

//                var CardList = db.TCARD.Where(x => x.USR_NBR == userNbr && x.CARD_TCD == cardTCD).ToList();
//                if (CardList.Count() == 0) { return null; }

//                var card = CardList[0];
//                if (card == null) { return null; }

//                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
//                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
//                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN); 
//                return card;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public Card getCardByCardID(int cardID)
//        {
//            try
//            {
//                var card = db.TCARD.Find(cardID);
//                if (card == null) { return null; }

//                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
//                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
//                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
//                return card;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public Card getCardByUsrNbr(string usrNbr, string cardTCD)
//        {
//            try
//            {
//                var cardList = db.TCARD.Where(x => x.USR_NBR == usrNbr && x.CARD_TCD == cardTCD).ToList();
//                if(cardList.Count() != 1) { return null; }

//                var card = cardList[0];
//                if (card == null) { return null; }

//                card.CARD_NBR = Encryption.DecryptAes(card.CARD_NBR);
//                card.CARD_CVV_CD = Encryption.DecryptAes(card.CARD_CVV_CD);
//                card.CARD_PIN = Encryption.DecryptAes(card.CARD_PIN);
//                return card;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public string generateCardNumber(string usrTCD, string ctryCD)
//        {
//            try
//            {
//                string sevenNineChar;
//                if (usrTCD == "2") { sevenNineChar = "1"; }  //PKP employee
//                else if (usrTCD == "3" || usrTCD == "4" || usrTCD == "5") { sevenNineChar = "9"; }  //3 transfer business, 4 bill creditor business
//                else if (usrTCD == "1") { sevenNineChar = "7"; }  //client
//                else { sevenNineChar = "0"; }  //admin
//                return "9183" + ctryCD + sevenNineChar + generateCardLastPartNumber(db.TCARD.ToList().Count());
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public string generateCardLastPartNumber(int currentLength)
//        {
//            if (currentLength != 0)
//            {
//                int lastPart = 153713 + currentLength;
//                string strlastPart = lastPart.ToString();
//                if (strlastPart.Length == 6) { return "00" + strlastPart; }
//                else if (strlastPart.Length == 7) { return "0" + strlastPart; }
//                else { return strlastPart; }
//            }
//            else { return "00153713"; }
//        }

//        public string generateCardCvvCD(int currentLength)
//        {
//            if (currentLength != 0)
//            {
//                currentLength += 1;
//                int intModulo = (currentLength % 8999) + 1;
//                string strLength = intModulo.ToString();
//                if (strLength.Length == 1) { return "100" + strLength; }
//                else if (strLength.Length == 2) { return "10" + strLength; }
//                else if (strLength.Length == 3) { return "1" + strLength; }
//                else
//                {
//                    int fourDigitLength = intModulo + 1000;
//                    return Convert.ToString(fourDigitLength);
//                }
//            }
//            else { return "1001"; }
//        }

//        public string formatCardNumber(string cardNbr)
//        {
//            string part1, part2, part3, part4;
//            part1 = cardNbr.Substring(0, 4);
//            part2 = cardNbr.Substring(4, 4);
//            part3 = cardNbr.Substring(8, 4);
//            part4 = cardNbr.Substring(12, 4);
//            return part1 + " " + part2 + " " + part3 + " " + part4;
//        }

//        public Card createBusinessCardNumber(string userNBR, string userTCD, string userFulNm, 
//                                            string ctryCD, string defaultCardPinIND)
//        {
//            try
//            {
//                var newCard = new Card();

//                string cardNbr = "";
//                string cardCvvCD = "";

//                cardNbr = generateCardNumber(userTCD, ctryCD);
//                cardCvvCD = generateCardCvvCD(db.TCARD.ToList().Count());

//                if (string.IsNullOrWhiteSpace(cardNbr) || cardNbr.Length != 16 ||
//                    string.IsNullOrWhiteSpace(cardCvvCD) || cardCvvCD.Length != 4)
//                {
//                    return null;
//                }
//                newCard.CARD_OWNR_FNM = userFulNm;
//                newCard.USR_NBR = userNBR;
//                newCard.CARD_CTRY_CD = ctryCD;
//                newCard.CARD_EDT = DateTime.Now.Date;
//                newCard.CARD_XDT = DateTime.Now.AddYears(4).Date;
//                newCard.CARD_NBR = cardNbr;
//                newCard.CARD_CVV_CD = cardCvvCD;
//                newCard.CARD_PIN = "0000";     //default value
//                newCard.CARD_CDT = DateTime.Now;
//                newCard.CARD_TCD = "2"; //business
//                newCard.CARD_SCD = "01";
//                newCard.DFLT_PIN_IND = defaultCardPinIND; //1= yes, 0 = no
//                return newCard;
//            }
//            catch
//            {
//                return null;
//            }
//        }
//    }
//}