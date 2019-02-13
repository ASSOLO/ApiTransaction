using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaykapDataAccess;
using ApiPaykapTransaction.MyEntities;
using System.Data;
using System.Data.Entity;
using System.Web.Http.Description;
using ApiPaykapTransaction.Models;
using Resources;
using Microsoft.AspNet.Identity;
using ApiPaykapTransaction.Models.DAL;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using pkpApp.Models;
using pkpApp.Models.DAL; //using System.ComponentModel;




namespace ApiPaykapTransaction.Controllers
{
    public class TransactionsController : ApiController
    {
        private DalContext db = new DalContext();
        private DataModel DBContext = new DataModel();
        private Account acct = new Account();
        private DalFunction DAL = new DalFunction();
        private ApplicationUserManager _userManager;
        private AccountHistory acctHist = new AccountHistory();
        private Contact ktct = new Contact();
        private BusinessAgency busAgcy = new BusinessAgency();
        private BusinessCommissionTransaction busCmsnTrans = new BusinessCommissionTransaction();
        private TransactionTransferCreditDebit transObj = new TransactionTransferCreditDebit();
        private TransactionIdentificationDocument transIdDOC = new TransactionIdentificationDocument();
        private Agent agnt = new Agent();
        private UserWithdrawalCredit userWithCredit = new UserWithdrawalCredit();
        private BusinessFee busCtryFee = new BusinessFee();
        private BusinessUser busUsr = new BusinessUser();
        private Business bus = new Business();
        private MoneyTransferAuthorizedLimit authAmt = new MoneyTransferAuthorizedLimit();
        private UserPhoneLogin userPhoneLogin = new UserPhoneLogin();
        private BusinessCommission busCmsn = new BusinessCommission();
        private Card card = new Card();
        private User usr = new User();
        public System.Web.Mvc.TempDataDictionary TempData { get; set; }




        //public  string GetTest(string email, string password, string currentUserId)
        //public string GetTest(string currentUserId)
        // public string GetTest(string unsr_nbr)
          public string GetTest( string card)
         {
             //var userNbrList = db.TUSR.Where(x => x.USR_NBR == unsr_nbr).ToList();
             //var userId = userNbrList[0].Id;
             //var userList = db.TUSR.Where(x => x.PHN1_NBR == phone).ToList();
             //var user1 = userList[0];
             //var cardList = db.TCARD.Where(x => x.USR_NBR == user1.USR_NBR).ToList();
             //var card = cardList[0];
             //var user= db.TUSR.Where(x => x.Id == "8EA92390-5C0A-48C9-9011-6202AB83C582").ToList();
             // var admin = AdminUser();
             //var cardNbrHash = Encryption.EncryptAes(CarNbr);   
             //string CarNbr = "lESgR/ETWjUeC+d5j9TTOgrxjAVNZcfPXHmiSpnv8OKKVJBEYHV8m83xa47y7Eyy";
             //var cardOwner = CardOwnerByCardNbr(CarNbr);
             //var AccountCardOwner = AccountCardOwnerByCardNbr(CarNbr);

             var clientModel = ClientData("lESgR/ETWjUeC+d5j9TTOgrxjAVNZcfPXHmiSpnv8OKKVJBEYHV8m83xa47y7Eyy", null, "withdrawal");
             //int retVal = DAL.testIsInRole(db, UserId);    CardOwnerByCardNbr
             // string result = Convert.ToString(retVal);
             //var businessModel = BusinessUserData(currentUserId);
             //var busUser = BusinessUser(UsrNbr, UserId);
             //var busUser = busUsr.getBusinessUserByUsrNbr("0150705229");
             //var user = CurrentUserByUserId(currentUserId);
             // var businessModel = BusinessUserData(UserId);
             //string testons = businessModel.BUS_SHORT_NM +"_"+ businessModel.BUS_CRCY_CD; 
             //return clientModel.CLT_FUL_NM + "_"+ clientModel.CLT_CTRY_CD + "_"+ clientModel.CLT_USR_NBR + "_"+ clientModel.CLT_ACCT_ID;
             //return AccountCardOwner.USR_NBR + "_" + AccountCardOwner.CRCY_CD + "_" + AccountCardOwner.ACCT_NAME + "_" + AccountCardOwner.CHECK_ACCT_BAL;
             //return cardOwner.USR_NBR + "_" + cardOwner.CARD_OWNR_FNM.ToUpper()+"_"+cardOwner.CARD_PIN;
             //return busUser.BUS_USR_EDT +"_"+ busUser.BUS_AGCY_NBR+"_"+ busUser.BUS_USR_TCD;
             // string a = currentUserId;
             //string b = a.Replace("", "+");
             return clientModel.CLT_FUL_NM + "_"+ clientModel.CLT_CTRY_CD ;
            // return businessModel.BUS_USR_NBR + "_" + businessModel.BUS_ACCT_CLTR_INFO + "_" + businessModel.BUS_SHORT_NM;
             //var result = await SignInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, shouldLockout: true);
         }  

       

        [ResponseType(typeof(DETAIL_TRANSACTION))]
        public List<MyEntities.DETAIL_TRANSACTION> GetConfirmTransaction(string  id, decimal montant,string phone, string currentUserId)
        {
            //currentUserId est le USR_NBR de lagent en cours
            var userNbrList = db.TUSR.Where(x => x.USR_NBR == currentUserId).ToList();
            var IdCurrentAgent = userNbrList[0].Id;
            //IdCurrentAgent est Id de lagent en cours

            var model = new AccountWithdrawalConfirmationViewModel();
            var userList = db.TUSR.Where(x => x.PHN1_NBR == phone).ToList();
            var user1 = userList[0];
            var cardList = db.TCARD.Where(x => x.USR_NBR == user1.USR_NBR).ToList();
            var card = cardList[0];
            if (id != "1" && id != "2")
            { throw new Exception(); }

            if (id == "1")
            {
                model.ACCT_WITHDRWL_WITH_PIN_IND = true;
            }
            else
            {
                model.ACCT_WITHDRWL_WITH_PIN_IND = false;
                //string strID_DOC_ID = Convert.ToString(TempData["ID_DOC_ID"]);
                string strID_DOC_ID = Convert.ToString(20);
                int resultID_DOC_ID;
                bool boolID_DOC_ID = Int32.TryParse(strID_DOC_ID, out resultID_DOC_ID);
                if (!boolID_DOC_ID)
                { throw new Exception(); }

                model.ID_DOC_ID = resultID_DOC_ID;
                //model.ID_DOC_NBR = Convert.ToString(TempData["ID_DOC_NBR"]);
                model.ID_DOC_NBR = Convert.ToString(20);
                //model.ID_DOC_XDT = Convert.ToDateTime(TempData["ID_DOC_XDT"]);
                model.ID_DOC_XDT = Convert.ToDateTime(DateTime.Now.ToString());
                //model.CLT_ID_DOC_BRDAY = Convert.ToDateTime(TempData["CLT_ID_DOC_BRDAY"]);  
                model.CLT_ID_DOC_BRDAY = Convert.ToDateTime(DateTime.Now.ToString()); ;
            }
            //string transAmt = Convert.ToString(TempData["TRANS_AMT"]);
            string transAmt = Convert.ToString(montant);

            if (string.IsNullOrWhiteSpace(transAmt))
            { throw new Exception(); }

           // model.TRANS_AMT = Convert.ToDecimal(TempData["TRANS_AMT"]);
            model.TRANS_AMT = Convert.ToDecimal(montant);
           // model.CARD_NBR = Convert.ToString(TempData["CARD_NBR"]);
            model.CARD_NBR = Convert.ToString(card.CARD_NBR);
           // model.PROMO_CODE = Convert.ToString(TempData["PROMO_CODE"]);
            model.PROMO_CODE = Convert.ToString(6);

            var businessModel = BusinessUserData(IdCurrentAgent);
            var clientModel = ClientData(model.CARD_NBR, null, "withdrawal");
            if (businessModel == null || clientModel == null)
            { throw new Exception(); }

            model.BUS_CTRY_CD = businessModel.BUS_CTRY_CD;
           // model.BUS_CTRY_CD = "124";
            model.BUS_ACCT_ID = businessModel.BUS_ACCT_ID;
           // model.BUS_CRCY_CD = "XAF";
            model.BUS_CRCY_CD = businessModel.BUS_CRCY_CD;
            model.BUS_USR_NBR = businessModel.BUS_USR_NBR;
            model.BN = businessModel.BN;
            model.BUS_SHORT_NM = businessModel.BUS_SHORT_NM.ToUpper();
            model.MANAGER_ACCT_ID = businessModel.MANAGER_ACCT_ID;
            string BUS_ACCT_CLTR_INFO = businessModel.BUS_ACCT_CLTR_INFO;

            model.CLT_CTRY_CD = clientModel.CLT_CTRY_CD;
            model.CLT_ACCT_ID = clientModel.CLT_ACCT_ID;
            model.CLT_CRCY_CD = clientModel.CLT_CRCY_CD;
            //model.CLT_CRCY_CD = "XAF";
            model.CLT_FUL_NM = clientModel.CLT_FUL_NM;
            model.CLT_USR_NBR = clientModel.CLT_USR_NBR;
            model.CLT_USR_ID = clientModel.CLT_USR_ID;
            string CLT_ACCT_CLTR_INFO = clientModel.CLT_ACCT_CLTR_INFO;

            model.FROM_SERV_CTRY_ID = 6; //6 = PayKap Account
            model.TO_SERV_CTRY_ID = 2; //2 = Cash Pickup

            if (model.BUS_CTRY_CD != model.CLT_CTRY_CD)
            {
               // ViewBag.ERROR = Resources.Resources.z3PKPBController9_;     //"Votre pays est different de celui du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            //convert when different currencies
            if (model.BUS_CRCY_CD != model.CLT_CRCY_CD)
            {
               // ViewBag.ERROR = Resources.Resources.z3PKPBController10_;        //"Votre devise est differente de celle du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            model.CRCY_XCHG_RT_IND = false;
            model.CRCY_XCHG_RT_TXT = "";
            model.CRCY_XCHG_RT = 0.0m;
            model.AMT_TO_PAY = model.TRANS_AMT;
            model.AMT_TO_RECEIVE = model.TRANS_AMT;

            //get the business commission
            string srvcTCD = "06"; //withdrawal deposit
            string BUS_CMSN_SCD = "06"; // withdrawal deposit
                                        //get the business commission
            decimal busFeeAmt = busCtryFee.getBusinessFeeAmount(model.AMT_TO_RECEIVE, model.BUS_CTRY_CD, model.BUS_CRCY_CD, srvcTCD);
            if (busFeeAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }
            model.TRANS_FEE_AMT = busFeeAmt;
            model.FEE_AMT = busFeeAmt;
            string BUS_OFR_SRVC_TO_OWN_CLT_IND = "0";
            decimal busCnsmAmt = busCmsn.getBusinessCommissionAmount(model.TRANS_AMT, model.BN, model.BUS_CTRY_CD, model.BUS_CRCY_CD, BUS_CMSN_SCD, model.TRANS_FEE_AMT, BUS_OFR_SRVC_TO_OWN_CLT_IND);
            if (busCnsmAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }

            model.BUS_CMSN_AMT = busCnsmAmt;

            //check if the card owner has withdrawal credit
            model.UPDATE_CLT_CRDT_IND = false;
            model.REMAINING_CRDT_NBR = 0;
            var getCardOwnerCredit = userWithCredit.getWithdrawalCreditByUsrNbr(model.CLT_USR_NBR);
            if (getCardOwnerCredit != null)
            {
                if (getCardOwnerCredit.USR_WHDRL_CRDT_NBR > 0)
                {
                    model.FEE_AMT = 0.0m;
                    int newBalCredit = getCardOwnerCredit.USR_WHDRL_CRDT_NBR - 1;
                    model.UPDATE_CLT_CRDT_IND = true;
                    model.REMAINING_CRDT_NBR = newBalCredit;
                }
            }

            if (model.FEE_AMT != 0.0m && !string.IsNullOrWhiteSpace(model.PROMO_CODE))
            {
                model.FEE_AMT = model.FEE_AMT - 1000.0m;
                if (model.FEE_AMT < 0.0m)
                {
                    model.FEE_AMT = 0.0m;
                }
            }

            model.TOT_AMT_TO_PAY = model.AMT_TO_PAY + model.FEE_AMT;
            //check the card owner balance
            decimal cardOwnerNewBal = acct.debitTransaction(model.CLT_ACCT_ID, model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD);
            if (cardOwnerNewBal == -1.0m)
            { throw new Exception(); }

            if (cardOwnerNewBal == -2.0m)
            {
                decimal negativeBal = acct.getNegativeDifferenceBalanceForTransaction(model.CLT_ACCT_ID, model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD);
               // ViewBag.NEGATIVE_BAL_IND = "true";
               // ViewBag.NEGATIVE_BAL_TXT = Resources.Resources.z3PKPBController33_ + CommonLibrary.displayFormattedCurrency(negativeBal, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);        //"Montant manquant : "
               // ViewBag.ERROR = Resources.Resources.z3PKPBController34_;        //"Le compte PayKap du client n'a pas suffisamment d'argent pour complèter cette transaction."
                throw new Exception();
            }

            model.AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController14_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_PAY, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant : "
            model.FEE_AMT_TXT = Resources.Resources.z3PKPBController15_ + CommonLibrary.displayFormattedCurrency(model.FEE_AMT, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);     //"Frais : "
            model.TOT_AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController16_ + CommonLibrary.displayFormattedCurrency(model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant à prélever : "
            model.AMT_TO_RECEIVE_TXT = Resources.Resources.z3PKPBController17_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_RECEIVE, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);       //"Montant à recevoir : "

            //****************************************  creation de la transaction ************************************
            var cardOwner = CardOwnerByCardNbr(model.CARD_NBR);
           /* if (cardOwner == null)
            {
                //ViewBag.ERROR1 = Resources.Resources.z3PKPBController35_;       //"Ce numéro de carte PayKap n'est pas valide"
                throw new Exception();
            }

            if (model.ACCT_WITHDRWL_WITH_PIN_IND) //check the pin if it is a pin transaction
            {
                var cardPinHash = Encryption.EncryptAes(model.CARD_PIN);
                if (cardOwner.CARD_PIN != cardPinHash)
                {
                    //ViewBag.CARD_NBR_ERROR = Resources.Resources.z3PKPBController36_;       //Ce NIP n'est pas valide.
                    throw new Exception();
                }
            } */

            string transTCD = "06"; //06 = Withdrawal transaction
            string transSCD = "06"; //06 = Transaction completed
            DateTime transXDT = DateTime.Now.AddMonths(1);
            bool usedDefaultExpiryDate = true;
            int RCPT_USR_BUS_ID = 0;

            var admin = AdminUser();
            if (admin == null)
            { throw new Exception(); }

            var getRcptAdmin = db.TRCPT_USR_BUS.Where(x => x.RCPT_USR_NBR == admin.USR_NBR && x.USR_NBR == admin.USR_NBR &&
                                                                x.RCPT_USR_BUS_TCD == "0").ToList();
            if (getRcptAdmin.Count() == 0)
            { throw new Exception(); }

            var getRcptAdmin1 = getRcptAdmin[0];
            RCPT_USR_BUS_ID = getRcptAdmin1.RCPT_USR_BUS_ID;

            string TRANS_DESC = Resources.Resources.z3PKPBController37_ + model.BUS_SHORT_NM;       //"Retrait/Cash - "
            var newTrans = transObj.createTransaction(model.FROM_SERV_CTRY_ID, model.TO_SERV_CTRY_ID,
                                                      model.CLT_CTRY_CD, model.BUS_CTRY_CD,
                                                      model.CLT_CRCY_CD, model.BUS_CRCY_CD,
                                                      model.CRCY_XCHG_RT, model.AMT_TO_PAY, model.FEE_AMT,
                                                      model.TOT_AMT_TO_PAY, model.AMT_TO_RECEIVE, transSCD,
                                                      transXDT, usedDefaultExpiryDate, model.CLT_USR_NBR,
                                                      RCPT_USR_BUS_ID, transTCD, TRANS_DESC);

            string checkIfCltInBusIND = checkIfCurrentUserIsClientInBusinessIndicator(IdCurrentAgent);
            string CASHIER_OR_CLT_IN_BUS_TCD;
            decimal newBal;
            if (checkIfCltInBusIND == "true")
            {
                //insert client in business account history
                newBal = acct.creditTransaction(model.BUS_ACCT_ID, model.AMT_TO_RECEIVE, model.BUS_CRCY_CD);
                CASHIER_OR_CLT_IN_BUS_TCD = "2"; // 2 client in business
            }
            else
            {
                //insert business user account history
                newBal = acct.debitBusinessTransaction(model.BUS_ACCT_ID, model.AMT_TO_RECEIVE, model.BUS_CRCY_CD);
                CASHIER_OR_CLT_IN_BUS_TCD = "1"; //1 cashier
            }
            if (newBal == -1.0m)
            { throw new Exception(); }

            string TRANS_TCD;
            string TRANS_PAY_SRC_CD = "1"; // 1 = cash
            string TRANS_SRVC_TCD = transTCD; ///06- withdrawal transaction
            if (checkIfCltInBusIND == "true")
            {
                TRANS_TCD = "1"; // 1 CREDIT
            }
            else
            {
                TRANS_TCD = "2"; // 2 DEBIT
            }

            var busHistory = acctHist.insertAccountHistory(model.BUS_ACCT_ID, TRANS_TCD, TRANS_PAY_SRC_CD, TRANS_SRVC_TCD,
                                                        newBal, model.AMT_TO_RECEIVE, TRANS_DESC);

            //insert client account history
            decimal cltNewBal = acct.debitTransaction(model.CLT_ACCT_ID, model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD);
            if (cltNewBal == -1.0m)
            { throw new Exception(); }

            if (cltNewBal == -2.0m)
            {
               // ViewBag.ERROR1 = Resources.Resources.z3PKPBController34_;       //Le compte PayKap du client n'a pas suffisamment d'argent pour complèter cette transaction.
                throw new Exception();
            }

            string CLT_TRANS_PAY_SRC_CD = "1"; // 1 = cash
            string CLT_TRANS_SRVC_TCD = transTCD; ///06- withdrawal transaction
            var cltHistory = acctHist.insertAccountHistory(model.CLT_ACCT_ID, "2", CLT_TRANS_PAY_SRC_CD, CLT_TRANS_SRVC_TCD,
                                                        cltNewBal, model.TOT_AMT_TO_PAY, TRANS_DESC);

            int TRANS_ID = 0;
            var getBusCmsnTrans = busCmsnTrans.insertBusinessCommissionTransaction(TRANS_ID, model.BUS_CMSN_AMT,
                                                    model.BUS_CRCY_CD, model.BUS_USR_NBR, transTCD);
            if (getBusCmsnTrans == null)
            { throw new Exception(); }

            string insertBusAcctHistIND = "0"; // 0 = not insert business account history

            string RCPT_USR_NBR = model.CLT_USR_NBR;
            string UPDATE_CLT_CRDT_IND = "0";
            int USR_WHDRL_CRDT_NBR = 0;

            if (model.UPDATE_CLT_CRDT_IND)
            {
                USR_WHDRL_CRDT_NBR = model.REMAINING_CRDT_NBR;
                UPDATE_CLT_CRDT_IND = "1";
            }

            //CHECK DUPLICATE TRANSACTION
            bool checkDuplication = CommonLibrary.duplicatedTransactionAgencyOnlineIndicator(db,
                                                    newTrans.FROM_USR_NBR,
                                                    newTrans.FROM_TRSF_SERV_ID, newTrans.TO_TRSF_SERV_ID,
                                                    newTrans.RCPT_USR_BUS_ID, newTrans.TRANS_SCD,
                                                    model.BUS_USR_NBR);
            int AGNT_ACCT_ID = 25;
            int AGNT_ID = 25;
            decimal AGNT_CMSN_AMT = 2000;
            if (!checkDuplication)
            {
                var retVal = DAL.withdrawalTransaction(db, newTrans.FROM_TRSF_SERV_ID, newTrans.TO_TRSF_SERV_ID,
                                     newTrans.FROM_CTRY_CD, newTrans.TO_CTRY_CD, newTrans.FROM_CRCY_CD, newTrans.TO_CRCY_CD,
                                     newTrans.CRCY_XCHG_RT, newTrans.FROM_TRANS_AMT, newTrans.FROM_FEE_AMT,
                                     newTrans.FROM_TOT_AMT, newTrans.TO_TRANS_AMT, newTrans.TRANS_SCD,
                                     newTrans.TRANS_CDT, newTrans.TRANS_PAID_DPST_DT, newTrans.TRANS_XDT,
                                     newTrans.FROM_USR_NBR, newTrans.RCPT_USR_BUS_ID, newTrans.TRANS_TRSF_CRDT_DBT_TCD, newTrans.TRANS_DESC,
                                     insertBusAcctHistIND,
                                     busHistory.ACCT_ID, busHistory.TRANS_TCD, busHistory.TRANS_PAY_SRC_CD, busHistory.TRANS_SRVC_TCD,
                                     busHistory.BAL_AFTR_TRANS, busHistory.TRANS_AMT, busHistory.TRANS_DTTM, busHistory.TRANS_DESC,
                                     cltHistory.ACCT_ID, cltHistory.TRANS_TCD, cltHistory.TRANS_PAY_SRC_CD, cltHistory.TRANS_SRVC_TCD,
                                     cltHistory.BAL_AFTR_TRANS, cltHistory.TRANS_AMT, cltHistory.TRANS_DTTM, cltHistory.TRANS_DESC,
                                     getBusCmsnTrans.BUS_CMSN_AMT, getBusCmsnTrans.CRCY_CD, getBusCmsnTrans.BUS_USR_NBR,
                                     UPDATE_CLT_CRDT_IND, RCPT_USR_NBR, USR_WHDRL_CRDT_NBR, model.MANAGER_ACCT_ID, CASHIER_OR_CLT_IN_BUS_TCD, "1", AGNT_ACCT_ID, AGNT_ID, AGNT_CMSN_AMT);
            }
            else
            {
                //ViewBag.ERROR1 = CommonLibrary.displayAlreadyMakeTransactionAgencyErrorMessage()**;
                throw new ProcessException(CommonLibrary.displayAlreadyMakeTransactionAgencyErrorMessage());
                //throw new Exception();
            }

            var lastTransList = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == newTrans.FROM_USR_NBR &&
                                                                    x.FROM_TRSF_SERV_ID == newTrans.FROM_TRSF_SERV_ID &&
                                                                    x.TO_TRSF_SERV_ID == newTrans.TO_TRSF_SERV_ID &&
                                                                    x.RCPT_USR_BUS_ID == newTrans.RCPT_USR_BUS_ID &&
                                                                    x.TRANS_SCD == newTrans.TRANS_SCD)
                                                                    .OrderByDescending(y => y.TRANS_CDT).ToList();
            if (lastTransList.Count() != 0)
            {
                var lastTrans = lastTransList[0];
                string TRANS_NBR = Convert.ToString(lastTrans.TRANS_ID);
                string TRANS_DATE = newTrans.TRANS_CDT.ToString("dd/MM/yyyy");

                if (model.ACCT_WITHDRWL_WITH_PIN_IND == false)
                {
                    var insertDOC = transIdDOC.createTransactionIdentificationDocument(lastTrans.TRANS_ID, model.ID_DOC_ID,
                                                            model.ID_DOC_NBR, model.ID_DOC_XDT,
                                                            model.CLT_ID_DOC_BRDAY, model.BUS_USR_NBR, model.CLT_USR_NBR);
                }

                sendTransactionTranscript(model.CLT_USR_ID, cltHistory.TRANS_DESC, model.AMT_TO_RECEIVE_TXT,
                                                    TRANS_DATE, TRANS_NBR, "FRA");

                string SRVC_TCD = "06";
                agnt.insertBusinessAgentCommission(UserManager, DAL, model.TRANS_FEE_AMT,
                                                   model.BUS_CTRY_CD, model.BUS_CRCY_CD, SRVC_TCD, model.BN,
                                                   TRANS_NBR, model.CLT_USR_NBR, model.CLT_FUL_NM);

                //if it is not the first transaction, insert the agent commission transaction // else insert the sponsored to agntSpnsrd table
                SRVC_TCD = "01"; // 01 = transfer
                agnt.insertAgentCommission(UserManager, DAL, model.PROMO_CODE, model.FEE_AMT, model.BUS_CTRY_CD,
                                      model.BUS_CRCY_CD, model.CLT_USR_NBR, model.CLT_FUL_NM, TRANS_NBR, SRVC_TCD);

            }

            /*var getLastInsertedTransId = (DBContext.LastInsertedTransID()).ToList();
            int? transID = getLastInsertedTransId[0];*/
            var lastTrans1 = lastTransList[0];
            string TRANS_NBR1 = Convert.ToString(lastTrans1.TRANS_ID);


            //List<MyEntities.TRANS_INFO> DetailTransaction = new List<MyEntities.TRANS_INFO>();
            //**************** Detail debtransaction *******************
            var tUser = CurrentUserByUserId(IdCurrentAgent);    //get the Tuser here
            if (string.IsNullOrWhiteSpace(TRANS_NBR1) || tUser == null)
            { throw new Exception(); }
            int transID1 = Convert.ToInt32(TRANS_NBR1);
            string userId = tUser.Id.TrimEnd();
            var getTrans = transObj.getTransactionByTransID(transID1);
            var newCmsnTransList = db.TBUS_CMSN_TRANS.Where(x => x.TRANS_ID == transID1).ToList();    //get the business commission transaction
            if (getTrans == null || newCmsnTransList.Count() == 0)
            { throw new Exception(); }
            var newCmsnTrans = newCmsnTransList[0];

            bool displayCashierNmIND = true;

            string transSCD1 = "";
            if (getTrans.TRANS_SCD == "01")
            {
                transSCD1 = Resources.Resources.z3PKPBController55_;     //"Attente de paiement"
            }
            else if (getTrans.TRANS_SCD == "02" || getTrans.TRANS_SCD == "03")
            {
                transSCD1 = Resources.Resources.z3PKPBController56_;     //"Attente de validation"
            }
            else if (getTrans.TRANS_SCD == "04")
            {
                transSCD1 = Resources.Resources.z3PKPBController57_;     //"Transaction bloquée"
            }
            else if (getTrans.TRANS_SCD == "05")
            {
                transSCD1 = Resources.Resources.z3PKPBController58_;     //"Transaction expirée"
            }
            else if (getTrans.TRANS_SCD == "06")
            {
                transSCD1 = Resources.Resources.z3PKPBController59_;     //"Transaction complétée"
            }

            string transDESC;
            string labelToAmount = Resources.Resources.z3PKPBController60_;     //"Montant"
            if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01")
            {
                transDESC = Resources.Resources.z3PKPBController61_;        //"Virement d'argent"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "02" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "03")
            {
                transDESC = Resources.Resources.z3PKPBController62_;        //"Paiement de facture"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "04")
            {
                transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
            {
                transDESC = Resources.Resources.z3PKPBController64_;        //"Dépôt Espèces"
                labelToAmount = Resources.Resources.z3PKPBController65_;        //"Montant déposé"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
            {
                transDESC = Resources.Resources.z3PKPBController66_;        //Retrait d'espèces
                labelToAmount = Resources.Resources.z3PKPBController67_;        //"Montant retiré"
            }
            else
            {
                transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
            }

            var getBusUsr = busUsr.getBusinessUserByID(newCmsnTrans.BUS_USR_NBR);
            var getClient = usr.getUserByUsrNbr(getTrans.FROM_USR_NBR);
            if (getBusUsr == null || getClient == null)
            { throw new Exception(); }

            var getBus = bus.getBusinessByBN(getBusUsr.BN);
            var getBusAgcy = busAgcy.getOneBusinessAgencyByAgcyNbr(getBusUsr.BN, getBusUsr.BUS_AGCY_NBR);
            var getBusAcct = acct.getAccountByAcctID(getBusUsr.BUS_ACCT_ID);
            var getCashier = usr.getUserByUsrNbr(getBusUsr.BUS_EMPE_USR_NBR);
            var getAgcyKtct = ktct.getContactByKtctID(getBusAgcy.BUS_AGCY_KTCT_ID);
            string ACCT_TCD = "1";
            if (getClient.USR_TCD != "2")
            {
                ACCT_TCD = "2";
            }
            var getCltAcct = acct.getAccountByUsrNbr(getClient.USR_NBR, ACCT_TCD);
            if (getAgcyKtct == null || getCashier == null || getBus == null || getBusAgcy == null || getBusAcct == null || getCltAcct == null)
            { throw new Exception(); }

            string fromAgcyNM = getBusAgcy.BUS_AGCY_NM;
            string fromAgcyNbr = getBusAgcy.BUS_AGCY_NBR;
            string fromBusNM = getBus.BUS_NM;
            string fromBusAcct = acct.formatAccountNumber(getBusAcct.ACCT_NBR, "3");  // 3 = cashier // 4 = agence   5 = Company;
            string fromCashierNM = getCashier.USR_FUL_NM;
            string fromCashierNbr = getCashier.USR_NBR;
            string fromAgcyCityNM = getAgcyKtct.CITY_NM;

            string cltNM = getClient.USR_FUL_NM;
            string transDT = getTrans.TRANS_CDT.ToString("dd/MM/yyyy");
            string fromCultureInfo = getBusAcct.ACCT_CLTR_INFO;
            string toCultureInfo = getCltAcct.ACCT_CLTR_INFO;
            string transAmtTxt = "";

            if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
            {
                transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, fromCultureInfo);
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
            {
                transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, fromCultureInfo);
            }

            bool crcyXchgRtIND = false;
            string crcyXchgRtTXT = "";
            string amtToReceiveTXT = "";
            if (getTrans.CRCY_XCHG_RT != 0.0m)
            {
                crcyXchgRtIND = true;
                decimal fromXchgRt = 1.0m;
                if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
                {
                    string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.TO_CRCY_CD);
                    crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.FROM_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.TO_CRCY_CD;
                    amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, toCultureInfo);
                }
                else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
                {
                    string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.FROM_CRCY_CD);
                    crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.TO_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.FROM_CRCY_CD;
                    amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, toCultureInfo);
                }
            }


            //DataModel DBContext = new DataModel();

            List<MyEntities.DETAIL_TRANSACTION> DetailTransaction = new List<MyEntities.DETAIL_TRANSACTION>
                {
            new MyEntities.DETAIL_TRANSACTION{
            TRANS_SCD = transSCD1,
            TRANS_DESC=transDESC,
            BUS_AGCY_NM = fromAgcyNM,
            BUS_AGCY_NBR = fromAgcyNbr,
            BUS_NM = fromBusNM,
            BUS_CSHR_ACCT = fromBusAcct,
            BUS_CSHR_FUL_NM = fromCashierNM,
            BUS_CSHR_USR_NBR = fromCashierNbr,
            BUS_AGCY_CITY_NM = fromAgcyCityNM,
            CLT_FUL_NM = cltNM,
            VIEW_CSHR_NM_IND=true,
            TRANS_AMT = transAmtTxt,
            CRCY_XCHG_RT_IND = crcyXchgRtIND,
            CRCY_XCHG_RT = crcyXchgRtTXT,
            CLT_TRANS_AMT = amtToReceiveTXT
            }

        };
            return (DetailTransaction);
        }

        
        //************************Detailde la transaction ***************************************** 
        [ResponseType(typeof(DETAIL_TRANSACTION))]
        public List<MyEntities.DETAIL_TRANSACTION> GetTransDetailByID(string id, string currenUserId)
        {
            //currentUserId est le USR_NBR de lagent en cours
            var userNbrList = db.TUSR.Where(x => x.USR_NBR == currenUserId).ToList();
            var IdCurrentAgent = userNbrList[0].Id;
            //IdCurrentAgent est Id de lagent en cours

            var tUser = CurrentUserByUserId(IdCurrentAgent);    //get the Tuser here
            if (string.IsNullOrWhiteSpace(id) || tUser == null)
            { throw new Exception(); }
            int transID = Convert.ToInt32(id);
            string userId = tUser.Id.TrimEnd();
            var getTrans = transObj.getTransactionByTransID(transID);
            var newCmsnTransList = db.TBUS_CMSN_TRANS.Where(x => x.TRANS_ID == transID).ToList();    //get the business commission transaction
            if (getTrans == null || newCmsnTransList.Count() == 0)
            { throw new Exception(); }
            var newCmsnTrans = newCmsnTransList[0];

            bool displayCashierNmIND = true;
        
            string transSCD = "";
            if (getTrans.TRANS_SCD == "01")
            {
                transSCD = Resources.Resources.z3PKPBController55_;     //"Attente de paiement"
            }
            else if (getTrans.TRANS_SCD == "02" || getTrans.TRANS_SCD == "03")
            {
                transSCD = Resources.Resources.z3PKPBController56_;     //"Attente de validation"
            }
            else if (getTrans.TRANS_SCD == "04")
            {
                transSCD = Resources.Resources.z3PKPBController57_;     //"Transaction bloquée"
            }
            else if (getTrans.TRANS_SCD == "05")
            {
                transSCD = Resources.Resources.z3PKPBController58_;     //"Transaction expirée"
            }
            else if (getTrans.TRANS_SCD == "06")
            {
                transSCD = Resources.Resources.z3PKPBController59_;     //"Transaction complétée"
            }

            string transDESC;
            string labelToAmount = Resources.Resources.z3PKPBController60_;     //"Montant"
            if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01")
            {
                transDESC = Resources.Resources.z3PKPBController61_;        //"Virement d'argent"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "02" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "03")
            {
                transDESC = Resources.Resources.z3PKPBController62_;        //"Paiement de facture"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "04")
            {
                transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
            {
                transDESC = Resources.Resources.z3PKPBController64_;        //"Dépôt Espèces"
                labelToAmount = Resources.Resources.z3PKPBController65_;        //"Montant déposé"
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
            {
                transDESC = Resources.Resources.z3PKPBController66_;        //Retrait d'espèces
                labelToAmount = Resources.Resources.z3PKPBController67_;        //"Montant retiré"
            }
            else
            {
                transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
            }

            var getBusUsr = busUsr.getBusinessUserByID(newCmsnTrans.BUS_USR_NBR);
            var getClient = usr.getUserByUsrNbr(getTrans.FROM_USR_NBR);
            if (getBusUsr == null || getClient == null)
            { throw new Exception(); }

            var getBus = bus.getBusinessByBN(getBusUsr.BN);
            var getBusAgcy = busAgcy.getOneBusinessAgencyByAgcyNbr(getBusUsr.BN, getBusUsr.BUS_AGCY_NBR);
            var getBusAcct = acct.getAccountByAcctID(getBusUsr.BUS_ACCT_ID);
            var getCashier = usr.getUserByUsrNbr(getBusUsr.BUS_EMPE_USR_NBR);
            var getAgcyKtct = ktct.getContactByKtctID(getBusAgcy.BUS_AGCY_KTCT_ID);
            string ACCT_TCD = "1";
            if (getClient.USR_TCD != "2")
            {
                ACCT_TCD = "2";
            }
            var getCltAcct = acct.getAccountByUsrNbr(getClient.USR_NBR, ACCT_TCD);
            if (getAgcyKtct == null || getCashier == null || getBus == null || getBusAgcy == null || getBusAcct == null || getCltAcct == null)
            { throw new Exception(); }

            string fromAgcyNM = getBusAgcy.BUS_AGCY_NM;
            string fromAgcyNbr = getBusAgcy.BUS_AGCY_NBR;
            string fromBusNM = getBus.BUS_NM;
            string fromBusAcct = acct.formatAccountNumber(getBusAcct.ACCT_NBR, "3");  // 3 = cashier // 4 = agence   5 = Company;
            string fromCashierNM = getCashier.USR_FUL_NM;
            string fromCashierNbr = getCashier.USR_NBR;
            string fromAgcyCityNM = getAgcyKtct.CITY_NM;

            string cltNM = getClient.USR_FUL_NM;
            string transDT = getTrans.TRANS_CDT.ToString("dd/MM/yyyy");
            string fromCultureInfo = getBusAcct.ACCT_CLTR_INFO;
            string toCultureInfo = getCltAcct.ACCT_CLTR_INFO;
            string transAmtTxt = "";

            if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
            {
                transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, fromCultureInfo);
            }
            else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
            {
                transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, fromCultureInfo);
            }

            bool crcyXchgRtIND = false;
            string crcyXchgRtTXT = "";
            string amtToReceiveTXT = "";
            if (getTrans.CRCY_XCHG_RT != 0.0m)
            {
                crcyXchgRtIND = true;
                decimal fromXchgRt = 1.0m;
                if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
                {
                    string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.TO_CRCY_CD);
                    crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.FROM_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.TO_CRCY_CD;
                    amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, toCultureInfo);
                }
                else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
                {
                    string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.FROM_CRCY_CD);
                    crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.TO_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.FROM_CRCY_CD;
                    amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, toCultureInfo);
                }
            }
          
                List<MyEntities.DETAIL_TRANSACTION> DetailTransaction = new List<MyEntities.DETAIL_TRANSACTION>
                {
                new MyEntities.DETAIL_TRANSACTION{
                    TRANS_SCD = transSCD,
                    TRANS_DESC=transDESC,
                    BUS_AGCY_NM = fromAgcyNM,
                    BUS_AGCY_NBR = fromAgcyNbr,
                    BUS_NM = fromBusNM,
                    BUS_CSHR_ACCT = fromBusAcct,
                    BUS_CSHR_FUL_NM = fromCashierNM,
                    BUS_CSHR_USR_NBR = fromCashierNbr,
                    BUS_AGCY_CITY_NM = fromAgcyCityNM,
                    CLT_FUL_NM = cltNM,
                    VIEW_CSHR_NM_IND=true,
                    TRANS_AMT = transAmtTxt,
                    CRCY_XCHG_RT_IND = crcyXchgRtIND,
                    CRCY_XCHG_RT = crcyXchgRtTXT,
                    CLT_TRANS_AMT = amtToReceiveTXT
                    }
    
            };
            return (DetailTransaction);
        }

        //***  API***** Transaction : Retrait  *********
        [ResponseType(typeof(RETRAIT_DETAIL))]
        public List<MyEntities.RETRAIT_DETAIL> GetDatailsAmountPhone(decimal montant, string numPhone, string currentUserId)
        {
            var model = new AccountWithdrawalConfirmationViewModel();
            var userList = db.TUSR.Where(x => x.PHN1_NBR == numPhone).ToList();
            var user1 = userList[0];
            var cardList = db.TCARD.Where(x => x.USR_NBR == user1.USR_NBR).ToList();
            var card = cardList[0];

            //currentUserId est le USR_NBR de lagent en cours
            var userNbrList = db.TUSR.Where(x => x.USR_NBR == currentUserId).ToList();
            var IdCurrentAgent = userNbrList[0].Id;
            //IdCurrentAgent est Id de lagent en cours

            //string transAmt = Convert.ToString(TempData["TRANS_AMT"]);
            string transAmt = Convert.ToString(montant);

            if (string.IsNullOrWhiteSpace(transAmt))
            { throw new Exception(); }

            // model.TRANS_AMT = Convert.ToDecimal(TempData["TRANS_AMT"]);
            model.TRANS_AMT = Convert.ToDecimal(montant);
            // model.CARD_NBR = Convert.ToString(TempData["CARD_NBR"]);
            //model.CARD_NBR = Convert.ToString(cardNumber);
            // model.PROMO_CODE = Convert.ToString(TempData["PROMO_CODE"]);
            model.PROMO_CODE = Convert.ToString(6);

            var businessModel = BusinessUserData(IdCurrentAgent);
            var clientModel = ClientData(card.CARD_NBR, null, "withdrawal");
            if (businessModel == null || clientModel == null)
            { throw new Exception(); }

            model.BUS_CTRY_CD = businessModel.BUS_CTRY_CD;
            model.BUS_ACCT_ID = businessModel.BUS_ACCT_ID;
            model.BUS_CRCY_CD = businessModel.BUS_CRCY_CD;
            model.BUS_USR_NBR = businessModel.BUS_USR_NBR;
            model.BN = businessModel.BN;
            model.BUS_SHORT_NM = businessModel.BUS_SHORT_NM.ToUpper();
            model.MANAGER_ACCT_ID = businessModel.MANAGER_ACCT_ID;
            string BUS_ACCT_CLTR_INFO = businessModel.BUS_ACCT_CLTR_INFO; 

            model.CLT_CTRY_CD = clientModel.CLT_CTRY_CD;
            model.CLT_ACCT_ID = clientModel.CLT_ACCT_ID;
            model.CLT_CRCY_CD = clientModel.CLT_CRCY_CD;
            model.CLT_FUL_NM = clientModel.CLT_FUL_NM;
            model.CLT_USR_NBR = clientModel.CLT_USR_NBR;
            model.CLT_USR_ID = clientModel.CLT_USR_ID;
            string CLT_ACCT_CLTR_INFO = clientModel.CLT_ACCT_CLTR_INFO;

            model.FROM_SERV_CTRY_ID = 6; //6 = PayKap Account
            model.TO_SERV_CTRY_ID = 2; //2 = Cash Pickup

            if (model.BUS_CTRY_CD != model.CLT_CTRY_CD)
            {
                // ViewBag.ERROR = Resources.Resources.z3PKPBController9_;     //"Votre pays est different de celui du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            //convert when different currencies
            if (model.BUS_CRCY_CD != model.CLT_CRCY_CD)
            {
                // ViewBag.ERROR = Resources.Resources.z3PKPBController10_;        //"Votre devise est differente de celle du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            model.CRCY_XCHG_RT_IND = false;
            model.CRCY_XCHG_RT_TXT = "";
            model.CRCY_XCHG_RT = 0.0m;
            model.AMT_TO_PAY = model.TRANS_AMT;
            model.AMT_TO_RECEIVE = model.TRANS_AMT;

            //get the business commission
            string srvcTCD = "06"; //withdrawal deposit
            string BUS_CMSN_SCD = "06"; // withdrawal deposit
                                        //get the business commission
            decimal busFeeAmt = busCtryFee.getBusinessFeeAmount(model.AMT_TO_RECEIVE, model.BUS_CTRY_CD, model.BUS_CRCY_CD, srvcTCD);
            if (busFeeAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }
            model.TRANS_FEE_AMT = busFeeAmt;
            model.FEE_AMT = busFeeAmt;
            string BUS_OFR_SRVC_TO_OWN_CLT_IND = "0";
            decimal busCnsmAmt = busCmsn.getBusinessCommissionAmount(model.TRANS_AMT, model.BN, model.BUS_CTRY_CD, model.BUS_CRCY_CD, BUS_CMSN_SCD, model.TRANS_FEE_AMT, BUS_OFR_SRVC_TO_OWN_CLT_IND);
            if (busCnsmAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }

            model.BUS_CMSN_AMT = busCnsmAmt;

            //check if the card owner has withdrawal credit
            model.UPDATE_CLT_CRDT_IND = false;
            model.REMAINING_CRDT_NBR = 0;
            var getCardOwnerCredit = userWithCredit.getWithdrawalCreditByUsrNbr(model.CLT_USR_NBR);
            if (getCardOwnerCredit != null)
            {
                if (getCardOwnerCredit.USR_WHDRL_CRDT_NBR > 0)
                {
                    model.FEE_AMT = 0.0m;
                    int newBalCredit = getCardOwnerCredit.USR_WHDRL_CRDT_NBR - 1;
                    model.UPDATE_CLT_CRDT_IND = true;
                    model.REMAINING_CRDT_NBR = newBalCredit;
                }
            }

            if (model.FEE_AMT != 0.0m && !string.IsNullOrWhiteSpace(model.PROMO_CODE))
            {
                model.FEE_AMT = model.FEE_AMT - 1000.0m;
                if (model.FEE_AMT < 0.0m)
                {
                    model.FEE_AMT = 0.0m;
                }
            }

            model.TOT_AMT_TO_PAY = model.AMT_TO_PAY + model.FEE_AMT;
            //check the card owner balance
            decimal cardOwnerNewBal = acct.debitTransaction(model.CLT_ACCT_ID, model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD);
            if (cardOwnerNewBal == -1.0m)
            { throw new Exception(); }

            if (cardOwnerNewBal == -2.0m)
            {
                decimal negativeBal = acct.getNegativeDifferenceBalanceForTransaction(model.CLT_ACCT_ID, model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD);
                // ViewBag.NEGATIVE_BAL_IND = "true";
                // ViewBag.NEGATIVE_BAL_TXT = Resources.Resources.z3PKPBController33_ + CommonLibrary.displayFormattedCurrency(negativeBal, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);        //"Montant manquant : "
                // ViewBag.ERROR = Resources.Resources.z3PKPBController34_;        //"Le compte PayKap du client n'a pas suffisamment d'argent pour complèter cette transaction."
                throw new Exception();
            }

            model.AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController14_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_PAY, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant : "
            model.FEE_AMT_TXT = Resources.Resources.z3PKPBController15_ + CommonLibrary.displayFormattedCurrency(model.FEE_AMT, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);     //"Frais : "
            model.TOT_AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController16_ + CommonLibrary.displayFormattedCurrency(model.TOT_AMT_TO_PAY, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant à prélever : "
            model.AMT_TO_RECEIVE_TXT = Resources.Resources.z3PKPBController17_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_RECEIVE, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);       //"Montant à recevoir : "
                                                                                                                                                                                            //****************************
                                                                                                                                                                                            // DataModel DBContext = new DataModel();
            var getDetailFeeAmt = (DBContext.RetraitDetails2(montant, numPhone)).ToList();
            var CLT_USR_NBR = getDetailFeeAmt[0].CLT_USR_NBR;
            string CLT_FUL_NM = getDetailFeeAmt[0].CLT_FUL_NM;
            decimal FROM_FEE_AMT = getDetailFeeAmt[0].FEE_AMT ?? 0;
            decimal FROM_TOT_AMT = getDetailFeeAmt[0].TOT_AMT_TO_PAY ?? 0;
            decimal TO_TRANS_AMT = getDetailFeeAmt[0].AMT_TO_RECEIVE ?? 0;

            List<MyEntities.RETRAIT_DETAIL> DetailTransaction = new List<MyEntities.RETRAIT_DETAIL>
                {
            new MyEntities.RETRAIT_DETAIL{
            CLT_USR_NBR = "transSCD",
            CLT_FUL_NM = model.CLT_FUL_NM,
            FEE_AMT = model.FEE_AMT_TXT,
            TOT_AMT_TO_PAY = model.TOT_AMT_TO_PAY_TXT,
            AMT_TO_RECEIVE = model.AMT_TO_RECEIVE_TXT
            }

            };
                return (DetailTransaction); 
            }
        //***  FIN API***** Transaction : Retrait  *********

        [ResponseType(typeof(RETRAIT_DETAIL))]
        public List<MyEntities.RETRAIT_DETAIL> GetDatailsAmountDepositeByPhone(decimal montant, string numPhone, string currentUserId2)
        {
            var model = new AccountDepositConfirmationViewModel();
            //currentUserId est le USR_NBR de lagent en cours
            var userNbrList = db.TUSR.Where(x => x.USR_NBR == currentUserId2).ToList();
            var IdCurrentAgent = userNbrList[0].Id;
            //IdCurrentAgent est Id de lagent en cours

            var userList = db.TUSR.Where(x => x.PHN1_NBR == numPhone).ToList();
            var user1 = userList[0];
            var cardList = db.TCARD.Where(x => x.USR_NBR == user1.USR_NBR).ToList();
            var card = cardList[0];
            string transAmt = Convert.ToString(montant);
            //1= no promo code, 2 = with promo code
            /*if (string.IsNullOrWhiteSpace(transAmt) || (id != "1" && id != "2"))
            { throw new Exception(); }*/

            model.TRANS_AMT = Convert.ToDecimal(montant);
            model.CARD_NBR = Convert.ToString(card.CARD_NBR);
            model.PROMO_CODE = Convert.ToString(6);

            var businessModel = BusinessUserData(IdCurrentAgent);
            var clientModel = ClientData(model.CARD_NBR, null, "deposit");
            if (businessModel == null || clientModel == null)
            { throw new Exception(); }

            model.BUS_CTRY_CD = businessModel.BUS_CTRY_CD;
            model.BUS_ACCT_ID = businessModel.BUS_ACCT_ID;
            model.BUS_CRCY_CD = businessModel.BUS_CRCY_CD;
            model.BUS_USR_NBR = businessModel.BUS_USR_NBR;
            model.BN = businessModel.BN;
            model.BUS_SHORT_NM = businessModel.BUS_SHORT_NM.ToUpper();
            model.MANAGER_ACCT_ID = businessModel.MANAGER_ACCT_ID;
            string BUS_ACCT_CLTR_INFO = businessModel.BUS_ACCT_CLTR_INFO;

            model.CLT_CTRY_CD = clientModel.CLT_CTRY_CD;
            model.CLT_ACCT_ID = clientModel.CLT_ACCT_ID;
            model.CLT_CRCY_CD = clientModel.CLT_CRCY_CD;
            model.CLT_FUL_NM = clientModel.CLT_FUL_NM;
            model.CLT_USR_NBR = clientModel.CLT_USR_NBR;
            model.CLT_USR_ID = clientModel.CLT_USR_ID;
            string CLT_ACCT_CLTR_INFO = clientModel.CLT_ACCT_CLTR_INFO;

            model.FROM_SERV_CTRY_ID = 9; //9 = Cash from agency
            model.TO_SERV_CTRY_ID = 6; //6 = PayKap Account

            if (model.BUS_CTRY_CD != model.CLT_CTRY_CD)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController9_;     //"Votre pays est different de celui du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            //convert when different currencies
            if (model.BUS_CRCY_CD != model.CLT_CRCY_CD)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController10_;        //"Votre devise est differente de celle du client. La transaction ne peut pas être autorisée."
                throw new Exception();
            }

            model.CRCY_XCHG_RT_IND = false;
            model.CRCY_XCHG_RT_TXT = "";
            model.CRCY_XCHG_RT = 0.0m;
            model.AMT_TO_DEPOSIT = model.TRANS_AMT;
            model.FEE_AMT = 0.0m;
            model.FEE_AMT_IND = true;

            //get the business commission, 
            string srvcTCD = "06"; //account deposit (we must get the Withdraw fee to calculate the busCmsnAmt)
            string BUS_CMSN_SCD = "05"; // account deposit, the service code is 05
            decimal busFeeAmt = busCtryFee.getBusinessFeeAmount(model.TRANS_AMT, model.BUS_CTRY_CD, model.BUS_CRCY_CD, srvcTCD);
            if (busFeeAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }
            model.TRANS_FEE_AMT = busFeeAmt;
            string BUS_OFR_SRVC_TO_OWN_CLT_IND = "0";
            decimal busCnsmAmt = busCmsn.getBusinessCommissionAmount(model.TRANS_AMT, model.BN, model.BUS_CTRY_CD, model.BUS_CRCY_CD, BUS_CMSN_SCD, model.TRANS_FEE_AMT, BUS_OFR_SRVC_TO_OWN_CLT_IND);
            if (busCnsmAmt == -1.0m)
            {
                //ViewBag.ERROR = Resources.Resources.z3PKPBController12_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                throw new Exception();
            }

            model.BUS_CMSN_AMT = busCnsmAmt;
            model.AMT_TO_PAY = model.TRANS_AMT + model.FEE_AMT;

            //check if the client in business has enough money to complete the current transaction
            string checkIfCltInBusIND = checkIfCurrentUserIsClientInBusinessIndicator(IdCurrentAgent);
            if (checkIfCltInBusIND == "true")
            {
                decimal checkBal = acct.debitTransaction(model.BUS_ACCT_ID, model.AMT_TO_PAY, model.BUS_CRCY_CD);
                if (checkBal == -1.0m)
                { throw new Exception(); }

                if (checkBal == -2.0m)
                {
                    //ViewBag.ERROR = Resources.Resources.z3PKPBController13_;        //"Votre compte PayKap Affaire n'a pas suffisamment d'argent pour complèter cette transaction. Rechargez votre compte."
                    throw new Exception();
                }
            }

            model.TRANS_AMT_TXT = Resources.Resources.z3PKPBController14_ + CommonLibrary.displayFormattedCurrency(model.TRANS_AMT, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);     //"Montant : "
            model.FEE_AMT_TXT = Resources.Resources.z3PKPBController15_ + CommonLibrary.displayFormattedCurrency(model.FEE_AMT, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);     //"Frais : "
            model.AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController16_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_PAY, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);       //"Montant à payer : "
            model.AMT_TO_DEPOSIT_TXT = Resources.Resources.z3PKPBController17_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_DEPOSIT, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant à déposer : "

            List<MyEntities.RETRAIT_DETAIL> DetailTransaction = new List<MyEntities.RETRAIT_DETAIL>
                {
            new MyEntities.RETRAIT_DETAIL{
            CLT_USR_NBR = "transSCD",
            CLT_FUL_NM = model.CLT_FUL_NM,
            FEE_AMT = model.FEE_AMT_TXT,
            TOT_AMT_TO_PAY = model.AMT_TO_PAY_TXT,
            AMT_TO_RECEIVE = model.AMT_TO_DEPOSIT_TXT
            }

            };
            return (DetailTransaction);

        }

         [ResponseType(typeof(DETAIL_TRANSACTION))]
         public List<MyEntities.DETAIL_TRANSACTION> GetDepot(string id, decimal montant, string phone, string currentUserId1)
         {
             var model = new AccountDepositConfirmationViewModel();
             //currentUserId est le USR_NBR de lagent en cours
             var userNbrList = db.TUSR.Where(x => x.USR_NBR == currentUserId1).ToList();
             var IdCurrentAgent = userNbrList[0].Id;
             //IdCurrentAgent est Id de lagent en cours

             var userList = db.TUSR.Where(x => x.PHN1_NBR == phone).ToList();
             var user1 = userList[0];
             var cardList = db.TCARD.Where(x => x.USR_NBR == user1.USR_NBR).ToList();
             var card = cardList[0];
             string transAmt = Convert.ToString(montant);
             //1= no promo code, 2 = with promo code
             if (string.IsNullOrWhiteSpace(transAmt) || (id != "1" && id != "2"))
             { throw new Exception(); }

             model.TRANS_AMT = Convert.ToDecimal(montant);
             model.CARD_NBR = Convert.ToString(card.CARD_NBR);
             model.PROMO_CODE = Convert.ToString(6);

             var businessModel = BusinessUserData(IdCurrentAgent);
             var clientModel = ClientData(model.CARD_NBR, null, "deposit");
             if (businessModel == null || clientModel == null)
             { throw new Exception(); }

             model.BUS_CTRY_CD = businessModel.BUS_CTRY_CD;
             model.BUS_ACCT_ID = businessModel.BUS_ACCT_ID;
             model.BUS_CRCY_CD = businessModel.BUS_CRCY_CD;
             model.BUS_USR_NBR = businessModel.BUS_USR_NBR;
             model.BN = businessModel.BN;
             model.BUS_SHORT_NM = businessModel.BUS_SHORT_NM.ToUpper();
             model.MANAGER_ACCT_ID = businessModel.MANAGER_ACCT_ID;
             string BUS_ACCT_CLTR_INFO = businessModel.BUS_ACCT_CLTR_INFO;

             model.CLT_CTRY_CD = clientModel.CLT_CTRY_CD;
             model.CLT_ACCT_ID = clientModel.CLT_ACCT_ID;
             model.CLT_CRCY_CD = clientModel.CLT_CRCY_CD;
             model.CLT_FUL_NM = clientModel.CLT_FUL_NM;
             model.CLT_USR_NBR = clientModel.CLT_USR_NBR;
             model.CLT_USR_ID = clientModel.CLT_USR_ID;
             string CLT_ACCT_CLTR_INFO = clientModel.CLT_ACCT_CLTR_INFO;

             model.FROM_SERV_CTRY_ID = 9; //9 = Cash from agency
             model.TO_SERV_CTRY_ID = 6; //6 = PayKap Account

             if (model.BUS_CTRY_CD != model.CLT_CTRY_CD)
             {
                 //ViewBag.ERROR = Resources.Resources.z3PKPBController9_;     //"Votre pays est different de celui du client. La transaction ne peut pas être autorisée."
                 throw new Exception();
             }

             //convert when different currencies
             if (model.BUS_CRCY_CD != model.CLT_CRCY_CD)
             {
                 //ViewBag.ERROR = Resources.Resources.z3PKPBController10_;        //"Votre devise est differente de celle du client. La transaction ne peut pas être autorisée."
                 throw new Exception();
             }

             model.CRCY_XCHG_RT_IND = false;
             model.CRCY_XCHG_RT_TXT = "";
             model.CRCY_XCHG_RT = 0.0m;
             model.AMT_TO_DEPOSIT = model.TRANS_AMT;
             model.FEE_AMT = 0.0m;
             model.FEE_AMT_IND = true;

             //get the business commission, 
             string srvcTCD = "06"; //account deposit (we must get the Withdraw fee to calculate the busCmsnAmt)
             string BUS_CMSN_SCD = "05"; // account deposit, the service code is 05
             decimal busFeeAmt = busCtryFee.getBusinessFeeAmount(model.TRANS_AMT, model.BUS_CTRY_CD, model.BUS_CRCY_CD, srvcTCD);
             if (busFeeAmt == -1.0m)
             {
                 //ViewBag.ERROR = Resources.Resources.z3PKPBController11_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                 throw new Exception();
             }
             model.TRANS_FEE_AMT = busFeeAmt;
             string BUS_OFR_SRVC_TO_OWN_CLT_IND = "0";
             decimal busCnsmAmt = busCmsn.getBusinessCommissionAmount(model.TRANS_AMT, model.BN, model.BUS_CTRY_CD, model.BUS_CRCY_CD, BUS_CMSN_SCD, model.TRANS_FEE_AMT, BUS_OFR_SRVC_TO_OWN_CLT_IND);
             if (busCnsmAmt == -1.0m)
             {
                 //ViewBag.ERROR = Resources.Resources.z3PKPBController12_;        //"Il se peut que le type de transaction que vous effectuez n'est pas autorisé pour votre compagnie. Contactez vos gestionnaires si vous croyez être une erreur."
                 throw new Exception();
             }

             model.BUS_CMSN_AMT = busCnsmAmt;
             model.AMT_TO_PAY = model.TRANS_AMT + model.FEE_AMT;

             //check if the client in business has enough money to complete the current transaction
             string checkIfCltInBusIND = checkIfCurrentUserIsClientInBusinessIndicator(IdCurrentAgent);
             if (checkIfCltInBusIND == "true")
             {
                 decimal checkBal = acct.debitTransaction(model.BUS_ACCT_ID, model.AMT_TO_PAY, model.BUS_CRCY_CD);
                 if (checkBal == -1.0m)
                 { throw new Exception(); }

                 if (checkBal == -2.0m)
                 {
                     //ViewBag.ERROR = Resources.Resources.z3PKPBController13_;        //"Votre compte PayKap Affaire n'a pas suffisamment d'argent pour complèter cette transaction. Rechargez votre compte."
                     throw new Exception();
                 }
             }

             model.TRANS_AMT_TXT = Resources.Resources.z3PKPBController14_ + CommonLibrary.displayFormattedCurrency(model.TRANS_AMT, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);     //"Montant : "
             model.FEE_AMT_TXT = Resources.Resources.z3PKPBController15_ + CommonLibrary.displayFormattedCurrency(model.FEE_AMT, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);     //"Frais : "
             model.AMT_TO_PAY_TXT = Resources.Resources.z3PKPBController16_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_PAY, model.BUS_CRCY_CD, BUS_ACCT_CLTR_INFO);       //"Montant à payer : "
             model.AMT_TO_DEPOSIT_TXT = Resources.Resources.z3PKPBController17_ + CommonLibrary.displayFormattedCurrency(model.AMT_TO_DEPOSIT, model.CLT_CRCY_CD, CLT_ACCT_CLTR_INFO);       //"Montant à déposer : "

             //********************************************* création transaction depot*************

             string transTCD = "05"; //05 = deposit transaction
             string transSCD = "06"; //06 = Transaction completed
             DateTime transXDT = DateTime.Now.AddMonths(1);
             bool usedDefaultExpiryDate = true;
             int RCPT_USR_BUS_ID = 0;

             var admin = AdminUser();
             if (admin == null)
             { throw new Exception(); }

             var getRcptAdmin = db.TRCPT_USR_BUS.Where(x => x.RCPT_USR_NBR == admin.USR_NBR && x.USR_NBR == admin.USR_NBR &&
                                                                x.RCPT_USR_BUS_TCD == "0").ToList();
             if (getRcptAdmin.Count() == 0)
             { throw new Exception(); }

             var getRcptAdmin1 = getRcptAdmin[0];
             RCPT_USR_BUS_ID = getRcptAdmin1.RCPT_USR_BUS_ID;

             string TRANS_DESC = Resources.Resources.z3PKPBController18_ + model.BUS_SHORT_NM;       //"Dépôt/Deposit - "
             var newTrans = transObj.createTransaction(model.FROM_SERV_CTRY_ID, model.TO_SERV_CTRY_ID,
                                                       model.BUS_CTRY_CD, model.CLT_CTRY_CD,
                                                       model.BUS_CRCY_CD, model.CLT_CRCY_CD,
                                                       model.CRCY_XCHG_RT, model.TRANS_AMT, model.FEE_AMT,
                                                       model.AMT_TO_PAY, model.AMT_TO_DEPOSIT, transSCD,
                                                       transXDT, usedDefaultExpiryDate, model.CLT_USR_NBR,
                                                       RCPT_USR_BUS_ID, transTCD, TRANS_DESC);
             //insert business user account history

             string checkIfCltInBusIND1 = checkIfCurrentUserIsClientInBusinessIndicator(IdCurrentAgent);
             string CASHIER_OR_CLT_IN_BUS_TCD;
             decimal newBal;

             if (checkIfCltInBusIND1 == "true")
             {
                 //insert client in business account history
                 newBal = acct.debitTransaction(model.BUS_ACCT_ID, model.AMT_TO_PAY, model.BUS_CRCY_CD);
                 if (newBal == -1.0m)
                 { throw new Exception(); }

                 if (newBal == -2.0m)
                 {
                     //ViewBag.ERROR1 = Resources.Resources.z3PKPBController19_;       //"Votre compte PayKap Affaire n'a pas suffisamment d'argent pour complèter cette transaction. Rechargez votre compte."
                     throw new Exception();
                 }
                 CASHIER_OR_CLT_IN_BUS_TCD = "2"; //2 client in business
             }
             else
             {
                 //insert business user account history
                 newBal = acct.creditTransaction(model.BUS_ACCT_ID, model.AMT_TO_PAY, model.BUS_CRCY_CD);
                 if (newBal == -1.0m)
                 { throw new Exception(); }

                 CASHIER_OR_CLT_IN_BUS_TCD = "1"; // 1 cashier
             }

             string TRANS_TCD;
             string TRANS_PAY_SRC_CD = "1"; // 1 = cash
             string TRANS_SRVC_TCD = transTCD; //05- deposit
             if (checkIfCltInBusIND == "true")
             {
                 TRANS_TCD = "2"; // 2 DEBIT
             }
             else
             {
                 TRANS_TCD = "1"; // 1 CREDIT
             }
             var busHistory = acctHist.insertAccountHistory(model.BUS_ACCT_ID, TRANS_TCD, TRANS_PAY_SRC_CD, TRANS_SRVC_TCD,
                                                         newBal, model.AMT_TO_PAY, TRANS_DESC);

             //insert client account history
             decimal cltNewBal = acct.creditTransaction(model.CLT_ACCT_ID, model.AMT_TO_DEPOSIT, model.CLT_CRCY_CD);
             if (cltNewBal == -1.0m)
             { throw new Exception(); }

             string CLT_TRANS_PAY_SRC_CD = "1"; // 1 = cash
             string CLT_TRANS_SRVC_TCD = transTCD; //05 deposit
             var cltHistory = acctHist.insertAccountHistory(model.CLT_ACCT_ID, "1", CLT_TRANS_PAY_SRC_CD, CLT_TRANS_SRVC_TCD,
                                                         cltNewBal, model.AMT_TO_DEPOSIT, TRANS_DESC);

             int TRANS_ID = 0;
             var getBusCmsnTrans = busCmsnTrans.insertBusinessCommissionTransaction(TRANS_ID, model.BUS_CMSN_AMT,
                                                     model.BUS_CRCY_CD, model.BUS_USR_NBR, transTCD);
             if (getBusCmsnTrans == null)
             { throw new Exception(); }

             string insertBusAcctHistIND = "0"; // 0 = not insert business account history

             //CHECK DUPLICATE TRANSACTION
             bool checkDuplication = CommonLibrary.duplicatedTransactionAgencyOnlineIndicator(db,
                                                     newTrans.FROM_USR_NBR,
                                                     newTrans.FROM_TRSF_SERV_ID, newTrans.TO_TRSF_SERV_ID,
                                                     newTrans.RCPT_USR_BUS_ID, newTrans.TRANS_SCD,
                                                     model.BUS_USR_NBR);
             if (!checkDuplication)
             {
                 var retVal = DAL.depositTransaction(db, newTrans.FROM_TRSF_SERV_ID, newTrans.TO_TRSF_SERV_ID,
                                    newTrans.FROM_CTRY_CD, newTrans.TO_CTRY_CD, newTrans.FROM_CRCY_CD, newTrans.TO_CRCY_CD,
                                    newTrans.CRCY_XCHG_RT, newTrans.FROM_TRANS_AMT, newTrans.FROM_FEE_AMT,
                                    newTrans.FROM_TOT_AMT, newTrans.TO_TRANS_AMT, newTrans.TRANS_SCD,
                                    newTrans.TRANS_CDT, newTrans.TRANS_PAID_DPST_DT, newTrans.TRANS_XDT,
                                    newTrans.FROM_USR_NBR, newTrans.RCPT_USR_BUS_ID, newTrans.TRANS_TRSF_CRDT_DBT_TCD, newTrans.TRANS_DESC,
                                    insertBusAcctHistIND,
                                    busHistory.ACCT_ID, busHistory.TRANS_TCD, busHistory.TRANS_PAY_SRC_CD, busHistory.TRANS_SRVC_TCD,
                                    busHistory.BAL_AFTR_TRANS, busHistory.TRANS_AMT, busHistory.TRANS_DTTM, busHistory.TRANS_DESC,
                                    cltHistory.ACCT_ID, cltHistory.TRANS_TCD, cltHistory.TRANS_PAY_SRC_CD, cltHistory.TRANS_SRVC_TCD,
                                    cltHistory.BAL_AFTR_TRANS, cltHistory.TRANS_AMT, cltHistory.TRANS_DTTM, cltHistory.TRANS_DESC,
                                    getBusCmsnTrans.BUS_CMSN_AMT, getBusCmsnTrans.CRCY_CD, getBusCmsnTrans.BUS_USR_NBR,
                                    model.MANAGER_ACCT_ID, CASHIER_OR_CLT_IN_BUS_TCD);
             }
             else
             {
                // ViewBag.ERROR1 = CommonLibrary.displayAlreadyMakeTransactionErrorMessage();
                 throw new Exception();
             }

             var lastTransList = db.TTRANS_TRSF_CRDT_DBT.Where(x => x.FROM_USR_NBR == newTrans.FROM_USR_NBR &&
                                                                        x.FROM_TRSF_SERV_ID == newTrans.FROM_TRSF_SERV_ID &&
                                                                        x.TO_TRSF_SERV_ID == newTrans.TO_TRSF_SERV_ID &&
                                                                        x.RCPT_USR_BUS_ID == newTrans.RCPT_USR_BUS_ID &&
                                                                        x.TRANS_SCD == newTrans.TRANS_SCD)
                                                                        .OrderByDescending(y => y.TRANS_CDT).ToList();
             if (lastTransList.Count() != 0)
             {
                 var lastTrans = lastTransList[0];
                 string TRANS_NBR = Convert.ToString(lastTrans.TRANS_ID);

                 string TRANS_DATE = newTrans.TRANS_CDT.ToString("dd/MM/yyyy");
                 sendTransactionTranscript(model.CLT_USR_ID, cltHistory.TRANS_DESC, model.AMT_TO_DEPOSIT_TXT,
                                                 TRANS_DATE, TRANS_NBR, "FRA");

                 string SRVC_TCD = "05";// 05 = account deposit
                 agnt.insertBusinessAgentCommission(UserManager, DAL, model.TRANS_FEE_AMT,
                                                    model.BUS_CTRY_CD, model.BUS_CRCY_CD, SRVC_TCD, model.BN,
                                                    TRANS_NBR, model.CLT_USR_NBR, model.CLT_FUL_NM);

                 //if it is not the first transaction, insert the agent commission transaction // else insert the sponsored to agntSpnsrd table
                 SRVC_TCD = "01"; // deposit trans but need transfer code 01 to insert agent cmsn
                 agnt.insertAgentCommission(UserManager, DAL, model.PROMO_CODE, model.FEE_AMT, model.BUS_CTRY_CD,
                                            model.BUS_CRCY_CD, model.CLT_USR_NBR, model.CLT_FUL_NM, TRANS_NBR, SRVC_TCD);
                // return RedirectToAction("TransactionDetails", new { id = TRANS_NBR });
             }

             var lastTrans1 = lastTransList[0];
             string TRANS_NBR1 = Convert.ToString(lastTrans1.TRANS_ID);
             //**************** Detail debtransaction *******************
             var tUser = CurrentUserByUserId(IdCurrentAgent);    //get the Tuser here
             if (string.IsNullOrWhiteSpace(TRANS_NBR1) || tUser == null)
             { throw new Exception(); }
             int transID1 = Convert.ToInt32(TRANS_NBR1);
             string userId = tUser.Id.TrimEnd();
             var getTrans = transObj.getTransactionByTransID(transID1);
             var newCmsnTransList = db.TBUS_CMSN_TRANS.Where(x => x.TRANS_ID == transID1).ToList();    //get the business commission transaction
             if (getTrans == null || newCmsnTransList.Count() == 0)
             { throw new Exception(); }
             var newCmsnTrans = newCmsnTransList[0];

             bool displayCashierNmIND = true;

             string transSCD1 = "";
             if (getTrans.TRANS_SCD == "01")
             {
                 transSCD1 = Resources.Resources.z3PKPBController55_;     //"Attente de paiement"
             }
             else if (getTrans.TRANS_SCD == "02" || getTrans.TRANS_SCD == "03")
             {
                 transSCD1 = Resources.Resources.z3PKPBController56_;     //"Attente de validation"
             }
             else if (getTrans.TRANS_SCD == "04")
             {
                 transSCD1 = Resources.Resources.z3PKPBController57_;     //"Transaction bloquée"
             }
             else if (getTrans.TRANS_SCD == "05")
             {
                 transSCD1 = Resources.Resources.z3PKPBController58_;     //"Transaction expirée"
             }
             else if (getTrans.TRANS_SCD == "06")
             {
                 transSCD1 = Resources.Resources.z3PKPBController59_;     //"Transaction complétée"
             }

             string transDESC;
             string labelToAmount = Resources.Resources.z3PKPBController60_;     //"Montant"
             if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01")
             {
                 transDESC = Resources.Resources.z3PKPBController61_;        //"Virement d'argent"
             }
             else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "02" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "03")
             {
                 transDESC = Resources.Resources.z3PKPBController62_;        //"Paiement de facture"
             }
             else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "04")
             {
                 transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
             }
             else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
             {
                 transDESC = Resources.Resources.z3PKPBController64_;        //"Dépôt Espèces"
                 labelToAmount = Resources.Resources.z3PKPBController65_;        //"Montant déposé"
             }
             else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
             {
                 transDESC = Resources.Resources.z3PKPBController66_;        //Retrait d'espèces
                 labelToAmount = Resources.Resources.z3PKPBController67_;        //"Montant retiré"
             }
             else
             {
                 transDESC = Resources.Resources.z3PKPBController63_;        //"Paiement"
             }

             var getBusUsr = busUsr.getBusinessUserByID(newCmsnTrans.BUS_USR_NBR);
             var getClient = usr.getUserByUsrNbr(getTrans.FROM_USR_NBR);
             if (getBusUsr == null || getClient == null)
             { throw new Exception(); }

             var getBus = bus.getBusinessByBN(getBusUsr.BN);
             var getBusAgcy = busAgcy.getOneBusinessAgencyByAgcyNbr(getBusUsr.BN, getBusUsr.BUS_AGCY_NBR);
             var getBusAcct = acct.getAccountByAcctID(getBusUsr.BUS_ACCT_ID);
             var getCashier = usr.getUserByUsrNbr(getBusUsr.BUS_EMPE_USR_NBR);
             var getAgcyKtct = ktct.getContactByKtctID(getBusAgcy.BUS_AGCY_KTCT_ID);
             string ACCT_TCD = "1";
             if (getClient.USR_TCD != "2")
             {
                 ACCT_TCD = "2";
             }
             var getCltAcct = acct.getAccountByUsrNbr(getClient.USR_NBR, ACCT_TCD);
             if (getAgcyKtct == null || getCashier == null || getBus == null || getBusAgcy == null || getBusAcct == null || getCltAcct == null)
             { throw new Exception(); }

             string fromAgcyNM = getBusAgcy.BUS_AGCY_NM;
             string fromAgcyNbr = getBusAgcy.BUS_AGCY_NBR;
             string fromBusNM = getBus.BUS_NM;
             string fromBusAcct = acct.formatAccountNumber(getBusAcct.ACCT_NBR, "3");  // 3 = cashier // 4 = agence   5 = Company;
             string fromCashierNM = getCashier.USR_FUL_NM;
             string fromCashierNbr = getCashier.USR_NBR;
             string fromAgcyCityNM = getAgcyKtct.CITY_NM;

             string cltNM = getClient.USR_FUL_NM;
             string transDT = getTrans.TRANS_CDT.ToString("dd/MM/yyyy");
             string fromCultureInfo = getBusAcct.ACCT_CLTR_INFO;
             string toCultureInfo = getCltAcct.ACCT_CLTR_INFO;
             string transAmtTxt = "";

             if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
             {
                 transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, fromCultureInfo);
             }
             else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
             {
                 transAmtTxt = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, fromCultureInfo);
             }

             bool crcyXchgRtIND = false;
             string crcyXchgRtTXT = "";
             string amtToReceiveTXT = "";
             if (getTrans.CRCY_XCHG_RT != 0.0m)
             {
                 crcyXchgRtIND = true;
                 decimal fromXchgRt = 1.0m;
                 if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "01" || getTrans.TRANS_TRSF_CRDT_DBT_TCD == "05")
                 {
                     string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.TO_CRCY_CD);
                     crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.FROM_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.TO_CRCY_CD;
                     amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.FROM_TOT_AMT, getTrans.FROM_CRCY_CD, toCultureInfo);
                 }
                 else if (getTrans.TRANS_TRSF_CRDT_DBT_TCD == "06")
                 {
                     string formatString = CommonLibrary.getExchangeRateDecimalPartByCurrencyCD(getTrans.FROM_CRCY_CD);
                     crcyXchgRtTXT = fromXchgRt.ToString("N2") + " " + getTrans.TO_CRCY_CD + " = " + getTrans.CRCY_XCHG_RT.ToString(formatString) + " " + getTrans.FROM_CRCY_CD;
                     amtToReceiveTXT = CommonLibrary.displayFormattedCurrency(getTrans.TO_TRANS_AMT, getTrans.TO_CRCY_CD, toCultureInfo);
                 }
             }


             //DataModel DBContext = new DataModel();

             List<MyEntities.DETAIL_TRANSACTION> DetailTransaction = new List<MyEntities.DETAIL_TRANSACTION>
                 {
             new MyEntities.DETAIL_TRANSACTION{
                 TRANS_SCD = transSCD1,
                 TRANS_DESC=transDESC,
                 BUS_AGCY_NM = fromAgcyNM,
                 BUS_AGCY_NBR = fromAgcyNbr,
                 BUS_NM = fromBusNM,
                 BUS_CSHR_ACCT = fromBusAcct,
                 BUS_CSHR_FUL_NM = fromCashierNM,
                 BUS_CSHR_USR_NBR = fromCashierNbr,
                 BUS_AGCY_CITY_NM = fromAgcyCityNM,
                 CLT_FUL_NM = cltNM,
                 VIEW_CSHR_NM_IND=true,
                 TRANS_AMT = transAmtTxt,
                 CRCY_XCHG_RT_IND = crcyXchgRtIND,
                 CRCY_XCHG_RT = crcyXchgRtTXT,
                 CLT_TRANS_AMT = amtToReceiveTXT
                 }

         };            
             return (DetailTransaction);

         } 

        //**************** Fonctions utiles
        public string checkIfCurrentUserIsClientInBusinessIndicator(string currenUserId)
        {
            var user = CurrentUserByUserId(currenUserId);
            if (user != null)
            {
                string userTCD = user.USR_TCD;
                if (userTCD == "2")
                {
                    //var cltInBusiness = cltInBus.getClientInBusinessByUsrNbr(user.USR_NBR);
                    //if (cltInBusiness != null)
                    //{
                    //    return "true";
                    //}
                    return "false";
                }
            }
            return null;
        }

        public User AdminUser()
        {
           // var user = UserManager.FindByEmail(CommonLibrary.getAdminEmail());
            var user = db.TUSR.Where(x => x.Id == "8EA92390-5C0A-48C9-9011-6202AB83C582").ToList();
            if (user == null)
            {
                return null;
            }
            string userId = "8EA92390-5C0A-48C9-9011-6202AB83C582";  
            //string userId = user.Id;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }
            var userList = db.TUSR.Where(x => x.Id == userId).ToList();
            if (userList.Count() == 0)
            {
                return null;
            }
            else
            {
                var user1 = userList[0];
                if (user1 == null)
                {
                    return null;
                }
                return user1;
            }
        }

        public void AccountDepositPhonePOST(string PHN_NBR, string ctryCD, decimal TRANS_AMT)
        {
            PHN_NBR = CommonLibrary.replaceWhiteSpace(PHN_NBR);
            var getCardNbr = userPhoneLogin.getCardByPhnNbr(PHN_NBR);
            if (getCardNbr == null || TRANS_AMT < 1.0m)
            {
                if (getCardNbr == null)
                {
                  //  ViewBag.PHN_NBR_ERROR = Resources.Resources.z3PKPBController6_;     //"Le numéro de téléphone PayKap n'est pas valide."
                }
                throw new Exception();
            }

            TempData["TRANS_AMT"] = TRANS_AMT;
            TempData["CARD_NBR"] = getCardNbr.CARD_NBR;
        }

        /*public BusinessUser businessUser(string USR_NBR, string userId)
        {
             string busUsrTCD = null;
             if (UserManager.IsInRole(userId, "Cashier"))
             { //userId
                 busUsrTCD = "02";
             }
             else if (UserManager.IsInRole(userId, "BusinessDirector"))
             {
                 busUsrTCD = "03";
             }
             else if (UserManager.IsInRole(userId, "BusinessManager"))
             {
                 busUsrTCD = "04";
             }
            
            if (string.IsNullOrWhiteSpace(busUsrTCD))
            {
                return null;
            }

            var busUser = busUsr.getBusinessUserByUsrNbr(USR_NBR);
            if (busUser == null)
            {
                return null;
            }
            return busUser;
        } */
        
        public Card CardOwnerByCardNbr(string cardNbr)
        {
            //var cardNbrHash = Encryption.EncryptAes(cardNbr); CarNbr.ToString().Trim()
            var cardNbrHash = cardNbr;
            var CardList = db.TCARD.Where(x => x.CARD_NBR == cardNbrHash).ToList();
              //var CardList = db.TCARD.Where(x => x.CARD_NBR == "lESgR/ETWjUeC+d5j9TTOgrxjAVNZcfPXHmiSpnv8OKKVJBEYHV8m83xa47y7Eyy").ToList();
            //var CardList = db.TCARD.Where(x => x.CARD_NBR == "YluZJ/ESbQcGPdqljSlwKAnc+R7prqqsC7NyFT9cUmiGtKZ5TwdfN4fSlxt1dXI8").ToList();
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

        public Account AccountCardOwnerByCardNbr(string cardNbr)
        {
            var cardOwner = CardOwnerByCardNbr(cardNbr);
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

        public ClientDataModel ClientData(string CARD_NBR, string ACCT_NBR, string TRANS_CD)
        {
            var model = new ClientDataModel();
            if (TRANS_CD == "deposit" || TRANS_CD == "withdrawal")
            {
                var cardOwner = CardOwnerByCardNbr(CARD_NBR);
                var acctOwner = AccountCardOwnerByCardNbr(CARD_NBR);
                if (acctOwner == null || cardOwner == null)
                {
                    return null;
                }

                var cltUser = usr.getUserByUsrNbr(cardOwner.USR_NBR);
                if (cltUser == null)
                {
                    return null;
                }

                string CLT_ACCT_NBR = acctOwner.ACCT_NBR;
                if (CLT_ACCT_NBR.Length < 17)
                {
                    model.CLT_CTRY_CD = acctOwner.ACCT_NBR.Substring(0, 3);
                }
                else
                {
                    model.CLT_CTRY_CD = acctOwner.ACCT_NBR.Substring(9, 3);
                }
                model.CLT_ACCT_ID = acctOwner.ACCT_ID;
                model.CLT_CRCY_CD = acctOwner.CRCY_CD;
                model.CLT_FUL_NM = cardOwner.CARD_OWNR_FNM.ToUpper();
                model.CLT_USR_NBR = acctOwner.USR_NBR;
                model.CLT_USR_ID = cltUser.Id.TrimEnd();
                model.CLT_ACCT_CLTR_INFO = acctOwner.ACCT_CLTR_INFO;
                return model;
            }
            else if (TRANS_CD == "thirdpartydeposit")
            {
                var CltUsrAcct = acct.getAccountByAcctNbr(ACCT_NBR, "1");
                if (CltUsrAcct == null)
                {
                    return null;
                }

                var senderCardOwner = CardOwnerByCardNbr(CARD_NBR);
                var cltUser = usr.getUserByUsrNbr(CltUsrAcct.USR_NBR);
                if (cltUser == null || cltUser == null)
                {
                    return null;
                }

                model.CLT_CTRY_CD = CltUsrAcct.ACCT_NBR.Substring(0, 3);
                model.CLT_ACCT_ID = CltUsrAcct.ACCT_ID;
                model.CLT_CRCY_CD = CltUsrAcct.CRCY_CD;
                model.CLT_FUL_NM = cltUser.USR_FUL_NM.ToUpper();
                model.CLT_FUL_NM_DSPLY = "Destinataire : " + cltUser.USR_FUL_NM.ToUpper();
                model.CLT_USR_NBR = CltUsrAcct.USR_NBR;
                model.CLT_USR_ID = cltUser.Id.TrimEnd();
                model.CLT_ACCT_CLTR_INFO = CltUsrAcct.ACCT_CLTR_INFO;

                model.CARD_OWNR_FUL_NM = senderCardOwner.CARD_OWNR_FNM.ToUpper();
                model.CARD_OWNR_FUL_NM_DSPLY = Resources.Resources.z3PKPBController84_ + model.CARD_OWNR_FUL_NM;        //"Déposant : "
                model.CARD_USR_NBR = senderCardOwner.USR_NBR;
                return model;
            }
            else
            {
                return null;
            }
        }
       /* public User CurrentUserByUserId(string currenUserId)
        {
            //var userId = User.Identity.GetUserId().Trim();
            var userId = currenUserId;
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }
            var userList = db.TUSR.Where(x => x.Id == userId).ToList();
            if (userList.Count() == 0)
            {
                return null;
            }
            else
            {
                var user = userList[0];
                if (user == null)
                {
                    return null;
                }
                return user;
            }
        } */

        public BusinessUser BusinessUser(string USR_NBR, string UserId)
        {
            int retVal = DAL.testIsInRole(db, UserId);
            string result = Convert.ToString(retVal);

            string busUsrTCD = null;
            if (result=="1")
            {
                busUsrTCD = "02";
            }
            else if (result == "2")
            {
                busUsrTCD = "03";
            }
            else if (result == "3")
            {
                busUsrTCD = "04";
            }
            else if (result == "4")
            {
                busUsrTCD = null;
            }
            /*if (UserManager.IsInRole(UserId, "Cashier"))
            {
                busUsrTCD = "02";
            }
            else if (UserManager.IsInRole(UserId, "BusinessDirector"))
            {
                busUsrTCD = "03";
            }
            else if (UserManager.IsInRole(UserId, "BusinessManager"))
            {
                busUsrTCD = "04";
            }*/

            if (string.IsNullOrWhiteSpace(busUsrTCD))
            {
                return null;
            }

            var busUser = busUsr.getBusinessUserByUsrNbr(USR_NBR);
            if (busUser == null)
            {
                return null;
            }
            return busUser;
        }

        public BusinessUserDataModel BusinessUserData(string currentUserId)
        {
             var tUser = CurrentUserByUserId(currentUserId);
             if (tUser == null)
             {
                 return null;
             }
            //string userId = tUser.Id.TrimEnd(); userId
            string userId = currentUserId;

            var model = new BusinessUserDataModel();
            var busUser = BusinessUser(tUser.USR_NBR, userId);
            if (busUser == null)
            {
                return null;
            }

            var acctBusCashier = acct.getAccountByAcctID(busUser.BUS_ACCT_ID);
            var getBus = bus.getBusinessByBN(busUser.BN);
            if (acctBusCashier == null || getBus == null)
            {
                return null;
            }

            model.BUS_CTRY_CD = acctBusCashier.ACCT_NBR.Substring(9, 3);
            model.BUS_ACCT_ID = acctBusCashier.ACCT_ID;
            model.BUS_CRCY_CD = acctBusCashier.CRCY_CD;
            model.BUS_USR_NBR = busUser.BUS_USR_NBR;
            model.BN = busUser.BN;
            model.MANAGER_ACCT_ID = getBus.ACCT_ID;
            model.BUS_SHORT_NM = getBus.BUS_SHORT_NM;

            model.BUS_ACCT_CLTR_INFO = acctBusCashier.ACCT_CLTR_INFO;
            return model;
        }

       /* public BusinessUserDataModel businessUserData(string currentUserId, string USR_NBR)
        {
            var tUser = CurrentUserByUserId(currentUserId);
            if (tUser == null)
            {
                return null;
            }
            // string userId = tUser.Id.TrimEnd();
            string userId = currentUserId;

            var model = new BusinessUserDataModel();
            var busUser = businessUser(USR_NBR, userId);
            if (busUser == null)
            {
                return null;
            }

            var acctBusCashier = acct.getAccountByAcctID(busUser.BUS_ACCT_ID);
            var getBus = bus.getBusinessByBN(busUser.BN);
            if (acctBusCashier == null || getBus == null)
            {
                return null;
            }

            model.BUS_CTRY_CD = acctBusCashier.ACCT_NBR.Substring(9, 3);
            model.BUS_ACCT_ID = acctBusCashier.ACCT_ID;
            model.BUS_CRCY_CD = acctBusCashier.CRCY_CD;
            model.BUS_USR_NBR = busUser.BUS_USR_NBR;
            model.BN = busUser.BN;
            model.MANAGER_ACCT_ID = getBus.ACCT_ID;
            model.BUS_SHORT_NM = getBus.BUS_SHORT_NM;

            model.BUS_ACCT_CLTR_INFO = acctBusCashier.ACCT_CLTR_INFO;
            return model;
        }*/


        //**************** Fonctions utiles  retrait transaction
        public bool sendTransactionTranscript(string userID, string TRANS_DESC, string TRANS_AMT,
                                            string TRANS_DATE, string TRANS_NBR, string lang)
        {
            string subject = Resources.Resources.z3PKPBController49_;       //"Votre reçu de transaction - Your transaction receipt"
            var body = SendEmail.PopulateBodyTransactionTranscript(TRANS_DESC, TRANS_AMT, TRANS_DATE, TRANS_NBR, lang);
            UserManager.SendEmail(userID, subject, body);
            return true;
        }
        public User CurrentUserByUserId(string  currentUserId)
        {
            //var userId = User.Identity.GetUserId().Trim();
            var userId = currentUserId;
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }
            var userList = db.TUSR.Where(x => x.Id == userId).ToList();
            if (userList.Count() == 0)
            {
                return null;
            }
            else
            {
                var user = userList[0];
                if (user == null)
                {
                    return null;
                }
                return user;
            }
        }
        /*public string checkIfCurrentUserIsClientInBusinessIndicator(string currentUserId)
        {
            var user = CurrentUserByUserId(currentUserId);
            if (user != null)
            {
                string userTCD = user.USR_TCD;
                if (userTCD == "2")
                {
                    return "false";
                }
            }
            return null;
        } */

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

      
    }
}
