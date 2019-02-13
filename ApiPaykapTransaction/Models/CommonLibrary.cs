using Microsoft.AspNet.Identity;
using pkpApp.Helpers;
using ApiPaykapTransaction.Models.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace ApiPaykapTransaction.Models
{
    public class CommonLibrary
    {
        public static string getDefaultUsrNbr()
        {
            return "0000000001";
        }

        public static decimal roundAmountToCeiling(decimal amt)
        {
            decimal rndAmt = Math.Floor(amt);
            return rndAmt + 0.99999999m;
        }

        public static bool duplicatedTransactionClientOnlineIndicator(DataModel db, string FROM_USR_NBR, 
                                        int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID, int RCPT_USR_BUS_ID,
                                        string TRANS_SCD)
        {
            var lastTransList = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == FROM_USR_NBR &&
                                                                   x.FROM_TRSF_SERV_ID == FROM_TRSF_SERV_ID &&
                                                                   x.TO_TRSF_SERV_ID == TO_TRSF_SERV_ID &&
                                                                   x.RCPT_USR_BUS_ID == RCPT_USR_BUS_ID &&
                                                                   x.TRANS_SCD == TRANS_SCD)
                                                                   .OrderByDescending(y => y.TRANS_CDT).ToList();
            if (lastTransList.Count() != 0)
            {
                var lastTrans = lastTransList[0];
                DateTime cdt = lastTrans.TRANS_CDT;
                DateTime xdt = cdt.AddMinutes(2);
                if (DateTime.Compare(xdt, DateTime.Now) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool duplicatedTransactionAgencyOnlineIndicator(DalContext db, string FROM_USR_NBR,
                                        int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID, int RCPT_USR_BUS_ID,
                                        string TRANS_SCD, int BUS_USR_NBR)
        {
            var query = from trans in db.TTRANS_TRSF_CRDT_DBT
                        join busTrans in db.TBUS_CMSN_TRANS on trans.TRANS_ID equals busTrans.TRANS_ID
                        where (trans.FROM_USR_NBR == FROM_USR_NBR &&
                               trans.FROM_TRSF_SERV_ID == FROM_TRSF_SERV_ID &&
                               trans.TO_TRSF_SERV_ID == TO_TRSF_SERV_ID && 
                               trans.RCPT_USR_BUS_ID == RCPT_USR_BUS_ID &&
                               trans.TRANS_SCD == TRANS_SCD && 
                               busTrans.BUS_USR_NBR == BUS_USR_NBR)
                        orderby trans.TRANS_ID descending
                        select trans;

            if (query.Count() != 0)
            {
                foreach (var trans in query)
                {
                    var lastTrans = trans;
                    DateTime cdt = lastTrans.TRANS_CDT;
                    DateTime xdt = cdt.AddMinutes(2);
                    if (DateTime.Compare(xdt, DateTime.Now) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static List<SelectListItem> getBusinessServiceType(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1", Selected = true });    //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });         //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });       //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });     //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });       //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });       //"PayKap d'un pays"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2", Selected = true });     //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3", Selected = true });     //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "4")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4", Selected = true });     //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "5")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5", Selected = true });     //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "6")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6", Selected = true });     //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "7")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7", Selected = true });     //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            else if (selectedValue == "8")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8", Selected = true });     //"PayKap d'un pays"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType1_, Value = "1" });      //"Transfert Mobile Money (Institution Financière)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType2_, Value = "2" });      //"Transfert Mobile Money (Agent Independant)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType3_, Value = "3" });      //"Gestion Autonome Carte Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType4_, Value = "4" });      //"Paiement de facture en ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType5_, Value = "5" });      //"Paiement de facture en magasin"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType6_, Value = "6" });      //"Paiement de salaires"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType7_, Value = "7" });      //"Paiement en ligne (shopping)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3CommonLibrarygetBusinessServiceType8_, Value = "8" });      //"PayKap d'un pays"
            }
            return items;
        }


        public static decimal getPromoCodeDiscountAmount(string ctryCD, string crcyCD)
        {
            if(ctryCD == "120" && crcyCD == "XAF")
            {
                return 1000.0m;
            }
            return 0.0m;
        }

        public static string adminPhoneNumber()
        {
            return "+16134043467";
        }

        public static string getAdminEmail()
        {
            return "admin@paykap.com";
        }

        public static string getGenericPassword()
        {
            return "Pkp00$@@";
        }

        public static string getDefaultCardPin()
        {
            return "0000";
        }

        public static bool validatedUserCardPin(string cardPIN)
        {
            if(cardPIN == "0000" || cardPIN == "1111" || cardPIN == "2222" || cardPIN == "3333" ||
               cardPIN == "4444" || cardPIN == "5555" || cardPIN == "6666" || cardPIN == "7777" ||
               cardPIN == "8888" || cardPIN == "9999" || cardPIN == "1234")
            {
                return false;
            }
            return true;
        }

        public static bool validatedUserCardPinLength(string cardPIN)
        {
            if (cardPIN.Length != 4)
            {
                return false;
            }
            return true;
        }

        public static string validatedUserCardPinErrorMessage(string CARD_PIN)
        {
            bool validatedCardPIN = validatedUserCardPin(CARD_PIN);
            if (!validatedCardPIN)
            {
                return Resources.Resources.z3validatedUserCardPinErrorMessage1_;        //"Le code ou NIP ne peut pas avoir 4 chiffres identiques (Ex. 0000) ou être 1234."
            }

            bool validatedCardPINLength = validatedUserCardPinLength(CARD_PIN);
            if (!validatedCardPINLength)
            {
                return Resources.Resources.z3validatedUserCardPinErrorMessage2_;        //"Le code secret doit avoir exactement 4 chiffres."
            }
            return "ok";
        }

        public static string checkValidCountryPhoneLength(DataModel db, string ctryCD, string phn)
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

        public static bool checkValidity(DateTime xdt)
        {
            if (DateTime.Compare(xdt, DateTime.Now.Date) > 0)
            {
                return true;
            }
            return false;
        }

        public static bool checkUserAuthorization(DataModel db, string currentIpAddress)
        {
            if (string.IsNullOrWhiteSpace(currentIpAddress))
            {
                return false;
            }
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if(url.Contains("localhost"))
            {
                return true;
            }
            var ipAddr = db.TIP_ADDR.Find(currentIpAddress);
            if(ipAddr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DateTime Last24Hours(DateTime date)
        {
            date = date.AddDays(-1);
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public static DateTime StartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }

        public static DateTime StartOfMonth(int year, int month)
        {
            return new DateTime(year, month, 1, 0, 0, 0);
        }
        
        public static DateTime EndOfMonth(DateTime date)
        {
            DateTime firstDate = StartOfMonth(date);
            return firstDate.AddMonths(1).AddSeconds(-1);
        }

        public static DateTime EndOfMonth(int year, int month)
        {
            DateTime firstDate = StartOfMonth(year, month);
            return firstDate.AddMonths(1).AddSeconds(-1);
        }

        public static string displayFormattedCurrency(decimal amt, string cultureInfo)
        {
            string formatString = "C2";
            string strAmt;
            if(amt < 0.0m)
            {
                decimal positiveAmt = Math.Abs(amt);
                if (cultureInfo == "INVAR")
                {
                    strAmt = positiveAmt.ToString("N2");
                }
                else
                {
                    // Creates a CultureInfo
                    CultureInfo culInfo = new CultureInfo(cultureInfo);
                    strAmt = positiveAmt.ToString(formatString, culInfo);
                }
                //reconvert to negative amount
                strAmt = "-" + strAmt;
            }
            else
            {
                if (cultureInfo == "INVAR")
                {
                    strAmt = amt.ToString("N2");
                }
                else
                {
                    // Creates a CultureInfo
                    CultureInfo culInfo = new CultureInfo(cultureInfo);
                    strAmt = amt.ToString(formatString, culInfo);
                }
            }
            // Display amt formatted as currency
            return strAmt;
        }

        public static string displayFormattedCurrency(decimal amt, string crcyCD, string cultureInfo)
        {
            string formatString = "C2";
            string strAmt;
            if (amt < 0.0m)
            {
                decimal positiveAmt = Math.Abs(amt);
                if (cultureInfo == "INVAR")
                {
                    strAmt = crcyCD.ToUpper() + " " + positiveAmt.ToString("N2");
                }
                else
                {
                    // Creates a CultureInfo
                    CultureInfo culInfo = new CultureInfo(cultureInfo);
                    strAmt = crcyCD.ToUpper() + " " + positiveAmt.ToString(formatString, culInfo);
                }
                //reconvert to negative amount
                strAmt = "-" + strAmt;
            }
            else
            {
                if (cultureInfo == "INVAR")
                {
                    strAmt = crcyCD.ToUpper() + " " + amt.ToString("N2");
                }
                else
                {
                    // Creates a CultureInfo
                    CultureInfo culInfo = new CultureInfo(cultureInfo);
                    strAmt = crcyCD.ToUpper() + " " + amt.ToString(formatString, culInfo);
                }
            }
            // Display amt formatted as currency
            return strAmt;
        }

        public static string displayGenericErrorMessage()
        {
            return Resources.Resources.z3displayGenericErrorMessage_;      //"Une erreur inattendue a eu lieu. Contactez nous si l'erreur persiste."
        }

        public static string displayNotAgentErrorMessage()
        {
            return Resources.Resources.z3displayNotAgentErrorMessage_; ;       //"Vous n'êtes pas encore un agent PayKap. Cliquez 'Devenir Agent PayKap' sur le menu à droite de votre écran pour devenir un agent et commencez à faire de l'argent pour chaque transaction effectuée par vos filleuls et filleules."
        }

        public static string displayNotSponsorAgentErrorMessage()
        {
            return Resources.Resources.z3displayNotSponsorAgentErrorMessage_; ;        //"Votre parrain n'est pas un agent PayKap. Qu'il se connecte à son compte PayKap, cliquez d'abord sur 'Agent' sur le menu de haut, puis sur 'Devenir Agent PayKap' pour devenir un agent avant de vous recommander."
        }

        public static string displayExpiryAgentErrorMessage()
        {
            return Resources.Resources.z3displayExpiryAgentErrorMessage_; ;        //"Votre compte Agent a expiré. Cliquez 'Devenir Agent PayKap' sur le menu à droite de votre écran pour devenir à nouveau un agent et commencez à faire de l'argent pour chaque transaction effectuée par vos filleuls et filleules."
        }

        public static string displayAlreadyHasAnAccountErrorMessage(string txt)
        {
            return txt + Resources.Resources.z3displayAlreadyHasAnAccountErrorMessage1_;        //" Il se peut que son propriétaire ait déjà un compte PayKap. Vérifiez avec lui ou l'ajoutez comme bénéficaire en le cherchant par son numéro de téléphone PayKap. Si vous rencontrez les difficultés, contactez-nous."
        }

        public static string displayAlreadyHasAnAccountErrorMessage()
        {
            return Resources.Resources.z3displayAlreadyHasAnAccountErrorMessage2_;      //"Ce numéro existe déjà. Il se peut que vous ayez déjà un compte PayKap. Connectez-vous ou si vous croyez être une erreur, contactez-nous."
        }

        public static string displayAlreadyRecipientAccountErrorMessage(string txt)
        {
            return Resources.Resources.z3displayAlreadyRecipientAccountErrorMessageOp11_ + txt + Resources.Resources.z3displayAlreadyRecipientAccountErrorMessageOp12_;       //Ce compte      //" fait déjà partie de vos bénéficiaires."
        }

        public static string displayPhoneNumberLengthErrorMessage()
        {
            return Resources.Resources.z3displayAlreadyRecipientAccountErrorMessageOp2_;        //"La longueur du numéro de téléphone n'est pas valide pour le pays sélectionné. Ne pas inclure l'indicatif téléphonique international (exemple +1) sur le numéro." 
        }

        public static string displayPhoneNumberLengthErrorMessage2()
        {
            return Resources.Resources.z3displayPhoneNumberLengthErrorMessage2_;        //"La longueur du numéro de téléphone n'est pas valide dans le pays de votre compte. Ne pas inclure l'indicatif téléphonique international (exemple +1) sur le numéro."
        }

        public static string displayAlreadyMakeTransactionErrorMessage()
        {
            return Resources.Resources.z3displayAlreadyMakeTransactionErrorMessage_;        //"PayKap a détecté que vous venez tout juste de transférer de l'argent à ce bénéficiaire. Vous devez attendre au moins 2 minutes pour faire une autre transaction à ce bénéficiaire. Cliquez sur <<Consulter mes transactions>> sur le menu de droite pour vérifier si votre transaction n'a été enregistrée avec succès avant d'initier une nouvelle transaction."
        }

        public static string displayAlreadyMakeTransactionAgencyErrorMessage()
        {
            return Resources.Resources.z3displayAlreadyMakeTransactionAgencyErrorMessage_;      //"PayKap a détecté que vous venez tout juste d'effectuer une transaction au nom ce client. Vous devez attendre au moins 2 minutes pour faire une autre transaction à ce même client. Cliquez sur <<Consulter mes transactions>> pour vérifier si votre transaction n'a été enregistrée avec succès avant d'initier une nouvelle transaction."
        }

        public static string getLanguage()
        {
            string lang1 = "FRA";
            return lang1;
        }

        public static int setPageListNumber()
        {
            return 10;
        }

        public static int setPageListNumberMedium()
        {
            return 20;
        }

        public static int setPageListNumberBig()
        {
            return 30;
        }

        public static int setPageListNumberVeryBig()
        {
            return 100;
        }

        public static bool checkApplyingTax()
        {
            return true;
        }

        public static DateTime returnDateByCountryCD(string ctryCD)
        {
            if (ctryCD == "120")
            {
                return DateTime.UtcNow.AddMinutes(60);
            } 
            else if (ctryCD == "124")
            {
                return DateTime.UtcNow;
            }
            else
            {
                return DateTime.UtcNow;
            }
        }

        public static string generateStringCode(int codeLength, int currentLength)
        {
            if (codeLength == 3)        //if the length is 3
            {
                if (currentLength != 0)
                {
                    currentLength += 1;
                    string strLength = currentLength.ToString();
                    if (strLength.Length == 1) { return "00" + strLength; }
                    else if (strLength.Length == 2) { return "0" + strLength; }
                    else { return strLength; }
                }
                else { return "001"; }
            }
            else if (codeLength == 4)        //if the length is 4
            {
                if (currentLength != 0)
                {
                    currentLength += 1;
                    string strLength = currentLength.ToString();
                    if (strLength.Length == 1) { return "000" + strLength; }
                    else if (strLength.Length == 2) { return "00" + strLength; }
                    else if (strLength.Length == 3) { return "0" + strLength; }
                    else { return strLength; }
                }
                else { return "0001"; }
            }
            else if (codeLength == 5)        //if the length is 5
            {
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
            else if (codeLength == 8)        //if the length is 8
            {
                if (currentLength != 0)
                {
                    currentLength += 1;
                    return Convert.ToString(10011080 + currentLength);
                }
                else { return "10011080"; } //10011001
            }
            else { return ""; }         //if the length is 4
        }

        //public static string generateStringCode(int codeLength, int currentLength)
        //{
        //    if (codeLength == 4)        //if the length is 4
        //    {
        //        if (currentLength != 0)
        //        {
        //            currentLength += 1;
        //            string strLength = currentLength.ToString();
        //            if (strLength.Length == 1) { return "000" + strLength; }
        //            else if (strLength.Length == 2) { return "00" + strLength; }
        //            else if (strLength.Length == 3) { return "0" + strLength; }
        //            else { return strLength; }
        //        }
        //        else { return "0001"; }
        //    }
        //    else if (codeLength == 8)        //if the length is 8
        //    {
        //        if (currentLength != 0)
        //        {
        //            currentLength += 1;
        //            string strLength = currentLength.ToString();
        //            if (strLength.Length == 1) { return "1001000" + strLength; }
        //            else if (strLength.Length == 2) { return "100100" + strLength; }
        //            else if (strLength.Length == 3) { return "10010" + strLength; }
        //            else if (strLength.Length == 4) { return "1001" + strLength; }
        //            else
        //            {
        //                currentLength = currentLength + 10000;
        //                strLength = currentLength.ToString();
        //                if (strLength.Length == 5) { return "100" + strLength; }
        //                else if (strLength.Length == 6) { return "10" + strLength; }
        //                else if (strLength.Length == 7) { return "1" + strLength; }
        //                else
        //                {
        //                    currentLength = currentLength + 10000000;
        //                    strLength = currentLength.ToString();
        //                    return strLength;
        //                }
        //            }
        //        }
        //        else { return "10010001"; }
        //    }
        //    else if (codeLength == 10) // user number
        //    {
        //        if (currentLength != 0)
        //        {
        //            currentLength = currentLength + 1;
        //            return Convert.ToString(516700753 + currentLength);
        //        }
        //        else { return ""; }
        //    }
        //    else { return ""; }         //if the length is 4
        //}

        public static string formatCTPaiementAmount(decimal amt)
        {
            amt = amt * 100;
            amt = decimal.Ceiling(amt);
            amt = amt * 0.01m;
            string formatAmt;
            string strAmt = Convert.ToString(amt);
            if(strAmt.Contains("."))
            {
                decimal integral = Math.Truncate(amt);
                string strIntegral = Convert.ToString(integral);
                decimal fractional = amt - integral;
                string strfractional = Convert.ToString(fractional);
                string[] parts = strfractional.Split('.');
                string part2 = parts[1];
                int lengthPart2 = part2.Length;
                if(lengthPart2 == 1)
                {
                    formatAmt = strIntegral + "" + part2 + "0";
                }
                else
                {
                    formatAmt = strIntegral + "" + part2;
                }
            }
            else if (strAmt.Contains(","))
            {
                decimal integral = Math.Truncate(amt);
                string strIntegral = Convert.ToString(integral);
                decimal fractional = amt - integral;
                string strfractional = Convert.ToString(fractional);
                string[] parts = strfractional.Split(',');
                string part2 = parts[1];
                int lengthPart2 = part2.Length;
                if (lengthPart2 == 1)
                {
                    formatAmt = strIntegral + "" + part2 + "0";
                }
                else
                {
                    formatAmt = strIntegral + "" + part2;
                }
            }
            else
            {
                formatAmt = strAmt + "00";
            }

            int intFormatAmt = formatAmt.Length;
            string formatAmt2;
            if(intFormatAmt == 3)
            {
                formatAmt2 = "00000000" + formatAmt;
            }
            else if (intFormatAmt == 4)
            {
                formatAmt2 = "0000000" + formatAmt;
            }
            else if (intFormatAmt == 5)
            {
                formatAmt2 = "000000" + formatAmt;
            }
            else if (intFormatAmt == 6)
            {
                formatAmt2 = "00000" + formatAmt;
            }
            else if (intFormatAmt == 7)
            {
                formatAmt2 = "0000" + formatAmt;
            }
            else if (intFormatAmt == 8)
            {
                formatAmt2 = "000" + formatAmt;
            }
            else if (intFormatAmt == 9)
            {
                formatAmt2 = "00" + formatAmt;
            }
            else if (intFormatAmt == 10)
            {
                formatAmt2 = "0" + formatAmt;
            }
            else
            {
                formatAmt2 = formatAmt;
            }

            if(formatAmt2.Length != 11)
            {
                return null;
            }
            return formatAmt2;
        }

        public static string generateCTPaiementBillNumber(string transID)
        {
            int intFormatAmt = transID.Length;
            string formatAmt2;
            if (intFormatAmt == 3)
            {
                formatAmt2 = "000000000" + transID;
            }
            else if (intFormatAmt == 4)
            {
                formatAmt2 = "00000000" + transID;
            }
            else if (intFormatAmt == 5)
            {
                formatAmt2 = "0000000" + transID;
            }
            else if (intFormatAmt == 6)
            {
                formatAmt2 = "000000" + transID;
            }
            else if (intFormatAmt == 7)
            {
                formatAmt2 = "00000" + transID;
            }
            else if (intFormatAmt == 8)
            {
                formatAmt2 = "0000" + transID;
            }
            else if (intFormatAmt == 9)
            {
                formatAmt2 = "000" + transID;
            }
            else if (intFormatAmt == 10)
            {
                formatAmt2 = "00" + transID;
            }
            else if (intFormatAmt == 11)
            {
                formatAmt2 = "0" + transID;
            }
            else
            {
                formatAmt2 = transID;
            }

            if (formatAmt2.Length != 12)
            {
                return null;
            }
            return formatAmt2;
        }


        public static decimal convertExternalStringToDecimalAmount(string strAmt)
        {
            string integral, fractional;
            int strAmtLength = strAmt.Length;
            decimal amt;
            if (strAmtLength == 3)
            {
                integral = strAmt.Substring(0, 1);
                fractional = strAmt.Substring(1);
            }
            else if (strAmtLength == 4)
            {
                integral = strAmt.Substring(0, 2);
                fractional = strAmt.Substring(2);
            }
            else if (strAmtLength == 5)
            {
                integral = strAmt.Substring(0, 3);
                fractional = strAmt.Substring(3);
            }
            else if (strAmtLength == 6)
            {
                integral = strAmt.Substring(0, 4);
                fractional = strAmt.Substring(4);
            }
            else if (strAmtLength == 7)
            {
                integral = strAmt.Substring(0, 5);
                fractional = strAmt.Substring(5);
            }
            else if (strAmtLength == 8)
            {
                integral = strAmt.Substring(0, 6);
                fractional = strAmt.Substring(6);
            }
            else if (strAmtLength == 9)
            {
                integral = strAmt.Substring(0, 7);
                fractional = strAmt.Substring(7);
            }
            else if (strAmtLength == 10)
            {
                integral = strAmt.Substring(0, 8);
                fractional = strAmt.Substring(8);
            }
            else
            {
                integral = strAmt.Substring(0, 9);
                fractional = strAmt.Substring(9);
            }
            string concatAmt = integral + "." + fractional;
            amt = Convert.ToDecimal(concatAmt);
            return amt;
        }


        public static string generateAccountPIN()
        {
            Random rd = new Random();
            int len = rd.Next(0, 9999);
            string textToEncrypt;
            if (len != 0)
            {
                string strLength = len.ToString();
                if (strLength.Length == 1) { textToEncrypt = strLength + "009"; }
                else if (strLength.Length == 2) { textToEncrypt = strLength + "09"; }
                else if (strLength.Length == 3) { textToEncrypt = strLength + "9"; }
                else { textToEncrypt = strLength; }
            }
            else { textToEncrypt = "5079"; }
            return textToEncrypt;
        }

        public static string getRegionalCodeByCountry(string ctryCD)
        {
            if (!string.IsNullOrEmpty(ctryCD))
            {
                if (ctryCD == "120") { return "+237"; }
                else if (ctryCD == "124") { return "+1"; }
                else { return "+"; }
            }
            else { return "+"; }
        }

        public static string replaceWhiteSpace(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return item;
            }
            return item.Replace(" ", "");
        }

        //public static string getCurrencyByCountry(string ctryCD)
        //{
        //    if (!string.IsNullOrEmpty(ctryCD))        
        //    {
        //        if (ctryCD == "120") { return "XAF"; }
        //        else if (ctryCD == "124") { return "CAD"; }
        //        else { return ""; }
        //    }
        //    else { return ""; }
        //}
        
        //public static string getCultureInfoByCountryAndLanguage(string ctryCD, string langCD)
        //{
        //    if (!string.IsNullOrEmpty(ctryCD) && !string.IsNullOrEmpty(langCD))        
        //    {
        //        if (ctryCD == "120") { return "INVAR"; }
        //        else if (ctryCD == "124" && langCD == "FRA") { return "fr-CA"; }
        //        else if (ctryCD == "124" && langCD == "ENG") { return "en-CA"; }
        //        else { return "INVAR"; }
        //    }
        //    else { return ""; }
        //}

        //public static string getCultureInfoByCurrencyCD(string crcyCD)
        //{
        //    if (!string.IsNullOrEmpty(crcyCD))
        //    {
        //        if (crcyCD == "XAF") { return "INVAR"; }
        //        else if (crcyCD == "CAD") { return "en-CA"; }
        //        else { return "INVAR"; }
        //    }
        //    else { return ""; }
        //}

        public static string getExchangeRateDecimalPartByCurrencyCD(string crcyCD)
        {
            if (!string.IsNullOrEmpty(crcyCD))
            {
                if (!string.IsNullOrEmpty(crcyCD))
                {
                    if (crcyCD == "XAF") { return "N6"; }
                    else if (crcyCD == "CAD") { return "N2"; }
                    else { return "N2"; }
                }
                else { return ""; }
            }
            else { return ""; }
        }

        //Get FromCountry by Cookie or Session or Culture info
        public static string getFromCountryByCookieSessionOrCulture(string sessionCtryCD, string cookie)
        {
            var cultureCtryCD = CultureHelper.GetDefaultFromCountry();

            if (!string.IsNullOrEmpty(cookie))
            {
                return cookie;
            }
            else if(!string.IsNullOrEmpty(sessionCtryCD))
            {
                return sessionCtryCD;
            }
            else
            {
                return cultureCtryCD;
            }
        }

        //Get ToCountry by Cookie or Session or Culture info
        public static string getToCountryByCookieSessionOrCulture(string sessionCtryCD, string cookie)
        {
            var cultureCtryCD = CultureHelper.GetDefaultToCountry();

            if (!string.IsNullOrEmpty(cookie))
            {
                return cookie;
            }
            else if(!string.IsNullOrEmpty(sessionCtryCD))
            {
                return sessionCtryCD;
            }
            else
            {
                return cultureCtryCD;
            }
        }

        //Get Language by Cookie or Session or Culture info
        public static string getLanguageFromCookieSessionOrCulture(string sessionLangCD, string cookie)
        {
            var cultureLangCD = CultureHelper.GetDefaultLanguage();

            if (!string.IsNullOrEmpty(cookie))
            {
                return cookie;
            }
            else if (!string.IsNullOrEmpty(sessionLangCD))
            {
                return sessionLangCD;
            }
            else
            {
                return cultureLangCD;
            }
        }
        
        public static List<SelectListItem> getMoneyTransferFeeTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode1_, Value = "1", Selected = true });     //"Les montants fixes"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode2_, Value = "2" });      //"Les montants en %"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode1_, Value = "1" });      //"Les montants fixes"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode2_, Value = "2", Selected = true });     //"Les montants en %"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode1_, Value = "1" });      //"Les montants fixes"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeTypeCode2_, Value = "2" });      //"Les montants en %"
            }
            return items;
        }

        public static List<SelectListItem> getServiceTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.PKPCBillPaymentTitle_, Value = "1", Selected = true });       //"Payer une facture"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceTypeCode_, Value = "2" });        //"Virer ou transférer l'argent"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.PKPCBillPaymentTitle_, Value = "1" });        //"Payer une facture"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceTypeCode_, Value = "2", Selected = true });       //"Virer ou transférer l'argent"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.PKPCBillPaymentTitle_, Value = "1" });        //"Payer une facture"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceTypeCode_, Value = "2" });        //"Virer ou transférer l'argent"
            }
            return items;
        }
        
        public static List<SelectListItem> getServiceCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "01")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01", Selected = true });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //Paiement de factures (Entreprise Enregistrées)
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "02")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02", Selected = true });     //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "03")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03", Selected = true });     //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "04")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04", Selected = true });     //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "05")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05", Selected = true });     //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "06")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06", Selected = true });     //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            else if (selectedValue == "99")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99", Selected = true });     //"Tous les services"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode1_, Value = "01" });      //"Transfert - Virement - Dépôt Compte Tiers"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode2_, Value = "02" });      //"Paiement de factures (Entreprise Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode3_, Value = "03" });      //"Paiement de factures (Entreprise Non Enregistrées)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode4_, Value = "04" });      //"Paiement En Ligne (API)"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode5_, Value = "05" });      //"Dépôt au compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode6_, Value = "06" });      //"Retrait du compte propriétaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getServiceCode7_, Value = "99" });      //"Tous les services"
            }
            return items;
        }

        public static List<SelectListItem> getAccountTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "01")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01", Selected = true });     //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //Compte Courant Affaire
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autre compte"
            }
            else if (selectedValue == "02")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02", Selected = true });     //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autre compte"
            }
            else if (selectedValue == "03")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03", Selected = true });     //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autre compte"
            }
            else if (selectedValue == "04")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04", Selected = true });     //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autre compte"
            }
            else if (selectedValue == "05")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05", Selected = true });     //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autre compte"
            }
            else if (selectedValue == "06")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04"});       //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06", Selected = true });     //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autres comptes"
            }
            else if (selectedValue == "99")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99", Selected = true });     //"Autres comptes"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode1_, Value = "01" });      //"Compte Courant Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode2_, Value = "02" });      //"Compte Chèque Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode3_, Value = "03" });      //"Compte Épargne Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode4_, Value = "04" });      //"Compte Courant Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode5_, Value = "05" });      //"Compte Chèque Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode6_, Value = "06" });      //"Compte Épargne Affaire"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAccountTypeCode7_, Value = "99" });      //"Autres comptes"
            }
            return items;
        }


        public static List<SelectListItem> getMoneyTransferFeeGroupCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeGroupCode1_, Value = "001" });       //"Canada (CAD), En Ligne - Cash, 001"
            items.Add(new SelectListItem { Text = Resources.Resources.z3getMoneyTransferFeeGroupCode2_, Value = "002" });       //"Canada (CAD), En Ligne - Dépôt Bancaire, 002"
            return items;
        }

        public static List<SelectListItem> getMoneyTransferTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.SendTxt_, Value = "1", Selected = true });        //"Envoi"
                items.Add(new SelectListItem { Text = Resources.Resources.ReceptionTxt_, Value = "2" });        //"Reception"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.SendTxt_, Value = "1" });     //"Envoi"
                items.Add(new SelectListItem { Text = Resources.Resources.ReceptionTxt_, Value = "2", Selected = true });       //"Reception"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.SendTxt_, Value = "1" });     //"Envoi"
                items.Add(new SelectListItem { Text = Resources.Resources.ReceptionTxt_, Value = "2" });        //"Reception"
            }
            return items;
        }

        public static List<SelectListItem> getUserBusinessTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1", Selected = true });     //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2" });      //"Entreprise"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1" });      //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2", Selected = true });     //"Entreprise"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1" });      //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2" });      //"Entreprise"
            }
            
            return items;
        }

        public static List<SelectListItem> getUserBusinessTypeCode1(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1", Selected = true });     //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2" });      //"Entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBusinessTypeCode1_, Value = "3" });      //"Pas de parrain"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1" });      //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2", Selected = true });     //"Entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBusinessTypeCode1_, Value = "3" });      //"Pas de parrain"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1" });      //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2" });      //"Entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBusinessTypeCode1_, Value = "3", Selected = true });     //"Pas de parrain"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.ContactDeleteIndividualTxt_, Value = "1" });      //"Individu"
                items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "2" });      //"Entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBusinessTypeCode1_, Value = "3" });      //"Pas de parrain"
            }

            return items;
        }

        public static List<SelectListItem> getOnlineAgencyTypeCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode1_, Value = "1", Selected = true });     //"En Ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode2_, Value = "2" });      //"En Agence"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode3_, Value = "3" });      //"Les deux"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode1_, Value = "1" });      //"En Ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode2_, Value = "2", Selected = true });     //"En Agence"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode3_, Value = "3" });      //"Les deux"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode1_, Value = "1" });      //"En Ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode2_, Value = "2" });      //"En Agence"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode3_, Value = "3", Selected = true });     //"Les deux"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode1_, Value = "1" });      //"En Ligne"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode2_, Value = "2" });      //"En Agence"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getOnlineAgencyTypeCode3_, Value = "3" });      //"Les deux"
            }

            return items;
        }

        public static List<SelectListItem> getUser99PercentForceStatus(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = "Oui", Value = "1", Selected = true });
                items.Add(new SelectListItem { Text = "Non", Value = "2" });
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = "Oui", Value = "1" });
                items.Add(new SelectListItem { Text = "Non", Value = "2", Selected = true });
            }
            else
            {
                items.Add(new SelectListItem { Text = "Oui", Value = "1" });
                items.Add(new SelectListItem { Text = "Non", Value = "2" });
            }
            
            return items;
        }

        public static List<SelectListItem> getYearList(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "2018")
            {
                items.Add(new SelectListItem { Text = "2018", Value = "2018", Selected = true });
                items.Add(new SelectListItem { Text = "2019", Value = "2019" });
                items.Add(new SelectListItem { Text = "2020", Value = "2020" });
            }
            else if (selectedValue == "2019")
            {
                items.Add(new SelectListItem { Text = "2018", Value = "2018" });
                items.Add(new SelectListItem { Text = "2019", Value = "2019", Selected = true });
                items.Add(new SelectListItem { Text = "2020", Value = "2020" });
            }
            else if (selectedValue == "2020")
            {
                items.Add(new SelectListItem { Text = "2018", Value = "2018" });
                items.Add(new SelectListItem { Text = "2019", Value = "2019" });
                items.Add(new SelectListItem { Text = "2020", Value = "2020", Selected = true });
            }
            else
            {
                items.Add(new SelectListItem { Text = "2018", Value = "2018" });
                items.Add(new SelectListItem { Text = "2019", Value = "2019" });
                items.Add(new SelectListItem { Text = "2020", Value = "2020" });
            }

            return items;
        }

        public static List<SelectListItem> getMonthList(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "01")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01", Selected = true });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });

            }
            else if (selectedValue == "02")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02", Selected = true });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "03")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03", Selected = true });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "04")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04", Selected = true });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "05")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05", Selected = true });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "06")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06", Selected = true });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "07")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06"});
                items.Add(new SelectListItem { Text = "07", Value = "07", Selected = true });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "08")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08", Selected = true });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "09")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09", Selected = true });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "10")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10", Selected = true });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "11")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11", Selected = true });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            else if (selectedValue == "12")
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12", Selected = true });
            }
            else
            {
                items.Add(new SelectListItem { Text = "01", Value = "01" });
                items.Add(new SelectListItem { Text = "02", Value = "02" });
                items.Add(new SelectListItem { Text = "03", Value = "03" });
                items.Add(new SelectListItem { Text = "04", Value = "04" });
                items.Add(new SelectListItem { Text = "05", Value = "05" });
                items.Add(new SelectListItem { Text = "06", Value = "06" });
                items.Add(new SelectListItem { Text = "07", Value = "07" });
                items.Add(new SelectListItem { Text = "08", Value = "08" });
                items.Add(new SelectListItem { Text = "09", Value = "09" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "11", Value = "11" });
                items.Add(new SelectListItem { Text = "12", Value = "12" });
            }
            return items;
        }

        public static List<SelectListItem> getAllPhoneType(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType1_, Value = "1", Selected = true });     //"Cellulaire Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType2_, Value = "2" });      //Résidentiel
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType3_, Value = "3" });      //"Cellulaire Travail"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType4_, Value = "4" });      //"Bureau"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType1_, Value = "1" });      //"Cellulaire Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType2_, Value = "2", Selected = true });     //"Résidentiel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType3_, Value = "3" });      //"Cellulaire Travail"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType4_, Value = "4" });      //"Bureau"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType1_, Value = "1" });      //"Cellulaire Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType2_, Value = "2" });      //"Résidentiel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType3_, Value = "3", Selected = true });     //"Cellulaire Travail"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType4_, Value = "4" });      //"Bureau"
            }
            else if (selectedValue == "4")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType1_, Value = "1" });      //"Cellulaire Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType2_, Value = "2" });      //"Résidentiel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType3_, Value = "3" });      //"Cellulaire Travail"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType4_, Value = "4", Selected = true });     //"Bureau"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType1_, Value = "1" });      //"Cellulaire Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType2_, Value = "2" });      //"Résidentiel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType3_, Value = "3" });      //"Cellulaire Travail"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllPhoneType4_, Value = "4" });      //"Bureau"
            }
            return items;
        }

        public static List<SelectListItem> getAllEmailAddressType(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType1_, Value = "1", Selected = true });      //"Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType2_, Value = "2" });       //"Professionnel"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType1_, Value = "1" });       //"Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType2_, Value = "2", Selected = true });      //"Professionnel"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType1_, Value = "1" });       //"Personnel"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getAllEmailAddressType2_, Value = "2" });       //"Professionnel"
            }
            return items;
        }

        public static List<SelectListItem> getRecipientAccountPhoneNumberType(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1", Selected = true });      //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2", Selected = true });      //"Numéro de téléphone PayKap"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
            }
            return items;
        }

        public static List<SelectListItem> getUserBySearchType(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1", Selected = true });      //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType1_, Value = "3" });      //"Numéro de carte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType2_, Value = "4" });      //"Adresse électronique (e-mail)"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2", Selected = true });      //"Numéro de téléphone PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType1_, Value = "3" });      //"Numéro de carte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType2_, Value = "4" });      //"Adresse électronique (e-mail)"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType1_, Value = "3", Selected = true });     //"Numéro de carte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType2_, Value = "4" });      //"Adresse électronique (e-mail)"
            }
            else if (selectedValue == "4")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType1_, Value = "3" });      //"Numéro de carte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType2_, Value = "4", Selected = true });     //"Adresse électronique (e-mail)"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType1_, Value = "1" });       //"Numéro de compte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getRecipientAccountPhoneNumberType2_, Value = "2" });       //"Numéro de téléphone PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType1_, Value = "3" });      //"Numéro de carte PayKap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getUserBySearchType2_, Value = "4" });      //"Adresse électronique (e-mail)"
            }
            return items;
        }

        public static List<SelectListItem> getGender(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "1")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender1_, Value = "1", Selected = true });       //"M"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender2_, Value = "2" });        //"Mme"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender3_, Value = "3" });        //"Mlle"
            }
            else if (selectedValue == "2")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender1_, Value = "1" });        //"M"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender2_, Value = "2", Selected = true });       //"Mme"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender3_, Value = "3" });        //"Mlle"
            }
            else if (selectedValue == "3")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender1_, Value = "1" });        //"M"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender2_, Value = "2" });        //"Mme"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender3_, Value = "3", Selected = true });       //"Mlle"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender1_, Value = "1" });        //"M"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender2_, Value = "2" });        //"Mme"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getGender3_, Value = "3" });        //"Mlle"
            }
            return items;
        }

        public static List<SelectListItem> geUserTypeCode()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = Resources.Resources.z3geUserTypeCode1_, Value = "0" });       //"Admin"
            items.Add(new SelectListItem { Text = Resources.Resources.z3geUserTypeCode2_, Value = "1" });       //"Employé PayKap"
            items.Add(new SelectListItem { Text = Resources.Resources.z3geUserTypeCode3_, Value = "2" });       //"Client"
            items.Add(new SelectListItem { Text = Resources.Resources.Company, Value = "3" });      //"Entreprise"
            return items;
        }

        public static List<SelectListItem> getUserStatusCode()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Pas activé", Value = "00" });
            items.Add(new SelectListItem { Text = "Activé", Value = "01" });
            items.Add(new SelectListItem { Text = "Supprimé", Value = "02" });
            items.Add(new SelectListItem { Text = "Bloqué par Paykap", Value = "03" });
            items.Add(new SelectListItem { Text = "Bloqué par Une Entreprise", Value = "04" });
            items.Add(new SelectListItem { Text = "Bloqué par Paykap (Démandé par le client)", Value = "05" });
            return items;
        }

        public static List<SelectListItem> getBusinessTypeList(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "01")
            {
                items.Add(new SelectListItem { Text = "01", Value = "Financial Institution For Money Transfer", Selected = true });
                items.Add(new SelectListItem { Text = "02", Value = "Client In Business Partner" });
                items.Add(new SelectListItem { Text = "03", Value = "Business Offering PayKap Card" });
                items.Add(new SelectListItem { Text = "04", Value = "Business Client" });
            }
            else if (selectedValue == "02")
            {
                items.Add(new SelectListItem { Text = "01", Value = "Financial Institution For Money Transfer" });
                items.Add(new SelectListItem { Text = "02", Value = "Client In Business Partner", Selected = true });
                items.Add(new SelectListItem { Text = "03", Value = "Business Offering PayKap Card" });
                items.Add(new SelectListItem { Text = "04", Value = "Business Client" });
            }
            else if (selectedValue == "03")
            {
                items.Add(new SelectListItem { Text = "01", Value = "Financial Institution For Money Transfer" });
                items.Add(new SelectListItem { Text = "02", Value = "Client In Business Partner" });
                items.Add(new SelectListItem { Text = "03", Value = "Business Offering PayKap Card", Selected = true });
                items.Add(new SelectListItem { Text = "04", Value = "Business Client" });
            }
            else if (selectedValue == "04")
            {
                items.Add(new SelectListItem { Text = "01", Value = "Financial Institution For Money Transfer" });
                items.Add(new SelectListItem { Text = "02", Value = "Client In Business Partner" });
                items.Add(new SelectListItem { Text = "03", Value = "Business Offering PayKap Card" });
                items.Add(new SelectListItem { Text = "04", Value = "Business Client", Selected = true });
            }
            else
            {
                items.Add(new SelectListItem { Text = "01", Value = "Financial Institution For Money Transfer" });
                items.Add(new SelectListItem { Text = "02", Value = "Client In Business Partner" });
                items.Add(new SelectListItem { Text = "03", Value = "Business Offering PayKap Card" });
                items.Add(new SelectListItem { Text = "04", Value = "Business Client" });
            }

            return items;
        }

        public static List<SelectListItem> getBusinessUserStatusCode(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (selectedValue == "00")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00", Selected = true });      //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            else if (selectedValue == "01")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01", Selected = true });      //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            else if (selectedValue == "02")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02", Selected = true });      //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            else if (selectedValue == "03")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03", Selected = true });      //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            else if (selectedValue == "04")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04", Selected = true });      //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            else if (selectedValue == "05")
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05", Selected = true });      //"Bloqué à la demande de cet utilisateur"
            }
            else
            {
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode0_, Value = "00" });       //"Pas activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode1_, Value = "01" });       //"Activé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode2_, Value = "02" });       //"Supprimé"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode3_, Value = "03" });       //"Bloqué par Paykap"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode4_, Value = "04" });       //"Bloqué par l'entreprise"
                items.Add(new SelectListItem { Text = Resources.Resources.z3getBusinessUserStatusCode5_, Value = "05" });       //"Bloqué à la demande de cet utilisateur"
            }
            return items;
        }

        public static string generateOneEmail(string fnm, string lnm, ApplicationUserManager UserManager)
        {
            try
            {
                // remove accented character
                fnm = replaceAccentedCharacter(fnm);
                lnm = replaceAccentedCharacter(lnm);
                
                // remove white space
                fnm = replaceWhiteSpace(fnm);
                lnm = replaceWhiteSpace(lnm);

                // convert to lower case
                fnm = fnm.ToLower();
                lnm = lnm.ToLower();

                string part1;
                string part2 = "@paykap.com";
                string newEmail;
                bool newEmailIsAvailableIND = false;
                int i = 0;

                do
                {
                    if (i == 0)
                    {
                        part1 = string.Concat(fnm, ".", lnm);
                    }
                    else
                    {
                        part1 = string.Concat(fnm, ".", lnm, Convert.ToString(i));
                    }

                    newEmail = string.Concat(part1, part2);
                    var user = UserManager.FindByEmail(newEmail);
                    if (user == null)
                    {
                        newEmailIsAvailableIND = true;
                    }
                    i++;
                }
                while (newEmailIsAvailableIND == false);
                return newEmail;
            }
            catch
            {
                return null;
            }
        }

        //source : http://www.yvoz.net/2011/12/csharp-supprimer-accent-chaine/
        public static string replaceAccentedCharacter(string text)
        {
            //convert the text in table of char
            char[] charTable = text.ToCharArray();
            int mchar;
            for (int i = 0; i < text.Length; i++)
            {
                //Conversion du caractere en int
                mchar = (int)charTable[i];

                //MAJUSCULES
                // remplacement des accents par A
                if (mchar >= 192 && mchar <= 198)
                {
                    charTable[i] = 'a';//(char)65;
                }
                else if (mchar >= 200 && mchar <= 203) // remplacement des accents par E
                {
                    charTable[i] = 'e';//(char)69;
                }
                else if (mchar >= 204 && mchar <= 207) // remplacement des accents par I
                {
                    charTable[i] = 'i';//(char)73;
                }
                else if (mchar >= 210 && mchar <= 216 && mchar != 215) // remplacement des accents par O
                {
                    charTable[i] = 'o';//(char)79;
                }
                else if (mchar >= 217 && mchar <= 220) // remplacement des accents par U
                {
                    charTable[i] = 'u';//(char)85;
                }
                else if (mchar == 199) // remplacement des ç par C
                {
                    charTable[i] = 'c';//(char)67;
                }
                else if (mchar == 208) // remplacement des Ð par D
                {
                    charTable[i] = 'd';//(char)68;
                }
                else if (mchar == 209) // remplacement des Ñ par N
                {
                    charTable[i] = 'n';//(char)78;
                }
                else if (mchar == 221) // remplacement des Ý par Y
                {
                    charTable[i] = 'y';//(char)89;
                }
                //MINUSCULES
                else if (mchar >= 224 && mchar <= 230)  // remplacement des accents par A
                {
                    charTable[i] = 'a';//(char)97;
                }
                else if (mchar >= 232 && mchar <= 235) // remplacement des accents par E
                {
                    charTable[i] = 'e';//(char)101;
                }
                else if (mchar >= 236 && mchar <= 239) // remplacement des accents par I
                {
                    charTable[i] = 'i';//(char)105;
                }
                else if (mchar >= 242 && mchar <= 248) // remplacement des accents par O
                {
                    charTable[i] = 'o';//(char)111;
                }
                else if (mchar >= 249 && mchar <= 252) // remplacement des accents par U
                {
                    charTable[i] = 'u';//(char)117;
                }
                else if (mchar == 231) // remplacement des ç par C
                {
                    charTable[i] = 'c';//(char)99;
                }
                else if (mchar == 208) // remplacement des Ð par D
                {
                    charTable[i] = 'd';//(char)100;
                }
                else if (mchar == 241) // remplacement des Ñ par N
                {
                    charTable[i] = 'n';//(char)110;
                }
                else if (mchar == 253 || mchar == 255) // remplacement des Ý par Y
                {
                    charTable[i] = 'y';//(char)121;
                }
                else if (mchar == 176) // remplacement des ° par
                {
                    charTable[i] = ' ';
                }
                else // drop the character if not recognize
                {
                    charTable[i] = charTable[i];
                }
            }

            //Convert the char[] in text string
            return new string(charTable);
        }
    }
}