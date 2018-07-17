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

        [DisplayName("Кол-во")]
        [Required]
        public Nullable<int> Quantity { get; set; }

        [DisplayName("Ед.")]
        [Required]
        public int UnitID { get; set; }

        [DisplayName("Валюта")]
        [Required]
        public int CurrencyID { get; set; }

        [DisplayName("Цена")]
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Старая цена")]
        public Nullable<decimal> OldPrice { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
    }
}