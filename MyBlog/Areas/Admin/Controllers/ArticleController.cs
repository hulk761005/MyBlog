using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Areas.Admin.Models;
using MyBlog.Models;
using Microsoft.Security.Application;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MyBlog.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
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
        public async Task<ActionResult> Create(CreateArticleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(User.Identity.GetUserName());
                    var article = new Article();
                    article.ID = Guid.NewGuid().ToString();
                    article.Subject = model.Subject;
                    article.Summary = model.Summary;
                    // 過濾 XSS
                    article.ContentText = Sanitizer.GetSafeHtmlFragment(model.ContentText);

                    article.ViewCount = 0;
                    article.CreateUser = user.Id;
                    article.CreateDate = DateTime.Now;
                    article.UpdateUser = user.Id;
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
