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
    [Table("dbo.TBUS_CMSN")]
    public class BusinessCommission
    {
        public BusinessCommission()
        {
            BUS_CMSN_DT = DateTime.Now;
        }

        [Key]
        [Display(Name = "ID Commission Entreprise")]
        public int BUS_CMSN_ID { get; set; }

        [Display(Name = "1er ID Commission Entreprise")]
        public int FST_BUS_CMSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Min")]
        public decimal FROM_AMT { get; set; }

        [Display(Name = "Montant Min Texte")]
        [NotMapped]
        public string FROM_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FROM_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Max")]
        public decimal TO_AMT { get; set; }

        [Display(Name = "Montant Max Texte")]
        [NotMapped]
        public string TO_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(TO_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Commission")]
        public decimal FIX_CMSN_AMT { get; set; }

        [Display(Name = "Montant Commission Texte")]
        [NotMapped]
        public string FIX_CMSN_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FIX_CMSN_AMT, CRCY_CD, cultureInfo);
            }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Code Devise")]
        public string CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "% Commission")]
        public decimal PRCNT_CMSN_RT { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string PRCNT_CMSN_RT_TXT
        {
            get
            {
                decimal percent = PRCNT_CMSN_RT * 100;
                return percent.ToString("N2") + "%";
            }
        }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Commission")] //1 = fixed, 2=%
        public string BUS_CMSN_TCD { get; set; }

        [Display(Name = "Type CMSN")]
        [NotMapped]
        public string BUS_CMSN_TCD_TXT
        {
            get
            {
                if (BUS_CMSN_TCD == "1")
                {
                    return "Fixe";
                }
                return "%";
            }
        }


        [Required]
        [StringLength(2)]
        [Display(Name = "Service Commission")]   //01-Transfer    02-Bill Payment Registered Recipient   
                                                 //03-Bill Payment No Registered Recipient      
                                                 //04- Remote Payment To Registered Recipient 05-    Deposit    06- Withdrawal
        public string BUS_CMSN_SCD { get; set; }


        [Display(Name = "Service Commission Texte")]
        [NotMapped]
        public string BUS_CMSN_SCD_TXT
        {
            get
            {
                if (BUS_CMSN_SCD == "01")
                {
                    return "Transfert";
                }
                else if (BUS_CMSN_SCD == "02" || BUS_CMSN_SCD == "03")
                {
                    return "Paiement de facture";
                }
                else if (BUS_CMSN_SCD == "04")
                {
                    return "Paiement";
                }
                else if (BUS_CMSN_SCD == "05")
                {
                    return "Dépôt d'argent";
                }
                else if (BUS_CMSN_SCD == "06")
                {
                    return "Retrait d'argent";
                }
                return "Transaction";
            }
        }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime BUS_CMSN_DT { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Service Commission")]
        public string BUS_OFR_SRVC_TO_OWN_CLT_IND { get; set; }


        //01 TRANSFER
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Commission")]
        [NotMapped]
        public decimal FIX_CMSN_AMT_TRSF { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "% Commission")]
        [NotMapped]
        public decimal PRCNT_CMSN_RT_TRSF { get; set; }

        //05 deposit
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Commission")]
        [NotMapped]
        public decimal FIX_CMSN_AMT_DPST { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "% Commission")]
        [NotMapped]
        public decimal PRCNT_CMSN_RT_DPST { get; set; }

        //06 withdrawal
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Commission")]
        [NotMapped]
        public decimal FIX_CMSN_AMT_WDRW { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "% Commission")]
        [NotMapped]
        public decimal PRCNT_CMSN_RT_WDRW { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual Country TCTRY { get; set; }

        public virtual Currency TCRCY { get; set; }

        private DalContext db = new DalContext();

        public BusinessCommission createBusinessCommission(int FST_BUS_CMSN_ID,
                                            decimal FROM_AMT, decimal TO_AMT, int BN,
                                            string CTRY_CD, decimal FIX_CMSN_AMT, string CRCY_CD,
                                            decimal PRCNT_CMSN_RT, string BUS_CMSN_TCD, string BUS_CMSN_SCD,
                                            string BUS_OFR_SRVC_TO_OWN_CLT_IND)
        {
            try
            {
                var obj = new BusinessCommission();

                obj.FST_BUS_CMSN_ID = FST_BUS_CMSN_ID;
                obj.FROM_AMT = FROM_AMT;
                obj.TO_AMT = TO_AMT;
                obj.BN = BN;
                obj.CTRY_CD = CTRY_CD;
                obj.FIX_CMSN_AMT = FIX_CMSN_AMT;
                obj.CRCY_CD = CRCY_CD;
                obj.PRCNT_CMSN_RT = PRCNT_CMSN_RT;
                obj.BUS_CMSN_TCD = BUS_CMSN_TCD;
                obj.BUS_CMSN_SCD = BUS_CMSN_SCD;
                db.TBUS_CMSN.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public BusinessCommission getOneBusinessCommission(decimal transAmt, int BN, string CTRY_CD,
                                        string CRCY_CD, string BUS_CMSN_SCD, string BUS_OFR_SRVC_TO_OWN_CLT_IND)
        {
            try
            {
                var objList = db.TBUS_CMSN.Where(x => x.BN == BN && x.CTRY_CD == CTRY_CD && x.CRCY_CD == CRCY_CD &&
                                                      x.BUS_CMSN_SCD == BUS_CMSN_SCD &&
                                                      x.BUS_OFR_SRVC_TO_OWN_CLT_IND == BUS_OFR_SRVC_TO_OWN_CLT_IND &&
                                                      x.FROM_AMT <= transAmt && x.TO_AMT >= transAmt).ToList();
                if (objList.Count() == 0)
                {
                    return null;
                }
                var obj = objList[0];
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public decimal getBusinessCommissionAmount(decimal transAmt, int BN, string CTRY_CD,
                                                   string CRCY_CD, string BUS_CMSN_SCD, decimal feeAmt,
                                                   string BUS_OFR_SRVC_TO_OWN_CLT_IND)
        {
            try
            {
                var cmsn = getOneBusinessCommission(transAmt, BN, CTRY_CD, CRCY_CD, BUS_CMSN_SCD, BUS_OFR_SRVC_TO_OWN_CLT_IND);
                if (cmsn == null)
                {
                    return -1.0m;
                }

                if (cmsn.BUS_CMSN_TCD == "1")
                {
                    return cmsn.FIX_CMSN_AMT;
                }

                if (cmsn.BUS_CMSN_TCD == "2")
                {
                    return cmsn.PRCNT_CMSN_RT * feeAmt;
                }
                return -1.0m;
            }
            catch
            {
                return -1.0m;
            }
        }

        public List<BusinessCommission> getAllBusinessCommission(int BN, string CTRY_CD)
        {
            var list = new List<BusinessCommission>();
            try
            {
                return db.TBUS_CMSN.Where(x => x.BN == BN && x.CTRY_CD == CTRY_CD).ToList();
            }
            catch
            {
                return list;
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Web.Mvc;
//using System.Data.Entity;

//namespace pkpApp.Models.DAL
//{
//    [Table("dbo.TBUS_CMSN")]
//    public class BusinessCommission
//    {
//        public BusinessCommission()
//        {
//            BUS_CMSN_DT = DateTime.Now;
//        }

//        [Key]
//        [Display(Name = "ID Commission Entreprise")]
//        public int BUS_CMSN_ID { get; set; }

//        [Display(Name = "1er ID Commission Entreprise")]
//        public int FST_BUS_CMSN_ID { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Min")]
//        public decimal FROM_AMT { get; set; }

//        [Display(Name = "Montant Min Texte")]
//        [NotMapped]
//        public string FROM_AMT_TXT
//        {
//            get
//            {
//                var obj = new CountryCurrency();
//                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
//                return CommonLibrary.displayFormattedCurrency(FROM_AMT, CRCY_CD, cultureInfo);
//            }
//        }

//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Max")]
//        public decimal TO_AMT { get; set; }

//        [Display(Name = "Montant Max Texte")]
//        [NotMapped]
//        public string TO_AMT_TXT
//        {
//            get
//            {
//                var obj = new CountryCurrency();
//                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
//                return CommonLibrary.displayFormattedCurrency(TO_AMT, CRCY_CD, cultureInfo);
//            }
//        }

//        [Display(Name = "Numéro Entreprise")]
//        public int BN { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [DataType(DataType.Text)]
//        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
//        [Display(Name = "Code Pays")]
//        public string CTRY_CD { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Commission")]
//        public decimal FIX_CMSN_AMT { get; set; }

//        [Display(Name = "Montant Commission Texte")]
//        [NotMapped]
//        public string FIX_CMSN_AMT_TXT
//        {
//            get
//            {
//                var obj = new CountryCurrency();
//                string cultureInfo = obj.getCultureInfoByCurrencyCD(CRCY_CD, "FRA");
//                return CommonLibrary.displayFormattedCurrency(FIX_CMSN_AMT, CRCY_CD, cultureInfo);
//            }
//        }

//        [Required(ErrorMessage = "Le {0} est obligatoire.")]
//        [DataType(DataType.Text)]
//        [StringLength(3, ErrorMessage = "Le {0} doit compter {2} caractères.", MinimumLength = 3)]
//        [Display(Name = "Code Devise")]
//        public string CRCY_CD { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "% Commission")]
//        public decimal PRCNT_CMSN_RT { get; set; }

//        [Display(Name = "Type CMSN")]
//        [NotMapped]
//        public string PRCNT_CMSN_RT_TXT
//        {
//            get
//            {
//                decimal percent = PRCNT_CMSN_RT * 100;
//                return percent.ToString("N2") + "%";
//            }
//        }

//        [Required]
//        [StringLength(1)]
//        [Display(Name = "Type Commission")] //1 = fixed, 2=%
//        public string BUS_CMSN_TCD { get; set; }

//        [Display(Name = "Type CMSN")]
//        [NotMapped]
//        public string BUS_CMSN_TCD_TXT
//        {
//            get
//            {
//                if (BUS_CMSN_TCD == "1")
//                {
//                    return "Fixe";
//                }
//                return "%";
//            }
//        }


//        [Required]
//        [StringLength(2)]
//        [Display(Name = "Service Commission")]   //01-Transfer    02-Bill Payment Registered Recipient   
//                                                 //03-Bill Payment No Registered Recipient      
//                                                 //04- Remote Payment To Registered Recipient 05-    Deposit    06- Withdrawal
//        public string BUS_CMSN_SCD { get; set; }


//        [Display(Name = "Service Commission Texte")]
//        [NotMapped]
//        public string BUS_CMSN_SCD_TXT
//        {
//            get
//            {
//                if(BUS_CMSN_SCD == "01")
//                {
//                    return "Transfert";
//                }
//                else if (BUS_CMSN_SCD == "02" || BUS_CMSN_SCD == "03")
//                {
//                    return "Paiement de facture";
//                }
//                else if (BUS_CMSN_SCD == "04")
//                {
//                    return "Paiement";
//                }
//                else if (BUS_CMSN_SCD == "05")
//                {
//                    return "Dépôt d'argent";
//                }
//                else if (BUS_CMSN_SCD == "06")
//                {
//                    return "Retrait d'argent";
//                }
//                return "Transaction";
//            }
//        }

//        [Required]
//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
//        [DataType(DataType.Date)]
//        [Display(Name = "Date")]
//        public DateTime BUS_CMSN_DT { get; set; }


//        //01 TRANSFER
//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Commission")]
//        [NotMapped]
//        public decimal FIX_CMSN_AMT_TRSF { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "% Commission")]
//        [NotMapped]
//        public decimal PRCNT_CMSN_RT_TRSF { get; set; }

//        //05 deposit
//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Commission")]
//        [NotMapped]
//        public decimal FIX_CMSN_AMT_DPST { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "% Commission")]
//        [NotMapped]
//        public decimal PRCNT_CMSN_RT_DPST { get; set; }

//        //06 withdrawal
//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "Montant Commission")]
//        [NotMapped]
//        public decimal FIX_CMSN_AMT_WDRW { get; set; }

//        [Required(ErrorMessage = "Le {0} est obligatoire")]
//        [Range(0, 2, ErrorMessage = "Le % doit être compris entre 0 et 2")]
//        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
//        [DisplayFormat(DataFormatString = "{0:0.0000}")]
//        [Display(Name = "% Commission")]
//        [NotMapped]
//        public decimal PRCNT_CMSN_RT_WDRW { get; set; }


//        public virtual Business TBUS { get; set; }

//        public virtual Country TCTRY { get; set; }

//        public virtual Currency TCRCY { get; set; }

//        private DalContext db = new DalContext();

//        public BusinessCommission createBusinessCommission(int FST_BUS_CMSN_ID,
//                                            decimal FROM_AMT, decimal TO_AMT, int BN,
//                                            string CTRY_CD, decimal FIX_CMSN_AMT, string CRCY_CD,
//                                            decimal PRCNT_CMSN_RT, string BUS_CMSN_TCD, string BUS_CMSN_SCD)
//        {
//            try
//            {
//                var obj = new BusinessCommission();

//                obj.FST_BUS_CMSN_ID = FST_BUS_CMSN_ID;
//                obj.FROM_AMT = FROM_AMT;
//                obj.TO_AMT = TO_AMT;
//                obj.BN = BN;
//                obj.CTRY_CD = CTRY_CD;
//                obj.FIX_CMSN_AMT = FIX_CMSN_AMT;
//                obj.CRCY_CD = CRCY_CD;
//                obj.PRCNT_CMSN_RT = PRCNT_CMSN_RT;
//                obj.BUS_CMSN_TCD = BUS_CMSN_TCD;
//                obj.BUS_CMSN_SCD = BUS_CMSN_SCD;
//                db.TBUS_CMSN.Add(obj);
//                db.SaveChanges();
//                return obj;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public BusinessCommission getOneBusinessCommission(decimal transAmt, int BN, string CTRY_CD, string CRCY_CD, string BUS_CMSN_SCD)
//        {
//            try
//            {
//                var objList = db.TBUS_CMSN.Where(x => x.BN == BN && x.CTRY_CD == CTRY_CD &&  x.CRCY_CD == CRCY_CD && 
//                                                      x.BUS_CMSN_SCD == BUS_CMSN_SCD && 
//                                                      x.FROM_AMT <= transAmt && x.TO_AMT >= transAmt).ToList();
//                if (objList.Count() == 0)
//                {
//                    return null;
//                }
//                var obj = objList[0];
//                return obj;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public decimal getBusinessCommissionAmount(decimal transAmt, int BN, string CTRY_CD, string CRCY_CD, string BUS_CMSN_SCD, decimal feeAmt)
//        {
//            try
//            {
//                var cmsn = getOneBusinessCommission(transAmt, BN, CTRY_CD, CRCY_CD, BUS_CMSN_SCD);
//                if (cmsn == null)
//                {
//                    return -0.0m;
//                }

//                if (cmsn.BUS_CMSN_TCD == "1")
//                {
//                    return cmsn.FIX_CMSN_AMT;
//                }

//                if (cmsn.BUS_CMSN_TCD == "2")
//                {
//                    return cmsn.PRCNT_CMSN_RT * feeAmt;
//                }
//                return -0.0m;
//            }
//            catch
//            {
//                return -0.0m;
//            }
//        }

//        public List<BusinessCommission> getAllBusinessCommission(int BN, string CTRY_CD)
//        {
//            var list = new List<BusinessCommission>();
//            try
//            {
//                return db.TBUS_CMSN.Where(x => x.BN == BN && x.CTRY_CD == CTRY_CD).ToList();
//            }
//            catch
//            {
//                return list;
//            }
//        }
//    }
//}
