using System.Collections.Generic;

namespace Stromatolite.Models
{
    public class Currency
    {
        public Currency()
        {
            this.Offers = new HashSet<Offer>();
        }

        public int CurrencyID { get; set; }
        public string Title { get; set; }
        public string Abbr { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}