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

namespace Stromatolite.Controllers
{
    public class ProductsController : Controller
    {
        private StromatoliteModel db = new StromatoliteModel();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = db.Products.Include(p => p.Gallery).Include(p => p.Group);
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Title");
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,GroupID,Title,TitleFull,Article,Description,GalleryID,SEOurl,Active,Tags,MetaDescription,KeyWords,Ord")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = Guid.NewGuid();
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title", product.GalleryID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Title", product.GroupID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title", product.GalleryID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Title", product.GroupID);
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,GroupID,Title,TitleFull,Article,Description,GalleryID,SEOurl,Active,Tags,MetaDescription,KeyWords,Ord")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title", product.GalleryID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Title", product.GroupID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
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
