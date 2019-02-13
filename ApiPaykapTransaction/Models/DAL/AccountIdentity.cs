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
    [Table("dbo.TACCT_ID")]
    public class AccountIdentity
    {
        public AccountIdentity()
        {
            IDENT_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ACCT_ID { get; set; }


        [Display(Name = "Date")]
        public DateTime IDENT_DT { get; set; }

        private DalContext db = new DalContext();

        public AccountIdentity generateLastPartAccountNumber()
        {
            try
            {
                var obj = new AccountIdentity();
                db.TACCT_ID.Add(obj);
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