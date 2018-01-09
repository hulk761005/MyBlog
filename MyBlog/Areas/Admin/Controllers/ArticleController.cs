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
using MyBlog.Models.Services;
using MyBlog.Models.Repositories;
namespace MyBlog.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleService _articleSvc;
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
        public ArticleController()
        {
            var unitOfWork = new EFUnitOfWork();
            _articleSvc = new ArticleService(unitOfWork);
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
        public async Task<ActionResult> Create(ArticleCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(User.Identity.GetUserName());
                    _articleSvc.Create(model, user.Id);
                    _articleSvc.Save();
                    return RedirectToAction("Index");
                }
                return View();
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
        protected override void Dispose(bool disposing)
        {
            _articleSvc.Dispose();
            base.Dispose(disposing);
        }
    }
}
