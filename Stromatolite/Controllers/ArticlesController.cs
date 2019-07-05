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

namespace Stromatolite.Controllers
{
    public class ArticlesController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            var articles = await DAL.uof.ArticleRepository.GetAsync();
            return View(articles);
        }

        public PartialViewResult _Index()
        {
            var articles = DAL.uof.ArticleRepository.Get(filter: f => f.Approved, orderBy: q => q.OrderByDescending(d => d.ReleaseDate));
            return PartialView(articles);
        }

        // GET: Articles/Details/5
        public async Task<ActionResult> Details(string url)
        {
            if (url == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await DAL.uof.ArticleRepository.GetByFieldAsync(f => f.SeoUrl == url);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

      
    }
}
