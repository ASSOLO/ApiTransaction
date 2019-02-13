using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBUS_AGCY_SRVC")]
    public class BusinessAgencyService
    {
        public BusinessAgencyService()
        {
            LGC_DEL_IND = "0";
        }

        [Key]
        public int BUS_AGCY_SRVC_ID { get; set; }

        public int BN { get; set; }

        [Required]
        [StringLength(5)]
        public string BUS_AGCY_NBR { get; set; }

        [Required]
        [StringLength(2)]
        public string BUS_AGCY_SRVC_CD { get; set; }

        [Required]
        [StringLength(1)]
        public string LGC_DEL_IND { get; set; }

        public virtual BusinessAgency TBUS_AGCY { get; set; }
        private DalContext db = new DalContext();

        public BusinessAgencyService createBusinessAgencyService(int BN, string BUS_AGCY_NBR, string SRVC_CD)
        {
            var obj = new BusinessAgencyService();

            obj.BN = BN;
            obj.BUS_AGCY_NBR = BUS_AGCY_NBR;
            obj.BUS_AGCY_SRVC_CD = SRVC_CD;
            db.TBUS_AGCY_SRVC.Add(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
