using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using pkpApp.Models.DAL;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using ApiPaykapTransaction.Models.DAL;

namespace ApiPaykapTransaction.Models
{
    public class UserAccountManageViewModels
    {
    }

    //public class UserIndividualRegister  ApiPaykapTransaction.Models.DAL
    //{
    //    public int Id { get; set; }
    //    public User IndUser { get; set; }
    //    public Contact ContactUser { get; set; }
    //    public RegisterViewModel RegisterIndUser { get; set; }
    //    public Card card { get; set; }

    //    [Required(ErrorMessage = "Accepter les conditions de création de compte PayKap est obligatoire")]
    //    [Display(Name = "Conditions Creation")]
    //    public bool RecipientAcceptance { get; set; }

    //    [Display(Name = "ID Session Transaction")]
    //    public string TRANS_SSN_SECR_ID_TXT { get; set; }

    //    [Display(Name = "Contexte De Création")]
    //    public string registerContextCode { get; set; } // 1= Normal register, 2 = remote payment register, 3 = start external transaction

    //    public UserIndividualRegister()
    //    {
    //        IndUser = new User();
    //        ContactUser = new Contact();
    //        RegisterIndUser = new RegisterViewModel();
    //        card = new Card();
    //    }
    //}

    public class AccountBusinessServiceModel
    {
        [Key]
        public int ACCT_ID { get; set; }
        public string ACCT_NBR { get; set; }
        public string ACCT_NM { get; set; }
        public string ACCT_BAL { get; set; }
        public string ACCT_BUS_SRVC_CD { get; set; }
    }

    public class UserIndividualRegister
    {
        public int Id { get; set; }
        public User IndUser { get; set; }
        public Contact ContactUser { get; set; }
        public Card card { get; set; }
        public RegisterViewModel RegisterIndUser { get; set; }

        [Required(ErrorMessage = "Accepter les conditions de création de compte PayKap est obligatoire")]
        [Display(Name = "Conditions Creation")]
        public bool RecipientAcceptance { get; set; }

        [Display(Name = "Contexte De Création")]
        public string registerContextCode { get; set; } // 1= Normal register, 2 = remote payment register, 3 = start external transaction

        [Display(Name = "ID Session Transaction")]
        public string TRANS_SSN_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Code Promo")]
        [StringLength(8, ErrorMessage = "Le code promo doit compter avoir exactement 8 caractères.", MinimumLength = 8)]
        public string PROMO_CODE { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        public UserIndividualRegister()
        {
            IndUser = new User();
            ContactUser = new Contact();
            RegisterIndUser = new RegisterViewModel();
            card = new Card();
        }
    }

    public class ExternalCard
    {
        public int Id { get; set; }
        public Card card { get; set; }

        [Display(Name = "ID Session Transaction")]
        public long TRANS_SSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }

        public ExternalCard()
        {
            card = new Card();
        }
    }

    public class LoginDataModel
    {
        public int Id { get; set; }

        public Card card { get; set; }

        public User tUser { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public LoginDataModel()
        {
            card = new Card();
            tUser = new User();
        }
    }

    public class ExternalConnexionLog
    {
        public int Id { get; set; }
        public ConnexionLog cnxLog { get; set; }

        [Display(Name = "ID Session Transaction")]
        public long TRANS_SSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }

        [Required(ErrorMessage = "La question de sécurité 1 est obligatoire.")]
        [Display(Name = "Question Sécurité 1")]
        public int QUES1 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 2 est obligatoire.")]
        [Display(Name = "Question Sécurité 2")]
        public int QUES2 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 3 est obligatoire.")]
        [Display(Name = "Question Sécurité 3")]
        public int QUES3 { get; set; }

        public ExternalConnexionLog()
        {
            cnxLog = new ConnexionLog();
        }
    }

    public class BusinessRegister
    {
        public int Id { get; set; }
        public Business Business { get; set; }
        public Contact BusinessContact { get; set; }
        public BusinessAgency BusinessAgency { get; set; }
        public BusinessRegister()
        {
            Business = new Business();
            BusinessContact = new Contact();
            BusinessAgency = new BusinessAgency();
        }
    }

    public class UserBusinessRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le mot de passe doit comporter entre 8 et 20 caractères.", MinimumLength = 8)]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%*]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre majuscule, une lettre minuscule, un chiffre et un de ces caractères spéciaux (@#$%*).")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-zA-Z]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre et un chiffre.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        public User IndUser { get; set; }
        public Contact ContactUser { get; set; }
        public Business BusinessUser { get; set; }
        public Contact BusinessContact { get; set; }
        public BusinessAgency BusinessAgency { get; set; }
        public UserBusinessRegister()
        {
            IndUser = new User();
            ContactUser = new Contact();
            BusinessUser = new Business();
            BusinessContact = new Contact();
            BusinessAgency = new BusinessAgency();
        }
    }

    public class BusinessAgencyRegister
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        public BusinessAgency BusinessAgency { get; set; }
        public BusinessAgencyRegister()
        {
            Contact = new Contact();
            BusinessAgency = new BusinessAgency();
        }
    }

    public class ClientInBusinessRegister
    {
        public int Id { get; set; }

        public User IndUser { get; set; }
        public Business Business { get; set; }
        public Contact BusinessContact { get; set; }
        public BusinessCommission BusinessCommission { get; set; }
        public AgentCommission AgentCommission { get; set; }

        [StringLength(10, ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) du parrain n'est pas valide.")]
        [Display(Name = "Numéro PayKap")]
        public string SPNSR_USR_BUS_NBR { get; set; }

        public ClientInBusinessRegister()
        {
            IndUser = new User();
            Business = new Business();
            BusinessContact = new Contact();
            BusinessCommission = new BusinessCommission();
            AgentCommission = new AgentCommission();
        }
    }

    public class ConnectionInformation
    {
        public int Id { get; set; }
        public ChangeLoginEmailViewModel regChangeLoginEmailViewModel { get; set; }
        public ChangePasswordViewModel regChangePasswordViewModel { get; set; }

        public ConnectionInformation()
        {
            regChangeLoginEmailViewModel = new ChangeLoginEmailViewModel();
            regChangePasswordViewModel = new ChangePasswordViewModel();
        }
    }

    public class UserBusinessRegisterViewModels
    {
        public User busUser { get; set; }
        public RegisterViewModel registerBusUser { get; set; }
    }

    public class UserIndividualViewModel
    {
        public int Id { get; set; }
        public User IndUser { get; set; }
        public Contact ContactUser { get; set; }
        public Card CardUser { get; set; }
        public Account AccountUser { get; set; }
        public RegisterViewModel RegisterIndUser { get; set; }

        public UserIndividualViewModel()
        {
            IndUser = new User();
            ContactUser = new Contact();
            RegisterIndUser = new RegisterViewModel();
        }
    }

    public class RegisterViewModel
    {
        //[Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        //[Remote("UserAlreadyExistsAsync", "PKPA")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirmer l'email est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Les deux emails ne correspondent pas.")]
        [NotMapped]
        [Display(Name = "Confirmer Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le mot de passe doit comporter entre 8 et 20 caractères.", MinimumLength = 8)]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%*]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre majuscule, une lettre minuscule, un chiffre et un de ces caractères spéciaux (@#$%*).")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-zA-Z]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre et un chiffre.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmer le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Mot de passe ")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Les deux mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap ou le numéro de téléphone PayKap est obligatoire.")]
        [Display(Name = "Numéro Carte Téléphone")]
        public string LOGIN_DATA { get; set; }

        //[Required(ErrorMessage = "L'email est obligatoire.")]
        //[EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string TRANS_SSN_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Contexte De Connexion")]
        public string LoginContextCode { get; set; } // 1= Normal register, 2 = remote payment register, 3 = start external transaction
    }

    public class BillPaymentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le montant de la facture est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal BILL_AMT { get; set; }
        
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }
    }

    public class LoginViewAgentModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%*]).{8,20})", ErrorMessage = "Le format est invalide.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
    
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le mot de passe doit comporter entre 8 et 20 caractères.", MinimumLength = 8)]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%*]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre majuscule, une lettre minuscule, un chiffre et un de ces caractères spéciaux (@#$%*).")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-zA-Z]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre et un chiffre.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    public class SecurityQuestionAnswerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le ID de l'utilisateur est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro de la Question de Sécurité est obligatoire.")]
        [Display(Name = "Numéro Question")]
        public int QUESTION_NBR { get; set; }

        [Required(ErrorMessage = "La Question de Sécurité est obligatoire.")]
        [Display(Name = "Question de Sécurité")]
        public string QUESTION { get; set; }

        [Required(ErrorMessage = "La réponse à la Question de Sécurité est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Réponse Question")]
        public string RESPONSE { get; set; }

        [Required(ErrorMessage = "L'indicateur de réinitialisation du mot de passe est obligatoire.")]
        [Display(Name = "Réinitialiser mot de passe")]
        public string RESET_PASSWORD_INDICATOR { get; set; }
    }

    public class SecurityQuestionAnswerExternalViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le ID de l'utilisateur est obligatoire.")]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro de la Question de Sécurité est obligatoire.")]
        [Display(Name = "Numéro Question")]
        public int QUESTION_NBR { get; set; }

        [Required(ErrorMessage = "La Question de Sécurité est obligatoire.")]
        [Display(Name = "Question de Sécurité")]
        public string QUESTION { get; set; }

        [Required(ErrorMessage = "La réponse à la Question de Sécurité est obligatoire.")]
        [DataType(DataType.Password)]
        [Display(Name = "Réponse Question")]
        public string RESPONSE { get; set; }
        
        [Display(Name = "ID Session Transaction")]
        public long TRANS_SSN_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Numéro de téléphone")]
        public string phone { get; set; }
    }

    public class VerifyEmailViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Le ID de l'utilisateur est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "ID Utilisateur")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Le courriel de l'utilisateur est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class VerifyEmailExternalViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Le ID de l'utilisateur est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "ID Utilisateur")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Le courriel de l'utilisateur est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string TRANS_SSN_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }
        
        [Display(Name = "Contexte De Vérification")]
        public string VerifyEmailContextCode { get; set; } // 1= Normal register, 2 = remote payment register, 3 = start external transaction
    }

    public class VerifyPhoneNumberViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Le Code regional téléphone est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code regional téléphone")]
        public string regionalPhoneCode { get; set; }

        [Required(ErrorMessage = "Le ID utilisateur est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "ID utilisateur")]
        public string UserId { get; set; }
    }
    
    public class ChangePasswordViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "ID utilisateur")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Le mot de passe actuel est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe actuel")]
        public string OldPassword { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le mot de passe doit comporter entre 8 et 20 caractères.", MinimumLength = 8)]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%*]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre majuscule, une lettre minuscule, un chiffre et un de ces caractères spéciaux (@#$%*).")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-zA-Z]).{8,20})", ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères avec au moins une lettre et un chiffre.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Indicatif Reset Pwd")]
        public string RST_PWD_INFO_IND { get; set; }

    }

    public class ChangeLoginEmailViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'email actuel est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email actuel n'est pas valide.")]
        [Display(Name = "E-mail actuel")]
        public string OldEmail { get; set; }

        [Required(ErrorMessage = "Le nouvel email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le nouvel email n'est pas valide.")]
        [Display(Name = "Nouvel E-mail")]
        public string Email { get; set; }
    }

    public class AddBankAccountViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Le nom du compte bancaire doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le nom du compte bancaire est obligatoire.")]
        [Display(Name = "Nom Compte Bancaire")]
        public string EXRL_ACCT_NM { get; set; }

        [StringLength(100, ErrorMessage = "Le numéro du compte bancaire doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le numéro du compte bancaire est obligatoire.")]
        [Display(Name = "Numéro Compte Bancaire")]
        public string EXRL_ACCT_NBR { get; set; }

        [StringLength(255, ErrorMessage = "La description du compte bancaire doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La description du compte bancaire est obligatoire.")]
        [Display(Name = "Description Compte Bancaire")]

        public string EXRL_ACCT_DESC { get; set; }

        [StringLength(255, ErrorMessage = "Le format du compte bancaire doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le format du compte bancaire est obligatoire.")]
        [Display(Name = "Format Compte Bancaire")]
        public string EXRL_ACCT_FORMAT { get; set; }
        
        [StringLength(10, ErrorMessage = "Le ID du propriétaire du compte bancaire doit avoir 10 caractères.", MinimumLength = 10)]
        [Required(ErrorMessage = "Le ID du propriétaire du compte bancaire est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        public string RCPT_EXRL_ACCT_USR_NBR { get; set; }
    }

    public class AddBusinessBankAccountViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Le nom du compte bancaire doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le nom du compte bancaire est obligatoire.")]
        [Display(Name = "Nom Compte Bancaire")]
        public string EXRL_ACCT_NM { get; set; }

        [StringLength(100, ErrorMessage = "Le numéro du compte bancaire doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le numéro du compte bancaire est obligatoire.")]
        [Display(Name = "Numéro Compte Bancaire")]
        public string EXRL_ACCT_NBR { get; set; }

        [StringLength(255, ErrorMessage = "La description du compte bancaire doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "La description du compte bancaire est obligatoire.")]
        [Display(Name = "Description Compte Bancaire")]

        public string EXRL_ACCT_DESC { get; set; }

        [StringLength(255, ErrorMessage = "Le format du compte bancaire doit avoir 255 caractères maximum.", MinimumLength = 1)]
        [Required(ErrorMessage = "Le format du compte bancaire est obligatoire.")]
        [Display(Name = "Format Compte Bancaire")]
        public string EXRL_ACCT_FORMAT { get; set; }

        [StringLength(9, ErrorMessage = "Le NEP du compte bancaire doit avoir 9 caractères.", MinimumLength = 9)]
        [Required(ErrorMessage = "Le NEP du compte bancaire est obligatoire.")]
        [Display(Name = "Numéro Entreprise PayKap (NEP)")]
        public string BN { get; set; }
    }

    public class AddPayKapUserBusinessAccountViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le numéro du compte est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le numéro du compte n'est pas valide.")]
        [Display(Name = "Numéro Compte PayKap")]
        public string ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le nom du bénéficiaire du compte PayKap est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom du bénéficiaire du compte PayKap doit avoir 100 caractères maximum.", MinimumLength = 1)]
        [Display(Name = "Nom Bénéficiaire Compte PayKap")]
        public string USR_BUS_NM { get; set; }
    }
    
    public class AddPayKapBusinessRecipientClientAccountViewModel
    {
        [Key]
        [Required(ErrorMessage = "Le numéro du compte de l'entreprise est obligatoire.")]
        [Display(Name = "Numéro Compte Entreprise")]
        public int BPCS_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro du compte ou de client est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le numéro du compte ou de client doit avoir maximum 50 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Compte Client")]
        public string CLT_NBR { get; set; }

        [Required(ErrorMessage = "Le nom de l'entreprise est obligatoire.")]
        [StringLength(255, ErrorMessage = "Le nom de l'entreprise doit avoir entre 2 et 30 caractères.", MinimumLength = 2)]
        [Display(Name = "Nom Entreprise")]
        public string BPCS_BUS_NM { get; set; }

        [Required(ErrorMessage = "La description du numéro de compte des clients de l'entreprise est obligatoire.")]
        [StringLength(500, ErrorMessage = "La description du numéro de compte des clients doit avoir maximum 500 caractères.", MinimumLength = 2)]
        [Display(Name = "Description Compte Client Entreprise")]
        public string BPCS_CLT_ACCT_DESC { get; set; }
        
        [Display(Name = "ID Compte")]
        public int ACCT_ID { get; set; }
        
        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }
    }

    public class TransferViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "AmountTxt", ResourceType = typeof(Resources.Resources))]//Modified
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Indiquer le moyen de paiement est obligatoire")]
        [Display(Name = "Moyen de Paiement")]
        public string FROM_SRVC_IND { get; set; }

        [Required(ErrorMessage = "Indiquer le type de bénéficiaire est obligatoire")]
        [Display(Name = "Type de Bénéficiaire")]
        public string TO_SRVC_IND { get; set; }
    }

    public class TransferConfirmationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal TRANS_AMT { get; set; }
        
        [Display(Name = "Montant Texte")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Indicatif Frais")]
        public bool FEE_AMT_IND { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT { get; set; }

        [Display(Name = "Frais Texte")]
        public string FEE_AMT_TXT { get; set; }

        //[Display(Name = "Indicatif Autres Frais")]
        //public bool OTHR_FEE_IND { get; set; }

        //[Display(Name = "Autres Frais")]
        //public decimal OTHR_FEE_AMT { get; set; }

        //[Display(Name = "Autres Frais Texte")]
        //public string OTHR_FEE_AMT_TXT { get; set; }

        [Display(Name = "Montant total à payer")]
        public decimal AMT_TO_PAY { get; set; }

        [Display(Name = "Montant total à payer texte")]
        public string AMT_TO_PAY_TXT { get; set; }

        [Display(Name = "Montant à virer au bénéficiaire")]
        public decimal AMT_TO_RECEIVE { get; set; }

        [Display(Name = "Montant à virer au bénéficiaire Texte")]
        public string AMT_TO_RECEIVE_TXT { get; set; }

        [Display(Name = "Moyen de paiement (PayKap & Banque)")]
        public int FROM_PKP_BNK_ACCT { get; set; }

        [Display(Name = "Indicatif Moyen de paiement (PayKap)")]
        public bool FROM_PKP_IND { get; set; }  //indicates that the user is using the paykap account

        //[Display(Name = "Moyen de paiement")]
        //public string FROM_OTH_PYMT_WAY { get; set; }

        [Display(Name = "Comment Envoyer ?")]
        public int FROM_TRSF_SERV_CTRY_ID { get; set; }
        
        [Display(Name = "Comment Recevoir ?")]
        public int TO_TRSF_SERV_CTRY_ID { get; set; }
        
        [Display(Name = "Pays Envoi")]
        public string FROM_CTRY_CD { get; set; }
        
        [Display(Name = "Pays Reception")]
        public string TO_CTRY_CD { get; set; }
        
        [Display(Name = "Devise Envoi")]
        public string FROM_CRCY_CD { get; set; }
        
        [Display(Name = "Devise Reception")]
        public string TO_CRCY_CD { get; set; }

        [Display(Name = "Taux Change")]
        public Decimal CRCY_XCHG_RT { get; set; }

        [Display(Name = "Taux Change")]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Display(Name = "Indicatif Taux Change")]
        public bool CRCY_XCHG_RT_IND { get; set; }

        [Required(ErrorMessage = "Indiquer le moyen de paiement est obligatoire")]
        [Display(Name = "Moyen de Paiement")]
        public string FROM_SRVC_IND { get; set; }

        [Required(ErrorMessage = "Indiquer le type de bénéficiaire est obligatoire")]
        [Display(Name = "Type de Bénéficiaire")]
        public string TO_SRVC_IND { get; set; }

        [Display(Name = "Bénéficiaire PayKap")]
        public int TO_PKP_ACCT { get; set; }

        [Display(Name = "Bénéficiaire PayKap")]
        public int TO_BNK_ACCT { get; set; }

        [Display(Name = "Compte Bénéficiaire")]
        public string RCPT_ACCT_NBR { get; set; }

        [Display(Name = "ID Bénéficiaire")]
        public string RCPT_USR_NBR { get; set; }

        [Display(Name = "ID Bénéficiaire PayKap")]
        public int RCPT_USR_BUS_ID { get; set; }

        [Display(Name = "Nom Bénéficiaire")]
        public string RCPT_NAME { get; set; }

        //[Display(Name = "Nom Compte Bénéficiaire Texte")]
        //public string RCPT_ACCT_NAME_TXT { get; set; }

        [Display(Name = "Numéro Facture")]
        public string BILL_NBR { get; set; }

        [Display(Name = "Paiement Par Banque")]
        public bool FROM_BNK_IND { get; set; }

        [Display(Name = "Numéro Facture")]
        public bool TO_BNK_IND { get; set; }

        [Display(Name = "Indicatif Ville de retrait")]
        public bool CITY_AGCY_IND { get; set; }

        [Display(Name = "Détails Moyen Paiement")]
        public string FROM_PYMT_WAY_FORMAT { get; set; }

        [Display(Name = "Détails bénéficiaire")]
        public string TO_RCPT_FORMAT { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE_DISABLED { get; set; }

        [Display(Name = "From Culture Info")]
        public string FROM_ACCT_CLTR_INFO { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string TRANS_SSN_ID_TXT { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string CLT_SENDER_USR_NBR { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string CLT_SENDER_FUL_NM { get; set; }

        public bool ONBHLF_CLT_TRANS_IND { get; set; }

        //public TransactionStartExternalSessionTemporary transSSN { get; set; }

        //public TransferConfirmationViewModel()
        //{
        //    transSSN = new TransactionStartExternalSessionTemporary();
        //}

    }

    public class TransactionFeeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal FROM_TRANS_AMT { get; set; }

        [Display(Name = "Montant Texte")]
        public string FROM_TRANS_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal TO_TRANS_AMT { get; set; }

        [Display(Name = "Montant Texte")]
        public string TO_TRANS_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal TOT_TO_PAY_AMT { get; set; }

        [Display(Name = "Montant Texte")]
        public string TOT_TO_PAY_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal TOT_TO_PAY_AMT_PROMO_CD { get; set; }

        [Display(Name = "Montant Texte")]
        public string TOT_TO_PAY_AMT_TXT_PROMO_CD { get; set; }

        [Display(Name = "Indicatif Frais")]
        public bool FEE_AMT_IND { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT { get; set; }

        [Display(Name = "Frais Texte")]
        public string FEE_AMT_TXT { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT_PROMO_CD { get; set; }

        [Display(Name = "Frais Texte")]
        public string FEE_AMT_TXT_PROMO_CD { get; set; }

        [Display(Name = "Devise Envoi")]
        public string FROM_CRCY_CD { get; set; }

        [Display(Name = "Devise Reception")]
        public string TO_CRCY_CD { get; set; }

        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Display(Name = "Taux Change")]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Display(Name = "Taux Change")]
        public decimal ADJUST_XCHG_RT { get; set; }

        [Display(Name = "Indicatif Taux Change")]
        public bool CRCY_XCHG_RT_IND { get; set; }

        [Display(Name = "Message erreur")]
        public string ERROR_TXT { get; set; }

        [Display(Name = "Pays Envoi")]
        public string FROM_CTRY_CD { get; set; }

        [Display(Name = "Pays Reception")]
        public string TO_CTRY_CD { get; set; }

        [Display(Name = "Code Envoi ou Reception")]
        public string SEND_RCPT_CD { get; set; }

        [Display(Name = "Service Envoi")]
        public int FROM_SRVC_ID { get; set; }

        [Display(Name = "Service Reception")]
        public int TO_SRVC_ID { get; set; }

        [Display(Name = "Indicatif Login")]
        public bool LOGIN_IND { get; set; }

        [Display(Name = "Client or Au nom du client")]
        public string CLT_ON_CLT_BHLF_TCD { get; set; }
    }

    public class BillPaymentTransactionModel
    {
        public int Id { get; set; }
        public BankTransaction fromBank { get; set; }
        public BankTransaction toBank { get; set; }
        public AccountHistory fromAcctHist { get; set; }
        public AccountHistory toAcctHist { get; set; }

        [Display(Name = "Paiement Par Compte Bancaire")]
        public string FROM_BANK_TRANS_IND { get; set; }

        [Display(Name = "Paiement Par Compte PayKap")]
        public string FROM_PKP_TRANS_IND { get; set; }

        [Display(Name = "Bénéficaire Bancaire")]
        public string TO_BANK_TRANS_IND { get; set; }

        [Display(Name = "Bénéficaire PayKap")]
        public string TO_PKP_TRANS_IND { get; set; }

        [Display(Name = "Indicatif Numéro Facture")]
        public string BILL_NBR_IND { get; set; }

        public BillPaymentTransactionModel()
        {
            fromBank = new BankTransaction();
            toBank = new BankTransaction();
            fromAcctHist = new AccountHistory();
            toAcctHist = new AccountHistory();
        }
    }

    public class BillPaymentTransactionForBusinessViewModel
    {
        [Key]
        public int TRANS_ID { get; set; }
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Destinataire")]
        public decimal TO_TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Display(Name = "Texte Montant Destinataire")]
        public string TO_TRANS_AMT_TXT { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Statut Transaction")] //01- Sent but pending to pay the transfer
        public string TRANS_SCD { get; set; }  //02- Sent but need exceptional authorisation due to high amount
                                               //03- Paid,   04 Closed,    05 Locked,  06- Expired

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TRANS_CDT { get; set; }
        
        [Required]
        [StringLength(10)]
        [Display(Name = "ID Envoyeur")]
        public string FROM_USR_NBR { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Nom Utilisateur")]
        public string USR_FUL_NM { get; set; }

        [Display(Name = "ID Bénéficiaire")]  
        public int RCPT_USR_BUS_ID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Type Transaction")]   //01- Transfer    02- Bill Payment   03-Deposit   04- Withdrawal
        public string TRANS_TRSF_CRDT_DBT_TCD { get; set; }

        [Required(ErrorMessage = "Le numéro de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Le numéro de compte doit avoir entre 3 et 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Numéro Compte")]
        public string ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro matricule 1 est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le numéro  matricule 1 doit avoir entre 3 et 20 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Matricule 1")]
        public string RCPT_USR_BUS1_UIN { get; set; }

        [Required(ErrorMessage = "Le numéro matricule 2 est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le numéro  matricule 2 doit avoir entre 3 et 20 caractères.", MinimumLength = 1)]
        [Display(Name = "Numéro Matricule 2")]
        public string RCPT_USR_BUS2_UIN { get; set; }

        [Required(ErrorMessage = "Le nom du bénéficiaire est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Le nom du bénéficiaire doit avoir entre 2 et 30 caractères.", MinimumLength = 2)]
        [Display(Name = "Nom Bénéficiaire (Personne-Entreprise)")]
        public string RCPT_USR_BUS_NM { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Nom Bénéficiaire (Personne-Entreprise)")] //1- Client Without External ID  2- Business Without External ID 
        public string RCPT_TCD { get; set; }                       //3- Client With External ID 4- Business With External ID
        
        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Numéro Facture")]
        public string BIL_NBR { get; set; }

    }

    public class CreditDebitTransactionViewModel
    {
        [Key]
        [Display(Name = "Compte ID")]
        public int ACCT_ID { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant")]
        public decimal FROM_NEW_ACCT_BAL { get; set; }

        [Required(ErrorMessage = "Le solde de compte est obligatoire.")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Nouveau Solde Compte")]
        public decimal TO_NEW_ACCT_BAL { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire")]
        [StringLength(50, ErrorMessage = "Le {0} doit compter {2} caractères", MinimumLength = 1)]
        [Display(Name = "Erreur")]
        public string TRANS_ERROR_CD { get; set; }
    }

    public class ContactusViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [Display(Name = "Prénom & Nom")]
        public string FUL_NM { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [Display(Name = "E-mail")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "L'objet est obligatoire.")]
        [Display(Name = "Objet")]
        public string OBJET { get; set; }

        [Required(ErrorMessage = "Le message est obligatoire.")]
        [Display(Name = "Objet")]
        public string BODY { get; set; }
    }

    public class AccountDepositWithdrawalViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        [DataType(DataType.Password)]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }
    }

    public class ThirdPartyAccountWithdrawalByCardViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant à déposer ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }
    }

    public class AccountDepositWitdrawalByPhoneViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone PayKap est obligatoire.")]
        [Display(Name = "Numéro Carte PayKap")]
        public string PHN_NBR { get; set; }

        [Required(ErrorMessage = "Le montant de la transaction est obligatoire")]
        [Range(1, 1000000000, ErrorMessage = "Le montant de la transaction ne peut pas être inférieur à un.")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }
        
        [Display(Name = "Numéro Client")]
        public string CLT_USR_NBR { get; set; }

    }
    
    public class ThirdPartyAccountWithdrawalRecipientViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant à déposer ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        //[Required(ErrorMessage = "Le numéro de compte ou le numéro de téléphone PayKap est obligatoire")]
        //[Required(ErrorMessage = "Le numéro de téléphone PayKap est obligatoire")]
        [DataType(DataType.Text)]
        [Display(Name = "Numéro Compte ou Téléphone")]
        public string RCPT_ACCT_PHN_NBR { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Expediteur ID Utilisateur")]
        public string SENDER_USR_NBR { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }
    }

    public class ExternalTransactionRecipientViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap du déposant de l'argent doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant à déposer ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone PayKap du bénéficiaire est obligatoire.")]
        [DataType(DataType.Text)]
        [Display(Name = "Numéro Compte ou Téléphone")]
        public string RCPT_ACCT_PHN_NBR { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Expediteur ID Utilisateur")]
        public string SENDER_USR_NBR { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        [StringLength(8, ErrorMessage = "Le code promo doit compter avoir exactement 8 caractères.", MinimumLength = 8)]
        public string PROMO_CODE { get; set; }

        [Display(Name = "ID Session Transaction")]
        public string TRANS_SSN_ID_TXT { get; set; }

        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(250, ErrorMessage = "Le {0} doit compter au maximum 250 caractères.")]
        [DataType(DataType.Text)]
        [Display(Name = "Montant Transaction")]
        public string TRANS_AMT_TXT { get; set; }
    }

    public class AccountDepositWithdrawalWithoutCardViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }
    }

    public class AccountWithdrawalWithoutCardClientValidationViewModel
    {
        [Key]
        public int Id { get; set; }

        public List<TransactionIdentificationDocument> TRANS_ID_DOC_LIST { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Le numéro de carte PayKap doit avoir 16 chiffres")]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à déposer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }
        
        [Display(Name = "Propriétaire Carte")]
        public string CARD_OWNR_FNM { get; set; }

        [Required(ErrorMessage = "Le type du document est obligatoire")]
        [Display(Name = "Type Document")]
        public int ID_DOC_ID { get; set; }

        [Required(ErrorMessage = "Le numéro du document est obligatoire")]
        [StringLength(50, ErrorMessage = "Le numéro du document doit avoir entre 2 et 50 caractères.", MinimumLength = 2)]
        [Display(Name = "Numéro Document")]
        public string ID_DOC_NBR { get; set; }

        [Required(ErrorMessage = "La date d'expiration du document est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime ID_DOC_XDT { get; set; }

        [Display(Name = "ID Employé")]
        public int BUS_USR_NBR { get; set; }

        [StringLength(10)]
        [Display(Name = "ID Client")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "La date de naissance du propriétaire du compte est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Naissance")]
        public DateTime CLT_ID_DOC_BRDAY { get; set; }


        public AccountWithdrawalWithoutCardClientValidationViewModel()
        {
            TRANS_ID_DOC_LIST = new List<TransactionIdentificationDocument>();
        }
    }

    public class AccountDepositConfirmationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [StringLength(16, ErrorMessage = "Le numéro de carte PayKap doit avoir exactement 16 caractères", MinimumLength = 16)]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire.")]
        [Display(Name = "Montant Transaction Texte")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Commission Entreprise")]
        public decimal BUS_CMSN_AMT { get; set; }

        [Display(Name = "Indicatif Frais")]
        public bool FEE_AMT_IND { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT { get; set; }

        //[Display(Name = "Frais Total")]
        //public decimal FEE_TOT_AMT { get; set; }

        [Display(Name = "Frais Total Texte")]
        public string FEE_AMT_TXT { get; set; }

        [Display(Name = "Frais")]
        public decimal TRANS_FEE_AMT { get; set; }

        [Display(Name = "Montant total à payer")]
        public decimal AMT_TO_PAY { get; set; }

        [Display(Name = "Montant total à payer texte")]
        public string AMT_TO_PAY_TXT { get; set; }

        [Display(Name = "Montant à déposer au bénéficiaire")]
        public decimal AMT_TO_DEPOSIT { get; set; }

        [Display(Name = "Montant à déposer au bénéficiaire Texte")]
        public string AMT_TO_DEPOSIT_TXT { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire du compte est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire connexion est obligatoire.")]
        [Display(Name = "ID Propriétaire Connexion")]
        public string CLT_USR_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int BUS_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int MANAGER_ACCT_ID { get; set; }

        [Display(Name = "BN Entreprise")]
        public int BN { get; set; }

        [Display(Name = "BN Entreprise")]
        public string BUS_SHORT_NM { get; set; }

        [Display(Name = "ID Compte Client")]
        public int CLT_ACCT_ID { get; set; }

        [Display(Name = "Pays Entreprise")]
        public string BUS_CTRY_CD { get; set; }

        [Display(Name = "Pays Client")]
        public string CLT_CTRY_CD { get; set; }

        [Display(Name = "Devise Entreprise")]
        public string BUS_CRCY_CD { get; set; }

        [Display(Name = "Devise Client")]
        public string CLT_CRCY_CD { get; set; }

        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }
        
        [Display(Name = "Taux Change")]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Display(Name = "Indicatif Taux Change")]
        public bool CRCY_XCHG_RT_IND { get; set; }

        [Display(Name = "ID Service Départ")]
        public int FROM_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Compte Client")]
        public int TO_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Employé Entreprise")]
        public int BUS_USR_NBR { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE_DESC_TXT { get; set; }
    }

    public class ThirdPartyAccountDepositConfirmationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de compte du destinataire est obligatoire.")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Le numéro de compte du destinataire doit avoir maximum 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Numéro Compte")]
        public string ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [StringLength(16, ErrorMessage = "Le numéro de carte PayKap doit avoir exactement 16 caractères", MinimumLength = 16)]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire.")]
        [Display(Name = "Montant Transaction Texte")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Commission Entreprise")]
        public decimal BUS_CMSN_AMT { get; set; }

        [Display(Name = "Indicatif Frais")]
        public bool FEE_AMT_IND { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT { get; set; }

        [Display(Name = "Frais Total")]
        public decimal TRANS_FEE_AMT { get; set; }

        [Display(Name = "Frais Total Texte")]
        public string FEE_AMT_TXT { get; set; }

        [Display(Name = "Montant total à payer")]
        public decimal AMT_TO_PAY { get; set; }

        [Display(Name = "Montant total à payer texte")]
        public string AMT_TO_PAY_TXT { get; set; }

        [Display(Name = "Montant à déposer au bénéficiaire")]
        public decimal AMT_TO_DEPOSIT { get; set; }

        [Display(Name = "Montant à déposer au bénéficiaire Texte")]
        public string AMT_TO_DEPOSIT_TXT { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM_DSPLY { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire du compte est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire connexion est obligatoire.")]
        [Display(Name = "ID Propriétaire Connexion")]
        public string CLT_USR_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int BUS_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int MANAGER_ACCT_ID { get; set; }

        [Display(Name = "BN Entreprise")]
        public int BN { get; set; }

        [Display(Name = "ID Compte Client")]
        public int CLT_ACCT_ID { get; set; }

        [Display(Name = "Pays Entreprise")]
        public string BUS_CTRY_CD { get; set; }

        [Display(Name = "Pays Client")]
        public string CLT_CTRY_CD { get; set; }

        [Display(Name = "Devise Entreprise")]
        public string BUS_CRCY_CD { get; set; }

        [Display(Name = "Devise Client")]
        public string CLT_CRCY_CD { get; set; }

        [Display(Name = "Taux Change")]
        public decimal CRCY_XCHG_RT { get; set; }

        [Display(Name = "Taux Change")]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Display(Name = "Indicatif Taux Change")]
        public bool CRCY_XCHG_RT_IND { get; set; }

        [Display(Name = "ID Service Départ")]
        public int FROM_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Compte Client")]
        public int TO_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Employé Entreprise")]
        public int BUS_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire de la carte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Carte")]
        public string CARD_OWNR_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire de la carte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Carte")]
        public string CARD_OWNR_FUL_NM_DSPLY { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire de la carte est obligatoire.")]
        [Display(Name = "ID Propriétaire Carte")]
        public string CARD_USR_NBR { get; set; }

        [Display(Name = "Indicatif Ville")]
        public bool CITY_AGCY_IND { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE_DESC_TXT { get; set; }
    }

    public class AccountWithdrawalConfirmationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le type du document est obligatoire")]
        [Display(Name = "Type Document")]
        public int ID_DOC_ID { get; set; }

        [Required(ErrorMessage = "Le numéro du document est obligatoire")]
        [StringLength(50, ErrorMessage = "Le numéro du document doit avoir entre 2 et 50 caractères.", MinimumLength = 2)]
        [Display(Name = "Numéro Document")]
        public string ID_DOC_NBR { get; set; }

        [Required(ErrorMessage = "La date d'expiration du document est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Expiration")]
        public DateTime ID_DOC_XDT { get; set; }

        [Required(ErrorMessage = "La date de naissance du propriétaire du compte est obligatoire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Naissance")]
        public DateTime CLT_ID_DOC_BRDAY { get; set; }

        [Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        [StringLength(16, ErrorMessage = "Le numéro de carte PayKap doit avoir exactement 16 caractères", MinimumLength = 16)]
        [Display(Name = "Numéro Carte PayKap")]
        public string CARD_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire.")]
        [Display(Name = "Montant Transaction Texte")]
        public string TRANS_AMT_TXT { get; set; }

        [Display(Name = "Commission Entreprise")]
        public decimal BUS_CMSN_AMT { get; set; }

        [Display(Name = "Indicatif Frais")]
        public bool FEE_AMT_IND { get; set; }

        [Display(Name = "Frais")]
        public decimal FEE_AMT { get; set; }

        [Display(Name = "Frais")]
        public decimal TRANS_FEE_AMT { get; set; }

        [Display(Name = "Frais Total Texte")]
        public string FEE_AMT_TXT { get; set; }

        [Display(Name = "Montant à retirer")]
        public decimal AMT_TO_PAY { get; set; }

        [Display(Name = "Montant à retirer texte")]
        public string AMT_TO_PAY_TXT { get; set; }

        [Display(Name = "Montant total à payer")]
        public decimal TOT_AMT_TO_PAY { get; set; }

        [Display(Name = "Montant total à payer texte")]
        public string TOT_AMT_TO_PAY_TXT { get; set; }

        [Display(Name = "Montant à donner au bénéficiaire")]
        public decimal AMT_TO_RECEIVE { get; set; }

        [Display(Name = "Montant à donner au bénéficiaire Texte")]
        public string AMT_TO_RECEIVE_TXT { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire du compte est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire connexion est obligatoire.")]
        [Display(Name = "ID Propriétaire Connexion")]
        public string CLT_USR_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int BUS_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int MANAGER_ACCT_ID { get; set; }

        [Display(Name = "BN Entreprise")]
        public int BN { get; set; }

        [Display(Name = "BN Entreprise")]
        public string BUS_SHORT_NM { get; set; }

        [Display(Name = "ID Compte Client")]
        public int CLT_ACCT_ID { get; set; }

        [Display(Name = "Pays Entreprise")]
        public string BUS_CTRY_CD { get; set; }

        [Display(Name = "Pays Client")]
        public string CLT_CTRY_CD { get; set; }

        [Display(Name = "Devise Entreprise")]
        public string BUS_CRCY_CD { get; set; }

        [Display(Name = "Devise Client")]
        public string CLT_CRCY_CD { get; set; }

        [Display(Name = "Taux Change")]
        public Decimal CRCY_XCHG_RT { get; set; }

        [Display(Name = "Taux Change")]
        public decimal ADJUST_XCHG_RT { get; set; }

        [Display(Name = "Taux Change")]
        public string CRCY_XCHG_RT_TXT { get; set; }

        [Display(Name = "Indicatif Taux Change")]
        public bool CRCY_XCHG_RT_IND { get; set; }

        [Display(Name = "ID Service Départ")]
        public int FROM_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Compte Client")]
        public int TO_SERV_CTRY_ID { get; set; }

        [Required(ErrorMessage = "Le NIP est obligatoire.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP doit avoir des chiffres et de longueur 4.")]
        [DataType(DataType.Password)]
        [Display(Name = "NIP")]
        public string CARD_PIN { get; set; }

        [Display(Name = "ID Employé Entreprise")]
        public int BUS_USR_NBR { get; set; }

        [Display(Name = "Indicatif Modifier Credit Disponible")]
        public bool UPDATE_CLT_CRDT_IND { get; set; }

        [Display(Name = "Nombre Credit Disponible")]
        public int REMAINING_CRDT_NBR { get; set; }

        [Display(Name = "Indicatif Pas de NIP")]
        public bool ACCT_WITHDRWL_WITH_PIN_IND { get; set; }

        [Display(Name = "Indicatif Code Promo")]
        public bool DISPLAY_PROMO_CODE_IND { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE { get; set; }

        [Display(Name = "Code Promo")]
        public string PROMO_CODE_DESC_TXT { get; set; }
    }

    public class ConnexionLogViewModel
    {
        [Key]
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le ID Utilisateur doit avoir 10 caractères.", MinimumLength = 10)]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }

        [Required(ErrorMessage = "La question de sécurité 1 est obligatoire.")]
        [Display(Name = "Question Sécurité 1")]
        public int QUES1 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 1 est obligatoire.")]
        [StringLength(20, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [Display(Name = "Réponse Question 1")]
        public string RESP1 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 1 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP1", ErrorMessage = "Les deux réponses de la question 1 ne correspondent pas.")]
        [Display(Name = "Confirmer Réponse Question 1")]
        public string CONFIRM_RESP1 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 2 est obligatoire.")]
        [Display(Name = "Question Sécurité 2")]
        public int QUES2 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 2 est obligatoire.")]
        [StringLength(20, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [Display(Name = "Réponse Question 2")]
        public string RESP2 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 2 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP2", ErrorMessage = "Les deux réponses de la question 2 ne correspondent pas.")]
        [Display(Name = "Confirmer Réponse Question 2")]
        public string CONFIRM_RESP2 { get; set; }

        [Required(ErrorMessage = "La question de sécurité 3 est obligatoire.")]
        [Display(Name = "Question Sécurité 3")]
        public int QUES3 { get; set; }

        [Required(ErrorMessage = "La réponse à la question de sécurité 3 est obligatoire.")]
        [StringLength(20, ErrorMessage = "La réponse doit avoir au minimum 3 caractères.", MinimumLength = 3)]
        [Display(Name = "Réponse Question 3")]
        public string RESP3 { get; set; }

        [Required(ErrorMessage = "Confirmer la réponse à la question de sécurité 3 est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("RESP3", ErrorMessage = "Les deux réponses de la question 3 ne correspondent pas.")]
        [Display(Name = "Confirmer Réponse Question 3")]
        public string CONFIRM_RESP3 { get; set; }
    }

    public class ChangeUserPhoneLoginViewModel
    {
        [Key]
        [Display(Name = "ID Utilisateur")]
        public string USR_NBR { get; set; }
        
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Display(Name = "Code Régional Téléphone")]
        public string RGNL_CD { get; set; }

        [Display(Name = "Nombre De Téléphone")]
        public int PHN_NBR_COUNT { get; set; }

        [Display(Name = "Clé Primaire Téléphone 1")]
        public string USR_PHN_LGN_NBR_DB_KEY1 { get; set; }
        
        [Required(ErrorMessage = "Le nouveau numéro de téléphone PayKap est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le numéro de téléphone PayKap doit avoir maximum 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Nouveau numéro de téléphone")]
        public string NEW_PHN_NBR1 { get; set; }

        [Required(ErrorMessage = "Confirmer le nouveau numéro de téléphone PayKap est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("NEW_PHN_NBR1", ErrorMessage = "Les deux numéros de téléphones ne correspondent pas.")]
        [Display(Name = "Confirmer Nouveau numéro de téléphone")]
        public string CONFIRM_NEW_PHN_NBR1 { get; set; }

        [Display(Name = "Clé Primaire Téléphone 2")]
        public string USR_PHN_LGN_NBR_DB_KEY2 { get; set; }

        [Required(ErrorMessage = "Le nouveau numéro de téléphone PayKap est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le numéro de téléphone PayKap doit avoir maximum 20 caractères.", MinimumLength = 3)]
        [Display(Name = "Nouveau numéro de téléphone")]
        public string NEW_PHN_NBR2 { get; set; }

        [Required(ErrorMessage = "Confirmer le nouveau numéro de téléphone PayKap est obligatoire.")]
        [System.ComponentModel.DataAnnotations.Compare("NEW_PHN_NBR2", ErrorMessage = "Les deux numéros de téléphones ne correspondent pas.")]
        [Display(Name = "Confirmer Nouveau numéro de téléphone")]
        public string CONFIRM_NEW_PHN_NBR2 { get; set; }

    }

    public class BusinessAgencyViewModel
    {
        public int Id { get; set; }
        public BusinessAgency busAgcy { get; set; }
        
        [Display(Name = "Solde Agence")]
        public string BUS_AGCY_BAL_TXT { get; set; }
        
        [Display(Name = "Nom Directeur")]
        public string BUS_USR_DIR_NM { get; set; }
        
        [Display(Name = "Nom Ville Agence")]
        public string BUS_AGCY_CITY_NM { get; set; }

        public BusinessAgencyViewModel()
        {
            busAgcy = new BusinessAgency();
        }
    }

    public class BusinessAgencyDetailViewModel
    {
        public int Id { get; set; }
        public BusinessAgency busAgcy { get; set; }

        public List<BusinessUserViewModel> busUsrList { get; set; }

        [Display(Name = "Nom Directeur")]
        public string BUS_USR_DIR_NM { get; set; }

        public BusinessAgencyDetailViewModel()
        {
            busAgcy = new BusinessAgency();
            busUsrList = new List<BusinessUserViewModel>();
        }
    }
    
    public class BusinessUserViewModel
    {
        public int Id { get; set; }
        public BusinessUser busUsr { get; set; }
        
        [Display(Name = "Solde Employé")]
        public string BUS_USR_BAL_TXT { get; set; }

        [Display(Name = "Compte Employé")]
        public string BUS_USR_ACCT { get; set; }

        [Display(Name = "Role Employé")]
        public string BUS_USR_ROL_NM { get; set; }
        
        [Display(Name = "Nom Employé")]
        public string BUS_USR_FUL_NM { get; set; }

        [Display(Name = "Nom Agence")]
        public string BUS_USR_AGCY_NM { get; set; }

        public BusinessUserViewModel()
        {
            busUsr = new BusinessUser();
        }
    }

    public class BusinessUserDataModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int BUS_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Entreprise")]
        public int MANAGER_ACCT_ID { get; set; }

        [Display(Name = "BN Entreprise")]
        public int BN { get; set; }

        [Display(Name = "Nom Court Entreprise")]
        public string BUS_SHORT_NM { get; set; }

        [Display(Name = "Pays Entreprise")]
        public string BUS_CTRY_CD { get; set; }

        [Display(Name = "Devise Entreprise")]
        public string BUS_CRCY_CD { get; set; }

        [Display(Name = "ID Employé Entreprise")]
        public int BUS_USR_NBR { get; set; }

        [Display(Name = "Bus Culture Info")]
        public string BUS_ACCT_CLTR_INFO { get; set; }
    }

    public class ClientDataModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM { get; set; }

        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM_DSPLY { get; set; }

        [Display(Name = "ID Propriétaire Compte")]
        public string CLT_USR_NBR { get; set; }

        [Display(Name = "ID Propriétaire Connexion")]
        public string CLT_USR_ID { get; set; }

        [Display(Name = "ID Compte Client")]
        public int CLT_ACCT_ID { get; set; }

        [Display(Name = "Pays Client")]
        public string CLT_CTRY_CD { get; set; }

        [Display(Name = "Devise Client")]
        public string CLT_CRCY_CD { get; set; }

        [Display(Name = "Nom Propriétaire Carte")]
        public string CARD_OWNR_FUL_NM { get; set; }

        [Display(Name = "Nom Propriétaire Carte")]
        public string CARD_OWNR_FUL_NM_DSPLY { get; set; }

        [Display(Name = "ID Propriétaire Carte")]
        public string CARD_USR_NBR { get; set; }

        [Display(Name = "Client Culture Info")]
        public string CLT_ACCT_CLTR_INFO { get; set; }
    }

    public class TransactionTransferCreditDebitViewModel
    {
        public int Id { get; set; }
        public TransactionTransferCreditDebit trans { get; set; }

        [Display(Name = "Solde Employé")]
        public string BUS_USR_BAL_TXT { get; set; }

        [Display(Name = "Compte Employé")]
        public string BUS_USR_ACCT { get; set; }

        [Display(Name = "Role Employé")]
        public string BUS_USR_ROL_NM { get; set; }

        [Display(Name = "Nom Employé")]
        public string BUS_USR_FUL_NM { get; set; }

        [Display(Name = "Nom Agence")]
        public string BUS_USR_AGCY_NM { get; set; }

        public TransactionTransferCreditDebitViewModel()
        {
            trans = new TransactionTransferCreditDebit();
        }
    }

    public class TransactionTransferCreditDebitCountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Solde")]
        public string TRANS_BAL_TXT { get; set; }

        [Display(Name = "Montant Payé")]
        public string DEPOSIT_TOT_AMT_TXT { get; set; }

        [Display(Name = "Montant Payé Devise")]
        public string DEPOSIT_CRCY_CD { get; set; }

        [Display(Name = "Nombre Transaction Payé")]
        public int DEPOSIT_TRANS_NBR { get; set; }

        [Display(Name = "Montant Recu")]
        public string WITHDRAW_TOT_AMT_TXT { get; set; }

        [Display(Name = "Montant Recu Devise")]
        public string WITHDRAW_CRCY_CD { get; set; }

        [Display(Name = "Nombre Transaction Recu")]
        public int WITHDRAW_TRANS_NBR { get; set; }
    }

    public class BusinessCommissionTransactionCountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Solde")]
        public string TRANS_BAL_TXT { get; set; }

        [Display(Name = "Montant Payé")]
        public string BUS_CMSN_TOT_AMT_TXT { get; set; }

        [Display(Name = "Montant Payé Devise")]
        public string BUS_CMSN_CRCY_CD { get; set; }

        [Display(Name = "Nombre Transaction Payé")]
        public int BUS_CMSN_TRANS_NBR { get; set; }
    }

    public class InternalTransferBusinessUserCode
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [Display(Name = "Type Utilisateur")]
        public string BUS_USR_CD { get; set; }
    }

    public class InternalTransferViewModel
    {
        [Key]
        public int Id { get; set; }

        public BusinessInternalTransferTransaction busIntrnTrsfTRANS { get; set; }

        [Display(Name = "ID Compte Expéditeur")]
        public int FROM_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Destinataire")]
        public int TO_ACCT_ID { get; set; }

        [Display(Name = "Solde Apres Expéditeur")]
        public decimal FROM_AFTR_TRANS_BAL { get; set; }

        [Display(Name = "Solde Apres Destinataire")]
        public decimal TO_AFTR_TRANS_BAL { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [Display(Name = "Type Utilisateur")]
        public string BUS_USR_CD { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "La {0} doit compter {2} caractères.", MinimumLength = 1)]
        [Display(Name = "Description Transaction")]
        public string TRANS_DESC_TO_DISPLAY { get; set; }

        [Required(ErrorMessage = "La {0} est obligatoire")]
        [Display(Name = "Numéro Utilisateur")]
        public int BUS_USR_NBR { get; set; }

        public InternalTransferViewModel()
        {
            busIntrnTrsfTRANS = new BusinessInternalTransferTransaction();
        }
    }
    
    public class InternalTransferConfirmationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro de compte est obligatoire.")]
        [StringLength(20, ErrorMessage = "Le numéro de compte est invalide", MinimumLength = 10)]
        [Display(Name = "Numéro Compte")]
        public string ACCT_NBR { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire")]
        [Range(0, 1000000000, ErrorMessage = "Le montant ne peut pas inférieur à zéro")]
        [DataType(DataType.Text, ErrorMessage = "La value n'est pas un nombre")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        [Display(Name = "Montant Transaction")]
        public decimal TRANS_AMT { get; set; }

        [Required(ErrorMessage = "Le montant à retirer est obligatoire.")]
        [Display(Name = "Montant Transaction Texte")]
        public string TRANS_AMT_TXT { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string BUS_USR_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire connexion est obligatoire.")]
        [Display(Name = "ID Propriétaire Connexion")]
        public string BUS_USR_USR_ID { get; set; }

        [Display(Name = "ID Compte Départ")]
        public int FROM_ACCT_ID { get; set; }

        [Display(Name = "ID Compte Destinataire")]
        public int TO_ACCT_ID { get; set; }

        [Display(Name = "Devise Départ")]
        public string FROM_CRCY_CD { get; set; }

        [Display(Name = "Devise Destinataire")]
        public string TO_CRCY_CD { get; set; }

        [Display(Name = "ID Service Départ")]
        public int FROM_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Compte Destinataire")]
        public int TO_SERV_CTRY_ID { get; set; }

        [Display(Name = "ID Employé Entreprise")]
        public int FROM_USR_NBR { get; set; }
    }

    public class BusinessUserExceptionalRoleViewModel
    {
        public int Id { get; set; }

        public BusinessUserExceptionalRole busUsrExcpRole { get; set; }

        [Display(Name = "Nom Employé")]
        public string BUS_USR_FUL_NM { get; set; }

        [Display(Name = "Nom Agence")]
        public string BUS_USR_AGCY_NM { get; set; }
    }

    public class AddPayKapAgentViewModel
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) n'est pas valide.")]
        [Display(Name = "Numéro PayKap")]
        public string USR_BUS_NBR { get; set; }
    }

    public class AddPayKapAgentByAdminViewModel
    {
        [Key]
        public int Id { get; set; }

        //
        [StringLength(10, ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) du parrain n'est pas valide.")]
        [Display(Name = "Numéro PayKap")]
        public string SPNSR_USR_BUS_NBR { get; set; }

        [Required(ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) de l'agent est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le numéro PayKap Individuel (10 chiffres) ou d'organisation (9 chiffres) n'est pas valide.")]
        [Display(Name = "Numéro PayKap")]
        public string AGNT_USR_BUS_NBR { get; set; }
    }

    public class AgenWithErrorModel
    {
        [Key]
        public int Id { get; set; }

        public Agent agent { get; set; }

        [Display(Name = "Error")]
        public string ERR { get; set; }

        public AgenWithErrorModel()
        {
            agent = new Agent();
        }
    }

    public class AgentTransactionModel
    {
        [Key]
        public int Id { get; set; }
        public Agent SPNSR_AGNT_LVL1 { get; set; }
        public bool SPNSR_AGNT_IND1 { get; set; }
        public Agent SPNSR_AGNT_LVL2 { get; set; }
        public bool SPNSR_AGNT_IND2 { get; set; }
        public AgentTransactionCommission SPNSR_AGNT_CMSN_LVL1 { get; set; }
        public bool SPNSR_AGNT_CMSN_IND1 { get; set; }
        public AgentTransactionCommission SPNSR_AGNT_CMSN_LVL2 { get; set; }
        public bool SPNSR_AGNT_CMSN_IND2 { get; set; }

        public AgentTransactionModel()
        {
            SPNSR_AGNT_LVL1 = new Agent();
            SPNSR_AGNT_LVL2 = new Agent();
            SPNSR_AGNT_CMSN_LVL1 = new AgentTransactionCommission();
            SPNSR_AGNT_CMSN_LVL2 = new AgentTransactionCommission();
        }
    }
    
    public class AgencyTransactionClientData
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Le numéro de carte PayKap est obligatoire.")]
        //[StringLength(16, ErrorMessage = "Le numéro de carte PayKap doit avoir exactement 16 caractères", MinimumLength = 16)]
        //[Display(Name = "Numéro Carte PayKap")]
        //public string CARD_NBR { get; set; }

        //public bool CARD_NBR_USED_IND { get; set; }

        //[Display(Name = "Numéro Téléphone")]
        //public string USR_PHN_LGN_NBR { get; set; }

        //public bool PHN_NBR_USED_IND { get; set; }

        [Required(ErrorMessage = "Le nom du propriétaire du compte est obligatoire.")]
        [Display(Name = "Nom Propriétaire Compte")]
        public string CLT_FUL_NM { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire du compte est obligatoire.")]
        [Display(Name = "ID Propriétaire Compte")]
        public string CLT_USR_NBR { get; set; }

        [Required(ErrorMessage = "Le ID du propriétaire connexion est obligatoire.")]
        [Display(Name = "ID Propriétaire Connexion")]
        public string CLT_USR_ID { get; set; }

        [Display(Name = "ID Compte Client")]
        public int CLT_ACCT_ID { get; set; }

        [Display(Name = "Pays Client")]
        public string CLT_CTRY_CD { get; set; }

        [Display(Name = "Devise Client")]
        public string CLT_CRCY_CD { get; set; }

        //[Required(ErrorMessage = "Le NIP est obligatoire.")]
        //[RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Le NIP doit avoir des chiffres et de longueur 4.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "NIP")]
        //public string CARD_PIN { get; set; }
    }

    public class ViewClientDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "le numéro de téléphone ou le email est obligatoire.")]
        [Display(Name = "SEARCH")]
        public string PHN_NBR_EMAIL { get; set; }
    }

    public class GetUserBySearchTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [Display(Name = "Numéro ou Email")]
        public string NBR_OR_EMAIL { get; set; }
    }

    public class SelectPaymentViewModel
    {
        [Key]
        public int TRANS_ID { get; set; }

        [Required(ErrorMessage = "Choisir un type de paiement est obligatoire.")]
        [Display(Name = "Type Paiement")]
        public string PYMT_TCD { get; set; }
    }

    public class WithdrawalLocationListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Numéro Entreprise")]
        public int BN { get; set; }

        [Display(Name = "Nom Entreprise")]
        public string BUS_NM { get; set; }

        [Display(Name = "Code Agence")]
        public string BUS_AGCY_NBR { get; set; }
        
        [Display(Name = "Nom Agence")]
        public string BUS_AGCY_NM { get; set; }
        
        [Display(Name = "Description Heures Ouverture")]
        public string BUS_AGCY_OPNNG_HR { get; set; }
        
        [Display(Name = "Adresse Ligne 1")]
        public string BUS_AGCY_ADDR { get; set; }
        
        [Display(Name = "Téléphone")]
        public string PHN_NBR { get; set; }
        
        [Display(Name = "Nom Ville")]
        public string CITY_NM { get; set; }

        [Display(Name = "Nom Pays")]
        public string CTRY_NM { get; set; }
        
        [Display(Name = "Code Pays")]
        public string CTRY_CD { get; set; }

        [Display(Name = "Code Ville")]
        public int? CITY_CD { get; set; }

    }
}