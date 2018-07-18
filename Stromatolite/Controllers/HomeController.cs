using Stromatolite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stromatolite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OfferViewModel offerViewModel = new OfferViewModel();

            return View(offerViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}