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

namespace Stromatolite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GalCategoriesController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/GalCategories
        public async Task<ActionResult> Index()
        {
            var galCategories = await DAL.uof.GalCategoryRepository.GetAsync();
            return View(galCategories);
        }

        // GET: Admin/GalCategories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalCategory galCategory = await DAL.uof.GalCategoryRepository.GetByIDAsync(id);
            if (galCategory == null)
            {
                return HttpNotFound();
            }
            return View(galCategory);
        }

        // GET: Admin/GalCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GalCategories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GalCategoryID,Title,ProdGal")] GalCategory galCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    galCategory.GalCategoryID = Guid.NewGuid();
                    DAL.uof.GalCategoryRepository.Insert(galCategory);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Ошибка БД...");
                }
                
            }

            return View(galCategory);
        }

        // GET: Admin/GalCategories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalCategory galCategory = await DAL.uof.GalCategoryRepository.GetByIDAsync(id);
            if (galCategory == null)
            {
                return HttpNotFound();
            }
            return View(galCategory);
        }

        // POST: Admin/GalCategories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GalCategoryID,Title,ProdGal")] GalCategory galCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.GalCategoryRepository.Update(galCategory);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ошибка БД...");
                }
                
            }
            return View(galCategory);
        }

        // GET: Admin/GalCategories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalCategory galCategory = await DAL.uof.GalCategoryRepository.GetByIDAsync(id);
            if (galCategory == null)
            {
                return HttpNotFound();
            }
            return View(galCategory);
        }

        // POST: Admin/GalCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                DAL.uof.GalCategoryRepository.Delete(id);
                await DAL.uof.SaveAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("","Ошибка БД...");
            }
            
            return RedirectToAction("Index");
        }

    }
}
