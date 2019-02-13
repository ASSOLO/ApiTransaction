using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using ApiPaykapTransaction.Models;
using System.Data.Entity;
using PaykapDataAccess;
using ApiPaykapTransaction.MyEntities;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Web.Http.Description;
using Resources;
using Microsoft.AspNet.Identity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TACCT_HIST")]
    public class AccountHistory
    {
        public AccountHistory()
        {
            TRANS_DTTM = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Compte Historique")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ACCT_HIST_ID { get; set; }

        [Display(Name = "ID Compte")]
        public int ACCT_ID { get; set; }
        
        [Required(ErrorMessage = "Le type de la transaction est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le type de la transaction doit avoir 1 caractère.")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Transaction")]
        public string TRANS_TCD { get; set; } //1 = credit 2 = debit

        [Required(ErrorMessage = "La source de paiement de la transaction est obligatoire.")]
        [StringLength(1, ErrorMessage = "La source de paiement de la transaction doit avoir 1 caractère.")]
        [DataType(DataType.Text)]
        [Display(Name = "Source Paiement Transaction")]
        public string TRANS_PAY_SRC_CD { get; set; }  // 1- Cash       2- From paykap account      3- From External account

        [Required(ErrorMessage = "Le type de service de la transaction est obligatoire.")]
        [StringLength(2, ErrorMessage = "Le type de service de la transaction doit avoir 2 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Service Transaction")]
        public string TRANS_SRVC_TCD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Après Transaction")]
        public decimal BAL_AFTR_TRANS { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Transaction")]
        public DateTime TRANS_DTTM { get; set; }
        
        [Required(ErrorMessage = "La description de la transaction est obligatoire.")]
        [StringLength(250, ErrorMessage = "La description de la transaction doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Transaction Description")]
        public string TRANS_DESC { get; set; }

        public virtual Account TACCT { get; set; }

        private DataModel db = new DataModel();
        private string lang = "FRA";

        public List<AccountHistory> getCurrentMonthAccountHistory(int ACCT_ID)
        {

            return null;
            /* DateTime startDT = CommonLibrary.StartOfMonth(DateTime.Now);
             return db.TACCT_HIST.Where(x => x.ACCT_ID == ACCT_ID && x.TRANS_DTTM >= startDT).OrderByDescending(x => x.TRANS_DTTM).ToList();*/
        }

        public List<AccountHistory> getSelectedMonthAccountHistory(int ACCT_ID, string month, string year)
        {
            DataModel DBContext = new DataModel();
            return null;
           /* int intMonth = Convert.ToInt32(month);
            int intYear = Convert.ToInt32(year);
            DateTime firstDate = CommonLibrary.StartOfMonth(intYear, intMonth);
            DateTime lastDate = CommonLibrary.EndOfMonth(intYear, intMonth);
            return db.TACCT_HIST.Where(x => x.ACCT_ID == ACCT_ID && x.TRANS_DTTM >= firstDate && x.TRANS_DTTM <= lastDate).OrderByDescending(x => x.TRANS_DTTM).ToList(); */
        }

        public AccountHistory insertAccountHistory(int ACCT_ID, string TRANS_TCD, string TRANS_PAY_SRC_CD,
                                                   string TRANS_SRVC_TCD, decimal BAL_AFTR_TRANS, 
                                                   decimal TRANS_AMT, string TRANS_DESC)
        {
            try
            {
                var obj = new AccountHistory();

                obj.ACCT_ID = ACCT_ID;
                obj.TRANS_TCD = TRANS_TCD;
                obj.TRANS_PAY_SRC_CD = TRANS_PAY_SRC_CD;
                obj.TRANS_SRVC_TCD = TRANS_SRVC_TCD;
                obj.BAL_AFTR_TRANS = BAL_AFTR_TRANS;
                obj.TRANS_AMT = TRANS_AMT;
                obj.TRANS_DESC = TRANS_DESC;
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}