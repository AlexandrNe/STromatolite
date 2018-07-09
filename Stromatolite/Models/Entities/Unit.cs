using System.Collections.Generic;

namespace Stromatolite.Models
{
    public class Unit
    {
        public Unit()
        {
            this.Offers = new HashSet<Offer>();
        }

        public int UnitID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}