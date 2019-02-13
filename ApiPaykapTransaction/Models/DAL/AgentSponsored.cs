using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TAGNT_SPNSRD")]
    public class AgentSponsored
    {
        public AgentSponsored()
        {
            SPNSRD_CRT_DT = DateTime.Now;
        }

        [Key]
        [StringLength(10)]
        public string SPNSRD_USR_NBR { get; set; }

        public DateTime SPNSRD_CRT_DT { get; set; }

        [Required]
        [StringLength(255)]
        public string SPNSRD_FUL_NM { get; set; }

        public int AGNT_ID { get; set; }

        public virtual Agent TAGNT { get; set; }

        public virtual User TUSR { get; set; }

        private DalContext db = new DalContext();

        public bool createAgentSponsored(int agntID, string SPNSRD_USR_NBR, string SPNSRD_FUL_NM)
        {
            try
            {
                var usrSpnsrd = db.TAGNT_SPNSRD.Find(SPNSRD_USR_NBR);
                if(usrSpnsrd != null)
                {
                    return false;
                }

                var obj = new AgentSponsored();
                obj.SPNSRD_USR_NBR = SPNSRD_USR_NBR;
                obj.SPNSRD_FUL_NM = SPNSRD_FUL_NM;
                obj.AGNT_ID = agntID;
                db.TAGNT_SPNSRD.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<AgentSponsored> getAllAgentSponsoredByAgentID(int agntID)
        {
            var list = new List<AgentSponsored>();
            try
            {
                return db.TAGNT_SPNSRD.Where(x => x.AGNT_ID == agntID).ToList();
            }
            catch
            {
                return list;
            }
        }

    }
}
