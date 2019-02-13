using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBP_CTRCT")]
    public class BusinessProcessContract
    {
        public BusinessProcessContract()
        {
            BP_CTRCT_EDT = DateTime.Now.Date;
        }

        [Key]
        [StringLength(11, ErrorMessage = "Le numéro de contrat doit avoir 10 caractères.", MinimumLength = 11)]
        [Display(Name = "Numéro Contrat")]
        public string BP_CTRCT_NBR { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [Display(Name = "Code Processus D'affaire")]
        public int BP_ID { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime BP_CTRCT_EDT { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime BP_CTRCT_XDT { get; set; }

        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string BP_CTRCT_CRT_USR_NBR { get; set; }

        public virtual BusinessProcess TBP { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual User TUSR { get; set; }
        private DalContext db = new DalContext();

        private string lang = "FRA";

        public List<BusinessProcessContract> getAllBusinessProcessContract(int BN)
        {
            var list = new List<BusinessProcessContract>();
            try
            {
                var busProcessCtrctList = db.TBP_CTRCT.Where(x => x.BN == BN).ToList();
                foreach(var item in busProcessCtrctList)
                {
                    if(checkServiceDisponibilityValidity(item.BP_ID, BN))
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public bool checkServiceDisponibilityValidity(int BP_ID, int BN)
        {
            string id = Convert.ToString(BN) + "" + Convert.ToString(BP_ID);
            var check = db.TBP_CTRCT.Find(id);
            if (check == null)
            {
                return false;
            }
            bool ServiceDisponibility = true;

            bool ServiceValidity;
            if (DateTime.Compare(check.BP_CTRCT_XDT, DateTime.Now.Date) > 0)
            {
                ServiceValidity = true;
            }
            else
            {
                ServiceValidity = false;
            }

            if(ServiceDisponibility && ServiceValidity)
            {
                return true;
            }
            return false;
        }

        public bool checkServiceDisponibility(string busCntrctID)
        {
            var check = db.TBP_CTRCT.Find(busCntrctID);
            if(check == null)
            {
                return false;
            }

            return true;
        }

        public bool checkServiceDisponibility(int BP_ID, int BN)
        {
            string id = Convert.ToString(BN) + "" + Convert.ToString(BP_ID);
            var check = db.TBP_CTRCT.Find(id);
            if (check == null)
            {
                return false;
            }
            return true;
        }

        public bool checkServiceValidity(int BP_ID, int BN)
        {
            string id = Convert.ToString(BN) + "" + Convert.ToString(BP_ID);
            var check = db.TBP_CTRCT.Find(id);
            if (check == null)
            {
                return false;
            }

            if (DateTime.Compare(check.BP_CTRCT_XDT, DateTime.Now.Date) > 0)
            {
                return true;
            }
            return false;
        }

        public bool checkServiceValidity(string busCntrctID)
        {
            var check = db.TBP_CTRCT.Find(busCntrctID);
            if (check == null)
            {
                return false;
            }

            if (DateTime.Compare(check.BP_CTRCT_XDT, DateTime.Now.Date) > 0)
            {
                return true;
            }
            return false;
        }
    }
}