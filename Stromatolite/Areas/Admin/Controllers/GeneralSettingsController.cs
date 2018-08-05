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
    public class GeneralSettingsController : Controller
    {
        DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/GeneralSettings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Index()
        {
            return View(DAL.uof.GeneralSettingRepository.Get());
        }

        public async Task<ActionResult> _Details(int id)
        {
            GeneralSetting generalSetting = await DAL.uof.GeneralSettingRepository.GetByIDAsync(id);
            if (generalSetting == null)
            {
                return HttpNotFound();
            }
            
            return PartialView(generalSetting);
        }


        public ActionResult _Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneralSettingID,SettingName,SettingValue")] GeneralSetting generalSetting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.GeneralSettingRepository.Insert(generalSetting);
                    DAL.uof.Save();

                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_Index", DAL.uof.GeneralSettingRepository.Get());
                    }
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Ошибка БД...");
                }
            }
            if (Request.IsAjaxRequest())
            {
                return Content("<p class = 'text-danger'>Ошибка записи в БД!</p><p>Попробуйте еще раз или обновите страницу.</p>");
            }
            return View(generalSetting);
        }

        public async Task<ActionResult> Edit(int id)
        {
            GeneralSetting generalSetting = await DAL.uof.GeneralSettingRepository.GetByIDAsync(id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Edit", generalSetting);
            }
            return View(generalSetting);
        }

        public PartialViewResult _Edit()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneralSettingID,SettingName,SettingValue")] GeneralSetting generalSetting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.GeneralSettingRepository.Update(generalSetting);
                    DAL.uof.Save();
                    if (Request.IsAjaxRequest())
                    {
                        return RedirectToAction("_Details", new { id = generalSetting.GeneralSettingID });
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
                return PartialView("_Edit", generalSetting);
            }
            return View(generalSetting);
        }

    }

}
