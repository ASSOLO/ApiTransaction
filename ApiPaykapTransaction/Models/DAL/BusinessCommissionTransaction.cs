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
    [Table("dbo.TBUS_CMSN_TRANS")]
    public class BusinessCommissionTransaction
    {
        [Key]
        [Display(Name = "ID Commission Entreprise")]
        public int BUS_CMSN_TRANS_ID { get; set; }

        [Display(Name = "ID Transaction")]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "La montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Commission Entreprise")]
        public decimal BUS_CMSN_AMT { get; set; }

        [Display(Name = "Montant Total Départ Texte")]
        [NotMapped]
        public string BUS_CMSN_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(BUS_CMSN_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise")]
        public string CRCY_CD { get; set; }

        [Display(Name = "ID Enployé Entreprise")]
        public int BUS_USR_NBR { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Type Transaction")]  //01-Transfer    02-Bill Payment Registered Recipient   
                                              //03-Bill Payment No Registered Recipient      
                                              //04- Remote Payment To Registered Recipient 05-    Deposit    06- Withdrawal
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }

        public virtual TransactionTransferCreditDebit TTRANS_TRSF_CRDT_DBT { get; set; }

        public virtual BusinessUser TBUS_USR { get; set; }

        public virtual Currency TCRCY { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public BusinessCommissionTransaction insertBusinessCommissionTransaction(int TRANS_ID, 
                                                           decimal BUS_CMSN_AMT, string CRCY_CD,
                                                           int BUS_USR_NBR, string TRANS_TRSF_CRDT_DBT_TCD)
        {
            try
            {
                var obj = new BusinessCommissionTransaction();

                obj.TRANS_ID = TRANS_ID;
                obj.BUS_CMSN_AMT = BUS_CMSN_AMT;
                obj.CRCY_CD = CRCY_CD;
                obj.BUS_USR_NBR = BUS_USR_NBR;
                obj.TRANS_TRSF_CRDT_DBT_TCD = TRANS_TRSF_CRDT_DBT_TCD;
                return obj;
            }
            catch
            {
                return null;
            }
        }
        
             public List<BusinessCommissionTransaction> getAllLast24HoursTransactionCommission(int BN)
        {
            var list = new List<BusinessCommissionTransaction>();
            try
            {
                DateTime startDT = CommonLibrary.Last24Hours(DateTime.Now);
                var query = from busTrans in db.TBUS_CMSN_TRANS
                            join trans in db.TTRANS_TRSF_CRDT_DBT on busTrans.TRANS_ID equals trans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= startDT)
                            orderby trans.TRANS_ID descending
                            select busTrans;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public List<BusinessCommissionTransaction> getAllCurrentMonthBusinessCommissionTransaction(int BN)
        {
            var list = new List<BusinessCommissionTransaction>();
            try
            {
                DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
                var query = from busTrans in  db.TBUS_CMSN_TRANS
                            join trans in db.TTRANS_TRSF_CRDT_DBT on busTrans.TRANS_ID equals trans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= startDT)
                            orderby trans.TRANS_ID descending
                            select busTrans;

                foreach(var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public List<BusinessCommissionTransaction> getAllSelectedMonthBusinessCommissionTransaction(int BN, string month, string year)
        {
            var list = new List<BusinessCommissionTransaction>();
            try
            {
                int intMonth = Convert.ToInt32(month);
                int intYear = Convert.ToInt32(year);
                DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
                DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);
                
                var query = from busTrans in db.TBUS_CMSN_TRANS
                            join trans in db.TTRANS_TRSF_CRDT_DBT on busTrans.TRANS_ID equals trans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= firstDate && trans.TRANS_CDT <= lastDate)
                            orderby trans.TRANS_ID descending
                            select busTrans;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return list;
            }
        }


      /*  public BusinessCommissionTransactionCountViewModel getAllCurrentMonthBusinessCommissionTransactionCount(int BN)
        {
            try
            {
                DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
                var newObj = new BusinessCommissionTransactionCountViewModel();
                var query = from busTrans in db.TBUS_CMSN_TRANS
                            join trans in db.TTRANS_TRSF_CRDT_DBT on busTrans.TRANS_ID equals trans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= startDT)
                            orderby trans.TRANS_ID descending
                            select busTrans;

                List<decimal> busCnsmAmtList = new List<decimal>();
                List<string> busCnsmCrcyList = new List<string>();
                foreach (var x in query)
                {
                    busCnsmAmtList.Add(x.BUS_CMSN_AMT);
                    busCnsmCrcyList.Add(x.CRCY_CD);
                }
                decimal busCnsmAmt = busCnsmAmtList.Sum();
                var ctryCrcy = new CountryCurrency();

                if (busCnsmAmtList.Count() != 0)
                {
                    newObj.BUS_CMSN_CRCY_CD = busCnsmCrcyList[0].ToUpper();
                    string depositCulInfo = ctryCrcy.getCultureInfoByCurrencyCD(newObj.BUS_CMSN_CRCY_CD, "FRA");
                    newObj.BUS_CMSN_TOT_AMT_TXT = CommonLibrary.displayFormattedCurrency(busCnsmAmt, depositCulInfo);
                }
                else
                {
                    newObj.BUS_CMSN_CRCY_CD = "";
                    newObj.BUS_CMSN_TOT_AMT_TXT = busCnsmAmt.ToString("N2");
                }
                
                newObj.BUS_CMSN_TRANS_NBR = busCnsmAmtList.Count();
                return newObj;
            }
            catch
            {
                return null;
            }
        }

        public BusinessCommissionTransactionCountViewModel getAllSelectedMonthBusinessCommissionTransactionCount(int BN, string month, string year)
        {
            try
            {
                int intMonth = Convert.ToInt32(month);
                int intYear = Convert.ToInt32(year);
                DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
                DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);

                var newObj = new BusinessCommissionTransactionCountViewModel();
                var query = from busTrans in db.TBUS_CMSN_TRANS
                            join trans in db.TTRANS_TRSF_CRDT_DBT on busTrans.TRANS_ID equals trans.TRANS_ID
                            join busUsr in db.TBUS_USR on busTrans.BUS_USR_NBR equals busUsr.BUS_USR_NBR
                            where (busUsr.BN == BN && trans.TRANS_SCD == "06" && trans.TRANS_CDT >= firstDate && trans.TRANS_CDT <= lastDate)
                            orderby trans.TRANS_ID descending
                            select busTrans;

                List<decimal> busCnsmAmtList = new List<decimal>();
                List<string> busCnsmCrcyList = new List<string>();
                foreach (var x in query)
                {
                    busCnsmAmtList.Add(x.BUS_CMSN_AMT);
                    busCnsmCrcyList.Add(x.CRCY_CD);
                }
                decimal busCnsmAmt = busCnsmAmtList.Sum();
                var ctryCrcy = new CountryCurrency();

                if (busCnsmAmtList.Count() != 0)
                {
                    newObj.BUS_CMSN_CRCY_CD = busCnsmCrcyList[0].ToUpper();
                    string depositCulInfo = ctryCrcy.getCultureInfoByCurrencyCD(newObj.BUS_CMSN_CRCY_CD, "FRA");
                    newObj.BUS_CMSN_TOT_AMT_TXT = CommonLibrary.displayFormattedCurrency(busCnsmAmt, depositCulInfo);
                }
                else
                {
                    newObj.BUS_CMSN_CRCY_CD = "";
                    newObj.BUS_CMSN_TOT_AMT_TXT = busCnsmAmt.ToString("N2");
                }

                newObj.BUS_CMSN_TRANS_NBR = busCnsmAmtList.Count();
                return newObj;
            }
            catch
            {
                return null;
            }
        } */
    }
}
