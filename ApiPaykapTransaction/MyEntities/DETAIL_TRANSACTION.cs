using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPaykapTransaction.MyEntities
{
    public class DETAIL_TRANSACTION
    {
        public DETAIL_TRANSACTION() { }
        public DETAIL_TRANSACTION(
            string TRANS_SCD_1,
            string TRANS_DESC_1,
            string BUS_AGCY_NM_1,
            string BUS_AGCY_NBR_1,
            string BUS_NM_1,
            string BUS_CSHR_ACCT_1,
            string BUS_CSHR_FUL_NM_1,
            string BUS_CSHR_USR_NBR_1,
            string BUS_AGCY_CITY_NM_1,
            string CLT_FUL_NM_1,
            bool VIEW_CSHR_NM_IND_1,
            string TRANS_AMT_1,
            bool CRCY_XCHG_RT_IND_1,
            string CRCY_XCHG_RT_1,
            string CLT_TRANS_AMT_1
            )
        {
            this.TRANS_SCD = TRANS_SCD_1;
            this.TRANS_DESC = TRANS_DESC_1;
            this.BUS_AGCY_NM = BUS_AGCY_NM_1;
            this.BUS_AGCY_NBR = BUS_AGCY_NBR_1;
            this.BUS_NM = BUS_NM_1;
            this.BUS_CSHR_ACCT = BUS_CSHR_ACCT_1;
            this.BUS_CSHR_FUL_NM = BUS_CSHR_FUL_NM_1;
            this.BUS_CSHR_USR_NBR = BUS_CSHR_USR_NBR_1;
            this.BUS_AGCY_CITY_NM = BUS_AGCY_CITY_NM_1;
            this.CLT_FUL_NM = CLT_FUL_NM_1;
            this.VIEW_CSHR_NM_IND = VIEW_CSHR_NM_IND_1;
            this.TRANS_AMT = TRANS_AMT_1;
            this.CRCY_XCHG_RT_IND = CRCY_XCHG_RT_IND_1;
            this.CRCY_XCHG_RT = CRCY_XCHG_RT_1;
            this.CLT_TRANS_AMT = CLT_TRANS_AMT_1;
        }

        private string CLT_TRANS_AMT_1;
        public string CLT_TRANS_AMT
        {
            get { return CLT_TRANS_AMT_1; }
            set { CLT_TRANS_AMT_1 = value; }
        }

        private string CRCY_XCHG_RT_1;
        public string CRCY_XCHG_RT
        {
            get { return CRCY_XCHG_RT_1; }
            set { CRCY_XCHG_RT_1 = value; }
        }

        private bool CRCY_XCHG_RT_IND_1;
        public bool CRCY_XCHG_RT_IND
        {
            get { return CRCY_XCHG_RT_IND_1; }
            set { CRCY_XCHG_RT_IND_1 = value; }
        }

        private string TRANS_AMT_1;
        public string TRANS_AMT
        {
            get { return TRANS_AMT_1; }
            set { TRANS_AMT_1 = value; }
        }

        private bool VIEW_CSHR_NM_IND_1;
        public bool VIEW_CSHR_NM_IND
        {
            get { return VIEW_CSHR_NM_IND_1; }
            set { VIEW_CSHR_NM_IND_1 = value; }
        }

        private string CLT_FUL_NM_1;
        public string CLT_FUL_NM
        {
            get { return CLT_FUL_NM_1; }
            set { CLT_FUL_NM_1 = value; }
        }

        private string BUS_AGCY_CITY_NM_1;
        public string BUS_AGCY_CITY_NM
        {
            get { return BUS_AGCY_CITY_NM_1; }
            set { BUS_AGCY_CITY_NM_1 = value; }
        }

        private string BUS_CSHR_USR_NBR_1;
        public string BUS_CSHR_USR_NBR
        {
            get { return BUS_CSHR_USR_NBR_1; }
            set { BUS_CSHR_USR_NBR_1 = value; }
        }

        private string BUS_CSHR_FUL_NM_1;
        public string BUS_CSHR_FUL_NM
        {
            get { return BUS_CSHR_FUL_NM_1; }
            set { BUS_CSHR_FUL_NM_1 = value; }
        }

        private string BUS_CSHR_ACCT_1;
        public string BUS_CSHR_ACCT
        {
            get { return BUS_CSHR_ACCT_1; }
            set { BUS_CSHR_ACCT_1 = value; }
        }

        private string BUS_NM_1;
        public string BUS_NM
        {
            get { return BUS_NM_1; }
            set { BUS_NM_1 = value; }
        }

        private string BUS_AGCY_NBR_1;
        public string BUS_AGCY_NBR
        {
            get { return BUS_AGCY_NBR_1; }
            set { BUS_AGCY_NBR_1 = value; }
        }

        private string BUS_AGCY_NM_1;
        public string BUS_AGCY_NM
        {
            get { return BUS_AGCY_NM_1; }
            set { BUS_AGCY_NM_1 = value; }
        }

        private string TRANS_SCD_1;
        public string TRANS_SCD
        {
            get { return TRANS_SCD_1; }
            set { TRANS_SCD_1 = value; }
        }

        private string TRANS_DESC_1;
        public string TRANS_DESC
        {
            get { return TRANS_DESC_1; }
            set { TRANS_DESC_1 = value; }
        }
    }
}