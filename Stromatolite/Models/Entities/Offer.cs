using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Offer
    {
        [Key]
        public Guid OfferID { get; set; }

        public Guid ProductID { get; set; }

        public Nullable<int> Quantity { get; set; }
        public int UnitID { get; set; }
        public int CurrencyID { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
    }
}