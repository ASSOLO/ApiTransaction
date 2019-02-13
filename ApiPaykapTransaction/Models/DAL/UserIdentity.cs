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
    [Table("dbo.TUSR_ID")]
    public class UserIdentity
    {
        public UserIdentity()
        {
            IDENT_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int USR_ID { get; set; }


        [Display(Name = "Date")]
        public DateTime IDENT_DT { get; set; }

        private DalContext db = new DalContext();

        public UserIdentity generateLastPartUserNumber()
        {
            try
            {
                var obj = new UserIdentity();
                db.TUSR_ID.Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}