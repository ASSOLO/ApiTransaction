using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT")]
    public class Agent
    {
        public Agent()
        {
            TAGNT_CMSN = new HashSet<AgentCommission>();
            TAGNT_TRANS_CMSN = new HashSet<AgentTransactionCommission>();
            TAGNT_SPNSRD = new HashSet<AgentSponsored>();
            TAGNT1 = new HashSet<Agent>();
            TAGNT_TRSF = new HashSet<AgentTransfer>();
            AGNT_EXP_IND = "0";
            AGNT_EDT = DateTime.Now;
            AGNT_XDT = DateTime.Now.AddYears(1);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Agent")]
        public int AGNT_ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string AGNT_NM { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Exp. ?")]
        public string AGNT_EXP_IND { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Eff.")]
        public DateTime AGNT_EDT { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Exp.")]
        public DateTime AGNT_XDT { get; set; }

        [StringLength(10)]
        [Display(Name = "ID Utilisateur")]
        public string AGNT_USR_NBR { get; set; }

        [Display(Name = "BN Entreprise")]
        public int? AGNT_BUS_NBR { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Type Agent")]
        public string AGNT_BUS_USR_TCD { get; set; }

        [Display(Name = "Type Agent")]
        [NotMapped]
        public string AGNT_BUS_USR_TCD_TXT
        {
            get
            {
                if (AGNT_BUS_USR_TCD == "1")
                {
                    return "Individu";
                }
                return "Organisation";
            }
        }

        [Display(Name = "ID Compte Agent")]
        public int AGNT_ACCT_ID { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Code Promo Agent")]
        public string AGNT_TKN_CD { get; set; }

        [Display(Name = "ID Parrain Agent")]
        public int? SPNSR_AGNT_ID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "ID Parrain Agent ?")]
        public string SPNSR_AGNT_IND { get; set; }

        [Display(Name = "Type Agent")]
        [NotMapped]
        public string SPNSR_AGNT_IND_TXT
        {
            get
            {
                if (SPNSR_AGNT_IND == "1")
                {
                    return "Oui";
                }
                return "Non";
            }
        }

        public virtual AccountBusinessAgentCommission TACCT_BUS_AGNT_CMSN { get; set; }

        public virtual User TUSR { get; set; }

        public virtual Business TBUS { get; set; }

        public virtual ICollection<AgentCommission> TAGNT_CMSN { get; set; }

        public virtual ICollection<AgentTransactionCommission> TAGNT_TRANS_CMSN { get; set; }

        public virtual ICollection<AgentSponsored> TAGNT_SPNSRD { get; set; }

        public virtual ICollection<Agent> TAGNT1 { get; set; }

        public virtual Agent TAGNT2 { get; set; }

        public virtual ICollection<AgentTransfer> TAGNT_TRSF { get; set; }

        private DalContext db = new DalContext();
        private string lang = "FRA";

        public string becomeAgent(Account acct, string CTRY_CD,
                                  string SPNSR_USR_NBR, int? SPNSR_BUS_NBR, string SPNSR_BUS_USR_TCD,
                                  string CUR_USR_NBR, int? CUR_BUS_NBR, string CUR_USR_BUS_TCD, string CUR_USR_BUS_NM,
                                  string displayAccountToSponsorIND, string spnsorControlCommissionAccountIND)
        {
            int agentID = 0;
            try
            {
                string tokenCD = generateOneAgentToken(CUR_USR_NBR, CUR_BUS_NBR, CUR_USR_BUS_TCD);
                if ((string.IsNullOrWhiteSpace(CUR_USR_NBR) && CUR_BUS_NBR == null) || string.IsNullOrWhiteSpace(tokenCD))
                {
                    return "gen_error";
                }

                if(tokenCD == "already_agent")
                {
                    return "already_agent";
                }
                
                int? spnsorID = null;
                if (SPNSR_BUS_USR_TCD != "3")
                {
                    var spnsor = getOneAgent(SPNSR_USR_NBR, SPNSR_BUS_NBR, SPNSR_BUS_USR_TCD);
                    if (spnsor.ERR == "not_found")
                    {
                        return "spnsor_not_found";
                    }

                    if (spnsor.ERR == "expiry")
                    {
                        return "spnsor_expiry";
                    }
                    if (spnsor.agent == null || spnsor.ERR == "error")
                    {
                        return "gen_error";
                    }
                    spnsorID = spnsor.agent.AGNT_ID;
                }

                //check if already has agent account
                var objAcct = new AccountBusinessAgentCommission();
                var checkAgntAcct = objAcct.getCommissionAccountByAcctId(acct.ACCT_ID);
                if (checkAgntAcct == null)
                {
                    string BUS_AGNT_TCD = "1"; // 1- For Agent (Individual & Business) 2- For Business
                    var crtAcctBusAgntCmsn =  objAcct.createAccountBusinessAgentCommission(acct, BUS_AGNT_TCD, displayAccountToSponsorIND,
                                                                 spnsorControlCommissionAccountIND);
                    if (crtAcctBusAgntCmsn == null)
                    {
                        return null;
                    }
                }

                var obj = new Agent();
                obj.AGNT_ACCT_ID = acct.ACCT_ID;
                obj.AGNT_NM = CUR_USR_BUS_NM;
                obj.AGNT_USR_NBR = CUR_USR_NBR;
                obj.AGNT_BUS_NBR = CUR_BUS_NBR;
                obj.AGNT_TKN_CD = tokenCD;
                obj.AGNT_BUS_USR_TCD = CUR_USR_BUS_TCD;
                obj.SPNSR_AGNT_ID = spnsorID;
                if (spnsorID == null)
                {
                    obj.SPNSR_AGNT_IND = "0";
                }
                else
                {
                    obj.SPNSR_AGNT_IND = "1";
                }
                db.TAGNT.Add(obj);
                db.SaveChanges();
                return "true";
            }
            catch
            {
                if (agentID != 0)
                {
                    var getNewAgentInsert = db.TAGNT.Find(agentID);
                    if (getNewAgentInsert != null)
                    {
                        db.TAGNT.Remove(getNewAgentInsert);
                    }
                }
                return null;
            }
        }

        public string generateOneAgentToken(string CUR_USR_NBR, int? CUR_BUS_NBR, string CUR_USR_BUS_TCD)
        {
            try
            {
                var agnt = getOneAgent(CUR_USR_NBR, CUR_BUS_NBR, CUR_USR_BUS_TCD);
                if (agnt.ERR == "error")
                {
                    return null;
                }
                if (agnt.agent != null || agnt.ERR != "not_found")
                {
                    return "already_agent";
                }

                string part1 = null;
                if (CUR_USR_BUS_TCD == "1")
                {
                    var usr = db.TUSR.Find(CUR_USR_NBR);
                    if (usr == null)
                    {
                        return null;
                    }

                    string USR_FNM = usr.USR_FNM.TrimStart();
                    string USR_LNM = usr.USR_LNM.TrimStart();
                    USR_FNM = CommonLibrary.replaceAccentedCharacter(USR_FNM);
                    USR_LNM = CommonLibrary.replaceAccentedCharacter(USR_LNM);

                    string[] USR_FNM_LIST = USR_FNM.Split(' ');
                    string[] USR_LNM_LIST = USR_LNM.Split(' ');
                    string fnm;
                    string lnm;
                    if (USR_FNM_LIST.Length > 1)
                    {
                        string firstName1 = USR_FNM_LIST[0].Substring(0, 1);
                        string firstName2 = USR_FNM_LIST[1].Substring(0, 1);
                        fnm = string.Concat(firstName1, firstName2);
                        lnm = USR_LNM_LIST[0].Substring(0, 1);
                    }
                    else if (USR_LNM_LIST.Length > 1)
                    {
                        fnm = USR_FNM_LIST[0].Substring(0, 1);
                        string lastName1 = USR_LNM_LIST[0].Substring(0, 1);
                        string lastName2 = USR_LNM_LIST[1].Substring(0, 1);
                        lnm = string.Concat(lastName1, lastName2);
                    }
                    else
                    {
                        fnm = USR_FNM_LIST[0].Substring(0, 1);
                        lnm = USR_LNM_LIST[0].Substring(0, 2);
                    }
                    part1 = string.Concat(lnm, fnm);
                }

                if (CUR_USR_BUS_TCD == "2")
                {
                    var bus = db.TBUS.Find(CUR_BUS_NBR);
                    if (bus == null)
                    {
                        return null;
                    }
                    string BUS_SHORT_NM = CommonLibrary.replaceAccentedCharacter(bus.BUS_SHORT_NM);
                    part1 = BUS_SHORT_NM.Substring(0, 3);
                }

                if (string.IsNullOrWhiteSpace(part1))
                {
                    return null;
                }
                part1 = part1.ToUpper();

                int i = 0;
                bool newPromoCodeIsAvailableIND = false;
                string AGNT_TKN_CD;
                do
                {
                    var promoCodeList = from b in db.TAGNT where b.AGNT_TKN_CD.StartsWith(part1) select b;

                    int intPart3 = 107 + promoCodeList.Count() + i;
                    if (intPart3 < 1000)
                    {
                        AGNT_TKN_CD = string.Concat(part1, "00", Convert.ToString(intPart3));
                    }
                    else if (intPart3 >= 1000 && intPart3 < 10000)
                    {
                        AGNT_TKN_CD = string.Concat(part1, "0", Convert.ToString(intPart3));
                    }
                    else
                    {
                        AGNT_TKN_CD = string.Concat(part1, Convert.ToString(intPart3));
                    }

                    if (AGNT_TKN_CD.Length != 8)
                    {
                        return null;
                    }
                    
                    var checkNewAGNT_TKN_CD = getValidAgentByTokenCD(AGNT_TKN_CD);
                    if (checkNewAGNT_TKN_CD == null)
                    {
                        newPromoCodeIsAvailableIND = true;
                    }
                    i++;
                }
                while (newPromoCodeIsAvailableIND == false);

                if (string.IsNullOrWhiteSpace(AGNT_TKN_CD))
                {
                    return null;
                }
                return AGNT_TKN_CD;
            }
            catch
            {
                return null;
            }
        }

        public Agent getValidAgentByTokenCD(string tokenCD)
        {
            try
            {
                var getAgntList = db.TAGNT.Where(x => x.AGNT_TKN_CD == tokenCD).ToList();
                if (getAgntList.Count() == 0)
                {
                    return null;
                }

                var getAgnt = getAgntList[0];
                if (getAgnt == null)
                {
                    return null;
                }

                if (DateTime.Compare(getAgnt.AGNT_XDT, DateTime.Now.Date) > 0)
                {
                    return getAgnt;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Agent getValidAgentBySponsoredUsrNbr(string spnsrdUsrNbr)
        {
            try
            {
                var getSpnsrd = db.TAGNT_SPNSRD.Find(spnsrdUsrNbr);
                if (getSpnsrd == null)
                {
                    return null;
                }
                
                var getAgntModel = getOneAgent(getSpnsrd.AGNT_ID);
                if (getAgntModel.agent != null && getAgntModel.ERR == "valid")
                {
                    return getAgntModel.agent; ;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public AgenWithErrorModel getOneAgent(int? agntID)
        {
            var agnt = new AgenWithErrorModel();
            try
            {
                var getAgnt = db.TAGNT.Find(agntID);
                if (getAgnt == null)
                {
                    agnt.ERR = "not_found";
                    agnt.agent = null;
                    return agnt;
                }

                if (DateTime.Compare(getAgnt.AGNT_XDT, DateTime.Now.Date) > 0)
                {
                    agnt.ERR = "valid";
                    agnt.agent = getAgnt;
                    return agnt;
                }
                else
                {
                    agnt.ERR = "expiry";
                    agnt.agent = null;
                    return agnt;
                }
            }
            catch
            {
                agnt.ERR = "error";
                agnt.agent = null;
                return agnt;
            }
        }

        public AgenWithErrorModel getOneAgent(string CUR_USR_NBR, int? CUR_BUS_NBR, string CUR_USR_BUS_TCD)
        {
            var agnt = new AgenWithErrorModel();
            try
            {
                var getAgent = new Agent();

                if (CUR_USR_BUS_TCD == "1")
                {
                    var agntList = db.TAGNT.Where(x => x.AGNT_USR_NBR == CUR_USR_NBR && x.AGNT_BUS_USR_TCD == "1").ToList();
                    if (agntList.Count() == 0)
                    {
                        agnt.ERR = "not_found";
                        agnt.agent = null;
                        return agnt;
                    }
                    getAgent = agntList[0];
                }

                if (CUR_USR_BUS_TCD == "2")
                {
                    var agntList = db.TAGNT.Where(x => x.AGNT_BUS_NBR == CUR_BUS_NBR && x.AGNT_BUS_USR_TCD == "2").ToList();
                    if (agntList.Count() == 0)
                    {
                        agnt.ERR = "not_found";
                        agnt.agent = null;
                        return agnt;
                    }
                    getAgent = agntList[0];
                }

                if(getAgent == null)
                {
                    agnt.ERR = "not_found";
                    agnt.agent = null;
                    return agnt;
                }

                if (DateTime.Compare(getAgent.AGNT_XDT, DateTime.Now.Date) > 0)
                {
                    agnt.ERR = "valid";
                    agnt.agent = getAgent;
                    return agnt;
                }
                else
                {
                    agnt.ERR = "expiry";
                    agnt.agent = null;
                    return agnt;
                }
            }
            catch
            {
                agnt.ERR = null;
                agnt.agent = null;
                return agnt;
            }
        }  

        public string getAgentUserId(Agent agent)
        {
            var acct = new Account();
            try
            {
                string usrNbr = null;
                if (agent.AGNT_BUS_USR_TCD == "1")
                {
                    usrNbr = agent.AGNT_USR_NBR;
                }
                else
                {
                    var getBus = db.TBUS.Find(agent.AGNT_BUS_NBR);
                    if (getBus != null)
                    {
                        var getBusAcct = acct.getAccountByAcctID(getBus.ACCT_ID);
                        if (getBusAcct != null)
                        {
                            usrNbr = getBusAcct.USR_NBR;
                        }
                    }
                }

                string Id = null;
                if (!string.IsNullOrWhiteSpace(usrNbr))
                {
                    var getUsr = db.TUSR.Find(usrNbr);
                    if (getUsr != null)
                    {
                        Id = getUsr.Id.TrimEnd();
                    }
                }
                return Id;
            }
            catch
            {
                return null;
            }
        }

        public bool checkValidAgentByID(string CUR_USR_NBR, int? CUR_BUS_NBR, string CUR_USR_BUS_TCD)
        {
            try
            {
                var agnt = getOneAgent(CUR_USR_NBR, CUR_BUS_NBR, CUR_USR_BUS_TCD);
                if (agnt.agent == null || agnt.ERR == "not_found" || agnt.ERR == "error" || agnt.ERR == "expiry")
                {
                    return false;
                }
                if (DateTime.Compare(agnt.agent.AGNT_XDT, DateTime.Now.Date) > 0)
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

        public bool checkValidAgentByID(int agntID)
        {
            try
            {
                var agnt = getOneAgent(agntID);
                if (agnt.agent == null || agnt.ERR == "not_found" || agnt.ERR == "error" || agnt.ERR == "expiry")
                {
                    return false;
                }
                if (DateTime.Compare(agnt.agent.AGNT_XDT, DateTime.Now.Date) > 0)
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

        public string handlePromoCodeError(string SENDER_USR_NBR, string PROMO_CODE, bool DISPLAY_PROMO_CODE_IND)
        {
            try
            {
                var agnt = new Agent();
                if (DISPLAY_PROMO_CODE_IND)
                {
                    if (!string.IsNullOrWhiteSpace(PROMO_CODE))
                    {
                        var getAgent = agnt.getValidAgentByTokenCD(PROMO_CODE);
                        if (getAgent == null)
                        {
                            return "Ce code promo n'est pas valide ou a expiré. Si vous n'avez pas un code valide, laissez le champ vide.";
                        }

                        //The agent cannot use the promo code
                        if (getAgent.AGNT_USR_NBR == SENDER_USR_NBR && getAgent.AGNT_BUS_USR_TCD == "1")
                        {
                            return "Vous ne pouvez pas utiliser votre propre code promo. Laissez le champ vide.";
                        }

                        //CHECK if the current is an agent
                        var checkIfCurrentAgent = agnt.getOneAgent(SENDER_USR_NBR, null, "1");
                        if (checkIfCurrentAgent.ERR == "valid" && checkIfCurrentAgent.agent != null)
                        {
                            return "Vous êtes un agent. Par conséquent, vous ne pouvez pas utiliser de code promo. Laissez le champ vide.";
                        }
                    }
                }
                return "continue";
            }
            catch
            {
                return null;
            }
        }

        public bool insertAgentCommission(ApplicationUserManager UserManager, DalFunction DAL,
                                          string AGNT_TKN_CD, decimal FEE_AMT, string FROM_CTRY_CD, string FROM_CRCY_CD,
                                          string SPNSRD_USR_NBR, string SPNSRD_USR_FUL_NM, string TRANS_NBR, string SRVC_TCD)
        {
            try
            {
                var agntSpnsrd = new AgentSponsored();
                var agntPkpCmsn = new AgentPayKapCommission();
                var agntTransCmsn = new AgentTransactionCommission();
                var crcyXchgRt = new CurrencyExchangeRate();
                var agntCmsn = new AgentCommission();

                if (!string.IsNullOrWhiteSpace(AGNT_TKN_CD))
                {
                    var getAgent = getValidAgentByTokenCD(AGNT_TKN_CD);
                    if (getAgent == null)
                    {
                        return false;
                    }

                    //insert the sponsored to agntSpnsrd table
                    agntSpnsrd.createAgentSponsored(getAgent.AGNT_ID, SPNSRD_USR_NBR, SPNSRD_USR_FUL_NM);
                    return true;
                }
                else if (FEE_AMT != 0.0m)
                {
                    string onlineAgcySrvcTCD = "1";
                    var getAgntCmsn = agntPkpCmsn.getOneAgentPayKapCommission(FROM_CTRY_CD, SRVC_TCD, onlineAgcySrvcTCD);
                    var getAgent = getValidAgentBySponsoredUsrNbr(SPNSRD_USR_NBR);
                    if (getAgent == null || getAgntCmsn == null)
                    {
                        return false;
                    }
                    
                    var transCmsnModel = new AgentTransactionModel();
                    int? BN = null;
                    string busIND = "0";

                    //get the exceptional commission, when excep is available, use it first.
                    var getAgentExcep = agntCmsn.getOneAgentCommission(getAgent.AGNT_ID, FROM_CTRY_CD, SRVC_TCD, onlineAgcySrvcTCD, BN, busIND);
                    
                    decimal convertFeeAmt1 = 0.0m;
                    string agntCrcyCD = getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                    if (agntCrcyCD != FROM_CRCY_CD)
                    {
                        decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, agntCrcyCD);
                        if (xchgRT != 0.0m)
                        {
                            convertFeeAmt1 = FEE_AMT * xchgRT;
                        }
                    }
                    else
                    {
                        convertFeeAmt1 = FEE_AMT;
                    }

                    transCmsnModel.SPNSR_AGNT_LVL1 = getAgent;
                    transCmsnModel.SPNSR_AGNT_IND1 = true;
                    decimal spnsrCmsnLVL1;
                    if (getAgentExcep != null)
                    {
                        if (getAgentExcep.CMSN_TCD == "1")
                        {
                            spnsrCmsnLVL1 = getAgentExcep.AGNT_FIX_CMSN_AMT;
                        }
                        else
                        {
                            spnsrCmsnLVL1 = getAgentExcep.AGNT_PRCNT_CMSN_RT * convertFeeAmt1;
                        }
                    }
                    else
                    {
                        if (getAgntCmsn.CMSN_TCD == "1")
                        {
                            spnsrCmsnLVL1 = getAgntCmsn.AGNT_FIX_CMSN_AMT;
                        }
                        else
                        {
                            spnsrCmsnLVL1 = getAgntCmsn.AGNT_PRCNT_CMSN_RT * convertFeeAmt1;
                        }
                    }

                    string AGNT_SPNSR_TCD = "1"; // 1= direct sponsor 2= indirect sponsor
                    string TRANS_ID = TRANS_NBR;
                    string CRCY_CD = getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                    string CMSN_TRANS_DESC = "Dépôt commission / Commission Deposit";
                    string SPNSRD_NBR = SPNSRD_USR_NBR;
                    string SPNSRD_NM = SPNSRD_USR_FUL_NM;
                    string SPNSRD_TCD = "1"; // 1= Client 2= entreprise
                    var newAgntTransCmsn = agntTransCmsn.insertAgentTransactionCommission(getAgent.AGNT_ID, AGNT_SPNSR_TCD, TRANS_ID,
                                                spnsrCmsnLVL1, CRCY_CD, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                    transCmsnModel.SPNSR_AGNT_CMSN_LVL1 = newAgntTransCmsn;
                    transCmsnModel.SPNSR_AGNT_CMSN_IND1 = true;

                    string AGNT_CMSN_IND1 = "0";
                    if (transCmsnModel.SPNSR_AGNT_IND1 && spnsrCmsnLVL1 != 0.0m)
                    {
                        AGNT_CMSN_IND1 = "1";
                    }

                    //handle the sponsor commission
                    string AGNT_CMSN_IND2 = "0";
                    if (getAgent.SPNSR_AGNT_IND == "1" && getAgent.SPNSR_AGNT_ID != null)
                    {
                        decimal convertFeeAmt2 = 0.0m;
                        var getAgent2 = getOneAgent(getAgent.SPNSR_AGNT_ID);
                        if (getAgent2.agent != null)
                        {
                            string agnt1CrcyCD = getAgent2.agent.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                            if (agnt1CrcyCD != FROM_CRCY_CD)
                            {
                                decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, agnt1CrcyCD);
                                if (xchgRT != 0.0m)
                                {
                                    convertFeeAmt2 = FEE_AMT * xchgRT;
                                }
                            }
                            else
                            {
                                convertFeeAmt2 = FEE_AMT;
                            }

                            transCmsnModel.SPNSR_AGNT_LVL2 = getAgent2.agent;
                            transCmsnModel.SPNSR_AGNT_IND2 = true;
                        }

                        decimal spnsrCmsnLVL2;
                        if (getAgentExcep != null)
                        {
                            if (getAgentExcep.APLY_SPNSR_CMSN_IND == "1")
                            {
                                if (getAgentExcep.CMSN_TCD == "1")
                                {
                                    spnsrCmsnLVL2 = getAgentExcep.SPNSR_FIX_CMSN_AMT;
                                }
                                else
                                {
                                    spnsrCmsnLVL2 = getAgentExcep.SPNSR_PRCNT_CMSN_RT * convertFeeAmt2;
                                }
                            }
                            else
                            {
                                if (getAgntCmsn.CMSN_TCD == "1")
                                {
                                    spnsrCmsnLVL2 = getAgntCmsn.SPNSR_FIX_CMSN_AMT;
                                }
                                else
                                {
                                    spnsrCmsnLVL2 = getAgntCmsn.SPNSR_PRCNT_CMSN_RT * convertFeeAmt2;
                                }
                            }
                        }
                        else
                        {
                            if (getAgntCmsn.CMSN_TCD == "1")
                            {
                                spnsrCmsnLVL2 = getAgntCmsn.SPNSR_FIX_CMSN_AMT;
                            }
                            else
                            {
                                spnsrCmsnLVL2 = getAgntCmsn.SPNSR_PRCNT_CMSN_RT * convertFeeAmt2;
                            }
                        }
                        
                        if (transCmsnModel.SPNSR_AGNT_IND2)
                        {
                            string AGNT_SPNSR_TCD1 = "2"; // 1= direct sponsor 2= indirect sponsor
                            string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                            var newAgntTransCmsn1 = agntTransCmsn.insertAgentTransactionCommission(transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ID, AGNT_SPNSR_TCD1, TRANS_ID,
                                                        spnsrCmsnLVL2, CRCY_CD1, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                            transCmsnModel.SPNSR_AGNT_CMSN_LVL2 = newAgntTransCmsn1;
                            transCmsnModel.SPNSR_AGNT_CMSN_IND2 = true;
                        }
                        
                        if (transCmsnModel.SPNSR_AGNT_IND2 && spnsrCmsnLVL2 != 0.0m)
                        {
                            AGNT_CMSN_IND2 = "1";
                        }
                    }
                    
                    var retVal = DAL.transferAgentCommissionTransaction(db, getAgent.AGNT_ACCT_ID, AGNT_CMSN_IND1,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_SPNSR_TCD,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_AMT,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DT,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DESC,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NM,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.SRVC_TCD,
                                                              transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ACCT_ID, AGNT_CMSN_IND2,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_SPNSR_TCD,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_AMT,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DT,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DESC,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NM,
                                                              transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.SRVC_TCD);

                    string TRANS_DATE = Convert.ToString(DateTime.Now);
                    if (transCmsnModel.SPNSR_AGNT_CMSN_IND1)
                    {
                        string userId1 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL1);
                        if (!string.IsNullOrWhiteSpace(userId1))
                        {
                            string amtTXT1 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL1, CRCY_CD, getAgent.TACCT_BUS_AGNT_CMSN.ACCT_CLTR_INFO);
                            //send a transcript
                            sendTransactionTranscript(UserManager, userId1, CMSN_TRANS_DESC, amtTXT1, TRANS_DATE, TRANS_NBR, "FRA");
                        }
                    }

                    if (transCmsnModel.SPNSR_AGNT_CMSN_IND2)
                    {
                        string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                        string userId2 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL2);
                        if (!string.IsNullOrWhiteSpace(userId2))
                        {
                            string amtTXT2 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL1, CRCY_CD1, getAgent.TACCT_BUS_AGNT_CMSN.ACCT_CLTR_INFO);
                            //send a transcript
                            sendTransactionTranscript(UserManager, userId2, CMSN_TRANS_DESC, amtTXT2, TRANS_DATE, TRANS_NBR, "FRA");
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool insertAgentCommissionDeleted(ApplicationUserManager UserManager, DalFunction DAL,
                                          string AGNT_TKN_CD, decimal FEE_AMT, string FROM_CTRY_CD, string FROM_CRCY_CD,
                                          string SPNSRD_USR_NBR, string SPNSRD_USR_FUL_NM, string TRANS_NBR, string SRVC_TCD)
        {
            try
            {
                var agntSpnsrd = new AgentSponsored();
                var agntPkpCmsn = new AgentPayKapCommission(); 
                var agntTransCmsn = new AgentTransactionCommission();
                var crcyXchgRt = new CurrencyExchangeRate();

                if (!string.IsNullOrWhiteSpace(AGNT_TKN_CD))
                {
                    var getAgent = getValidAgentByTokenCD(AGNT_TKN_CD);
                    if (getAgent == null)
                    {
                        return false;
                    }

                    //insert the sponsored to agntSpnsrd table
                    agntSpnsrd.createAgentSponsored(getAgent.AGNT_ID, SPNSRD_USR_NBR, SPNSRD_USR_FUL_NM);
                    return true;
                }
                else if (FEE_AMT != 0.0m)
                {
                    var getAgent = getValidAgentBySponsoredUsrNbr(SPNSRD_USR_NBR);
                    if (getAgent == null)
                    {
                        return false;
                    }

                    var transCmsnModel = new AgentTransactionModel();
                    //get sponsor commission
                    string onlineAgcySrvcTCD = "1";
                    var getAgntCmsn = agntPkpCmsn.getOneAgentPayKapCommission(FROM_CTRY_CD, SRVC_TCD, onlineAgcySrvcTCD);
                    if (getAgntCmsn != null)
                    {
                        decimal convertFeeAmt1 = 0.0m;
                        decimal convertFeeAmt2 = 0.0m;
                        if (getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD != FROM_CRCY_CD)
                        {
                            decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD);
                            if (xchgRT != 0.0m)
                            {
                                convertFeeAmt1 = FEE_AMT * xchgRT;
                            }
                        }
                        else
                        {
                            convertFeeAmt1 = FEE_AMT;
                        }

                        transCmsnModel.SPNSR_AGNT_LVL1 = getAgent;
                        transCmsnModel.SPNSR_AGNT_IND1 = true;

                        //get sponsor 2 commission
                        if (getAgent.SPNSR_AGNT_IND == "1" && getAgent.SPNSR_AGNT_ID != null)
                        {
                            var getAgent2 = getOneAgent(getAgent.SPNSR_AGNT_ID);
                            if (getAgent2.agent != null)
                            {
                                if (getAgent2.agent.TACCT_BUS_AGNT_CMSN.CRCY_CD != FROM_CRCY_CD)
                                {
                                    decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(FROM_CRCY_CD, getAgent2.agent.TACCT_BUS_AGNT_CMSN.CRCY_CD);
                                    if (xchgRT != 0.0m)
                                    {
                                        convertFeeAmt2 = FEE_AMT * xchgRT;
                                    }
                                }
                                else
                                {
                                    convertFeeAmt2 = FEE_AMT;
                                }

                                transCmsnModel.SPNSR_AGNT_LVL2 = getAgent2.agent;
                                transCmsnModel.SPNSR_AGNT_IND2 = true;
                            }
                        }

                        decimal spnsrCmsnLVL1;
                        decimal spnsrCmsnLVL2;
                        if (getAgntCmsn.CMSN_TCD == "1")
                        {
                            spnsrCmsnLVL1 = getAgntCmsn.AGNT_FIX_CMSN_AMT;
                            spnsrCmsnLVL2 = getAgntCmsn.SPNSR_FIX_CMSN_AMT;
                        }
                        else
                        {
                            spnsrCmsnLVL1 = getAgntCmsn.AGNT_PRCNT_CMSN_RT * convertFeeAmt1;
                            spnsrCmsnLVL2 = getAgntCmsn.SPNSR_PRCNT_CMSN_RT * convertFeeAmt2;
                        }


                        string AGNT_SPNSR_TCD = "1"; // 1= direct sponsor 2= indirect sponsor
                        string TRANS_ID = TRANS_NBR;
                        string CRCY_CD = getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                        string CMSN_TRANS_DESC = "Dépôt commission / Commission Deposit";
                        string SPNSRD_NBR = SPNSRD_USR_NBR;
                        string SPNSRD_NM = SPNSRD_USR_FUL_NM;
                        string SPNSRD_TCD = "1"; // 1= Client 2= entreprise
                        var newAgntTransCmsn = agntTransCmsn.insertAgentTransactionCommission(getAgent.AGNT_ID, AGNT_SPNSR_TCD, TRANS_ID,
                                                    spnsrCmsnLVL1, CRCY_CD, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                        transCmsnModel.SPNSR_AGNT_CMSN_LVL1 = newAgntTransCmsn;
                        transCmsnModel.SPNSR_AGNT_CMSN_IND1 = true;

                        if (transCmsnModel.SPNSR_AGNT_IND2)
                        {
                            string AGNT_SPNSR_TCD1 = "2"; // 1= direct sponsor 2= indirect sponsor
                            string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                            var newAgntTransCmsn1 = agntTransCmsn.insertAgentTransactionCommission(transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ID, AGNT_SPNSR_TCD1, TRANS_ID,
                                                        spnsrCmsnLVL2, CRCY_CD1, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                            transCmsnModel.SPNSR_AGNT_CMSN_LVL2 = newAgntTransCmsn1;
                            transCmsnModel.SPNSR_AGNT_CMSN_IND2 = true;
                        }

                        string AGNT_CMSN_IND1 = "0";
                        if (transCmsnModel.SPNSR_AGNT_IND1 && spnsrCmsnLVL1 != 0.0m)
                        {
                            AGNT_CMSN_IND1 = "1";
                        }

                        string AGNT_CMSN_IND2 = "0";
                        if (transCmsnModel.SPNSR_AGNT_IND2 && spnsrCmsnLVL2 != 0.0m)
                        {
                            AGNT_CMSN_IND2 = "1";
                        }

                        var retVal = DAL.transferAgentCommissionTransaction(db, getAgent.AGNT_ACCT_ID, AGNT_CMSN_IND1,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_SPNSR_TCD,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_AMT,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DT,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DESC,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NM,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.SRVC_TCD,
                                                      transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ACCT_ID, AGNT_CMSN_IND2,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_SPNSR_TCD,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_AMT,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DT,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DESC,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NM,
                                                      transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.SRVC_TCD);

                        string TRANS_DATE = Convert.ToString(DateTime.Now);
                        if (transCmsnModel.SPNSR_AGNT_CMSN_IND1)
                        {
                            string userId1 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL1);
                            if (!string.IsNullOrWhiteSpace(userId1))
                            {
                                string amtTXT1 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL1, CRCY_CD, getAgent.TACCT_BUS_AGNT_CMSN.ACCT_CLTR_INFO);
                                //send a transcript
                                sendTransactionTranscript(UserManager, userId1, CMSN_TRANS_DESC, amtTXT1, TRANS_DATE, TRANS_NBR, "FRA");
                            }
                        }

                        if (transCmsnModel.SPNSR_AGNT_CMSN_IND2)
                        {
                            string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                            string userId2 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL2);
                            if (!string.IsNullOrWhiteSpace(userId2))
                            {
                                string amtTXT2 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL1, CRCY_CD1, getAgent.TACCT_BUS_AGNT_CMSN.ACCT_CLTR_INFO);
                                //send a transcript
                                sendTransactionTranscript(UserManager, userId2, CMSN_TRANS_DESC, amtTXT2, TRANS_DATE, TRANS_NBR, "FRA");
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool sendTransactionTranscript(ApplicationUserManager UserManager,
                                              string userID, string TRANS_DESC, string TRANS_AMT,
                                              string TRANS_DATE, string TRANS_NBR, string lang)
        {
            string subject = "Votre reçu de transaction - Your transaction receipt";
            var body = SendEmail.PopulateBodyTransactionTranscript(TRANS_DESC, TRANS_AMT, TRANS_DATE, TRANS_NBR, lang);
            UserManager.SendEmail(userID, subject, body);
            return true;
        }

        public bool receiveTransactionTranscript(ApplicationUserManager UserManager,
                                                 string userID, string TRANS_DESC, string TRANS_AMT,
                                                 string TRANS_DATE, string TRANS_NBR, string lang)
        {
            string subject = "Alerte Dépôt d'argent - Money Deposit Alert";
            var body = SendEmail.PopulateBodyTransactionTranscript(TRANS_DESC, TRANS_AMT, TRANS_DATE, TRANS_NBR, lang);
            UserManager.SendEmail(userID, subject, body);
            return true;
        }

        public bool insertBusinessAgentCommission(ApplicationUserManager UserManager, DalFunction DAL, 
                                                  decimal FEE_AMT, string BUS_CTRY_CD, string BUS_CRCY_CD, string SRVC_TCD, int BN,
                                                  string TRANS_NBR, string SPNSRD_USR_NBR, string SPNSRD_USR_FUL_NM)
        {
            try
            {
                var agntSpnsrd = new AgentSponsored();
                var agntCmsn = new AgentCommission();
                var agntPkpCmsn = new AgentPayKapCommission();
                var agntTransCmsn = new AgentTransactionCommission();
                var crcyXchgRt = new CurrencyExchangeRate();

                //get sponsor commission
                string onlineAgcySrvcTCD = "2"; // 2 = agency
                var getAgntCmsnList = agntCmsn.getOneBusinessAgentCommission(BUS_CTRY_CD, SRVC_TCD, onlineAgcySrvcTCD, BN);
                if (getAgntCmsnList.Count() == 0)
                {
                    return false;
                }
                else
                {
                    var transCmsnModel = new AgentTransactionModel();
                    //get sponsor commission
                    var getAgntCmsn = getAgntCmsnList[0];
                    if (getAgntCmsn != null)
                    {
                        var getAgentModel = getOneAgent(getAgntCmsn.AGNT_ID);
                        if (getAgentModel.ERR == "valid" && getAgentModel.agent != null)
                        {
                            var getAgent = getAgentModel.agent;

                            decimal convertFeeAmt1 = 0.0m;
                            decimal convertFeeAmt2 = 0.0m;

                            if (getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD != BUS_CRCY_CD)
                            {
                                decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(BUS_CRCY_CD, getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD);
                                if (xchgRT != 0.0m)
                                {
                                    convertFeeAmt1 = FEE_AMT * xchgRT;
                                }
                            }
                            else
                            {
                                convertFeeAmt1 = FEE_AMT;
                            }

                            transCmsnModel.SPNSR_AGNT_LVL1 = getAgent;
                            transCmsnModel.SPNSR_AGNT_IND1 = true;

                            decimal spnsrCmsnLVL1 = 0.0m;
                            decimal spnsrCmsnLVL2 = 0.0m;
                            if (getAgntCmsn.CMSN_TCD == "1")
                            {
                                spnsrCmsnLVL1 = getAgntCmsn.AGNT_FIX_CMSN_AMT;
                            }
                            else
                            {
                                spnsrCmsnLVL1 = getAgntCmsn.AGNT_PRCNT_CMSN_RT * convertFeeAmt1;
                            }

                            //get sponsor 2 commission
                            if (getAgntCmsnList.Count() > 1)
                            {
                                var getAgntCmsn1 = getAgntCmsnList[1];
                                if (getAgntCmsn1 != null)
                                {
                                    var getAgentModel1 = getOneAgent(getAgntCmsn1.AGNT_ID);
                                    if (getAgentModel1.ERR == "valid" && getAgentModel1.agent != null)
                                    {
                                        var getAgent2 = getAgentModel1.agent;
                                        if (getAgent2.TACCT_BUS_AGNT_CMSN.CRCY_CD != BUS_CRCY_CD)
                                        {
                                            decimal xchgRT = crcyXchgRt.getExchangeRateByCurrency(BUS_CRCY_CD, getAgent2.TACCT_BUS_AGNT_CMSN.CRCY_CD);
                                            if (xchgRT != 0.0m)
                                            {
                                                convertFeeAmt2 = FEE_AMT * xchgRT;
                                            }
                                        }
                                        else
                                        {
                                            convertFeeAmt2 = FEE_AMT;
                                        }

                                        transCmsnModel.SPNSR_AGNT_LVL2 = getAgent2;
                                        transCmsnModel.SPNSR_AGNT_IND2 = true;
                                    }

                                    if (getAgntCmsn1.CMSN_TCD == "1")
                                    {
                                        spnsrCmsnLVL2 = getAgntCmsn1.AGNT_FIX_CMSN_AMT;
                                    }
                                    else
                                    {
                                        spnsrCmsnLVL2 = getAgntCmsn1.AGNT_PRCNT_CMSN_RT * convertFeeAmt2;
                                    }
                                }
                            }

                            string AGNT_SPNSR_TCD = "1"; // 1= direct sponsor 2= indirect sponsor
                            string TRANS_ID = TRANS_NBR;
                            string CRCY_CD = getAgent.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                            string CMSN_TRANS_DESC = "Dépôt commission / Commission Deposit";
                            string SPNSRD_NBR = SPNSRD_USR_NBR;
                            string SPNSRD_NM = SPNSRD_USR_FUL_NM;
                            string SPNSRD_TCD = "2"; // 1= Client 2= entreprise
                            var newAgntTransCmsn = agntTransCmsn.insertAgentTransactionCommission(getAgent.AGNT_ID, AGNT_SPNSR_TCD, TRANS_ID,
                                                        spnsrCmsnLVL1, CRCY_CD, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                            transCmsnModel.SPNSR_AGNT_CMSN_LVL1 = newAgntTransCmsn;
                            transCmsnModel.SPNSR_AGNT_CMSN_IND1 = true;

                            if (transCmsnModel.SPNSR_AGNT_IND2)
                            {
                                string AGNT_SPNSR_TCD1 = "2"; // 1= direct sponsor 2= indirect sponsor
                                string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                                var newAgntTransCmsn1 = agntTransCmsn.insertAgentTransactionCommission(transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ID, AGNT_SPNSR_TCD1, TRANS_ID,
                                                            spnsrCmsnLVL2, CRCY_CD1, CMSN_TRANS_DESC, SPNSRD_NBR, SPNSRD_NM, SPNSRD_TCD, SRVC_TCD);

                                transCmsnModel.SPNSR_AGNT_CMSN_LVL2 = newAgntTransCmsn1;
                                transCmsnModel.SPNSR_AGNT_CMSN_IND2 = true;
                            }

                            string AGNT_CMSN_IND1 = "0";
                            if (transCmsnModel.SPNSR_AGNT_IND1 && spnsrCmsnLVL1 != 0.0m)
                            {
                                AGNT_CMSN_IND1 = "1";
                            }

                            string AGNT_CMSN_IND2 = "0";
                            if (transCmsnModel.SPNSR_AGNT_IND2 && spnsrCmsnLVL2 != 0.0m)
                            {
                                AGNT_CMSN_IND2 = "1";
                            }

                            var retVal = DAL.transferAgentCommissionTransaction(db, getAgent.AGNT_ACCT_ID, AGNT_CMSN_IND1,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.AGNT_SPNSR_TCD,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_AMT,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DT,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_CMSN_DESC,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_NM,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL1.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL1.SRVC_TCD,
                                                          transCmsnModel.SPNSR_AGNT_LVL2.AGNT_ACCT_ID, AGNT_CMSN_IND2,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.AGNT_SPNSR_TCD,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_ID, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_AMT,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DT,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_CRCY_CD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_CMSN_DESC,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NBR, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_NM,
                                                          transCmsnModel.SPNSR_AGNT_CMSN_LVL2.TRANS_SPNSRD_TCD, transCmsnModel.SPNSR_AGNT_CMSN_LVL2.SRVC_TCD);

                            string TRANS_DATE = Convert.ToString(DateTime.Now);
                            if (transCmsnModel.SPNSR_AGNT_CMSN_IND1)
                            {
                                string userId1 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL1);
                                if (!string.IsNullOrWhiteSpace(userId1))
                                {
                                    string amtTXT1 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL1, CRCY_CD, getAgent.TACCT_BUS_AGNT_CMSN.ACCT_CLTR_INFO);
                                    //send a transcript
                                    sendTransactionTranscript(UserManager, userId1, CMSN_TRANS_DESC, amtTXT1, TRANS_DATE, TRANS_NBR, "FRA");
                                }
                            }

                            if (transCmsnModel.SPNSR_AGNT_CMSN_IND2)
                            {
                                string CRCY_CD1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                                string ACCT_CLTR_INFO1 = transCmsnModel.SPNSR_AGNT_LVL2.TACCT_BUS_AGNT_CMSN.CRCY_CD;
                                string userId2 = getAgentUserId(transCmsnModel.SPNSR_AGNT_LVL2);
                                if (!string.IsNullOrWhiteSpace(userId2))
                                {
                                    string amtTXT2 = CommonLibrary.displayFormattedCurrency(spnsrCmsnLVL2, CRCY_CD1, ACCT_CLTR_INFO1);
                                    //send a transcript
                                    sendTransactionTranscript(UserManager, userId2, CMSN_TRANS_DESC, amtTXT2, TRANS_DATE, TRANS_NBR, "FRA");
                                }
                            }
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}

