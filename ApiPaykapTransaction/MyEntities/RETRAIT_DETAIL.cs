using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPaykapTransaction.MyEntities
{
    public class RETRAIT_DETAIL
    {
        public RETRAIT_DETAIL() { }

        public RETRAIT_DETAIL
            (
            string CLT_USR_NBR1,
            string CLT_FUL_NM1,
            string FEE_AMT1,
            string TOT_AMT_TO_PAY1,
            string AMT_TO_RECEIVE1
            )
        {
            this.CLT_USR_NBR = CLT_USR_NBR1;
            this.CLT_FUL_NM = CLT_FUL_NM1;
            this.FEE_AMT = FEE_AMT1;
            this.TOT_AMT_TO_PAY = TOT_AMT_TO_PAY1;
            this.AMT_TO_RECEIVE = AMT_TO_RECEIVE1;

        }


        private string AMT_TO_RECEIVE1;
        public string AMT_TO_RECEIVE
        {
            get { return AMT_TO_RECEIVE1; }
            set { AMT_TO_RECEIVE1 = value; }
        }

        private string TOT_AMT_TO_PAY1;
        public string TOT_AMT_TO_PAY
        {
            get { return TOT_AMT_TO_PAY1; }
            set { TOT_AMT_TO_PAY1 = value; }
        }

        private string FEE_AMT1;
        public string FEE_AMT
        {
            get { return FEE_AMT1; }
            set { FEE_AMT1 = value; }
        }

        private string CLT_USR_NBR1;
        public string CLT_USR_NBR
        {
            get { return CLT_USR_NBR1; }
            set { CLT_USR_NBR1 = value; }
        }

        private string CLT_FUL_NM1;
        public string CLT_FUL_NM
        {
            get { return CLT_FUL_NM1; }
            set { CLT_FUL_NM1 = value; }
        }
    }
}