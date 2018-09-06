using Stromatolite.DAL;
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
        private DataAccessLayer DAL = new DataAccessLayer();
        public ActionResult Index()
        {
            OfferViewModel offerViewModel = new OfferViewModel();
            ViewBag.Title = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "Заголовок главной траницы (Title)").SettingValue;
            ViewBag.MetaDescription = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "MetaDescription").SettingValue;
            ViewBag.MetaKeywords = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "MetaKeywords").SettingValue;
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