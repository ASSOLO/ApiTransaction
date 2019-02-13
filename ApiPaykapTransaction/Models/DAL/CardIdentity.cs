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
    [Table("dbo.TCARD_ID")]
    public class CardIdentity
    {
        public CardIdentity()
        {
            IDENT_DT = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CARD_ID { get; set; }


        [Display(Name = "Date")]
        public DateTime IDENT_DT { get; set; }

        private DalContext db = new DalContext();

        public CardIdentity generateLastPartCardNumber()
        {
            try
            {
                var obj = new CardIdentity();
                db.TCARD_ID.Add(obj);
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