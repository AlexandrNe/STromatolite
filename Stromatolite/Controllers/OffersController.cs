using Stromatolite.DAL;
using Stromatolite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stromatolite.Controllers
{
    public class OffersController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Offers
        public ActionResult Index()
        {
            OfferViewModel offerViewModel = new OfferViewModel();
            var offers = DAL.uof.OfferRepository.Get();
            return View(offerViewModel);
        }

        public ActionResult _Index()
        {
            var offers = DAL.uof.OfferRepository.Get();
            return View(offers);
        }

        // GET: Offers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Offers/Create
    
    }
}
