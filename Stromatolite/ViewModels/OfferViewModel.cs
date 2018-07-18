
using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stromatolite.ViewModels
{
    public class OfferViewModel
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        private IEnumerable<Offer> offers;
        private IEnumerable<Group> groups;

        public OfferViewModel()
        {
            this.offers = DAL.uof.OfferRepository.Get(filter: f => f.Product.Active, orderBy: q => q.OrderBy(d => d.Product.Ord));
            this.groups = DAL.uof.GroupRepository.Get(filter: f => f.Active, orderBy: q => q.OrderBy(d => d.Ord));

            //GroupComparer grComparer = new GroupComparer();
            //this.groups = this.groups.Distinct(grComparer).OrderBy(d => d.Ord).ToList();

        }
        public IEnumerable<Offer> Offers { get { return this.offers; } }
        public IEnumerable<Group> Groups { get { return this.groups; } }

    }

    //class GroupComparer : IEqualityComparer<Group>
    //{
    //    public bool Equals(Group x, Group y)
    //    {
    //        if (Object.ReferenceEquals(x, y))
    //        {
    //            return true;
    //        }

    //        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
    //        {
    //            return false;
    //        }

    //        return x.GroupID == y.GroupID;
    //    }

    //    public int GetHashCode(Group group)
    //    {
    //        if (Object.ReferenceEquals(group, null))
    //        {
    //            return 0;
    //        }

    //        int hashGroup = group.GroupID.GetHashCode();

    //        return hashGroup;
    //    }
    //}
}