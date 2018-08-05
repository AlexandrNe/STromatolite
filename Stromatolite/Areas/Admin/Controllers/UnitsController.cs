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
    [Authorize(Roles ="Admin")]
    public class UnitsController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Units
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Units.ToListAsync());
        //}

        public PartialViewResult _Index()
        {
            var units = DAL.uof.UnitRepository.Get();
            return PartialView(units);
        }

        // GET: Admin/Units/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Admin/Units/Create
        //Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку.Дополнительные
        //сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UnitID,Title")] Unit uNit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.UnitRepository.Insert(uNit);
                    await DAL.uof.SaveAsync();

                    if (Request.IsAjaxRequest())
                    {
                        return RedirectToAction("_Index");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View(uNit);
        }

        // GET: Admin/Units/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Unit unit = await db.Units.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unit);
        //}

        // POST: Admin/Units/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "UnitID,Title")] Unit unit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(unit).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(unit);
        //}

        //GET: Admin/Units/Delete/5
        public async Task<ActionResult> _Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await DAL.uof.UnitRepository.GetByIDAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _DeleteConfirmed(int id)
        {
            DAL.uof.UnitRepository.Delete(id);

            await DAL.uof.SaveAsync();
            if (Request.IsAjaxRequest())
            {
                return RedirectToAction("_Index");
            }

                return RedirectToAction("Index");
        }


    }
}
