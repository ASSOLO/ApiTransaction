using pkpApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiPaykapTransaction.Models.DAL;

namespace ApiPaykapTransaction.Models
{
    public class DalFunction
    {
        public async Task<int> createIndividualUser(DalContext db, string userID, string usrNbr, string userTCD, string userSCD,
                                        string fnm, string lnm, string gender, DateTime? bday, string langCD,
                                        string investor, string verify, DateTime mbrshipDate,
                                        string defaultPwdIND, string defaultEmailIND, string emailVerifIND, DateTime emailVerifDT,
                                        string adr1, string adr2, string phn1, string phn2, string email1, string email2, 
                                        string website, string ktctCD, string cityNm, string ctryCD,
                                        string acctTCD, string crcyCD, string acctSCD,
                                        string acctNbr, string acctNM, decimal acctBAL, 
                                        string acctCulInfo, DateTime acctCDT,
                                        string fcardFulname, string cardNBR, string cardCvvCD, 
                                        string cardPIN, DateTime cardEDT, DateTime cardXDT,
                                        string cardTCD, string cardSCD, string cardCTRY, DateTime cardCDT,
                                        string defaultPinIND)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = await db.Database.ExecuteSqlCommandAsync(
                "User_createIndividualUser @ReturnValue OUTPUT, @USR_ID, @USR_NBR, @USR_TCD, @USR_SCD, @USR_FNM, @USR_LNM, @USR_GNDR," +
                    "@USR_BRDAY, @USR_PREF_LCD, @USR_99P_FRC_IND, @USR_VERIF_IND, @USR_MBRSHP_EDT," +
                    "@USR_DFLT_PWD_IND, @USR_DFLT_EMAIL_IND, @USR_EMAIL_VRFT_IND, @USR_EMAIL_VRFT_DT," +
                    "@ADDR_LN1_TXT, @ADDR_LN2_TXT, @PHN1_NBR, @PHN2_NBR, @EM_ADDR1_TXT, @EM_ADDR2_TXT," +
                    "@WEBSITE_TXT, @KTCT_TCD, @CITY_NM, @CTRY_CD," +
                    "@ACCT_TCD, @CRCY_CD, @ACCT_SCD, @ACCT_NBR, @ACCT_NAME, @ACCT_BAL, @ACCT_CLTR_INFO,@ACCT_CDT," +
                    "@CARD_OWNR_FNM, @CARD_NBR, @CARD_CVV_CD, @CARD_PIN, @CARD_EDT, @CARD_XDT," +
                    "@CARD_TCD, @CARD_SCD, @CARD_CTRY_CD, @CARD_CDT, @DFLT_PIN_IND",
                    ReturnValue, new SqlParameter("@USR_ID", userID), new SqlParameter("@USR_NBR", usrNbr), 
                    new SqlParameter("@USR_TCD", userTCD), new SqlParameter("@USR_SCD", userSCD),
                    new SqlParameter("@USR_FNM", fnm), new SqlParameter("@USR_LNM", lnm), new SqlParameter("@USR_GNDR", gender),
                    new SqlParameter("@USR_BRDAY", bday), new SqlParameter("@USR_PREF_LCD", langCD), 
                    new SqlParameter("@USR_99P_FRC_IND", investor), new SqlParameter("@USR_VERIF_IND", verify), 
                    new SqlParameter("@USR_MBRSHP_EDT", mbrshipDate),
                    new SqlParameter("@USR_DFLT_PWD_IND", defaultPwdIND), new SqlParameter("@USR_DFLT_EMAIL_IND", defaultEmailIND),
                    new SqlParameter("@USR_EMAIL_VRFT_IND", emailVerifIND), new SqlParameter("@USR_EMAIL_VRFT_DT", emailVerifDT),
                    new SqlParameter("@ADDR_LN1_TXT", adr1), new SqlParameter("@ADDR_LN2_TXT", adr2), 
                    new SqlParameter("@PHN1_NBR", phn1), new SqlParameter("@PHN2_NBR", phn2),
                    new SqlParameter("@EM_ADDR1_TXT", email1), new SqlParameter("@EM_ADDR2_TXT", email2), 
                    new SqlParameter("@WEBSITE_TXT", website), new SqlParameter("@KTCT_TCD", ktctCD),
                    new SqlParameter("@CITY_NM", cityNm), new SqlParameter("@CTRY_CD", ctryCD), 
                    new SqlParameter("@ACCT_TCD", acctTCD), new SqlParameter("@CRCY_CD", crcyCD), 
                    new SqlParameter("@ACCT_SCD", acctSCD), new SqlParameter("@ACCT_NBR", acctNbr),
                    new SqlParameter("@ACCT_NAME", acctNM), new SqlParameter("@ACCT_BAL", acctBAL),
                    new SqlParameter("@ACCT_CLTR_INFO", acctCulInfo), new SqlParameter("@ACCT_CDT", acctCDT),
                    new SqlParameter("@CARD_OWNR_FNM", fcardFulname), new SqlParameter("@CARD_NBR", cardNBR),
                    new SqlParameter("@CARD_CVV_CD", cardCvvCD), new SqlParameter("@CARD_PIN", cardPIN),
                    new SqlParameter("@CARD_EDT", cardEDT), new SqlParameter("@CARD_XDT", cardXDT),
                    new SqlParameter("@CARD_TCD", cardTCD), new SqlParameter("@CARD_SCD", cardSCD),
                    new SqlParameter("@CARD_CTRY_CD", cardCTRY), new SqlParameter("@CARD_CDT", cardCDT),
                    new SqlParameter("@DFLT_PIN_IND", defaultPinIND));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int createIndividualUserEnd(DalContext db, string userID, int CARD_ID, string cardPIN)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "User_createIndividualUserEnd @ReturnValue OUTPUT, @USR_NBR, @CARD_ID, @CARD_PIN",
                    ReturnValue, new SqlParameter("@USR_NBR", userID),
                    new SqlParameter("@CARD_ID", CARD_ID),
                    new SqlParameter("@CARD_PIN", cardPIN));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int createIndividualUserRollBack(DalContext db, string userID)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "User_createIndividualUserRollBack @ReturnValue OUTPUT, @USR_ID",
                    ReturnValue, new SqlParameter("@USR_ID", userID));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int testIsInRole(DalContext db, string userID)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "User_IsInRole @ReturnValue OUTPUT, @UserId",
                    ReturnValue, new SqlParameter("@UserId", userID));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int ChangeUserPhoneNumberLogin(DalContext db, string userID, 
                                            string OLD_USR_PHN_LGN_NBR1, string NEW_USR_PHN_LGN_NBR1,
                                            string SECOND_USR_PHN_LGN_NBR_IND,
                                            string OLD_USR_PHN_LGN_NBR2, string NEW_USR_PHN_LGN_NBR2)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "User_ChangePhoneLoginNumber @ReturnValue OUTPUT, @USR_NBR," +
                "@OLD_USR_PHN_LGN_NBR1, @NEW_USR_PHN_LGN_NBR1, @SECOND_USR_PHN_LGN_NBR_IND," +
                "@OLD_USR_PHN_LGN_NBR2, @NEW_USR_PHN_LGN_NBR2",
                    ReturnValue, new SqlParameter("@USR_NBR", userID),
                    new SqlParameter("@OLD_USR_PHN_LGN_NBR1", OLD_USR_PHN_LGN_NBR1),
                    new SqlParameter("@NEW_USR_PHN_LGN_NBR1", NEW_USR_PHN_LGN_NBR1),
                    new SqlParameter("@SECOND_USR_PHN_LGN_NBR_IND", SECOND_USR_PHN_LGN_NBR_IND),
                    new SqlParameter("@OLD_USR_PHN_LGN_NBR2", OLD_USR_PHN_LGN_NBR2),
                    new SqlParameter("@NEW_USR_PHN_LGN_NBR2", NEW_USR_PHN_LGN_NBR2));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }


        public int changeCardPIN(DalContext db, int CARD_ID, string cardPIN)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Card_changeCardPIN @ReturnValue OUTPUT, @CARD_ID, @CARD_PIN",
                    ReturnValue, new SqlParameter("@CARD_ID", CARD_ID),
                    new SqlParameter("@CARD_PIN", cardPIN));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int createCard(DalContext db, string userNbr, string cardOwnername,
                                        string cardNBR, string cardCvvCD, string cardPIN, DateTime cardEDT, DateTime cardXDT,
                                        string cardTCD, string cardSCD, string cardCTRY, DateTime cardCDT)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Card_createCard @ReturnValue OUTPUT, @USR_NBR, " +
                    "@CARD_OWNR_FNM, @CARD_NBR, @CARD_CVV_CD, @CARD_PIN, @CARD_EDT, @CARD_XDT," +
                    "@CARD_TCD, @CARD_SCD, @CARD_CTRY_CD, @CARD_CDT",
                    ReturnValue, new SqlParameter("@USR_NBR", userNbr),
                    new SqlParameter("@CARD_OWNR_FNM", cardOwnername), new SqlParameter("@CARD_NBR", cardNBR),
                    new SqlParameter("@CARD_CVV_CD", cardCvvCD), new SqlParameter("@CARD_PIN", cardPIN),
                    new SqlParameter("@CARD_EDT", cardEDT), new SqlParameter("@CARD_XDT", cardXDT),
                    new SqlParameter("@CARD_TCD", cardTCD), new SqlParameter("@CARD_SCD", cardSCD),
                    new SqlParameter("@CARD_CTRY_CD", cardCTRY), new SqlParameter("@CARD_CDT", cardCDT));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int billPaymentTransaction(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT, 
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string FROM_BANK_TRANS_IND, string FROM_TO_USR_CD, 
                                        int EXRL_ACCT_ID, DateTime BNK_TRANS_DT, string EXRL_BNK_TRANS_ID,
                                        DateTime EXRL_BNK_TRANS_DT, string EXRL_BNK_TRANS_DESC,
                                        string TO_BANK_TRANS_IND, string TO_FROM_TO_USR_CD,
                                        int TO_EXRL_ACCT_ID, DateTime TO_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_ID,
                                        DateTime TO_EXRL_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_DESC,
                                        string FROM_PKP_TRANS_IND, int FROM_ACCT_ID, string TRANS_TCD,
                                        string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT,
                                        DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        string TO_PKP_TRANS_IND, int TO_ACCT_ID, string TO_TRANS_TCD,
                                        string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS , decimal to_TRANS_AMT,
                                        DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        string BILL_NBR_IND, string CLT_ACCT_NBR, string BIL_NBR, DateTime BIL_PYMT_TRANS_DT)
        {
            if(string.IsNullOrWhiteSpace(FROM_TO_USR_CD)) { FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_ID)) { EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_DESC)) { EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_FROM_TO_USR_CD)) { TO_FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_ID)) { TO_EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_DESC)) { TO_EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_TCD)) { TRANS_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_PAY_SRC_CD)) { TRANS_PAY_SRC_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_SRVC_TCD)) { TRANS_SRVC_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertBillPayment @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@FROM_BANK_TRANS_IND, @FROM_TO_USR_CD, @EXRL_ACCT_ID, @BNK_TRANS_DT,"+
                    "@EXRL_BNK_TRANS_ID, @EXRL_BNK_TRANS_DT, @EXRL_BNK_TRANS_DESC," +
                    "@TO_BANK_TRANS_IND, @TO_FROM_TO_USR_CD, @TO_EXRL_ACCT_ID, @TO_BNK_TRANS_DT," +
                    "@TO_EXRL_BNK_TRANS_ID, @TO_EXRL_BNK_TRANS_DT, @TO_EXRL_BNK_TRANS_DESC," +
                    "@FROM_PKP_TRANS_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_PKP_TRANS_IND, @TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@BILL_NBR_IND, @CLT_ACCT_NBR, @BIL_NBR, @BIL_PYMT_TRANS_DT",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC), 
                    new SqlParameter("@FROM_BANK_TRANS_IND", FROM_BANK_TRANS_IND), new SqlParameter("@FROM_TO_USR_CD", FROM_TO_USR_CD),
                    new SqlParameter("@EXRL_ACCT_ID", EXRL_ACCT_ID), new SqlParameter("@BNK_TRANS_DT", BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_ID", EXRL_BNK_TRANS_ID), new SqlParameter("@EXRL_BNK_TRANS_DT", EXRL_BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_DESC", EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@TO_BANK_TRANS_IND", TO_BANK_TRANS_IND), new SqlParameter("@TO_FROM_TO_USR_CD", TO_FROM_TO_USR_CD),
                    new SqlParameter("@TO_EXRL_ACCT_ID", TO_EXRL_ACCT_ID), new SqlParameter("@TO_BNK_TRANS_DT", TO_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_ID", TO_EXRL_BNK_TRANS_ID), new SqlParameter("@TO_EXRL_BNK_TRANS_DT", TO_EXRL_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_DESC", TO_EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@FROM_PKP_TRANS_IND", FROM_PKP_TRANS_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_PKP_TRANS_IND", TO_PKP_TRANS_IND), new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@BILL_NBR_IND", BILL_NBR_IND), new SqlParameter("@CLT_ACCT_NBR", CLT_ACCT_NBR),
                    new SqlParameter("@BIL_NBR", BIL_NBR), new SqlParameter("@BIL_PYMT_TRANS_DT", BIL_PYMT_TRANS_DT));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int billPaymentTransactionWithoutPayment(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string FROM_BANK_TRANS_IND, string FROM_TO_USR_CD,
                                        int EXRL_ACCT_ID, DateTime BNK_TRANS_DT, string EXRL_BNK_TRANS_ID,
                                        DateTime EXRL_BNK_TRANS_DT, string EXRL_BNK_TRANS_DESC,
                                        string TO_BANK_TRANS_IND, string TO_FROM_TO_USR_CD,
                                        int TO_EXRL_ACCT_ID, DateTime TO_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_ID,
                                        DateTime TO_EXRL_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_DESC,
                                        string BILL_NBR_IND, string CLT_ACCT_NBR, string BIL_NBR, DateTime BIL_PYMT_TRANS_DT,
                                        string FROM_PKP_ACCT_IND, int FROM_PKP_ACCT_ID, string FROM_TRANS_DESC,
                                        string TO_SRVC_IND, int TO_PKP_ACCT_ID, int TO_BNK_ACCT_ID, string TO_TRANS_DESC)
        {
            if (string.IsNullOrWhiteSpace(FROM_TO_USR_CD)) { FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_ID)) { EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_DESC)) { EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_FROM_TO_USR_CD)) { TO_FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_ID)) { TO_EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_DESC)) { TO_EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertBillPayment_WithoutPayment @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@FROM_BANK_TRANS_IND, @FROM_TO_USR_CD, @EXRL_ACCT_ID, @BNK_TRANS_DT," +
                    "@EXRL_BNK_TRANS_ID, @EXRL_BNK_TRANS_DT, @EXRL_BNK_TRANS_DESC," +
                    "@TO_BANK_TRANS_IND, @TO_FROM_TO_USR_CD, @TO_EXRL_ACCT_ID, @TO_BNK_TRANS_DT," +
                    "@TO_EXRL_BNK_TRANS_ID, @TO_EXRL_BNK_TRANS_DT, @TO_EXRL_BNK_TRANS_DESC," +
                    "@BILL_NBR_IND, @CLT_ACCT_NBR, @BIL_NBR, @BIL_PYMT_TRANS_DT," +
                    "@FROM_PKP_ACCT_IND, @FROM_PKP_ACCT_ID, @FROM_TRANS_DESC, @TO_SRVC_IND, @TO_PKP_ACCT_ID, @TO_BNK_ACCT_ID, @TO_TRANS_DESC",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@FROM_BANK_TRANS_IND", FROM_BANK_TRANS_IND), new SqlParameter("@FROM_TO_USR_CD", FROM_TO_USR_CD),
                    new SqlParameter("@EXRL_ACCT_ID", EXRL_ACCT_ID), new SqlParameter("@BNK_TRANS_DT", BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_ID", EXRL_BNK_TRANS_ID), new SqlParameter("@EXRL_BNK_TRANS_DT", EXRL_BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_DESC", EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@TO_BANK_TRANS_IND", TO_BANK_TRANS_IND), new SqlParameter("@TO_FROM_TO_USR_CD", TO_FROM_TO_USR_CD),
                    new SqlParameter("@TO_EXRL_ACCT_ID", TO_EXRL_ACCT_ID), new SqlParameter("@TO_BNK_TRANS_DT", TO_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_ID", TO_EXRL_BNK_TRANS_ID), new SqlParameter("@TO_EXRL_BNK_TRANS_DT", TO_EXRL_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_DESC", TO_EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@BILL_NBR_IND", BILL_NBR_IND), new SqlParameter("@CLT_ACCT_NBR", CLT_ACCT_NBR),
                    new SqlParameter("@BIL_NBR", BIL_NBR), new SqlParameter("@BIL_PYMT_TRANS_DT", BIL_PYMT_TRANS_DT),
                    new SqlParameter("@FROM_PKP_ACCT_IND", FROM_PKP_ACCT_IND), new SqlParameter("@FROM_PKP_ACCT_ID", FROM_PKP_ACCT_ID),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC), new SqlParameter("@TO_SRVC_IND", TO_SRVC_IND),
                    new SqlParameter("@TO_PKP_ACCT_ID", TO_PKP_ACCT_ID), new SqlParameter("@TO_BNK_ACCT_ID", TO_BNK_ACCT_ID),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int billPaymentTransactionEnd(DalContext db, int TRANS_ID, 
                                        string FROM_PKP_TRANS_IND, int FROM_ACCT_ID, string TRANS_TCD,
                                        string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT,
                                        DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        string TO_PKP_TRANS_IND, int TO_ACCT_ID, string TO_TRANS_TCD,
                                        string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT,
                                        DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        int EXRL_TRANS_ID, string TRANS_RETURN_CD, string TRANS_NBR)
        {
           
            if (String.IsNullOrWhiteSpace(TRANS_TCD)) { TRANS_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TRANS_PAY_SRC_CD)) { TRANS_PAY_SRC_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TRANS_SRVC_TCD)) { TRANS_SRVC_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertBillPaymentEnd @ReturnValue OUTPUT, @TRANS_ID," +
                    "@FROM_PKP_TRANS_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_PKP_TRANS_IND, @TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@EXRL_TRANS_ID, @TRANS_RETURN_CD, @TRANS_NBR",
                    ReturnValue, new SqlParameter("@TRANS_ID", TRANS_ID),
                    new SqlParameter("@FROM_PKP_TRANS_IND", FROM_PKP_TRANS_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_PKP_TRANS_IND", TO_PKP_TRANS_IND), new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@EXRL_TRANS_ID", EXRL_TRANS_ID), new SqlParameter("@TRANS_RETURN_CD", TRANS_RETURN_CD),
                    new SqlParameter("@TRANS_NBR", TRANS_NBR));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int transferTransaction(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string FROM_BANK_TRANS_IND, string FROM_TO_USR_CD,
                                        int EXRL_ACCT_ID, DateTime BNK_TRANS_DT, string EXRL_BNK_TRANS_ID,
                                        DateTime EXRL_BNK_TRANS_DT, string EXRL_BNK_TRANS_DESC,
                                        string TO_BANK_TRANS_IND, string TO_FROM_TO_USR_CD,
                                        int TO_EXRL_ACCT_ID, DateTime TO_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_ID,
                                        DateTime TO_EXRL_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_DESC,
                                        string FROM_PKP_TRANS_IND, int FROM_ACCT_ID, string TRANS_TCD,
                                        string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT,
                                        DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        string TO_PKP_TRANS_IND, int TO_ACCT_ID, string TO_TRANS_TCD,
                                        string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT,
                                        DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        string INSERT_NEW_ROW_IND, string RCPT_USR_NBR, int USR_WHDRL_CRDT_NBR)
        {
            if (String.IsNullOrWhiteSpace(FROM_TO_USR_CD)) { FROM_TO_USR_CD = "d"; }
            if (String.IsNullOrWhiteSpace(EXRL_BNK_TRANS_ID)) { EXRL_BNK_TRANS_ID = "d"; }
            if (String.IsNullOrWhiteSpace(EXRL_BNK_TRANS_DESC)) { EXRL_BNK_TRANS_DESC = "d"; }
            if (String.IsNullOrWhiteSpace(TO_FROM_TO_USR_CD)) { TO_FROM_TO_USR_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_ID)) { TO_EXRL_BNK_TRANS_ID = "d"; }
            if (String.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_DESC)) { TO_EXRL_BNK_TRANS_DESC = "d"; }
            if (String.IsNullOrWhiteSpace(TRANS_TCD)) { TRANS_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TRANS_PAY_SRC_CD)) { TRANS_PAY_SRC_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TRANS_SRVC_TCD)) { TRANS_SRVC_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertTransfer @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@FROM_BANK_TRANS_IND, @FROM_TO_USR_CD, @EXRL_ACCT_ID, @BNK_TRANS_DT," +
                    "@EXRL_BNK_TRANS_ID, @EXRL_BNK_TRANS_DT, @EXRL_BNK_TRANS_DESC," +
                    "@TO_BANK_TRANS_IND, @TO_FROM_TO_USR_CD, @TO_EXRL_ACCT_ID, @TO_BNK_TRANS_DT," +
                    "@TO_EXRL_BNK_TRANS_ID, @TO_EXRL_BNK_TRANS_DT, @TO_EXRL_BNK_TRANS_DESC," +
                    "@FROM_PKP_TRANS_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_PKP_TRANS_IND, @TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@INSERT_NEW_ROW_IND, @RCPT_USR_NBR, @USR_WHDRL_CRDT_NBR",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@FROM_BANK_TRANS_IND", FROM_BANK_TRANS_IND), new SqlParameter("@FROM_TO_USR_CD", FROM_TO_USR_CD),
                    new SqlParameter("@EXRL_ACCT_ID", EXRL_ACCT_ID), new SqlParameter("@BNK_TRANS_DT", BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_ID", EXRL_BNK_TRANS_ID), new SqlParameter("@EXRL_BNK_TRANS_DT", EXRL_BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_DESC", EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@TO_BANK_TRANS_IND", TO_BANK_TRANS_IND), new SqlParameter("@TO_FROM_TO_USR_CD", TO_FROM_TO_USR_CD),
                    new SqlParameter("@TO_EXRL_ACCT_ID", TO_EXRL_ACCT_ID), new SqlParameter("@TO_BNK_TRANS_DT", TO_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_ID", TO_EXRL_BNK_TRANS_ID), new SqlParameter("@TO_EXRL_BNK_TRANS_DT", TO_EXRL_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_DESC", TO_EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@FROM_PKP_TRANS_IND", FROM_PKP_TRANS_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_PKP_TRANS_IND", TO_PKP_TRANS_IND), new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@INSERT_NEW_ROW_IND", INSERT_NEW_ROW_IND), new SqlParameter("@RCPT_USR_NBR", RCPT_USR_NBR),
                    new SqlParameter("@USR_WHDRL_CRDT_NBR", USR_WHDRL_CRDT_NBR));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int transferTransactionWithoutPayment(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string FROM_BANK_TRANS_IND, string FROM_TO_USR_CD,
                                        int EXRL_ACCT_ID, DateTime BNK_TRANS_DT, string EXRL_BNK_TRANS_ID,
                                        DateTime EXRL_BNK_TRANS_DT, string EXRL_BNK_TRANS_DESC,
                                        string TO_BANK_TRANS_IND, string TO_FROM_TO_USR_CD,
                                        int TO_EXRL_ACCT_ID, DateTime TO_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_ID,
                                        DateTime TO_EXRL_BNK_TRANS_DT, string TO_EXRL_BNK_TRANS_DESC,
                                        string FROM_PKP_ACCT_IND, int FROM_PKP_ACCT_ID, string FROM_TRANS_DESC,
                                        string TO_SRVC_IND, int TO_PKP_ACCT_ID, int TO_BNK_ACCT_ID, string TO_TRANS_DESC)
        {
            if (string.IsNullOrWhiteSpace(FROM_TO_USR_CD)) { FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_ID)) { EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(EXRL_BNK_TRANS_DESC)) { EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_FROM_TO_USR_CD)) { TO_FROM_TO_USR_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_ID)) { TO_EXRL_BNK_TRANS_ID = "d"; }
            if (string.IsNullOrWhiteSpace(TO_EXRL_BNK_TRANS_DESC)) { TO_EXRL_BNK_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertTransfer_WithoutPayment @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@FROM_BANK_TRANS_IND, @FROM_TO_USR_CD, @EXRL_ACCT_ID, @BNK_TRANS_DT," +
                    "@EXRL_BNK_TRANS_ID, @EXRL_BNK_TRANS_DT, @EXRL_BNK_TRANS_DESC," +
                    "@TO_BANK_TRANS_IND, @TO_FROM_TO_USR_CD, @TO_EXRL_ACCT_ID, @TO_BNK_TRANS_DT," +
                    "@TO_EXRL_BNK_TRANS_ID, @TO_EXRL_BNK_TRANS_DT, @TO_EXRL_BNK_TRANS_DESC," +
                    "@FROM_PKP_ACCT_IND, @FROM_PKP_ACCT_ID, @FROM_TRANS_DESC, @TO_SRVC_IND, @TO_PKP_ACCT_ID, @TO_BNK_ACCT_ID, @TO_TRANS_DESC",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@FROM_BANK_TRANS_IND", FROM_BANK_TRANS_IND), new SqlParameter("@FROM_TO_USR_CD", FROM_TO_USR_CD),
                    new SqlParameter("@EXRL_ACCT_ID", EXRL_ACCT_ID), new SqlParameter("@BNK_TRANS_DT", BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_ID", EXRL_BNK_TRANS_ID), new SqlParameter("@EXRL_BNK_TRANS_DT", EXRL_BNK_TRANS_DT),
                    new SqlParameter("@EXRL_BNK_TRANS_DESC", EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@TO_BANK_TRANS_IND", TO_BANK_TRANS_IND), new SqlParameter("@TO_FROM_TO_USR_CD", TO_FROM_TO_USR_CD),
                    new SqlParameter("@TO_EXRL_ACCT_ID", TO_EXRL_ACCT_ID), new SqlParameter("@TO_BNK_TRANS_DT", TO_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_ID", TO_EXRL_BNK_TRANS_ID), new SqlParameter("@TO_EXRL_BNK_TRANS_DT", TO_EXRL_BNK_TRANS_DT),
                    new SqlParameter("@TO_EXRL_BNK_TRANS_DESC", TO_EXRL_BNK_TRANS_DESC),
                    new SqlParameter("@FROM_PKP_ACCT_IND", FROM_PKP_ACCT_IND), new SqlParameter("@FROM_PKP_ACCT_ID", FROM_PKP_ACCT_ID),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC), new SqlParameter("@TO_SRVC_IND", TO_SRVC_IND),
                    new SqlParameter("@TO_PKP_ACCT_ID", TO_PKP_ACCT_ID), new SqlParameter("@TO_BNK_ACCT_ID", TO_BNK_ACCT_ID),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int transferTransactionEnd(DalContext db, int TRANS_ID,
                                        string FROM_PKP_TRANS_IND, int FROM_ACCT_ID, string TRANS_TCD,
                                        string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT,
                                        DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        string TO_PKP_TRANS_IND, int TO_ACCT_ID, string TO_TRANS_TCD,
                                        string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT,
                                        DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        int EXRL_TRANS_ID, string TRANS_RETURN_CD, string TRANS_NBR,
                                        string INSERT_NEW_ROW_IND, string RCPT_USR_NBR, int USR_WHDRL_CRDT_NBR)
        {
            if (string.IsNullOrWhiteSpace(TRANS_TCD)) { TRANS_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_PAY_SRC_CD)) { TRANS_PAY_SRC_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_SRVC_TCD)) { TRANS_SRVC_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertTransferEnd @ReturnValue OUTPUT, @TRANS_ID," +
                    "@FROM_PKP_TRANS_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_PKP_TRANS_IND, @TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@EXRL_TRANS_ID, @TRANS_RETURN_CD, @TRANS_NBR," +
                    "@INSERT_NEW_ROW_IND, @RCPT_USR_NBR, @USR_WHDRL_CRDT_NBR",
                    ReturnValue, new SqlParameter("@TRANS_ID", TRANS_ID),
                    new SqlParameter("@FROM_PKP_TRANS_IND", FROM_PKP_TRANS_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_PKP_TRANS_IND", TO_PKP_TRANS_IND), new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@EXRL_TRANS_ID", EXRL_TRANS_ID), new SqlParameter("@TRANS_RETURN_CD", TRANS_RETURN_CD),
                    new SqlParameter("@TRANS_NBR", TRANS_NBR),
                    new SqlParameter("@INSERT_NEW_ROW_IND", INSERT_NEW_ROW_IND), new SqlParameter("@RCPT_USR_NBR", RCPT_USR_NBR),
                    new SqlParameter("@USR_WHDRL_CRDT_NBR", USR_WHDRL_CRDT_NBR));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int paymentTransactionBeforePayment(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string BILL_NBR_IND, string CLT_ACCT_NBR, string BIL_NBR, DateTime BIL_PYMT_TRANS_DT,
                                        string FROM_PKP_ACCT_IND, int FROM_PKP_ACCT_ID, string FROM_TRANS_DESC,
                                        string TO_SRVC_IND, int TO_PKP_ACCT_ID, int TO_BNK_ACCT_ID, string TO_TRANS_DESC)
        {
            if (String.IsNullOrWhiteSpace(FROM_TRANS_DESC)) { FROM_TRANS_DESC = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertRemotePayment_BeforePayment @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@BILL_NBR_IND, @CLT_ACCT_NBR, @BIL_NBR, @BIL_PYMT_TRANS_DT," +
                    "@FROM_PKP_ACCT_IND, @FROM_PKP_ACCT_ID, @FROM_TRANS_DESC, @TO_SRVC_IND, @TO_PKP_ACCT_ID, @TO_BNK_ACCT_ID, @TO_TRANS_DESC",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@BILL_NBR_IND", BILL_NBR_IND), new SqlParameter("@CLT_ACCT_NBR", CLT_ACCT_NBR),
                    new SqlParameter("@BIL_NBR", BIL_NBR), new SqlParameter("@BIL_PYMT_TRANS_DT", BIL_PYMT_TRANS_DT),
                    new SqlParameter("@FROM_PKP_ACCT_IND", FROM_PKP_ACCT_IND), new SqlParameter("@FROM_PKP_ACCT_ID", FROM_PKP_ACCT_ID),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC), new SqlParameter("@TO_SRVC_IND", TO_SRVC_IND),
                    new SqlParameter("@TO_PKP_ACCT_ID", TO_PKP_ACCT_ID), new SqlParameter("@TO_BNK_ACCT_ID", TO_BNK_ACCT_ID),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int remotePaymentTransactionEnd(DalContext db, int TRANS_ID, int TO_ACCT_ID, string TO_TRANS_TCD,
                                        string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT,
                                        DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        int EXRL_TRANS_ID, string TRANS_RETURN_CD, string TRANS_NBR)
        {
            
            if (String.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (String.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_insertRemotePaymentEnd @ReturnValue OUTPUT, @TRANS_ID," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@EXRL_TRANS_ID, @TRANS_RETURN_CD, @TRANS_NBR",
                    ReturnValue, new SqlParameter("@TRANS_ID", TRANS_ID), new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@EXRL_TRANS_ID", EXRL_TRANS_ID), new SqlParameter("@TRANS_RETURN_CD", TRANS_RETURN_CD),
                    new SqlParameter("@TRANS_NBR", TRANS_NBR));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public async Task<int> deleteCardByUserId(DalContext db, string userID)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = await db.Database.ExecuteSqlCommandAsync(
                "Card_deleteCardByUserId @ReturnValue OUTPUT, @USER_ID", ReturnValue, new SqlParameter("@USER_ID", userID));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int depositTransaction(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string INSERT_BUS_ACCT_HIST_IND,
                                        int FROM_ACCT_ID, string TRANS_TCD, string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT, DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        int TO_ACCT_ID, string TO_TRANS_TCD, string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT, DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        decimal BUS_CMSN_AMT, string CRCY_CD, int BUS_USR_NBR, int MANAGER_ACCT_ID,
                                        string CASHIER_OR_CLT_IN_BUS_TCD)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_DepositAccount @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@INSERT_BUS_ACCT_HIST_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@BUS_CMSN_AMT, @CRCY_CD, @BUS_USR_NBR, @MANAGER_ACCT_ID, @CASHIER_OR_CLT_IN_BUS_TCD",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@INSERT_BUS_ACCT_HIST_IND", INSERT_BUS_ACCT_HIST_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@BUS_CMSN_AMT", BUS_CMSN_AMT), new SqlParameter("@CRCY_CD", CRCY_CD),
                    new SqlParameter("@BUS_USR_NBR", BUS_USR_NBR),
                    new SqlParameter("@MANAGER_ACCT_ID", MANAGER_ACCT_ID),
                    new SqlParameter("@CASHIER_OR_CLT_IN_BUS_TCD", CASHIER_OR_CLT_IN_BUS_TCD));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int withdrawalTransaction(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string INSERT_BUS_ACCT_HIST_IND,
                                        int FROM_ACCT_ID, string TRANS_TCD, string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT, DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        int TO_ACCT_ID, string TO_TRANS_TCD, string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT, DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        decimal BUS_CMSN_AMT, string CRCY_CD, int BUS_USR_NBR,
                                        string UPDATE_CLT_CRDT_IND, string RCPT_USR_NBR, int USR_WHDRL_CRDT_NBR, int MANAGER_ACCT_ID,
                                        string CASHIER_OR_CLT_IN_BUS_TCD, string INSERT_CTRY_AGNT_CMSN_IND, int AGNT_ACCT_ID, int AGNT_ID, decimal AGNT_CMSN_AMT)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_WithdrawalAccount @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@INSERT_BUS_ACCT_HIST_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@BUS_CMSN_AMT, @CRCY_CD, @BUS_USR_NBR, @UPDATE_CLT_CRDT_IND, @RCPT_USR_NBR, @USR_WHDRL_CRDT_NBR, @MANAGER_ACCT_ID, @CASHIER_OR_CLT_IN_BUS_TCD, @INSERT_CTRY_AGNT_CMSN_IND, @AGNT_ACCT_ID, @AGNT_ID, @AGNT_CMSN_AMT",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@INSERT_BUS_ACCT_HIST_IND", INSERT_BUS_ACCT_HIST_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@BUS_CMSN_AMT", BUS_CMSN_AMT), new SqlParameter("@CRCY_CD", CRCY_CD),
                    new SqlParameter("@BUS_USR_NBR", BUS_USR_NBR),
                    new SqlParameter("@UPDATE_CLT_CRDT_IND", UPDATE_CLT_CRDT_IND), new SqlParameter("@RCPT_USR_NBR", RCPT_USR_NBR),
                    new SqlParameter("@USR_WHDRL_CRDT_NBR", USR_WHDRL_CRDT_NBR),
                    new SqlParameter("@MANAGER_ACCT_ID", MANAGER_ACCT_ID),
                    new SqlParameter("@CASHIER_OR_CLT_IN_BUS_TCD", CASHIER_OR_CLT_IN_BUS_TCD),
                    new SqlParameter("@INSERT_CTRY_AGNT_CMSN_IND", INSERT_CTRY_AGNT_CMSN_IND),
                    new SqlParameter("@AGNT_ACCT_ID", AGNT_ACCT_ID),
                    new SqlParameter("@AGNT_ID", AGNT_ID),
                    new SqlParameter("@AGNT_CMSN_AMT", AGNT_CMSN_AMT));
            //@@AGNT_CMSN_AMT
            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int businessInternalTransferTransaction(DalContext db, int FROM_BUS_USR_NBR, string FROM_BUS_USR_NM,
                                        int TO_BUS_USR_NBR, string TO_BUS_USR_NM,
                                        string FROM_ACCT_NBR, string TO_ACCT_NBR, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_DT, string TRANS_TCD, string TRANS_DESC,
                                        int FROM_ACCT_ID, string FROM_TRANS_TCD, string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT, DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        int TO_ACCT_ID, string TO_TRANS_TCD, string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT, DateTime TO_TRANS_DTTM, string TO_TRANS_DESC)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_BusinessInternalTransfer @ReturnValue OUTPUT, @FROM_BUS_USR_NBR, @FROM_BUS_USR_NM, @TO_BUS_USR_NBR, @TO_BUS_USR_NM," +
                    "@FROM_ACCT_NBR, @TO_ACCT_NBR, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @TO_TRANS_AMT, @TRANS_SCD, @TRANS_DT, @TRANS_TCD, @TRANS_DESC," +
                    "@FROM_ACCT_ID, @FROM_TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC",
                    ReturnValue, new SqlParameter("@FROM_BUS_USR_NBR", FROM_BUS_USR_NBR), new SqlParameter("@FROM_BUS_USR_NM", FROM_BUS_USR_NM),
                    new SqlParameter("@TO_BUS_USR_NBR", TO_BUS_USR_NBR), new SqlParameter("@TO_BUS_USR_NM", TO_BUS_USR_NM),
                    new SqlParameter("@FROM_ACCT_NBR", FROM_ACCT_NBR), new SqlParameter("@TO_ACCT_NBR", TO_ACCT_NBR),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_DT", TRANS_DT), new SqlParameter("@TRANS_TCD", TRANS_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@FROM_TRANS_TCD", FROM_TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int transferAgentCommission(DalContext db, int AGNT_ID, decimal AGNT_TRSF_AMT, DateTime AGNT_TRSF_DT, string CRCY_CD,
                                        int FROM_ACCT_ID, decimal FROM_BAL_AFTR_TRANS, 
                                        int TO_ACCT_ID, string TO_TRANS_TCD, string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT, DateTime TO_TRANS_DTTM, string TO_TRANS_DESC)
        {

            if (string.IsNullOrWhiteSpace(TO_TRANS_TCD)) { TO_TRANS_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_PAY_SRC_CD)) { TO_TRANS_PAY_SRC_CD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_SRVC_TCD)) { TO_TRANS_SRVC_TCD = "d"; }
            if (string.IsNullOrWhiteSpace(TO_TRANS_DESC)) { TO_TRANS_DESC = "d"; }

            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Agent_TransferCommission @ReturnValue OUTPUT, @AGNT_ID, @AGNT_TRSF_AMT, @AGNT_TRSF_DT, @CRCY_CD," +
                    "@FROM_ACCT_ID, @FROM_BAL_AFTR_TRANS," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC",
                    ReturnValue, new SqlParameter("@AGNT_ID", AGNT_ID), new SqlParameter("@AGNT_TRSF_AMT", AGNT_TRSF_AMT),
                    new SqlParameter("@AGNT_TRSF_DT", AGNT_TRSF_DT), new SqlParameter("@CRCY_CD", CRCY_CD),
                    new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int transferAgentCommissionTransaction(DalContext db, int ACCT_ID1, string AGNT_CMSN_IND1, int AGNT_ID1, string AGNT_SPNSR_TCD1,
                                     string TRANS_ID1, decimal TRANS_CMSN_AMT1, DateTime TRANS_CMSN_DT1, string TRANS_CMSN_CRCY_CD1, string TRANS_CMSN_DESC1,
                                     string TRANS_SPNSRD_NBR1, string TRANS_SPNSRD_NM1, string @TRANS_SPNSRD_TCD1, string SRVC_TCD1,
                                     int ACCT_ID2, string AGNT_CMSN_IND2, int AGNT_ID2, string AGNT_SPNSR_TCD2,
                                     string TRANS_ID2, decimal TRANS_CMSN_AMT2, DateTime TRANS_CMSN_DT2, string TRANS_CMSN_CRCY_CD2, string TRANS_CMSN_DESC2,
                                     string TRANS_SPNSRD_NBR2, string TRANS_SPNSRD_NM2, string @TRANS_SPNSRD_TCD2, string SRVC_TCD2)
        {
            if (string.IsNullOrWhiteSpace(AGNT_SPNSR_TCD2)) { AGNT_SPNSR_TCD2 = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_ID2)) { TRANS_ID2 = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_CMSN_CRCY_CD2)) { TRANS_CMSN_CRCY_CD2 = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_CMSN_DESC2)) { TRANS_CMSN_DESC2 = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_SPNSRD_NBR2)) { TRANS_SPNSRD_NBR2 = "d"; }
            if (string.IsNullOrWhiteSpace(TRANS_SPNSRD_NM2)) { TRANS_SPNSRD_NM2 = "d"; }
            if (string.IsNullOrWhiteSpace(@TRANS_SPNSRD_TCD2)) { @TRANS_SPNSRD_TCD2 = "d"; }
            if (string.IsNullOrWhiteSpace(SRVC_TCD2)) { SRVC_TCD2 = "d"; }
            
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Agent_TransferCommissionTransaction @ReturnValue OUTPUT, @ACCT_ID1, @AGNT_CMSN_IND1, @AGNT_ID1, @AGNT_SPNSR_TCD1, @TRANS_ID1, @TRANS_CMSN_AMT1, @TRANS_CMSN_DT1," +
                    "@TRANS_CMSN_CRCY_CD1, @TRANS_CMSN_DESC1, @TRANS_SPNSRD_NBR1, @TRANS_SPNSRD_NM1, @TRANS_SPNSRD_TCD1, @SRVC_TCD1," +
                    "@ACCT_ID2, @AGNT_CMSN_IND2, @AGNT_ID2, @AGNT_SPNSR_TCD2, @TRANS_ID2, @TRANS_CMSN_AMT2, @TRANS_CMSN_DT2," +
                    "@TRANS_CMSN_CRCY_CD2, @TRANS_CMSN_DESC2, @TRANS_SPNSRD_NBR2, @TRANS_SPNSRD_NM2, @TRANS_SPNSRD_TCD2, @SRVC_TCD2",
                    ReturnValue, new SqlParameter("@ACCT_ID1", ACCT_ID1), new SqlParameter("@AGNT_CMSN_IND1", AGNT_CMSN_IND1),
                    new SqlParameter("@AGNT_ID1", AGNT_ID1), new SqlParameter("@AGNT_SPNSR_TCD1", AGNT_SPNSR_TCD1),
                    new SqlParameter("@TRANS_ID1", TRANS_ID1), new SqlParameter("@TRANS_CMSN_AMT1", TRANS_CMSN_AMT1),
                    new SqlParameter("@TRANS_CMSN_DT1", TRANS_CMSN_DT1),
                    new SqlParameter("@TRANS_CMSN_CRCY_CD1", TRANS_CMSN_CRCY_CD1), new SqlParameter("@TRANS_CMSN_DESC1", TRANS_CMSN_DESC1),
                    new SqlParameter("@TRANS_SPNSRD_NBR1", TRANS_SPNSRD_NBR1), new SqlParameter("@TRANS_SPNSRD_NM1", TRANS_SPNSRD_NM1),
                    new SqlParameter("@TRANS_SPNSRD_TCD1", TRANS_SPNSRD_TCD1), new SqlParameter("@SRVC_TCD1", SRVC_TCD1),
                    new SqlParameter("@ACCT_ID2", ACCT_ID2), new SqlParameter("@AGNT_CMSN_IND2", AGNT_CMSN_IND2),
                    new SqlParameter("@AGNT_ID2", AGNT_ID2), new SqlParameter("@AGNT_SPNSR_TCD2", AGNT_SPNSR_TCD2),
                    new SqlParameter("@TRANS_ID2", TRANS_ID2), new SqlParameter("@TRANS_CMSN_AMT2", TRANS_CMSN_AMT2),
                    new SqlParameter("@TRANS_CMSN_DT2", TRANS_CMSN_DT2),
                    new SqlParameter("@TRANS_CMSN_CRCY_CD2", TRANS_CMSN_CRCY_CD2), new SqlParameter("@TRANS_CMSN_DESC2", TRANS_CMSN_DESC2),
                    new SqlParameter("@TRANS_SPNSRD_NBR2", TRANS_SPNSRD_NBR2), new SqlParameter("@TRANS_SPNSRD_NM2", TRANS_SPNSRD_NM2),
                    new SqlParameter("@TRANS_SPNSRD_TCD2", TRANS_SPNSRD_TCD2), new SqlParameter("@SRVC_TCD2", SRVC_TCD2));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }

        public int thirdPartyDepositTransaction(DalContext db, int FROM_TRSF_SERV_ID, int TO_TRSF_SERV_ID,
                                        string FROM_CTRY_CD, string TO_CTRY_CD, string FROM_CRCY_CD, string TO_CRCY_CD,
                                        decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal FROM_FEE_AMT,
                                        decimal FROM_TOT_AMT, decimal TO_TRANS_AMT, string TRANS_SCD,
                                        DateTime TRANS_CDT, DateTime TRANS_PAID_DPST_DT, DateTime TRANS_XDT,
                                        string FROM_USR_NBR, int RCPT_USR_BUS_ID, string TRANS_TRSF_CRDT_DBT_TCD, string TRANS_DESC,
                                        string INSERT_BUS_ACCT_HIST_IND,
                                        int FROM_ACCT_ID, string TRANS_TCD, string TRANS_PAY_SRC_CD, string TRANS_SRVC_TCD,
                                        decimal FROM_BAL_AFTR_TRANS, decimal TRANS_AMT, DateTime TRANS_DTTM, string FROM_TRANS_DESC,
                                        int TO_ACCT_ID, string TO_TRANS_TCD, string TO_TRANS_PAY_SRC_CD, string TO_TRANS_SRVC_TCD,
                                        decimal TO_BAL_AFTR_TRANS, decimal to_TRANS_AMT, DateTime TO_TRANS_DTTM, string TO_TRANS_DESC,
                                        decimal BUS_CMSN_AMT, string CRCY_CD, int BUS_USR_NBR, int MANAGER_ACCT_ID,
                                        string INSERT_NEW_ROW_IND, string CLT_USR_NBR, int USR_WHDRL_CRDT_NBR,
                                        string CASHIER_OR_CLT_IN_BUS_TCD)
        {
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", -1);
            ReturnValue.Direction = System.Data.ParameterDirection.Output;

            var retRowsAffected = db.Database.ExecuteSqlCommand(
                "Transaction_ThirdPartyDepositAccount @ReturnValue OUTPUT, @FROM_TRSF_SERV_ID, @TO_TRSF_SERV_ID," +
                    "@FROM_CTRY_CD, @TO_CTRY_CD, @FROM_CRCY_CD, @TO_CRCY_CD," +
                    "@CRCY_XCHG_RT, @FROM_TRANS_AMT, @FROM_FEE_AMT, @FROM_TOT_AMT," +
                    "@TO_TRANS_AMT, @TRANS_SCD, @TRANS_CDT," +
                    "@TRANS_PAID_DPST_DT, @TRANS_XDT, @FROM_USR_NBR, @RCPT_USR_BUS_ID," +
                    "@TRANS_TRSF_CRDT_DBT_TCD, @TRANS_DESC," +
                    "@INSERT_BUS_ACCT_HIST_IND, @FROM_ACCT_ID, @TRANS_TCD, @TRANS_PAY_SRC_CD," +
                    "@TRANS_SRVC_TCD, @FROM_BAL_AFTR_TRANS, @TRANS_AMT, @TRANS_DTTM, @FROM_TRANS_DESC," +
                    "@TO_ACCT_ID, @TO_TRANS_TCD, @TO_TRANS_PAY_SRC_CD," +
                    "@TO_TRANS_SRVC_TCD, @TO_BAL_AFTR_TRANS, @TO_TRANS_AMT_HIST, @TO_TRANS_DTTM, @TO_TRANS_DESC," +
                    "@BUS_CMSN_AMT, @CRCY_CD, @BUS_USR_NBR, @MANAGER_ACCT_ID, @INSERT_NEW_ROW_IND, @CLT_USR_NBR, @USR_WHDRL_CRDT_NBR, @CASHIER_OR_CLT_IN_BUS_TCD",
                    ReturnValue, new SqlParameter("@FROM_TRSF_SERV_ID", FROM_TRSF_SERV_ID), new SqlParameter("@TO_TRSF_SERV_ID", TO_TRSF_SERV_ID),
                    new SqlParameter("@FROM_CTRY_CD", FROM_CTRY_CD), new SqlParameter("@TO_CTRY_CD", TO_CTRY_CD),
                    new SqlParameter("@FROM_CRCY_CD", FROM_CRCY_CD), new SqlParameter("@TO_CRCY_CD", TO_CRCY_CD),
                    new SqlParameter("@CRCY_XCHG_RT", CRCY_XCHG_RT), new SqlParameter("@FROM_TRANS_AMT", FROM_TRANS_AMT),
                    new SqlParameter("@FROM_FEE_AMT", FROM_FEE_AMT), new SqlParameter("@FROM_TOT_AMT", FROM_TOT_AMT),
                    new SqlParameter("@TO_TRANS_AMT", TO_TRANS_AMT), new SqlParameter("@TRANS_SCD", TRANS_SCD),
                    new SqlParameter("@TRANS_CDT", TRANS_CDT), new SqlParameter("@TRANS_PAID_DPST_DT", TRANS_PAID_DPST_DT),
                    new SqlParameter("@TRANS_XDT", TRANS_XDT), new SqlParameter("@FROM_USR_NBR", FROM_USR_NBR),
                    new SqlParameter("@RCPT_USR_BUS_ID", RCPT_USR_BUS_ID), new SqlParameter("@TRANS_TRSF_CRDT_DBT_TCD", TRANS_TRSF_CRDT_DBT_TCD),
                    new SqlParameter("@TRANS_DESC", TRANS_DESC),
                    new SqlParameter("@INSERT_BUS_ACCT_HIST_IND", INSERT_BUS_ACCT_HIST_IND), new SqlParameter("@FROM_ACCT_ID", FROM_ACCT_ID),
                    new SqlParameter("@TRANS_TCD", TRANS_TCD), new SqlParameter("@TRANS_PAY_SRC_CD", TRANS_PAY_SRC_CD),
                    new SqlParameter("@TRANS_SRVC_TCD", TRANS_SRVC_TCD), new SqlParameter("@FROM_BAL_AFTR_TRANS", FROM_BAL_AFTR_TRANS),
                    new SqlParameter("@TRANS_AMT", TRANS_AMT), new SqlParameter("@TRANS_DTTM", TRANS_DTTM),
                    new SqlParameter("@FROM_TRANS_DESC", FROM_TRANS_DESC),
                    new SqlParameter("@TO_ACCT_ID", TO_ACCT_ID),
                    new SqlParameter("@TO_TRANS_TCD", TO_TRANS_TCD), new SqlParameter("@TO_TRANS_PAY_SRC_CD", TO_TRANS_PAY_SRC_CD),
                    new SqlParameter("@TO_TRANS_SRVC_TCD", TO_TRANS_SRVC_TCD), new SqlParameter("@TO_BAL_AFTR_TRANS", TO_BAL_AFTR_TRANS),
                    new SqlParameter("@TO_TRANS_AMT_HIST", to_TRANS_AMT), new SqlParameter("@TO_TRANS_DTTM", TO_TRANS_DTTM),
                    new SqlParameter("@TO_TRANS_DESC", TO_TRANS_DESC),
                    new SqlParameter("@BUS_CMSN_AMT", BUS_CMSN_AMT), new SqlParameter("@CRCY_CD", CRCY_CD),
                    new SqlParameter("@BUS_USR_NBR", BUS_USR_NBR),
                    new SqlParameter("@MANAGER_ACCT_ID", MANAGER_ACCT_ID),
                    new SqlParameter("@INSERT_NEW_ROW_IND", INSERT_NEW_ROW_IND), new SqlParameter("@CLT_USR_NBR", CLT_USR_NBR),
                    new SqlParameter("@USR_WHDRL_CRDT_NBR", USR_WHDRL_CRDT_NBR),
                    new SqlParameter("@CASHIER_OR_CLT_IN_BUS_TCD", CASHIER_OR_CLT_IN_BUS_TCD));

            int retValue = Convert.ToInt32(ReturnValue.Value);
            return retValue;
        }
    }
}