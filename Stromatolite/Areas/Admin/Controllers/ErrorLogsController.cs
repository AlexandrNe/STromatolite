﻿using System;
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
    public class ErrorLogsController : Controller
    {
        private StromatoliteModel db = new StromatoliteModel();

        // GET: Admin/ErrorLogs
        public async Task<ActionResult> Index()
        {
            return View(await db.ErrorLogs.ToListAsync());
        }

        // GET: Admin/ErrorLogs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorLog errorLog = await db.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return HttpNotFound();
            }
            return View(errorLog);
        }

        // GET: Admin/ErrorLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ErrorLogs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ErrorLogID,ErrDate,ErrDescription")] ErrorLog errorLog)
        {
            if (ModelState.IsValid)
            {
                errorLog.ErrorLogID = Guid.NewGuid();
                db.ErrorLogs.Add(errorLog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(errorLog);
        }

        // GET: Admin/ErrorLogs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorLog errorLog = await db.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return HttpNotFound();
            }
            return View(errorLog);
        }

        // POST: Admin/ErrorLogs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ErrorLogID,ErrDate,ErrDescription")] ErrorLog errorLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(errorLog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(errorLog);
        }

        // GET: Admin/ErrorLogs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorLog errorLog = await db.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return HttpNotFound();
            }
            return View(errorLog);
        }

        // POST: Admin/ErrorLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ErrorLog errorLog = await db.ErrorLogs.FindAsync(id);
            db.ErrorLogs.Remove(errorLog);
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
