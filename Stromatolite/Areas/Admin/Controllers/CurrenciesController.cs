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
    public class CurrenciesController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Currencies
        public PartialViewResult _Index()
        {
            var currencies = DAL.uof.CurrencyRepository.Get();
            return PartialView(currencies);
        }

        
    }
}
