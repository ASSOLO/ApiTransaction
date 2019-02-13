namespace ApiPaykapTransaction.Models.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Common;
    using ApiPaykapTransaction.Models;

    public partial class DalContext : DbContext
    {
        public DalContext()
            : base("name=DalContext")
        {
        }

        public DalContext(DbConnection CN, bool ownContext)
            : base(CN, ownContext)
        {

        }

        public virtual DbSet<Currency> TCRCY { get; set; }
        public virtual DbSet<Country> TCTRY { get; set; }
        public virtual DbSet<CallingCountry> TCAL_CTRY { get; set; }
        public virtual DbSet<Province> TPROV { get; set; }
        public virtual DbSet<City> TCITY { get; set; }
        public virtual DbSet<Language> TLANG { get; set; }
        public virtual DbSet<BusinessProcess> TBP { get; set; }
        public virtual DbSet<TransferService> TTRSF_SERV { get; set; }
        public virtual DbSet<TransferServiceCountry> TTRSF_SERV_CTRY { get; set; }
        public virtual DbSet<MoneyTransferRaison> TMNYT_RSN { get; set; }
        public virtual DbSet<FinancialInstitution> TFI { get; set; }
        public virtual DbSet<SecurityQuestion> TSCTY_QUES_LIST { get; set; }
        public virtual DbSet<MoneyTransferAuthorizedLimit> TMNYT_AUTH_LMIT { get; set; }
        public virtual DbSet<TaxRateCountry> TTAX_RT_CTRY { get; set; }
        public virtual DbSet<User> TUSR { get; set; }
        public virtual DbSet<Contact> TKTCT { get; set; }
        public virtual DbSet<Account> TACCT { get; set; }
        public virtual DbSet<Card> TCARD { get; set; }
        public virtual DbSet<ConnexionLog> TCNX_LOG { get; set; }
        public virtual DbSet<CurrencyExchangeRate> TCRCY_XCHG_RT { get; set; }
        public virtual DbSet<InternetProtocolAddress> TIP_ADDR { get; set; }
        public virtual DbSet<BusinessProcessContract> TBP_CTRCT { get; set; }
        public virtual DbSet<Business> TBUS { get; set; }
        public virtual DbSet<BusinessAgency> TBUS_AGCY { get; set; }
        public virtual DbSet<BusinessUser> TBUS_USR { get; set; }
        public virtual DbSet<AccountCredit> TACCT_CRDT { get; set; }
        public virtual DbSet<FinancialInstitutionExternalAccount> TFI_EXRL_ACCT { get; set; }
        public virtual DbSet<FinancialInstitutionExternalAccountDescription> TFI_EXRL_ACCT_DESC { get; set; }
        public virtual DbSet<FinancialInstitutionType> TFI_TY { get; set; }
        public virtual DbSet<FinancialInstitutionCountry> TFI_CTRY { get; set; }
        public virtual DbSet<AccountHistory> TACCT_HIST { get; set; }
        public virtual DbSet<BankTransaction> TBNK_TRANS { get; set; }
        public virtual DbSet<BusinessCommission> TBUS_CMSN { get; set; }
        public virtual DbSet<BusinessCommissionTransaction> TBUS_CMSN_TRANS { get; set; }
        public virtual DbSet<CurrencyExchangePercent> TCRCY_XCHG_PRCNT { get; set; }
        public virtual DbSet<ExceptionalTransaction> TEXCEPT_TRANS { get; set; }
        public virtual DbSet<RecipientUserBusiness> TRCPT_USR_BUS { get; set; }
        public virtual DbSet<TransactionFee> TTRANS_FEE { get; set; }
        public virtual DbSet<TransactionTransferCreditDebit> TTRANS_TRSF_CRDT_DBT { get; set; }
        public virtual DbSet<TransferFeeServiceCountry> TTRSF_FEE_SERV_CTRY { get; set; }
        public virtual DbSet<UserWithdrawalCredit> TUSR_WHDRL_CRDT { get; set; }
        public virtual DbSet<BillPaymentTransaction> TBIL_PYMT_TRANS { get; set; }
        public virtual DbSet<BillPaymentCreditor> TBPCS { get; set; }
        public virtual DbSet<TransactionSession> TTRANS_SSN { get; set; }
        public virtual DbSet<PaymentPartner> TPYMT_PRTR { get; set; }
        public virtual DbSet<ExternalTransaction> TEXRL_TRANS { get; set; }
        public virtual DbSet<TransactionTemporary> TTRANS_TEMPO { get; set; }
        public virtual DbSet<RecipientExternalAccountForBusiness> TRCPT_EXRL_ACCT_FOR_BUS { get; set; }
        public virtual DbSet<CountryCurrency> TCTRY_CRCY { get; set; }
        public virtual DbSet<BusinessUserExceptionalRole> TBUS_USR_EXCP_ROL { get; set; }
        public virtual DbSet<IdentificationDocument> TID_DOC { get; set; }
        public virtual DbSet<TransactionIdentificationDocument> TTRANS_ID_DOC { get; set; }
        public virtual DbSet<BusinessInternalTransferTransaction> TBUS_INTRN_TRSF_TRANS { get; set; }
        public virtual DbSet<BusinessFee> TBUS_CTRY_FEE { get; set; }

        //public virtual DbSet<Account> TACCT { get; set; }
        public virtual DbSet<AccountBusinessAgentCommission> TACCT_BUS_AGNT_CMSN { get; set; }
        public virtual DbSet<Agent> TAGNT { get; set; }
        public virtual DbSet<AgentCommission> TAGNT_CMSN { get; set; }
        public virtual DbSet<AgentPayKapCommission> TAGNT_PKP_CMSN { get; set; }
        public virtual DbSet<AgentSponsored> TAGNT_SPNSRD { get; set; }
        public virtual DbSet<AgentTransactionCommission> TAGNT_TRANS_CMSN { get; set; }
        public virtual DbSet<AgentTransfer> TAGNT_TRSF { get; set; }
        //public virtual DbSet<Business> TBUS { get; set; }
        //public virtual DbSet<Currency> TCRCY { get; set; }
        //public virtual DbSet<Country> TCTRY { get; set; }
        public virtual DbSet<PayKapTrackCommissionFee> TPKP_TRCK_CMSN_FEE { get; set; }
        public virtual DbSet<AgentTransactionCommissionTemporary> TAGNT_TRANS_CMSN_TEMPO { get; set; }
        public virtual DbSet<UserPhoneLogin> TUSR_PHN_LGN { get; set; }
        public virtual DbSet<TransactionStartExternalSessionTemporary> TTRANS_START_XSSN_TEMPO { get; set; }
        public virtual DbSet<RecipientBusiness> TRCPT_BUS { get; set; }
        public virtual DbSet<OnBehalfClientCommission> TONBHLF_CLT_CMSN { get; set; }
        public virtual DbSet<OnBehalfClientTransaction> TONBHLF_CLT_TRANS { get; set; }
        public virtual DbSet<BusinessAgencyService> TBUS_AGCY_SRVC { get; set; }
        public virtual DbSet<AccountBusinessService> TACCT_BUS_SRVC { get; set; }
        public virtual DbSet<AccountIdentity> TACCT_ID { get; set; }
        public virtual DbSet<CardIdentity> TCARD_ID { get; set; }
        public virtual DbSet<UserIdentity> TUSR_ID { get; set; }
        public virtual DbSet<BusinessType> TBUS_TY { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //***************Currency entity*********************//
            modelBuilder.Entity<Currency>().Property(e => e.CRCY_CD).IsFixedLength().IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_FRA_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_ENG_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_SPA_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_ARB_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_POR_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_ZHO_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_RUS_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_DEU_NM).IsUnicode(false);

            modelBuilder.Entity<Currency>().Property(e => e.CRCY_ITA_NM).IsUnicode(false);

            //*****************FOREIGN KEY*****************************//

            modelBuilder.Entity<Currency>().HasMany(e => e.TCRCY_XCHG_RT).WithRequired(e => e.TCRCY).HasForeignKey(e => e.FROM_CRCY_CD).WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>().HasMany(e => e.TCRCY_XCHG_RT1).WithRequired(e => e.TCRCY1).HasForeignKey(e => e.TO_CRCY_CD).WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>().HasMany(e => e.TMNYT_AUTH_LMIT).WithRequired(e => e.TCRCY).WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>().HasMany(e => e.TACCT).WithRequired(e => e.TCRCY).WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TBUS_CMSN)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TBUS_CMSN_TRANS)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT)
                .WithRequired(e => e.TCRCY)
                .HasForeignKey(e => e.FROM_CRCY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT1)
                .WithRequired(e => e.TCRCY1)
                .HasForeignKey(e => e.TO_CRCY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TFI_EXRL_ACCT)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TTRANS_FEE)
                .WithRequired(e => e.TCRCY)
                .HasForeignKey(e => e.FROM_CRCY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TTRANS_FEE1)
                .WithRequired(e => e.TCRCY1)
                .HasForeignKey(e => e.TO_CRCY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TCTRY_CRCY)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TBUS_CTRY_FEE)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TAGNT_PKP_CMSN)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TONBHLF_CLT_TRANS)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TONBHLF_CLT_CMSN)
                .WithRequired(e => e.TCRCY)
                .WillCascadeOnDelete(false);

            //***************Country entity****************************//
            modelBuilder.Entity<Country>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.FRA_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ENG_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.SPA_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ARB_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.POR_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ZHO_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.RUS_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.DEU_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ITA_CTRY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
               .Property(e => e.LGC_DEL_IND)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<Country>()
               .Property(e => e.CTRY_LTR_CD)
               .IsFixedLength()
               .IsUnicode(false);

            //***********FOREIGN KEY MANAGEMENT*******************//
            modelBuilder.Entity<Country>()
                .HasMany(e => e.TPROV)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TCITY)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTAX_RT_CTRY)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TMNYT_AUTH_LMIT)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TKTCT)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TCARD)
                .WithRequired(e => e.TCTRY)
                .HasForeignKey(e => e.CARD_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTRSF_SERV_CTRY)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TFI_CTRY)
                .WithRequired(e => e.TCTRY)
                .HasForeignKey(e => e.FI_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TFI_EXRL_ACCT_DESC)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TBUS_CMSN)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT)
                .WithRequired(e => e.TCTRY)
                .HasForeignKey(e => e.FROM_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT1)
                .WithRequired(e => e.TCTRY1)
                .HasForeignKey(e => e.TO_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTRSF_FEE_SERV_CTRY)
                .WithRequired(e => e.TCTRY)
                .HasForeignKey(e => e.FROM_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TTRSF_FEE_SERV_CTRY1)
                .WithRequired(e => e.TCTRY1)
                .HasForeignKey(e => e.TO_CTRY_CD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TCTRY_CRCY)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TBUS_CTRY_FEE)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.TONBHLF_CLT_CMSN)
                .WithRequired(e => e.TCTRY)
                .WillCascadeOnDelete(false);

            //***************CallingCountry entity****************************//
            modelBuilder.Entity<CallingCountry>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CallingCountry>()
                .Property(e => e.CAL_CTRY_CD)
                .IsUnicode(false);

            modelBuilder.Entity<CallingCountry>()
                .Property(e => e.CTRY_PHN_NBR_LNGH_CNT);

            modelBuilder.Entity<CallingCountry>()
                .Property(e => e.CTRY_PHN_NBR_LNGH_LST_UPD_DT);

            modelBuilder.Entity<CallingCountry>()
               .Property(e => e.LGC_DEL_IND)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CallingCountry>()
                .HasMany(e => e.TUSR_PHN_LGN)
                .WithRequired(e => e.TCAL_CTRY)
                .WillCascadeOnDelete(false);

            //*********Province entity***********************************//
            modelBuilder.Entity<Province>()
                .Property(e => e.FRA_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ENG_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.SPA_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ARB_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.POR_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ZHO_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.RUS_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.DEU_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ITA_PROV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //***********FOREIGN KEY***************//
            modelBuilder.Entity<Province>()
                .HasMany(e => e.TTRSF_SERV_CTRY)
                .WithRequired(e => e.TPROV)
                .WillCascadeOnDelete(false);

            //*********************City entity************************//
            modelBuilder.Entity<City>()
                .Property(e => e.CITY_CD);

            modelBuilder.Entity<City>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.FRA_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ENG_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.SPA_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ARB_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.POR_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ZHO_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.RUS_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.DEU_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ITA_CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<City>()
               .HasMany(e => e.TKTCT)
               .WithRequired(e => e.TCITY)
               .WillCascadeOnDelete(false);

            //***************Language entity*********************//
            modelBuilder.Entity<Language>()
                .Property(e => e.LANG_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.FRA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ENG_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.SPA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ARB_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.POR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ZHO_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.RUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.DEU_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ITA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //*************FOREIGN KEY********************//
            modelBuilder.Entity<Language>()
                .HasMany(e => e.TUSR)
                .WithRequired(e => e.TLANG)
                .HasForeignKey(e => e.USR_PREF_LCD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.TCTRY_CRCY)
                .WithRequired(e => e.TLANG)
                .WillCascadeOnDelete(false);

            //***************BusinessProcesses entity*********************//
            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_FRA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_ENG_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_SPA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_ARB_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_POR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_ZHO_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_RUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_DEU_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.BP_ITA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcess>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //FK
            modelBuilder.Entity<BusinessProcess>()
                .HasMany(e => e.TBP_CTRCT)
                .WithRequired(e => e.TBP)
                .WillCascadeOnDelete(false);

            //***************BusinessProcessContract entity*********************//
            modelBuilder.Entity<BusinessProcessContract>()
                .Property(e => e.BP_CTRCT_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessProcessContract>()
               .Property(e => e.BN);

            modelBuilder.Entity<BusinessProcessContract>()
               .Property(e => e.BP_ID);

            modelBuilder.Entity<BusinessProcessContract>()
               .Property(e => e.BP_CTRCT_EDT);

            modelBuilder.Entity<BusinessProcessContract>()
               .Property(e => e.BP_CTRCT_XDT);

            modelBuilder.Entity<BusinessProcessContract>()
                .Property(e => e.BP_CTRCT_CRT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            //***************MoneyTransferService entity*********************//
            modelBuilder.Entity<TransferService>()
                .Property(e => e.FRA_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.ENG_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.SPA_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.ARB_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.POR_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.ZHO_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.RUS_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.DEU_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.ITA_TRSF_SERV_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransferService>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //***********FOREIGN KEY***************//
            modelBuilder.Entity<TransferService>()
                .HasMany(e => e.TTRSF_FEE_SERV_CTRY)
                .WithRequired(e => e.TTRSF_SERV)
                .HasForeignKey(e => e.FROM_TRSF_SERV_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferService>()
                .HasMany(e => e.TTRSF_FEE_SERV_CTRY1)
                .WithRequired(e => e.TTRSF_SERV1)
                .HasForeignKey(e => e.TO_TRSF_SERV_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransferService>()
                .HasMany(e => e.TTRSF_SERV_CTRY)
                .WithRequired(e => e.TTRSF_SERV)
                .WillCascadeOnDelete(false);

            //***************TransferServiceCountry entity***************//
            modelBuilder.Entity<TransferServiceCountry>()
               .Property(e => e.TRSF_SERV_CTRY_ID);

            modelBuilder.Entity<TransferServiceCountry>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransferServiceCountry>()
               .Property(e => e.PROV_CD);

            modelBuilder.Entity<TransferServiceCountry>()
               .Property(e => e.TRSF_SERV_ID);

            modelBuilder.Entity<TransferServiceCountry>()
               .Property(e => e.TRSF_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransferServiceCountry>()
                .Property(e => e.LAST_UPDT_DT);

            //***************MoneyTransferRaison entity*********************//
            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.FRA_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.ENG_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.SPA_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.ARB_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.POR_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.ZHO_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.RUS_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.DEU_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.ITA_MNYT_RSN_NM)
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferRaison>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //***************FinancialInstitution entity*********************//
            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_FRA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_ENG_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_SPA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_ARB_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_POR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_ZHO_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_RUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_DEU_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.FI_ITA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitution>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //***************FinancialInstitutionExternalAccount entity*********************//
            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_ID);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.EXRL_ACCT_TCD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_PRT1_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_PRT2_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_PRT3_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_PRT4_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_PRT5_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.EXRL_ACCT_PRT_NBR);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_VLDT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.EXRL_ACCT_DT);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.FI_CTRY_ID);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.EXRL_ACCT_USR_NBR)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
              .Property(e => e.EXRL_ACCT_BUS_NBR);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.EXRL_ACCT_USR_BUS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
               .Property(e => e.EXRL_ACCT_FOR_CURT_USR_IND)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .HasMany(e => e.TBNK_TRANS)
                .WithRequired(e => e.TFI_EXRL_ACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccount>()
                .HasMany(e => e.TRCPT_EXRL_ACCT_FOR_BUS)
                .WithOptional(e => e.TFI_EXRL_ACCT)
                .HasForeignKey(e => e.EXRL_ACCT_ID);

            //***************FinancialInstitutionExternalAccountDescription entity*********************//
            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
               .Property(e => e.EXRL_ACCT_DESC_ID);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
                .Property(e => e.EXRL_ACCT_PRT1_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
                .Property(e => e.EXRL_ACCT_PRT2_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
                .Property(e => e.EXRL_ACCT_PRT3_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
                .Property(e => e.EXRL_ACCT_PRT4_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
                .Property(e => e.EXRL_ACCT_PRT5_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
               .Property(e => e.EXRL_ACCT_DESC_DT);

            modelBuilder.Entity<FinancialInstitutionExternalAccountDescription>()
               .Property(e => e.CTRY_CD)
               .IsFixedLength()
                .IsUnicode(false);

            //***************FinancialInstitutionCountry entity*********************//
            modelBuilder.Entity<FinancialInstitutionCountry>()
              .Property(e => e.FI_CTRY_ID);

            modelBuilder.Entity<FinancialInstitutionCountry>()
               .Property(e => e.FI_CTRY_FRA_NM)
               .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_ENG_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_SPA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_ARB_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_POR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_ZHO_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_RUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_DEU_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_ITA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_ID);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.FI_TCD);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionCountry>()
                .HasMany(e => e.TFI_EXRL_ACCT)
                .WithRequired(e => e.TFI_CTRY)
                .WillCascadeOnDelete(false);

            //***************FinancialInstitutionType entity*********************//
            modelBuilder.Entity<FinancialInstitutionType>()
               .Property(e => e.FI_TCD);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_FRA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_ENG_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_SPA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_ARB_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_POR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_ZHO_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_RUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_DEU_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.FI_TY_ITA_NM)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FinancialInstitutionType>()
                .HasMany(e => e.TFI_CTRY)
                .WithRequired(e => e.TFI_TY)
                .WillCascadeOnDelete(false);

            //***************SecurityQuestion entity*********************//
            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_FRA)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_ENG)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_SPA)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_ARB)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_POR)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_ZHO)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_RUS)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_DEU)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.SCTY_QUES_ITA)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //*********FOREIGN KEY****************/
            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.TCNX_LOG)
                .WithRequired(e => e.TSCTY_QUES_LIST)
                .HasForeignKey(e => e.QUES1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.TCNX_LOG1)
                .WithRequired(e => e.TSCTY_QUES_LIST1)
                .HasForeignKey(e => e.QUES2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.TCNX_LOG2)
                .WithRequired(e => e.TSCTY_QUES_LIST2)
                .HasForeignKey(e => e.QUES3)
                .WillCascadeOnDelete(false);

            //***************MoneyTransferFee entity*********************//
            //modelBuilder.Entity<MoneyTransferFee>()
            //    .HasKey(e => e.MNYT_FEE_ID);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.MNYT_FEE_ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //    base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.FROM_CTRY_CD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.TO_CTRY_CD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //  .Property(e => e.PROV_CD);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.FROM_CRCY_CD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.TO_CRCY_CD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //   .Property(e => e.FROM_MNYT_SERV_ID);

            //modelBuilder.Entity<MoneyTransferFee>()
            //   .Property(e => e.TO_MNYT_SERV_ID);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.FROM_AMT)
            //    .HasPrecision(14, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.TO_AMT)
            //    .HasPrecision(14, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.FIX_FEE_AMT)
            //    .HasPrecision(14, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.PRCNT_FEE_RT)
            //    .HasPrecision(6, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.PRCNT_NO_99P_FRC_INV)
            //    .HasPrecision(6, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.PRCNT_CRCY_XCH_RT_AJSMN)
            //    .HasPrecision(6, 4);

            //modelBuilder.Entity<MoneyTransferFee>()
            //   .Property(e => e.MNYT_TCD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.MNYT_FEE_TCD)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<MoneyTransferFee>()
            //    .Property(e => e.LAST_UPDT_DT);

            //***************MoneyTransferAuthorizedLimit entity***************//
            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
               .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
               .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
               .Property(e => e.MNYT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
                .Property(e => e.TRANS_AUTH_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
                .Property(e => e.DLY_AUTH_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
                .Property(e => e.WKLY_AUTH_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
                .Property(e => e.MTHLY_AUTH_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<MoneyTransferAuthorizedLimit>()
                .Property(e => e.LAST_UPDT_DT);

            //***************TaxRateCountry entity***************//
            modelBuilder.Entity<TaxRateCountry>()
               .Property(e => e.TAX_RT_CTRY_ID);

            modelBuilder.Entity<TaxRateCountry>()
               .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaxRateCountry>()
                .Property(e => e.TAX_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<TaxRateCountry>()
                .Property(e => e.LAST_UPDT_DT);

            //**************User entity****************//
            modelBuilder.Entity<User>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_FNM)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_LNM)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_GNDR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_BRDAY);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_PREF_LCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_KTCT_ID);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_99P_FRC_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_VERIF_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_MBRSHP_EDT);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_DFLT_PWD_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_DFLT_EMAIL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USR_EMAIL_VRFT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
               .Property(e => e.USR_EMAIL_VRFT_DT);

            modelBuilder.Entity<User>()
               .Property(e => e.USR_LNM)
               .IsUnicode(false);

            modelBuilder.Entity<User>()
               .Property(e => e.PHN1_NBR)
               .IsUnicode(false);

            //**************** FOREIGN KEYS ****************//
            modelBuilder.Entity<User>()
               .HasMany(e => e.TACCT)
               .WithRequired(e => e.TUSR)
               .HasForeignKey(e => e.USR_NBR)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TCARD)
                .WithRequired(e => e.TUSR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.TCNX_LOG)
                .WithRequired(e => e.TUSR);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TCRCY_XCHG_RT)
                .WithRequired(e => e.TUSR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TBP_CTRCT)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.BP_CTRCT_CRT_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TBUS_USR)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.BUS_EMPE_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TFI_EXRL_ACCT)
                .WithRequired(e => e.TUSR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TFI_EXRL_ACCT)
                .WithOptional(e => e.TUSR)
                .HasForeignKey(e => e.EXRL_ACCT_USR_NBR);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TFI_EXRL_ACCT1)
                .WithRequired(e => e.TUSR1)
                .HasForeignKey(e => e.USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TIP_ADDR)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.IP_ADDR_CRT_UPD_USR_NBR)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.TEXCEPT_TRANS)
            //    .WithRequired(e => e.TUSR)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TRCPT_USR_BUS)
                .WithOptional(e => e.TUSR)
                .HasForeignKey(e => e.RCPT_USR_NBR);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TRCPT_USR_BUS1)
                .WithRequired(e => e.TUSR1)
                .HasForeignKey(e => e.USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.FROM_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.TUSR_WHDRL_CRDT)
                .WithRequired(e => e.TUSR);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TTRANS_SSN)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.CLT_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TTRANS_ID_DOC)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.CLT_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TAGNT)
                .WithOptional(e => e.TUSR)
                .HasForeignKey(e => e.AGNT_USR_NBR);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.TAGNT_SPNSRD)
                .WithRequired(e => e.TUSR);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TUSR_PHN_LGN)
                .WithRequired(e => e.TUSR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TRCPT_BUS)
                .WithRequired(e => e.TUSR)
                .HasForeignKey(e => e.RCPT_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TRCPT_BUS1)
                .WithRequired(e => e.TUSR1)
                .HasForeignKey(e => e.USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(e => e.TONBHLF_CLT_TRANS)
               .WithRequired(e => e.TUSR)
               .HasForeignKey(e => e.USR_NBR)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(e => e.TONBHLF_CLT_CMSN)
               .WithRequired(e => e.TUSR)
               .HasForeignKey(e => e.USR_NBR)
               .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.TUSR_MBRSHP_FEE_PYMNT_TRANS)
            //    .WithRequired(e => e.TUSR)
            //    .WillCascadeOnDelete(false);

            //*********************Contact entity*****************************/
            modelBuilder.Entity<Contact>()
               .Property(e => e.KTCT_ID); ;

            modelBuilder.Entity<Contact>()
                .Property(e => e.ADDR_LN1_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ADDR_LN2_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.PHN1_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.PHN2_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.EM_ADDR1_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.EM_ADDR2_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.WEBSITE_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.KTCT_TCD);

            modelBuilder.Entity<Contact>()
                .Property(e => e.CITY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.CITY_CD);

            //Foreign K
            modelBuilder.Entity<Contact>()
                .HasMany(e => e.TBUS)
                .WithRequired(e => e.TKTCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.TBUS_AGCY)
                .WithRequired(e => e.TKTCT)
                .HasForeignKey(e => e.BUS_AGCY_KTCT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.TUSR)
                .WithRequired(e => e.TKTCT)
                .HasForeignKey(e => e.USR_KTCT_ID)
                .WillCascadeOnDelete(false);


            //*********************Account entity*****************************/
            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_ID);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_BAL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_CLTR_INFO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ACCT_CDT);

            modelBuilder.Entity<Account>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            //************FOREIGN KEY*****************************************//
            modelBuilder.Entity<Account>()
                .HasMany(e => e.TACCT_HIST)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TBUS_USR)
                .WithRequired(e => e.TACCT)
                .HasForeignKey(e => e.BUS_ACCT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TBUS_AGCY)
                .WithRequired(e => e.TACCT)
                .HasForeignKey(e => e.BUS_AGCY_ACCT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TBUS)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TRCPT_USR_BUS)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TBPCS)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.TACCT_BUS_AGNT_CMSN)
                .WithRequired(e => e.TACCT);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TUSR_PHN_LGN)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.TACCT_CRDT)
                .WithRequired(e => e.TACCT);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TRCPT_BUS)
                .WithRequired(e => e.TACCT)
                .HasForeignKey(e => e.RCPT_ACCT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TACCT_BUS_SRVC)
                .WithRequired(e => e.TACCT)
                .WillCascadeOnDelete(false);

            //*********************Account Credit entity*****************************/
            modelBuilder.Entity<AccountCredit>()
               .Property(e => e.ACCT_ID);

            modelBuilder.Entity<AccountCredit>()
                .Property(e => e.ACCT_CRDT_AMT)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AccountCredit>()
               .Property(e => e.ACCT_CRDT_DT);

            modelBuilder.Entity<AccountCredit>()
                .Property(e => e.ACCT_CRDT_NO_CHCK_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //*********************Account History entity*****************************/
            modelBuilder.Entity<AccountHistory>()
               .Property(e => e.ACCT_HIST_ID);

            modelBuilder.Entity<AccountHistory>()
               .Property(e => e.ACCT_ID);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_PAY_SRC_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.BAL_AFTR_TRANS)
                .HasPrecision(18, 4);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_DTTM);

            modelBuilder.Entity<AccountHistory>()
                .Property(e => e.TRANS_DESC)
                .IsUnicode(false);

            //*********************Card entity*****************************/
            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_ID);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_OWNR_FNM)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_CVV_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_PIN)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_EDT);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_XDT);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.CARD_CDT);

            modelBuilder.Entity<Card>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.DFLT_PIN_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.PHYS_CARD_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .HasMany(e => e.TUSR_PHN_LGN)
                .WithRequired(e => e.TCARD)
                .WillCascadeOnDelete(false);
            
            //*********************Connexion Log entity*****************************/
            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.QUES1);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.RESP1)
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.QUES2);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.RESP2)
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.QUES3);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.RESP3)
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.CNX_SCTY_QUES_SEQ_NBR);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.CNX_SCTY_QUES_CHKED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.IP_ADDR_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.IP_VERS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ConnexionLog>()
                .Property(e => e.LAST_CNX_DTTM);

            //***************CurrencyExchangeRate entity*********************//

            modelBuilder.Entity<CurrencyExchangeRate>()
                .Property(e => e.FROM_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyExchangeRate>()
                .Property(e => e.TO_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyExchangeRate>()
                .Property(e => e.CRCY_XCHG_RT)
                .HasPrecision(18, 10);

            modelBuilder.Entity<CurrencyExchangeRate>()
                .Property(e => e.CRCY_XCHG_RT_UPD_DT);

            modelBuilder.Entity<CurrencyExchangeRate>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            //***************InternetProtocolAddress entity*********************//
            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.IP_ADDR_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.IP_VERS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.IP_ADDR_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.BUS_AGCY_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.IP_ADDR_CRT_DT);

            modelBuilder.Entity<InternetProtocolAddress>()
                .Property(e => e.IP_ADDR_CRT_UPD_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            //***************Business entity*********************//
            modelBuilder.Entity<Business>()
               .Property(e => e.BN);

            modelBuilder.Entity<Business>()
              .Property(e => e.KTCT_ID);

            modelBuilder.Entity<Business>()
              .Property(e => e.ACCT_ID);

            modelBuilder.Entity<Business>()
               .Property(e => e.BUS_NM)
               .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.BUS_SHORT_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.BUS_AREA)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.CARD_ID);

            modelBuilder.Entity<Business>()
                .Property(e => e.BUS_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.DFLT_BUS_DSPL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TBUS_TY)
                .WithRequired(e => e.TBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TBP_CTRCT)
                .WithRequired(e => e.TBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TBUS_AGCY)
                .WithRequired(e => e.TBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
               .HasMany(e => e.TBUS_CMSN)
               .WithRequired(e => e.TBUS)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TRCPT_USR_BUS)
                .WithOptional(e => e.TBUS)
                .HasForeignKey(e => e.RCPT_BUS_NBR);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TFI_EXRL_ACCT)
                .WithOptional(e => e.TBUS)
                .HasForeignKey(e => e.EXRL_ACCT_BUS_NBR);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TBPCS)
                .WithRequired(e => e.TBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TRCPT_EXRL_ACCT_FOR_BUS)
                .WithRequired(e => e.TBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TAGNT)
                .WithOptional(e => e.TBUS)
                .HasForeignKey(e => e.AGNT_BUS_NBR);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.TAGNT_CMSN)
                .WithOptional(e => e.TBUS)
                .HasForeignKey(e => e.PRTNSP_BN);

            //***************BusinessAgency entity*********************//
            modelBuilder.Entity<BusinessAgency>()
               .Property(e => e.BN);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
               .Property(e => e.BUS_AGCY_KTCT_ID);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_HDQRTR_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
              .Property(e => e.BUS_AGCY_ACCT_ID);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_INTRNT_CHK_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_MXAMT_TO_WDRW_AMT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_AV_AMT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_OPNNG_HR)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
                .Property(e => e.BUS_AGCY_NO_SRVC_AV_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgency>()
                .HasMany(e => e.TIP_ADDR)
                .WithOptional(e => e.TBUS_AGCY)
                .HasForeignKey(e => new { e.BN, e.BUS_AGCY_NBR });

            modelBuilder.Entity<BusinessAgency>()
                .HasMany(e => e.TBUS_USR)
                .WithRequired(e => e.TBUS_AGCY)
                .HasForeignKey(e => new { e.BN, e.BUS_AGCY_NBR })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessAgency>()
               .HasMany(e => e.TBUS_USR_EXCP_ROL)
               .WithRequired(e => e.TBUS_AGCY)
               .HasForeignKey(e => new { e.BN, e.BUS_AGCY_NBR })
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessAgency>()
                .HasMany(e => e.TBUS_AGCY_SRVC)
                .WithRequired(e => e.TBUS_AGCY)
                .HasForeignKey(e => new { e.BN, e.BUS_AGCY_NBR })
                .WillCascadeOnDelete(false);

            //***************BusinessAgencyService entity*********************//
            modelBuilder.Entity<BusinessAgencyService>()
                .Property(e => e.BN);

            modelBuilder.Entity<BusinessAgencyService>()
                .Property(e => e.BUS_AGCY_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgencyService>()
                .Property(e => e.BUS_AGCY_SRVC_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAgencyService>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //***************BusinessUser entity*********************//
            modelBuilder.Entity<BusinessUser>()
              .Property(e => e.BUS_USR_NBR);

            modelBuilder.Entity<BusinessUser>()
             .Property(e => e.BN);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_AGCY_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_ACCT_ID);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_USR_EDT);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_USR_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_AV_CAMT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_EMPE_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_USR_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUser>()
                .Property(e => e.BUS_EMPE_IS_PKP_CLT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUser>()
                .HasMany(e => e.TBUS_CMSN_TRANS)
                .WithRequired(e => e.TBUS_USR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessUser>()
                .HasMany(e => e.TBUS_USR_EXCP_ROL)
                .WithRequired(e => e.TBUS_USR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessUser>()
                .HasMany(e => e.TTRANS_ID_DOC)
                .WithRequired(e => e.TBUS_USR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessUser>()
                .HasMany(e => e.TBUS_INTRN_TRSF_TRANS)
                .WithRequired(e => e.TBUS_USR)
                .HasForeignKey(e => e.FROM_BUS_USR_NBR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessUser>()
                .HasMany(e => e.TBUS_INTRN_TRSF_TRANS1)
                .WithRequired(e => e.TBUS_USR1)
                .HasForeignKey(e => e.TO_BUS_USR_NBR)
                .WillCascadeOnDelete(false);

            //BankTransaction
            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.FROM_TO_USR_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.TRANS_TRSF_CRDT_DBT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.EXRL_BNK_TRANS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.EXRL_BNK_TRANS_DESC)
                .IsUnicode(false);

            //BusinessCommission
            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.FROM_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.TO_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.BUS_CMSN_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.BUS_CMSN_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessCommission>()
                .Property(e => e.BUS_OFR_SRVC_TO_OWN_CLT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //BusinessCommissionTransaction
            modelBuilder.Entity<BusinessCommissionTransaction>()
                .Property(e => e.BUS_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessCommissionTransaction>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessCommissionTransaction>()
                .Property(e => e.TRANS_TRSF_CRDT_DBT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            //CurrencyExchangePercent
            modelBuilder.Entity<CurrencyExchangePercent>()
                .Property(e => e.IVSTR_CRCY_XCHG_PRCNT_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<CurrencyExchangePercent>()
                .Property(e => e.NIVSTR_CRCY_XCHG_PRCNT_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<CurrencyExchangePercent>()
                .HasMany(e => e.TTRANS_FEE)
                .WithRequired(e => e.TCRCY_XCHG_PRCNT)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<ExceptionalTransaction>()
                .Property(e => e.EXCEPT_TRANS_RCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionalTransaction>()
                .Property(e => e.TRANS_AUTH_KTCT_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionalTransaction>()
                .Property(e => e.TRANS_AUTH_KTCT_PHN)
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionalTransaction>()
                .Property(e => e.ACTION_TAKEN_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<ExceptionalTransaction>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS_ID);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.ACCT_ID);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS1_UIN)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS2_UIN)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS3_UIN)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_BUS_NBR);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.RCPT_USR_BUS_EDT);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
               .Property(e => e.LGC_DEL_IND)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .Property(e => e.ACTVT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .HasMany(e => e.TTRANS_TRSF_CRDT_DBT)
                .WithRequired(e => e.TRCPT_USR_BUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipientUserBusiness>()
                .HasMany(e => e.TRCPT_EXRL_ACCT_FOR_BUS)
                .WithOptional(e => e.TRCPT_USR_BUS)
                .HasForeignKey(e => e.RCPT_USR_BUS_ID);

            //
            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.FROM_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.TO_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.FROM_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.TO_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.IVSTR_FIX_FEE_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.IVSTR_PRCNT_FEE_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.NIVSTR_FIX_FEE_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.NIVSTR_PRCNT_FEE_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.TRANS_FEE_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.TRANS_FEE_GRP_NM)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionFee>()
                .Property(e => e.TRANS_FEE_GRP_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionFee>()
                .HasMany(e => e.TTRSF_FEE_SERV_CTRY)
                .WithRequired(e => e.TTRANS_FEE)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TO_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TO_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.CRCY_XCHG_RT)
                .HasPrecision(13, 6);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_FEE_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_TOT_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TO_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TRANS_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.FROM_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TRANS_TRSF_CRDT_DBT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .Property(e => e.TRANS_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasMany(e => e.TBNK_TRANS)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasMany(e => e.TBUS_CMSN_TRANS)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasOptional(e => e.TEXCEPT_TRANS)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasOptional(e => e.TBIL_PYMT_TRANS)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasOptional(e => e.TTRANS_TEMPO)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasOptional(e => e.TTRANS_ID_DOC)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
                .HasOptional(e => e.TAGNT_TRANS_CMSN_TEMPO)
                .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            modelBuilder.Entity<TransactionTransferCreditDebit>()
               .HasOptional(e => e.TONBHLF_CLT_TRANS)
               .WithRequired(e => e.TTRANS_TRSF_CRDT_DBT);

            //
            modelBuilder.Entity<TransferFeeServiceCountry>()
               .Property(e => e.TRSF_FEE_SERV_CTRY_ID);

            modelBuilder.Entity<TransferFeeServiceCountry>()
               .Property(e => e.TRANS_FEE_ID);

            modelBuilder.Entity<TransferFeeServiceCountry>()
               .Property(e => e.FROM_TRSF_SERV_ID);

            modelBuilder.Entity<TransferFeeServiceCountry>()
               .Property(e => e.TO_TRSF_SERV_ID);

            modelBuilder.Entity<TransferFeeServiceCountry>()
                .Property(e => e.FROM_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransferFeeServiceCountry>()
                .Property(e => e.TO_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<UserWithdrawalCredit>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserWithdrawalCredit>()
                .Property(e => e.USR_WHDRL_CRDT_NBR);

            //
            modelBuilder.Entity<BillPaymentTransaction>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<BillPaymentTransaction>()
                .Property(e => e.CLT_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentTransaction>()
                .Property(e => e.BIL_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentTransaction>()
               .Property(e => e.BIL_PYMT_TRANS_DT);

            //
            modelBuilder.Entity<TransactionSession>()
              .Property(e => e.TRANS_SSN_ID);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_SECR_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_SECR_ID_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_AMT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_AMT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_CUST_AMT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_SURL_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_FURL_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
               .Property(e => e.TRANS_SSN_EDTTM);

            modelBuilder.Entity<TransactionSession>()
               .Property(e => e.TRANS_SSN_XDTTM);

            modelBuilder.Entity<TransactionSession>()
               .Property(e => e.BPCS_NBR);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.CLT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.CLT_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
               .Property(e => e.CLT_EMAIL_TXT)
               .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.CLT_LANG_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
               .Property(e => e.CLT_CTRY_CD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.CLT_BIL_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH1_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH2_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH3_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH4_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH5_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionSession>()
                .Property(e => e.TRANS_SSN_OTH5_TXT)
                .IsUnicode(false);

            //
            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.BPCS_BUS_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.BPCS_BUS_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.BPCS_CLT_ACCT_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.BPCS_URL_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.BPCS_URL_NEED_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .Property(e => e.ACCT_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BillPaymentCreditor>()
                .HasMany(e => e.TTRANS_SSN)
                .WithRequired(e => e.TBPCS)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<PaymentPartner>()
                .Property(e => e.PYMT_PRTR_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PaymentPartner>()
                .Property(e => e.PYMT_PRTR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentPartner>()
                .Property(e => e.PYMT_PRTR_EDT);

            modelBuilder.Entity<PaymentPartner>()
                .Property(e => e.PYMT_PRTR_XDT);

            modelBuilder.Entity<PaymentPartner>()
                .Property(e => e.PYMT_PRTR_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentPartner>()
               .HasMany(e => e.TEXRL_TRANS)
                .WithRequired(e => e.TPYMT_PRTR)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<ExternalTransaction>()
                .Property(e => e.EXRL_TRANS_ID);

            modelBuilder.Entity<ExternalTransaction>()
                .Property(e => e.PKP_TRANS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.PRTR_TRANS_ID)
               .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.PRTR_TRANS_RCD)
               .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.EXRL_TRANS_NSS_ID)
               .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.EXRL_TRANS_OTH_DTL_TXT)
               .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.PYMT_PRTR_ID)
               .IsUnicode(false);

            modelBuilder.Entity<ExternalTransaction>()
               .Property(e => e.EXRL_TRANS_DT);

            //
            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.FROM_PKP_ACCT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.FROM_PKP_ACCT_ID);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.FROM_TRANS_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.TO_SRVC_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.TO_PKP_ACCT_ID);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.TO_BNK_ACCT_ID);

            modelBuilder.Entity<TransactionTemporary>()
                .Property(e => e.TO_TRANS_DESC)
                .IsUnicode(false);

            //
            modelBuilder.Entity<RecipientExternalAccountForBusiness>()
                .Property(e => e.RCPT_EXRL_ACCT_FOR_BUS_ID);

            modelBuilder.Entity<RecipientExternalAccountForBusiness>()
                .Property(e => e.EXRL_ACCT_ID);

            modelBuilder.Entity<RecipientExternalAccountForBusiness>()
                .Property(e => e.RCPT_USR_BUS_ID);

            modelBuilder.Entity<RecipientExternalAccountForBusiness>()
                .Property(e => e.BN);

            modelBuilder.Entity<RecipientExternalAccountForBusiness>()
                .Property(e => e.RCPT_EXRL_ACCT_FOR_BUS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.CTRY_CRCY_ID);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.LANG_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.CRCY_CLTR_INFO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.CTRY_CRCY_CDT);

            modelBuilder.Entity<CountryCurrency>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<BusinessUserExceptionalRole>()
               .Property(e => e.BUS_USR_EXCP_ROL_ID);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.BN);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.BUS_AGCY_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.BUS_USR_EXCP_ROL_EXPY_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.BUS_USR_EXCP_ROL_EDT);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.BUS_USR_EXCP_ROL_XDT);

            modelBuilder.Entity<BusinessUserExceptionalRole>()
                .Property(e => e.TRANS_TRSF_CRDT_DBT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            //***************IdentificationDocument entity****************************//
            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.ID_DOC_ID);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.FRA_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.ENG_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.SPA_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.ARB_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.POR_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.ZHO_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.RUS_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.DEU_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
                .Property(e => e.ITA_ID_DOC_NM)
                .IsUnicode(false);

            modelBuilder.Entity<IdentificationDocument>()
               .Property(e => e.LGC_DEL_IND)
               .IsFixedLength()
               .IsUnicode(false);

            //***********FOREIGN KEY MANAGEMENT*******************//
            modelBuilder.Entity<IdentificationDocument>()
                .HasMany(e => e.TTRANS_ID_DOC)
                .WithRequired(e => e.TID_DOC)
                .WillCascadeOnDelete(false);


            //***************TransactionIdentificationDocument entity****************************//
            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.ID_DOC_ID);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.ID_DOC_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.ID_DOC_XDT);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.BUS_USR_NBR);

            modelBuilder.Entity<TransactionIdentificationDocument>()
               .Property(e => e.CLT_USR_NBR)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.CLT_ID_DOC_BRDAY);

            modelBuilder.Entity<TransactionIdentificationDocument>()
                .Property(e => e.TRANS_ID_DOC_DT);

            //
            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.FROM_BUS_USR_NBR);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.FROM_BUS_USR_NM)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TO_BUS_USR_NBR);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
               .Property(e => e.TO_BUS_USR_NM)
               .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.FROM_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TO_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.FROM_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TO_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.CRCY_XCHG_RT)
                .HasPrecision(13, 6);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.FROM_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TO_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TRANS_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TRANS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessInternalTransferTransaction>()
                .Property(e => e.TRANS_DESC)
                .IsUnicode(false);

            //
            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.FROM_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.TO_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.FIX_FEE_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.PRCNT_FEE_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.BUS_FEE_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessFee>()
                .Property(e => e.BUS_FEE_DT);

            //
            modelBuilder.Entity<AccountBusinessAgentCommission>()
           .Property(e => e.ACCT_TCD)
           .IsFixedLength()
           .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.ACCT_BAL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.ACCT_CLTR_INFO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.ACCT_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.BUS_AGNT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.DPLY_ACCT_TO_SPNSR_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .Property(e => e.SPNSR_CNTL_CMSN_ACCT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessAgentCommission>()
                .HasMany(e => e.TAGNT)
                .WithRequired(e => e.TACCT_BUS_AGNT_CMSN)
                .HasForeignKey(e => e.AGNT_ACCT_ID)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<Agent>()
                .Property(e => e.AGNT_NM)
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.AGNT_EXP_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.AGNT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.AGNT_BUS_USR_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.AGNT_TKN_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .Property(e => e.SPNSR_AGNT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.TAGNT_CMSN)
                .WithRequired(e => e.TAGNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.TAGNT_TRANS_CMSN)
                .WithRequired(e => e.TAGNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.TAGNT_SPNSRD)
                .WithRequired(e => e.TAGNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.TAGNT1)
                .WithOptional(e => e.TAGNT2)
                .HasForeignKey(e => e.SPNSR_AGNT_ID);

            modelBuilder.Entity<Agent>()
                .HasMany(e => e.TAGNT_TRSF)
                .WithRequired(e => e.TAGNT)
                .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<AgentCommission>()
                     .Property(e => e.SRVC_TCD)
                     .IsFixedLength()
                     .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.ONLN_AGCY_SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.AGNT_CLT_PRTR_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.AGNT_FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.AGNT_PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.SPNSR_FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.SPNSR_PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.CMSN_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.CMSN_CUR_APBL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.APLY_PRCNT_TRANS_FEE_PTNR_CMSN_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentCommission>()
                .Property(e => e.APLY_SPNSR_CMSN_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.ONLN_AGCY_SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.AGNT_FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.AGNT_PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.SPNSR_FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.SPNSR_PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.CMSN_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentPayKapCommission>()
                .Property(e => e.CMSN_CUR_APBL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<AgentSponsored>()
                .Property(e => e.SPNSRD_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentSponsored>()
                .Property(e => e.SPNSRD_FUL_NM)
                .IsUnicode(false);

            //
            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.AGNT_SPNSR_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_CMSN_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_CMSN_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_SPNSRD_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_SPNSRD_NM)
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.TRANS_SPNSRD_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommission>()
                .Property(e => e.SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<AgentTransfer>()
                .Property(e => e.AGNT_TRSF_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<AgentTransfer>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.TRANS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.TRANS_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.TRANS_US_AMT)
                .HasPrecision(13, 8);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.BUS_AGNT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.BUS_AGNT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PayKapTrackCommissionFee>()
                .Property(e => e.CMSN_FEE_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            //
            modelBuilder.Entity<AgentTransactionCommissionTemporary>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<AgentTransactionCommissionTemporary>()
                .Property(e => e.NEW_TO_TRSF_SRVC_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AgentTransactionCommissionTemporary>()
               .Property(e => e.AGNT_TKN_CD)
               .IsFixedLength()
               .IsUnicode(false);

            //
            modelBuilder.Entity<UserPhoneLogin>()
                .Property(e => e.USR_PHN_LGN_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<UserPhoneLogin>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserPhoneLogin>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserPhoneLogin>()
                .Property(e => e.USR_PHN_LGN_VRFT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserPhoneLogin>()
               .Property(e => e.USR_PHN_LGN_VRFT_DT);

            modelBuilder.Entity<UserPhoneLogin>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
               .Property(e => e.TRANS_SSN_ID);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
               .Property(e => e.TRANS_SSN_SECR_ID)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.FROM_SRVC_ID);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TO_SRVC_ID);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.FROM_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TO_CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.FROM_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TO_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.SEND_RCPT_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.FROM_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.FROM_TRANS_AMT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_FEE_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_FEE_AMT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_FEE_AMT_PROMO_CD)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_FEE_AMT_TXT_PROMO_CD)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TOT_TO_PAY_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TOT_TO_PAY_AMT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TOT_TO_PAY_AMT_PROMO_CD)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TOT_TO_PAY_AMT_TXT_PROMO_CD)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TO_TRANS_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TO_TRANS_AMT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.CRCY_XCHG_RT)
                .HasPrecision(18, 10);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.CRCY_XCHG_RT_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.DPLY_CRCY_XCHG_RT_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.ADJUST_XCHG_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_EDTTM);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_XDTTM);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.CLT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_OTH1_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_OTH2_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_OTH3_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_OTH4_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStartExternalSessionTemporary>()
                .Property(e => e.TRANS_OTH5_TXT)
                .IsUnicode(false);

            //RecipientBusiness
            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_ACCT_CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_FUL_NM)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.RCPT_EDT);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.ACTVT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecipientBusiness>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);
            
            //
            modelBuilder.Entity<OnBehalfClientTransaction>()
                .Property(e => e.TRANS_ID);

            modelBuilder.Entity<OnBehalfClientTransaction>()
               .Property(e => e.USR_NBR)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientTransaction>()
                .Property(e => e.CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<OnBehalfClientTransaction>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientTransaction>()
                .Property(e => e.TRANS_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            //
            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.USR_NBR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.SRVC_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.CTRY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.FIX_CMSN_AMT)
                .HasPrecision(14, 4);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.PRCNT_CMSN_RT)
                .HasPrecision(6, 4);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.CMSN_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OnBehalfClientCommission>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //AccountBusinessService
            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_BUS_SRVC_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.CRCY_CD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_NBR)
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_BAL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_CLTR_INFO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_SCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_OTH1_IND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AccountBusinessService>()
                .Property(e => e.ACCT_OTH2_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //BusinessType
            modelBuilder.Entity<BusinessType>()
                .Property(e => e.BUS_TCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BusinessType>()
                .Property(e => e.BN);

            modelBuilder.Entity<BusinessType>()
                .Property(e => e.LGC_DEL_IND)
                .IsFixedLength()
                .IsUnicode(false);

            //MAP TO THE STORED PROCEDURE
            //modelBuilder.Entity<UserIndividualRegister>().MapToStoredProcedures
            //(
            //    s => s.Insert(i => i.HasName("[dbo].[Product_Insert_HandCoded]"))
            //          .Update(u => u.HasName("[dbo].[Product_Update_HandCoded]"))
            //          .Delete(d => d.HasName("[dbo].[Product_Delete_HandCoded]"))
            //);
            //base.OnModelCreating(modelBuilder);

        }

        public DbSet<ApiPaykapTransaction.Models.UserIndividualRegister> UserIndividualRegisters { get; set; }

        public DbSet<ApiPaykapTransaction.Models.AddPhoneNumberViewModel> AddPhoneNumberViewModels { get; set; }

        public DbSet<ApiPaykapTransaction.Models.VerifyPhoneNumberViewModel> VerifyPhoneNumberViewModels { get; set; }

    }
}
