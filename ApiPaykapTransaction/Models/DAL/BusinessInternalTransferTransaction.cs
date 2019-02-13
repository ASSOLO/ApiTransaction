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
    [Table("dbo.TBUS_INTRN_TRSF_TRANS")]
    public class BusinessInternalTransferTransaction
    {
        public BusinessInternalTransferTransaction()
        {
            TRANS_DT = DateTime.Now;
            TRANS_SCD = "00";
        }

        [Key]
        [Display(Name = "ID Transaction")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Le ID de l'employé Expéditeur est requis")]
        [Display(Name = "ID Employé Expéditeur")]
        public int FROM_BUS_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Expéditeur")]
        public string FROM_BUS_USR_NM { get; set; }

        [Required(ErrorMessage = "Le ID de l'employé Destinataire est requis")]
        [Display(Name = "ID Employé Destinataire")]
        public int TO_BUS_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le {0} doit compter au maximum 255 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Destinataire")]
        public string TO_BUS_USR_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 17)]
        [Display(Name = "Numéro Compte Expéditeur")]
        public string FROM_ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 17)]
        [Display(Name = "Numéro Compte Destinataire")]
        public string TO_ACCT_NBR { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Envoi")]
        public string FROM_CRCY_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 3)]
        [Display(Name = "Devise Reception")]
        public string TO_CRCY_CD { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Départ")]
        public decimal FROM_TRANS_AMT { get; set; }
        
        [Display(Name = "Montant Total Départ Texte")]
        [NotMapped]
        public string FROM_TRANS_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(FROM_CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(FROM_TRANS_AMT, FROM_CRCY_CD, cultureInfo);
            }
            set { }
        }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Destinataire")]
        public decimal TO_TRANS_AMT { get; set; }

        [Display(Name = "Montant Total Départ Texte")]
        [NotMapped]
        public string TO_TRANS_AMT_TXT
        {
            get
            {
                var obj = new CountryCurrency();
                string cultureInfo = obj.getCultureInfoByCurrencyCD(TO_CRCY_CD, "FRA");
                return CommonLibrary.displayFormattedCurrency(TO_TRANS_AMT, TO_CRCY_CD, cultureInfo);
            }
            set { }
        }

        [Required]
        [StringLength(2)]
        [Display(Name = "Statut Transaction")] //00- Transferred & Closed
        public string TRANS_SCD { get; set; }  

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TRANS_DT { get; set; }
        
        [Required]
        [StringLength(2)]
        [Display(Name = "Type Transaction")]  //01-Checkout Transfer     02 = Agency Transfer   
        public string TRANS_TCD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Description Transaction")]
        public string TRANS_DESC { get; set; }

        public virtual BusinessUser TBUS_USR { get; set; }

        public virtual BusinessUser TBUS_USR1 { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public BusinessInternalTransferTransaction createTransaction(int FROM_BUS_USR_NBR, string FROM_BUS_USR_NM,
                                     int TO_BUS_USR_NBR, string TO_BUS_USR_NM,
                                     string FROM_ACCT_NBR, string TO_ACCT_NBR,
                                     string FROM_CRCY_CD, string TO_CRCY_CD,
                                     decimal CRCY_XCHG_RT, decimal FROM_TRANS_AMT, decimal TO_TRANS_AMT,
                                     string TRANS_SCD, string TRANS_TCD, string TRANS_DESC)
        {
            try
            {
                var obj = new BusinessInternalTransferTransaction();

                obj.FROM_BUS_USR_NBR = FROM_BUS_USR_NBR;
                obj.FROM_BUS_USR_NM = FROM_BUS_USR_NM;
                obj.TO_BUS_USR_NBR = TO_BUS_USR_NBR;
                obj.TO_BUS_USR_NM = TO_BUS_USR_NM;
                obj.FROM_ACCT_NBR = FROM_ACCT_NBR;
                obj.TO_ACCT_NBR = TO_ACCT_NBR;
                obj.FROM_CRCY_CD = FROM_CRCY_CD;
                obj.TO_CRCY_CD = TO_CRCY_CD;
                obj.CRCY_XCHG_RT = CRCY_XCHG_RT;
                obj.FROM_TRANS_AMT = FROM_TRANS_AMT;
                obj.TO_TRANS_AMT = TO_TRANS_AMT;
                obj.TRANS_SCD = TRANS_SCD;
                obj.TRANS_TCD = TRANS_TCD;
                obj.TRANS_DESC = TRANS_DESC;
                //db.TTRANS_TRSF_CRDT_DBT.Add(obj);
                //db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public List<BusinessInternalTransferTransaction> getAllInternalTransferTransactionByBusUsrNbr(string usrNbr)
        {
            var list = new List<BusinessInternalTransferTransaction>();
            try
            {
                var newBusUsr = new BusinessUser();
                var busUsr = newBusUsr.getBusinessUserByUsrNbr(usrNbr);
                if (busUsr == null)
                {
                    return list;
                }
                
                //if (BUS_USR_TCD == "02")
                //{
                //    return db.TBUS_INTRN_TRSF_TRANS.Where(x => x.FROM_BUS_USR_NBR == busUsr.BUS_USR_NBR).OrderByDescending(y => y.TRANS_ID).ToList();
                //}

                //if (BUS_USR_TCD == "03")
                //{
                //    return db.TBUS_INTRN_TRSF_TRANS.Where(x => x.FROM_BUS_USR_NBR == busUsr.BUS_USR_NBR || 
                //                                               x.TO_BUS_USR_NBR == busUsr.BUS_USR_NBR)
                //                                               .OrderByDescending(y => y.TRANS_ID).ToList();
                //}

                //if (BUS_USR_TCD == "04")
                //{
                //    return db.TBUS_INTRN_TRSF_TRANS.Where(x => x.TO_BUS_USR_NBR == busUsr.BUS_USR_NBR).OrderByDescending(y => y.TRANS_ID).ToList();
                //}
                return list;
            }
            catch
            {
                return list;
            }
        }
    }
}