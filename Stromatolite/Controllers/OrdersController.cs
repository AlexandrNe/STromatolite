using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
                            DAL.tagStop(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();

                        var notificationEmails = DAL.uof.NotificationEmailRepository.Get();
                        foreach (var email in notificationEmails)
                        {
                            MailDelivery.MailSend(email.Email, "Принят заказ №" + order.OrderNum, "<h4>Принят заказ №" + order.OrderNum + " от "+order.OrderDate+"</h4>"
                                +"<p>Email: <em><a href='mailto:" +order.Email+ "'>"+ order.Email + "</a></em></p>"
                                +"<p>Тел.: <em>" + order.PhoneNumber + "</em></p>"
                                + "<p>От: <em>" + order.FullName+ "</em></p>"
                                + order.Comment);
                        }

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

        public ActionResult _CreateCall(Guid? offerID)
        {
            ViewBag.OfferID = offerID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _CreateCall([Bind(Include = "OrderID,PhoneNumber,FullName,Comment")] Order order, Guid? offerID, int? quantity)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(order.PhoneNumber))
                {
                    ModelState.AddModelError("", "Нужно заполнить поле Номер телефона...");
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
                            DAL.tagStop(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();

                        var notificationEmails = DAL.uof.NotificationEmailRepository.Get();
                        foreach (var email in notificationEmails)
                        {
                            MailDelivery.MailSend(email.Email, "Принят заказ №" + order.OrderNum, "<h4>Принят заказ №" + order.OrderNum + " от " + order.OrderDate + "</h4>"
                                + "<p>Email: <em><a href='mailto:" + order.Email + "'>" + order.Email + "</a></em></p>"
                                + "<p>Тел.: <em>" + order.PhoneNumber + "</em></p>"
                                + "<p>От: <em>" + order.FullName + "</em></p>"
                                + order.Comment);
                        }

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

                        order.Comment = DAL.tagStop(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();


                        var notificationEmails = DAL.uof.NotificationEmailRepository.Get();
                        foreach (var email in notificationEmails)
                        {
                            MailDelivery.MailSend(email.Email, "Принят заказ №" + order.OrderNum , "<h4>Принят заказ №" + order.OrderNum + " от "+ order.OrderDate+"</h4>"
                                + "<p>Заявка на обратный звонок: <em>"+order.PhoneNumber+"</em></p>"
                                + "<p>От: <em>" + order.FullName + "</em></p>"
                                + order.Comment);
                        }

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

        public ActionResult _GetPrice()
        {
            return View();
        }
        // GET: Orders
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _GetPrice([Bind(Include = "OrderID,Email,FullName,Comment")] Order order)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(order.Email))
                {
                    ModelState.AddModelError("", "Заполните адрес электронной почты...");
                }
                else
                {
                    try
                    {
                        order.OrderID = Guid.NewGuid();
                        order.OrderNum = CalcNum("");
                        order.OrderDate = DateTime.UtcNow.AddHours(3);
                        order.Closed = false;

                        order.Comment = "<H4>Прайс</H4>" + DAL.tagStop(order.Comment);
                        DAL.uof.OrderRepository.Insert(order);
                        DAL.uof.Save();

                        var mSubject = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "Тема письма (Прайс)");
                        var mBody = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "Текст письма (Прайс)");
                        var mAttachment = DAL.uof.GeneralSettingRepository.GetByField(f => f.SettingName == "Прайс");
                        string attachment = Server.MapPath(mAttachment.SettingValue);
                        MailDelivery.MailSend(order.Email, mSubject.SettingValue, mBody.SettingValue, attachment);
                        var notificationEmails = DAL.uof.NotificationEmailRepository.Get();
                        foreach (var email in notificationEmails)
                        {
                            MailDelivery.MailSend(email.Email, "Принят заказ №" + order.OrderNum, "<h4>Принят заказ №" + order.OrderNum + " от "+order.OrderDate+"</h4>"
                                + "<p>Email: <em><a href='mailto:" + order.Email + "'>" + order.Email + "</a></em></p>"
                                + "<p>От: <em>" + order.FullName + "</em></p>"
                                + order.Comment);
                        }

                        return PartialView("_Result3", order.OrderNum);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return PartialView(order);
        }



        public ActionResult _Payment()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Payment(string value, string description, string fio)
        {
          
            string username = "615993"; string password = "live_c-e5Pztdi5FVfZxf6A7fmIJtbT8ndYX_kwxtgAtN9EI";
            string credentials = String.Format("{0}:{1}", username, password);
            byte[] credToBytes = Encoding.ASCII.GetBytes(credentials);
            string b64 = Convert.ToBase64String(credToBytes);
            string authorization = String.Concat("Basic ", b64);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://payment.yandex.net/api/v3/payments");
            request.Method = "POST";
            request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 64.0.3282.140 Safari / 537.36 Edge / 17.17134";
            request.Headers.Add("Authorization", authorization);
            request.ContentType = "application/json; charset=UTF-8";


            string IdempotenceKey = Guid.NewGuid().ToString();

            request.Headers.Add("Idempotence-Key", IdempotenceKey);
            request.KeepAlive = true;
            request.Timeout = Timeout.Infinite;
            request.Date = DateTime.UtcNow;

            string pm = "{\"amount\": {\"value\": \"" + value 
                + "\",\"currency\": \"RUB\"},\"capture\": true,\"confirmation\": {\"type\": \"redirect\",\"return_url\": \"https://www.kamenmarket.com/success\"},\"description\": \"" 
                + description + " " + fio + "\"}";

            var body = Encoding.UTF8.GetBytes(pm);
            request.ContentLength = body.Length;
            var m = "";
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    var stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    m = reader.ReadToEnd();
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    m = reader.ReadToEnd();
                }
                return Content(m);
            }
            catch (Exception ex)
            {

                m = ex.Message;
                return Content(m);
            }

            
            var start = m.IndexOf("confirmation_url");
            var start2 = m.IndexOf("https", start);
            var end = m.IndexOf('"', start2);
            var length = end - start2;
            var confirmationUrl = m.Substring(start2, length);

            return Redirect(confirmationUrl);
        }

        public ActionResult Success()
        {
            return View();
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

    public static class SessionKeyGen
    {
        static readonly char[] AvailableCharacters = {
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
    };

        internal static string GenerateKey(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % AvailableCharacters.Length;
                identifier[idx] = AvailableCharacters[pos];
            }

            return new string(identifier);
        }

    }

}