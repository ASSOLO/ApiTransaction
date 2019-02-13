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
    [Table("dbo.TBUS_USR_EXCP_ROL")]
    public class BusinessUserExceptionalRole
    {
        public  BusinessUserExceptionalRole()
        {
            BUS_USR_EXCP_ROL_EXPY_IND = "0";
            BUS_USR_EXCP_ROL_EDT = DateTime.Now;
            BUS_USR_EXCP_ROL_XDT = Convert.ToDateTime("9999-12-31");
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BUS_USR_EXCP_ROL_ID { get; set; }

        [Display(Name = "ID Employé")]
        public int BUS_USR_NBR { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }
        
        [StringLength(5, ErrorMessage = "Le numéro d'agence doit avoir 5 caractères.", MinimumLength = 5)]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [Display(Name = "Code Agence")]
        public string BUS_AGCY_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire.")]
        [StringLength(1, ErrorMessage = "La {0} doit compter au maximum 1 caractères.")]
        [Range(0, 1, ErrorMessage = "La valeur doit être soit 0 soit 1")]
        [Display(Name = "Expiration ?")]
        public string BUS_USR_EXCP_ROL_EXPY_IND { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Effective")]
        public DateTime BUS_USR_EXCP_ROL_EDT { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime BUS_USR_EXCP_ROL_XDT { get; set; }
        
        [Required]
        [StringLength(2)]
        [Display(Name = "Type Transaction")]  //01-Transfer    02-Bill Payment Registered Recipient   
                                              //03-Bill Payment No Registered Recipient      
                                              //04- Remote Payment To Registered Recipient 05-    Deposit    06- Withdrawal
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }

        public virtual BusinessAgency TBUS_AGCY { get; set; }

        public virtual BusinessUser TBUS_USR { get; set; }
        private DalContext db = new DalContext();
        private string lang = "FRA";

        public string addCashierToWithdrawalWithoutPinRole(BusinessUser busUsr, string BUS_AGCY_NBR, string SRVC_TCD)
        {
            try
            {
                var check = db.TBUS_USR_EXCP_ROL.Where(x => x.BUS_USR_NBR == busUsr.BUS_USR_NBR && x.BN == busUsr.BN &&
                                                x.BUS_AGCY_NBR == busUsr.BUS_AGCY_NBR && x.TRANS_TRSF_CRDT_DBT_TCD == SRVC_TCD).ToList();
                if (check.Count() != 0)
                {
                    return "already_in_role";
                }

                var newObj = new BusinessUserExceptionalRole();

                newObj.BUS_USR_NBR = busUsr.BUS_USR_NBR;
                newObj.BN = busUsr.BN;
                newObj.BUS_AGCY_NBR = BUS_AGCY_NBR;
                newObj.TRANS_TRSF_CRDT_DBT_TCD = SRVC_TCD;
                db.TBUS_USR_EXCP_ROL.Add(newObj);
                db.SaveChanges();
                return "true";
            }
            catch
            {
                return null;
            }
        }

        public string editCashierToWithdrawalWithoutPinRole(int BUS_USR_EXCP_ROL_ID, BusinessUser busUsr, string BUS_AGCY_NBR, string SRVC_TCD)
        {
            try
            {
                var check = db.TBUS_USR_EXCP_ROL.Where(x => x.BUS_USR_NBR == busUsr.BUS_USR_NBR && x.BN == busUsr.BN &&
                                                x.BUS_AGCY_NBR == busUsr.BUS_AGCY_NBR && x.TRANS_TRSF_CRDT_DBT_TCD == SRVC_TCD).ToList();
                if (check.Count() != 0)
                {
                    return "already_in_role";
                }

                var obj = db.TBUS_USR_EXCP_ROL.Find(BUS_USR_EXCP_ROL_ID);
                if (obj == null)
                {
                    return null;
                }

                obj.BUS_USR_NBR = busUsr.BUS_USR_NBR;
                obj.BN = busUsr.BN;
                obj.BUS_AGCY_NBR = BUS_AGCY_NBR;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return "true";
            }
            catch
            {
                return null;
            }
        }

        public string deletCashierToWithdrawalWithoutPinRole(int BUS_USR_EXCP_ROL_ID)
        {
            try
            {
                var busUsrExcpRole = db.TBUS_USR_EXCP_ROL.Find(BUS_USR_EXCP_ROL_ID);
                if (busUsrExcpRole == null)
                {
                    return "not_found";
                }

                db.TBUS_USR_EXCP_ROL.Remove(busUsrExcpRole);
                db.SaveChanges();
                return "true";
            }
            catch
            {
                return null;
            }
        }

        public BusinessUserExceptionalRole getOneCashierToWithdrawalWithoutPinRole(int BUS_USR_EXCP_ROL_ID)
        {
            try
            {
                var busUsrExcpRole = db.TBUS_USR_EXCP_ROL.Find(BUS_USR_EXCP_ROL_ID);
                if (busUsrExcpRole == null)
                {
                    return null;
                }
                return busUsrExcpRole;
            }
            catch
            {
                return null;
            }
        }

        public bool checkBusinessCashierInWithdrawalWithoutPinRoleByBusUsr(BusinessUser busUsr, string SRVC_TCD)
        {
            try
            {
                var busUsrExcpRoleList = db.TBUS_USR_EXCP_ROL.Where(x => x.BUS_USR_NBR == busUsr.BUS_USR_NBR && x.BN == busUsr.BN &&
                                                x.BUS_AGCY_NBR == busUsr.BUS_AGCY_NBR && x.TRANS_TRSF_CRDT_DBT_TCD == SRVC_TCD).ToList();
                if (busUsrExcpRoleList.Count() == 0)
                {
                    return false;
                }

                var busUsrExcpRole = busUsrExcpRoleList[0];
                if (busUsrExcpRole == null)
                {
                    return false;
                }

                if (DateTime.Compare(busUsrExcpRole.BUS_USR_EXCP_ROL_XDT, DateTime.Now.Date) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<BusinessUserExceptionalRoleViewModel> getAllBusinessCashierWithExceptionalRoleByDirector(string usrNbr, string srvcTCD)
        {
            List<BusinessUserExceptionalRoleViewModel> items = new List<BusinessUserExceptionalRoleViewModel>();
            var busUsrList = db.TBUS_USR.Where(x => x.BUS_EMPE_USR_NBR == usrNbr && x.BUS_USR_TCD == "03").ToList();
            if (busUsrList.Count() == 0)
            {
                return items;
            }

            foreach (var item in busUsrList)
            {
                var busUsrCashierList = db.TBUS_USR_EXCP_ROL.Where(x => x.BN == item.BN && x.BUS_AGCY_NBR == item.BUS_AGCY_NBR && x.TRANS_TRSF_CRDT_DBT_TCD == srvcTCD).ToList();
                foreach (var itemCashier in busUsrCashierList)
                {
                    var excpAuthModel = new BusinessUserExceptionalRoleViewModel();
                    excpAuthModel.busUsrExcpRole = itemCashier;

                    var busAgcy = new BusinessAgency();
                    var agcy = busAgcy.getOneBusinessAgencyByAgcyNbr(itemCashier.BN, itemCashier.BUS_AGCY_NBR);
                    if (agcy != null)
                    {
                        excpAuthModel.BUS_USR_AGCY_NM = agcy.BUS_AGCY_NM;
                    }

                    var busUsr = db.TBUS_USR.Find(itemCashier.BUS_USR_NBR);
                    if (busUsr != null)
                    {
                        var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                        if (usr != null)
                        {
                            excpAuthModel.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                        }
                    }
                    items.Add(excpAuthModel);
                }
            }
            return items;
        }

        public List<BusinessUserExceptionalRoleViewModel> getAllBusinessCashierWithExceptionalRoleByBN(int BN, string srvcTCD)
        {
            List<BusinessUserExceptionalRoleViewModel> items = new List<BusinessUserExceptionalRoleViewModel>();
            var busUsrCashierList = db.TBUS_USR_EXCP_ROL.Where(x => x.BN == BN && x.TRANS_TRSF_CRDT_DBT_TCD == srvcTCD).ToList();
            if (busUsrCashierList.Count() == 0)
            {
                return items;
            }

            foreach (var itemCashier in busUsrCashierList)
            {
                var excpAuthModel = new BusinessUserExceptionalRoleViewModel();
                excpAuthModel.busUsrExcpRole = itemCashier;

                var busAgcy = new BusinessAgency();
                var agcy = busAgcy.getOneBusinessAgencyByAgcyNbr(itemCashier.BN, itemCashier.BUS_AGCY_NBR);
                if (agcy != null)
                {
                    excpAuthModel.BUS_USR_AGCY_NM = agcy.BUS_AGCY_NM;
                }

                var busUsr = db.TBUS_USR.Find(itemCashier.BUS_USR_NBR);
                if (busUsr != null)
                {
                    var usr = db.TUSR.Find(busUsr.BUS_EMPE_USR_NBR);
                    if (usr != null)
                    {
                        excpAuthModel.BUS_USR_FUL_NM = usr.USR_FUL_NM;
                    }
                }
                items.Add(excpAuthModel);
            }
            return items;
        }
    }
}
