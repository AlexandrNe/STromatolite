
using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Stromatolite.ViewModels
{
    public sealed class OfferViewModel
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        private IEnumerable<Offer> offers;
        private IEnumerable<Group> groups;

        private async Task<OfferViewModel> InitializeAsync()
        {
            this.offers = await GetOffersAsync();
            this.groups = await GetGroupsAsync();
            return this;
        }

        public static Task<OfferViewModel> CreateAsync()
        {
            var ret = new OfferViewModel();
            return ret.InitializeAsync();
        }

        public IEnumerable<Offer> Offers { get { return this.offers; } }
        public IEnumerable<Group> Groups { get { return this.groups; } }



        private async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await DAL.uof.OfferRepository.GetAsync(filter: f => f.Product.Active, orderBy: q => q.OrderBy(d => d.Product.Ord));
        }

        private async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await DAL.uof.GroupRepository.GetAsync(filter: f => f.Active, orderBy: q => q.OrderBy(d => d.Ord));
        }

    }

}