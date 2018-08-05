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
    public class NotificationEmailsController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();
        // GET: Admin/NotificationEmails
        public async Task<ActionResult> Index()
        {
            IEnumerable<NotificationEmail> notEmail = await DAL.uof.NotificationEmailRepository.GetAsync();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", notEmail);
            }
            return View();
        }

        public PartialViewResult _Index()
        {
            IEnumerable<NotificationEmail> notEmail = DAL.uof.NotificationEmailRepository.Get();
            return PartialView(notEmail);
        }

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Create");
            }

            return View();
        }

        public PartialViewResult _Create()
        {
            return PartialView();
        }

        // GET: Admin/Units/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationEmail notificationEmail = await DAL.uof.NotificationEmailRepository.GetByIDAsync(id);
            if (notificationEmail == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Details", notificationEmail);
            }
            return View(notificationEmail);
        }

        public PartialViewResult _Details()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NotificationEmailID,NotificationID,Email")] NotificationEmail notificationEmail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.NotificationEmailRepository.Insert(notificationEmail);
                    DAL.uof.Save();
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_Index", await DAL.uof.NotificationEmailRepository.GetAsync());
                    }
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Ошибка записи в БД!");
                }

            }
            if (Request.IsAjaxRequest())
            {
                return Content("<p class = 'text-danger'>Ошибка записи в БД!</p><p>Попробуйте еще раз или обновите страницу.</p>");
            }
            return View(notificationEmail);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationEmail notificationEmail = await DAL.uof.NotificationEmailRepository.GetByIDAsync(id);
            if (notificationEmail == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", notificationEmail);
            }
            return View(notificationEmail);
        }

        public PartialViewResult _Edit()
        {
            return PartialView();
        }

        // POST: Admin/Units/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotificationEmailID,NotificationID,Email")] NotificationEmail notificationEmail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.NotificationEmailRepository.Update(notificationEmail);
                    DAL.uof.Save();
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_Details", notificationEmail);
                    }
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Ошибка записи в БД!");
                }
                if (Request.IsAjaxRequest())
                {
                    return Content("<p class = 'text-danger'>Ошибка записи в БД!</p><p>Попробуйте еще раз или обновите страницу.</p>");
                }
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", notificationEmail);
            }
            return View(notificationEmail);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationEmail notificationEmail = await DAL.uof.NotificationEmailRepository.GetByIDAsync(id);
            if (notificationEmail == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Delete", notificationEmail);
            }
            return View(notificationEmail);
        }

        public PartialViewResult _Delete()
        {
            return PartialView();
        }

        // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //try
            //{
            //    Unit unit = await db.Units.FindAsync(id);
            //    db.Units.Remove(unit);
            //    await db.SaveChangesAsync();
            //}
            //catch (DataException)
            //{
            //    ModelState.AddModelError("", "Ошибка записи в БД!");
            //}
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_Index", await db.Units.ToListAsync());
            //}
            return RedirectToAction("Index", new { area = "Admin" });
        }

        // POST: Admin/Currencies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _DeleteConfirmed(int id)
        {
            try
            {
                DAL.uof.NotificationEmailRepository.Delete(id);

                await DAL.uof.SaveAsync();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Ошибка записи в БД!");
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", await DAL.uof.NotificationEmailRepository.GetAsync(orderBy: q => q.OrderBy(d => d.Email)));
            }
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }

}
