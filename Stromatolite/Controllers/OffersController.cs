using Stromatolite.DAL;
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
            var offers = DAL.uof.OfferRepository.Get();
            return View(offers);
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Offers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Offers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
