using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TTRSF_SERV_CTRY")]
    public class TransferServiceCountry
    {
        public TransferServiceCountry()
        {
            LAST_UPDT_DT = DateTime.Now;
        }

        [Key]
        [Display(Name = "Code Service Pour Un Pays")]
        public int TRSF_SERV_CTRY_ID { get; set; }

        [Display(Name = "Code Service")]
        public int TRSF_SERV_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Province")]
        public int PROV_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Type Transfert d'Argent")]
        public string TRSF_TCD { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Dernière Mise à jour")]
        public DateTime LAST_UPDT_DT { get; set; }
        
        public virtual Country TCTRY { get; set; }
        public virtual TransferService TTRSF_SERV { get; set; }
        public virtual Province TPROV { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";
        
        public List<SelectListItem> getAllFromServiceCountry(string fromToTCD, string selectedValue)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                var ctryObj = new Country();
                var list = from srvc in db.TTRSF_SERV_CTRY
                           join ctry in db.TCTRY on srvc.CTRY_CD equals ctry.CTRY_CD
                           where srvc.TRSF_TCD == fromToTCD 
                           select new { srvc.CTRY_CD};
                list.Distinct();

                if (list.Count() == 0)
                {
                    return items;
                }
                else
                {
                    foreach (var item in list)
                    {
                        var newCtry = db.TCTRY.Find(item.CTRY_CD);
                        string ctryNM = newCtry.FRA_CTRY_NM;
                        if (item.CTRY_CD == selectedValue)
                        {
                            items.Add(new SelectListItem { Text = ctryNM, Value = item.CTRY_CD, Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = ctryNM, Value = item.CTRY_CD, Selected = false });
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

        //get all countries from and to
        public SelectList getAllCountryForMoneyTransfer(string selectedValue, string fromTo)
        {
            if (lang == "FRA")
            {
                using (var context = new DalContext())
                {
                    var fromToParam = new SqlParameter("@FromTo", fromTo);
                    string sqlQuery = @"select DISTINCT ctry.CTRY_CD MAP_CTRY_CD, FRA_CTRY_NM MAP_CTRY_NM from TTRSF_SERV_CTRY srvc 
                                        join TCTRY ctry on ctry.CTRY_CD = srvc.CTRY_CD 
                                        where TRSF_TCD = @FromTo";
                    var dataList = context.Database.SqlQuery<MappingServiceAndCountry>(sqlQuery, fromToParam).ToList();
                    return (new SelectList(dataList, "MAP_CTRY_CD", "MAP_CTRY_NM", selectedValue));
                }
            }
            else
            {
                return null;
            }
        }

        internal class MappingServiceAndCountry
        {
            public string MAP_CTRY_CD { get; set; }
            public string MAP_CTRY_NM { get; set; }
        }
                
        public List<SelectListItem> getAllMnytServiceByCountry(int selectedValue, string ctryCD, string TRSFTCD)
        {
            if (lang == "FRA")
            {
                var list = new List<SelectListItem>();
                var dataList = (from row in db.TTRSF_SERV_CTRY.Where(x => x.CTRY_CD == ctryCD && x.TRSF_TCD == TRSFTCD)
                                select new
                                {
                                    TRSF_SERV_ID = row.TRSF_SERV_ID,
                                    FRA_TRSF_SERV_NM = row.TTRSF_SERV.FRA_TRSF_SERV_NM
                                }).Distinct().ToList();

                foreach (var row in dataList)
                {
                    string strTRSF_SERV_ID = Convert.ToString(row.TRSF_SERV_ID);
                    if (row.TRSF_SERV_ID == selectedValue)
                    {
                        list.Add(new SelectListItem { Text = row.FRA_TRSF_SERV_NM, Value = strTRSF_SERV_ID, Selected = true });
                    }
                    else
                    {
                        list.Add(new SelectListItem { Text = row.FRA_TRSF_SERV_NM, Value = strTRSF_SERV_ID, Selected = false });
                    }
                };
                return list;
            }
            else {
                return null; }
        }

        public bool checkOneMnytServiceByCountry(string ctryCD, int transSrvcID, string TRSFTCD)
        {
            var objList = db.TTRSF_SERV_CTRY.Where(x => x.CTRY_CD == ctryCD && 
                                                   x.TRSF_SERV_ID == transSrvcID && x.TRSF_TCD == TRSFTCD).ToList();
            if(objList.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}