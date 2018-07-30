using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Stromatolite.Controllers
{
    public class OrdersController : Controller
    {

        private DataAccessLayer DAL = new DataAccessLayer();

        public ActionResult _Create(Guid? offerID)
        {
            ViewBag.OfferID = offerID;
            return View();
        }
        // GET: Orders
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "OrderID,Email,PhoneNumber,FullName,Comment")] Order order, Guid? offerID, int? quantity)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(order.Email) && String.IsNullOrEmpty(order.PhoneNumber))
                {
                    ModelState.AddModelError("", "Нужно заполнить хотя бы одно из полей: Email или Номер телефона...");
                }
                else
                { 

                    try
                    {
                        if (offerID == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        var offer = DAL.uof.OfferRepository.GetByID(offerID);
                        if (offer == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        order.OrderID = Guid.NewGuid();
                        order.OrderNum = CalcNum("");
                        order.OrderDate = DateTime.UtcNow.AddHours(3);
                        order.Closed = false;

                        order.Comment = "<p>Наименование товара: " + "<em>" + offer.Product.TitleFull + "</em>" + "</p>" +
                            "<p>Количество: " + "<em>" + quantity + "</em> " + offer.Unit.Title + "</p> </hr>" +
                            DAL.ClearSpecChars(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();

                        return PartialView("_Result", order.OrderNum);


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return PartialView(order);
        }

        public ActionResult _Callback()
        {
            return View();
        }
        // GET: Orders
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Callback([Bind(Include = "OrderID,PhoneNumber,FullName,Comment")] Order order)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(order.PhoneNumber))
                {
                    ModelState.AddModelError("", "Заполните номер телефона...");
                }
                else
                {
                    try
                    {
                        order.OrderID = Guid.NewGuid();
                        order.OrderNum = CalcNum("");
                        order.OrderDate = DateTime.UtcNow.AddHours(3);
                        order.Closed = false;

                        order.Comment = DAL.ClearSpecChars(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();

                        return PartialView("_Result2", order.OrderNum);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return PartialView(order);
        }

        private string CalcNum(string pref)
        {
            int curDayOfYear = -1 * DateTime.Today.DayOfYear;
            DateTime firstDay = DateTime.Today.AddDays(curDayOfYear + 1);
            string MaxOrderNum = DAL.uof.OrderRepository.Get(filter: f => f.OrderDate > firstDay).Max(f => f.OrderNum);
            if (MaxOrderNum == null)
            {
                MaxOrderNum = "0000000";
            }
            int maxNum = Int32.Parse(MaxOrderNum.Substring(4));
            maxNum++;
            MaxOrderNum = pref + maxNum.ToString("D7");
            return MaxOrderNum;
        }
    }
}