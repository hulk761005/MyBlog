using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Areas.Admin.Models;
using MyBlog.Models;

namespace MyBlog.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Article/Create
        [HttpPost]
        public ActionResult Create(CreateArticleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var article = new Article();
                    article.ID = Guid.NewGuid().ToString();
                    article.Subject = model.Subject;
                    article.Summary = model.Summary;
                    article.ContentText = model.ContentText;
                    article.ViewCount = 0;
                    article.CreateUser = "b180fb64-983f-4908-8269-3f8a3ae69b08";
                    article.CreateDate = DateTime.Now;
                    article.UpdateUser = "b180fb64-983f-4908-8269-3f8a3ae69b08";
                    article.UpdateDate = DateTime.Now;
                    db.Article.Add(article);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
