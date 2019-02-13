using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ApiPaykapTransaction.Models.DAL
{
    [Table("dbo.TBUS_TY")]
    public class BusinessType
    {
        public BusinessType()
        {
            LGC_DEL_IND = "0";
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string BUS_TCD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BN { get; set; }

        [Required]
        [StringLength(1)]
        public string LGC_DEL_IND { get; set; }

        public virtual Business TBUS { get; set; }
        private DalContext db = new DalContext();

        public BusinessType addBusinessType(string BUS_TCD, int BN)
        {
            try
            {
                var obj = new BusinessType();

                obj.BUS_TCD = BUS_TCD;
                obj.BN = BN;
                db.TBUS_TY.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public bool checkOneBusinessType(string BUS_TCD, int BN)
        {
            var busTY = db.TBUS_TY.Where(x => x.BUS_TCD == BUS_TCD && x.BN == BN &&
                                                  x.LGC_DEL_IND == "0").ToList();
            if (busTY != null)
            {
                return true;
            }
            return false;
        }
    }
}
