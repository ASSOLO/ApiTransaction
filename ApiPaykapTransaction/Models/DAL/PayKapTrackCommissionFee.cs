using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TPKP_TRCK_CMSN_FEE")]
    public class PayKapTrackCommissionFee
    {
        public PayKapTrackCommissionFee()
        {
            TRANS_DT = DateTime.Now;
        }

        [Key]
        public long PKP_TRCK_CMSN_FEE_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string TRANS_ID { get; set; }

        public decimal TRANS_AMT { get; set; }

        [Required]
        [StringLength(3)]
        public string TRANS_CRCY_CD { get; set; }

        public decimal TRANS_US_AMT { get; set; }

        [Required]
        [StringLength(20)]
        public string BUS_AGNT_NBR { get; set; }

        [Required]
        [StringLength(1)]
        public string BUS_AGNT_TCD { get; set; }

        public DateTime TRANS_DT { get; set; }

        [Required]
        [StringLength(2)]
        public string SRVC_TCD { get; set; }

        [Required]
        [StringLength(1)]
        public string CMSN_FEE_TCD { get; set; }
    }
}