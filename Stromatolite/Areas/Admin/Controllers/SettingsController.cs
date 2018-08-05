using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Stromatolite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {

        private DataAccessLayer DAL = new DataAccessLayer();
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _PriceList()
        {
            return View();
        }

        public ActionResult _SetPrice()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPrice(HttpPostedFileBase filePriceUrl)
        {
            if (ModelState.IsValid)
            {
                string priceDir = Server.MapPath("~/documents/");

                try
                {
             
                    if (filePriceUrl != null)
                    {
                        string priceName = Path.GetFileName(filePriceUrl.FileName);
                        filePriceUrl.SaveAs(priceDir + priceName);
                        var PriceUrl2 = "/documents/" + priceName;
                    }

                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Ошибка БД...");

                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPrice()
        {

            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {

                        var stream = fileContent.InputStream;

                        string fType = Path.GetFileName(file);

                        fType = fType.Substring(fType.LastIndexOf("."));
                        string fileName = "price" + fType;
                        string path = Path.Combine(Server.MapPath("~/img/temp/"), fileName);
                        using (FileStream fs = new FileInfo(path).Create())
                        {
                            stream.CopyTo(fs);
                        }

                        var price = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "Прайс");
                        if (price == null)
                        {
                            price = new GeneralSetting();
                            price.SettingName = "Прайс";
                            price.SettingValue = "~/img/temp/" + fileName;
                            DAL.uof.GeneralSettingRepository.Insert(price);
                        }
                        else
                        {
                            price.SettingValue = "~/img/temp/" + fileName;
                            DAL.uof.GeneralSettingRepository.Update(price);
                        }
                        DAL.uof.Save();

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
                
            }

            return Json("Файл успешно загружен.");
        }
    }
}