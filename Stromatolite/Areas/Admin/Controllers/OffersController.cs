using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stromatolite.Models;

namespace Stromatolite.Areas.Admin.Controllers
{
    public class OffersController : Controller
    {
        private StromatoliteModel db = new StromatoliteModel();

        // GET: Admin/Offers
        public async Task<ActionResult> Index()
        {
            var offers = db.Offers.Include(o => o.Currency).Include(o => o.Product).Include(o => o.Unit);
            return View(await offers.ToListAsync());
        }

        // GET: Admin/Offers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Admin/Offers/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Title");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title");
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title");
            return View();
        }

        // POST: Admin/Offers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OfferID,ProductID,Quantity,UnitID,CurrencyID,Price,OldPrice")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                offer.OfferID = Guid.NewGuid();
                db.Offers.Add(offer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Title", offer.CurrencyID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", offer.ProductID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", offer.UnitID);
            return View(offer);
        }

        // GET: Admin/Offers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Title", offer.CurrencyID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", offer.ProductID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", offer.UnitID);
            return View(offer);
        }

        // POST: Admin/Offers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OfferID,ProductID,Quantity,UnitID,CurrencyID,Price,OldPrice")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "Title", offer.CurrencyID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", offer.ProductID);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Title", offer.UnitID);
            return View(offer);
        }

        // GET: Admin/Offers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Admin/Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Offer offer = await db.Offers.FindAsync(id);
            db.Offers.Remove(offer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
