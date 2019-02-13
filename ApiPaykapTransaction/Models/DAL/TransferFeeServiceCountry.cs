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
    [Table("dbo.TTRSF_FEE_SERV_CTRY")]
    public class TransferFeeServiceCountry
    {
        [Key]
        [Display(Name = "ID Frais Service Transfert")]
        public int TRSF_FEE_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Frais Transaction")]
        public int TRANS_FEE_ID { get; set; }

        [Required(ErrorMessage = "Le service d'envoi est requis")]
        [Display(Name = "Comment Envoyer ?")]
        public int FROM_TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le service de reception est requis")]
        [Display(Name = "Comment Recevoir ?")]
        public int TO_TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 3)]
        [Display(Name = "Pays Envoi")]
        public string FROM_CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 3)]
        [Display(Name = "Pays Reception")]
        public string TO_CTRY_CD { get; set; }

        public virtual Country TCTRY { get; set; }

        public virtual Country TCTRY1 { get; set; }

        public virtual TransactionFee TTRANS_FEE { get; set; }

        public virtual TransferService TTRSF_SERV { get; set; }

        public virtual TransferService TTRSF_SERV1 { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public List<SelectListItem> getAllFromCountryServiceCountry(string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var ctryObj = new Country();
                var list = from srvc in db.TTRSF_FEE_SERV_CTRY
                           join ctry in db.TCTRY on srvc.FROM_CTRY_CD equals ctry.CTRY_CD
                           select new { CTRY_CD = srvc.FROM_CTRY_CD, CTRY_NM = ctry.FRA_CTRY_NM };
                list = list.AsQueryable().Distinct();

                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (item.CTRY_CD == selectedValue)
                        {
                            items.Add(new SelectListItem { Text = item.CTRY_NM, Value = item.CTRY_CD, Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = item.CTRY_NM, Value = item.CTRY_CD, Selected = false });
                        }
                    }
                }
                return items;
            }
            catch
            {
                return items;
            }
        }

        //To Currency for money transfer, 3 param are needed
        //sending country, receiving country, 
        //get either sending currency or receiving country
        public List<SelectListItem> getCurrencyForMoneyTransfer(string fromCtryCD, string toCtryCD, string MnytTCD)
        {
            var list = new List<SelectListItem>();
            var query = (from srvcCtry in db.TTRSF_FEE_SERV_CTRY
                        join fee in db.TTRANS_FEE on srvcCtry.TRANS_FEE_ID equals fee.TRANS_FEE_ID
                        where (srvcCtry.FROM_CTRY_CD == fromCtryCD && srvcCtry.TO_CTRY_CD == toCtryCD)
                        select new { FROM_CRCY_CD = fee.FROM_CRCY_CD, TO_CRCY_CD = fee.TO_CRCY_CD }).Distinct().ToList();

            //var query = (from row in db.TTRSF_FEE_SERV_CTRY.Where(x => x.FROM_CTRY_CD == fromCtryCD && x.TO_CTRY_CD == toCtryCD).ToList()
            //                select new { FROM_CRCY_CD = row.FROM_CRCY_CD, TO_CRCY_CD = row.TO_CRCY_CD }).Distinct().ToList();

            foreach (var row in query)
            {
                if (MnytTCD == "1")
                {
                    list.Add(new SelectListItem { Text = row.FROM_CRCY_CD, Value = row.FROM_CRCY_CD, Selected = true });
                }
                else
                {
                    list.Add(new SelectListItem { Text = row.TO_CRCY_CD, Value = row.TO_CRCY_CD, Selected = true });
                }

            }
            return list;
        }

    }
}
