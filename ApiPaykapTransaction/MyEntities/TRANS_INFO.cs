using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPaykapTransaction.MyEntities
{
    public class TRANS_INFO
    {
        public TRANS_INFO() { }

        public TRANS_INFO
            (
            string USR_FNM_1,
            string USR_LNM_1,
            string FROM_USR_NBR_1,
            string RCPT_USR_BUS_NM_1,
            int TRANS_ID_1,
            decimal TO_TRANS_AMT_1,
            string TRANS_DESC_1,
            string FRA_TRSF_SERV_NM_1,
            string TRANS_SCD_1,
            string CITY_NM_1,
            string ADDR_LN1_TXT_1
            )
        {
            this.USR_FNM = USR_FNM_1;
            this.USR_LNM = USR_LNM_1;
            this.FROM_USR_NBR = FROM_USR_NBR_1;
            this.RCPT_USR_BUS_NM = RCPT_USR_BUS_NM_1;
            this.TRANS_ID = TRANS_ID_1;
            this.TO_TRANS_AMT = TO_TRANS_AMT_1;
            this.TRANS_DESC = TRANS_DESC_1;
            this.FRA_TRSF_SERV_NM = FRA_TRSF_SERV_NM_1;
            this.TRANS_SCD = TRANS_SCD_1;
            this.CITY_NM = CITY_NM_1;
            this.ADDR_LN1_TXT = ADDR_LN1_TXT_1;

        }

        private string USR_FNM1;
        public string USR_FNM
        {
            get { return USR_FNM1; }
            set { USR_FNM1 = value; }
        }

        private string USR_LNM1;
        public string USR_LNM
        {
            get { return USR_LNM1; }
            set { USR_LNM1 = value; }
        }

        private string FROM_USR_NBR1;
        public string FROM_USR_NBR
        {
            get { return FROM_USR_NBR1; }
            set { FROM_USR_NBR1 = value; }
        }

        private string RCPT_USR_BUS_NM1;
        public string RCPT_USR_BUS_NM
        {
            get { return RCPT_USR_BUS_NM1; }
            set { RCPT_USR_BUS_NM1 = value; }
        }

        private int TRANS_ID1;
        public int TRANS_ID
        {
            get { return TRANS_ID1; }
            set { TRANS_ID1 = value; }
        }

        private decimal TO_TRANS_AMT1;
        public decimal TO_TRANS_AMT
        {
            get { return TO_TRANS_AMT1; }
            set { TO_TRANS_AMT1 = value; }
        }

        private string TRANS_DESC1;
        public string TRANS_DESC
        {
            get { return TRANS_DESC1; }
            set { TRANS_DESC1 = value; }
        }

        private string FRA_TRSF_SERV_NM1;
        public string FRA_TRSF_SERV_NM
        {
            get { return FRA_TRSF_SERV_NM1; }
            set { FRA_TRSF_SERV_NM1 = value; }
        }

        private string TRANS_SCD1;
        public string TRANS_SCD
        {
            get { return TRANS_SCD1; }
            set { TRANS_SCD1 = value; }
        }

        private string CITY_NM1;
        public string CITY_NM
        {
            get { return CITY_NM1; }
            set { CITY_NM1 = value; }
        }

        private string ADDR_LN1_TXT1;
        public string ADDR_LN1_TXT
        {
            get { return ADDR_LN1_TXT1; }
            set { ADDR_LN1_TXT1 = value; }
        }
    }
}