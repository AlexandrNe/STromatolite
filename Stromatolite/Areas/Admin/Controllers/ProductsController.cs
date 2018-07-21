using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Stromatolite.Models;
using Stromatolite.DAL;

namespace Stromatolite.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Products
        public async Task<ActionResult> Index()
        {
            var products = await DAL.uof.ProductRepository.GetAsync(orderBy: q => q.OrderBy(d => d.Ord));
            return View(products);
        }

        // GET: Admin/Products/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await DAL.uof.ProductRepository.GetByIDAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(DAL.uof.GroupRepository.Get(orderBy: q => q.OrderBy(d => d.Ord).ThenBy(d => d.Title)), "GroupID", "Title");
            return View();
        }

        // POST: Admin/Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,GroupID,Title,TitleFull,Article,Description,SEOurl,Active,Tags,MetaDescription,KeyWords,Ord")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductID = Guid.NewGuid();
                    Guid galleryID = Guid.NewGuid();
                    DAL.uof.GalleryRepository.Insert(new Gallery { GalCategoryID = DAL.uof.GalCategoryRepository.GetByField(f => f.ProdGal).GalCategoryID,
                                                                    GalleryID = galleryID,
                                                                    Title = product.Title});
                    product.GalleryID = galleryID;
                    DAL.uof.ProductRepository.Insert(product);
                    DAL.uof.OfferRepository.Insert(new Offer { OfferID = Guid.NewGuid(),
                                                                CurrencyID = 1,
                                                                UnitID = 1,
                                                                OldPrice = 1,
                                                                Price = 1,
                                                                ProductID = product.ProductID,
                                                                Quantity = 1});

                    DAL.uof.PictureRepository.Insert(new Picture
                                                                {
                                                                    PictureID = Guid.NewGuid(),
                                                                    GalleryID = galleryID,
                                                                    Ord = 100,
                                                                    PicUrl = "~/img"
                                                                });

                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Ошибка БД");
                }

            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await DAL.uof.ProductRepository.GetByIDAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,GroupID,Title,TitleFull,Article,Description,GalleryID,SEOurl,Active,Tags,MetaDescription,KeyWords,Ord")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.ProductRepository.Update(product);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Ошибка БД...");

                }
                
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await DAL.uof.ProductRepository.GetByIDAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                DAL.uof.ProductRepository.Delete(id);
                await DAL.uof.SaveAsync();
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Ошибка БД...");
            }

            return RedirectToAction("Index");
        }

      
    }
}
