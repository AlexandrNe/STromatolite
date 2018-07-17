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
    public class GroupsController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Groups
        public async Task<ActionResult> Index()
        {
            var groups = await DAL.uof.GroupRepository.GetAsync(orderBy: q => q.OrderBy(d => d.Ord).ThenBy(d => d.Title));
            return View(groups);
        }

        // GET: Admin/Groups/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await DAL.uof.GroupRepository.GetByIDAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Admin/Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Groups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GroupID,Title,Description,SEOurl,Active,Ord")] Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    group.GroupID = Guid.NewGuid();
                    DAL.uof.GroupRepository.Insert(group);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Ошибка БД...");
                }
                
            }

            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await DAL.uof.GroupRepository.GetByIDAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GroupID,Title,Description,SEOurl,Active,Ord")] Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.GroupRepository.Update(group);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Ошибка БД...");
                }
                
            }
            return View(group);
        }

        // GET: Admin/Groups/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await DAL.uof.GroupRepository.GetByIDAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                DAL.uof.GroupRepository.Delete(id); 
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
