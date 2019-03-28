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
    public class ArticlesController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        // GET: Admin/Articles
        public async Task<ActionResult> Index()
        {
            var articles = await DAL.uof.ArticleRepository.GetAsync(orderBy: q => q.OrderByDescending(d => d.AddedDate));
            return View(articles);
        }

        // GET: Admin/Articles/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await DAL.uof.ArticleRepository.GetByIDAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Articles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImgUrl,Title,Abstract,ArtBody,AddedDate,ReleaseDate,ExpireDate,Reference,Approved,CommentsEnabled,SeoUrl,Keywords,MetaDescription,Tags")] Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    article.ArticleID = Guid.NewGuid();
                    article.AddedDate = DateTime.UtcNow.AddHours(3);
                    article.ViewCount = 0;
                    article.Votes = 0;
                    article.TotalRating = 0;

                    DAL.uof.ArticleRepository.Insert(article);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Ошибка БД.");
                }
            }

            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await DAL.uof.ArticleRepository.GetByIDAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArticleID,ImgUrl,Title,Abstract,ArtBody,AddedDate,ReleaseDate,ExpireDate,Reference,Approved,CommentsEnabled,ViewCount,Votes,TotalRating,SeoUrl,Keywords,MetaDescription,Tags")] Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DAL.uof.ArticleRepository.Update(article);
                    await DAL.uof.SaveAsync();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Ошибка БД.");
                }
             
            }
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await DAL.uof.ArticleRepository.GetByIDAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                DAL.uof.ArticleRepository.Delete(id);
                await DAL.uof.SaveAsync();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Ошибка БД.");
            }

            return RedirectToAction("Index");
        }

    }
}
