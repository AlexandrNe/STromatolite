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
using Stromatolite.DAL;
using System.IO;
using Stromatolite.Helpers;

namespace Stromatolite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PicturesController : Controller
    {
        private StromatoliteModel db = new StromatoliteModel();
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Pictures
        public async Task<ActionResult> Index()
        {
            var pictures = db.Pictures.Include(p => p.Gallery);
            return View(await pictures.ToListAsync());
        }

        public PartialViewResult _Index(Guid id)
        {

            IEnumerable<Picture> pictures = DAL.uof.PictureRepository.Get(filter: f => f.GalleryID == id, orderBy: q => q.OrderBy(d => d.Ord).ThenBy(d => d.PicUrl));
            return PartialView(pictures);
        }

        // GET: Admin/Pictures/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = await db.Pictures.FindAsync(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Admin/Pictures/Create
        public ActionResult Create(Guid galleryID)
        {
            //ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title");
            return View();
        }

        // POST: Admin/Pictures/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {

                        var stream = fileContent.InputStream;

                        string fileName = Path.GetFileName(file);
                        string path = Path.Combine(Server.MapPath("~/img/temp"), fileName);
                        using (FileStream fs = new FileInfo(path).Create())
                        {
                            stream.CopyTo(fs);
                        }

                        if (Request.IsAjaxRequest())
                        {
                            //return PartialView("_Index", DAL.uof.PictureRepository.Get(filter: f => f.GalleryID == picture.GalleryID, orderBy: q => q.OrderBy(d => d.PicUrl)));
                        }

                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Сбой загрузки");
            }
            return Json("Файл успешно загружен.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFile()
        {

            string galleryID = Request.Form.GetValues("galleryID")[0];

            string galleryName = MyString.DeleteSpecChars(DAL.uof.GalleryRepository.GetByID(new Guid(galleryID)).Title);
            int ordMax = 0;
            IEnumerable<Picture> pics = (IEnumerable<Picture>)(await DAL.uof.PictureRepository.GetAsync(filter: f => f.GalleryID == new Guid(galleryID), orderBy: q => q.OrderBy(d => d.Ord)));

            if (pics != null)
            {
                try
                {
                    ordMax = (int)pics.Max(p => p.Ord);
                }
                catch (Exception)
                {

                    ordMax = 0;
                }

            }

            try
            {
                foreach (string file in Request.Files)
                {
                    ordMax++;
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {

                        var stream = fileContent.InputStream;

                        string fType = Path.GetFileName(file);

                        fType = fType.Substring(fType.LastIndexOf("."));
                        string fileName = MyString.Translit(MyString.HyphenTrim(galleryName)) + "-" + ordMax.ToString() + fType;
                        string path = Path.Combine(Server.MapPath("~/img/temp/"), fileName);
                        using (FileStream fs = new FileInfo(path).Create())
                        {
                            stream.CopyTo(fs);
                        }

                        string backFile = Path.Combine(Server.MapPath("~/img/temp"), "template-big2.jpg");
                        string frontFile = Path.Combine(Server.MapPath("~/img/temp"), "template-front2.png");

                        ImageHelpers.ConvertFile(path, backFile, frontFile, Server.MapPath("~/img/catalog/product-gallery"), fileName);

                        Picture picture = new Picture { GalleryID = new Guid(galleryID), PicUrl = "/img/catalog/product-gallery/" + fileName, PictureID = Guid.NewGuid(), Ord = ordMax, Title = fileName };
                        DAL.uof.PictureRepository.Insert(picture);
                        await DAL.uof.SaveAsync();

                    }
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Сбой загрузки: " + e.Message);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", await DAL.uof.PictureRepository.GetAsync(filter: f => f.GalleryID == new Guid(galleryID), orderBy: q => q.OrderBy(d => d.PicUrl)));
            }

            return Json("Файл успешно загружен.");
        }

        // GET: Admin/Pictures/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = await db.Pictures.FindAsync(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title", picture.GalleryID);
            return View(picture);
        }

        // POST: Admin/Pictures/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PictureID,Title,PicUrl,GalleryID,Ord")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Title", picture.GalleryID);
            return View(picture);
        }

        // GET: Admin/Pictures/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = await db.Pictures.FindAsync(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Admin/Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Picture picture = await db.Pictures.FindAsync(id);
            db.Pictures.Remove(picture);
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
