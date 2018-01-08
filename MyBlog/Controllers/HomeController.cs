using Microsoft.AspNet.Identity.Owin;
using MyBlog.Models;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _articleRep;
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
        public HomeController()
        {
            _articleRep = new ArticleRepository();
        }
        public ActionResult Index()
        {
            var listBlog = new List<ArticleViewModel>();
            var query = from a in _articleRep.GetAll()
                        join b in UserManager.Users on a.CreateUser equals b.Id
                        select new
                        {
                            a.ID,
                            a.Subject,
                            a.Summary,
                            b.UserName,
                            a.CreateDate
                        };
            foreach (var item in _articleRep.GetAll().ToList())
            {
                var blog = new ArticleViewModel()
                {
                    ID = item.ID,
                    Subject = item.Subject,
                    Summary = item.Summary,
                    CreateUser = item.CreateUser,
                    CreateDate = item.CreateDate
                };
                listBlog.Add(blog);
            }
            return View(listBlog);
        }
        public ActionResult Detail(string id)
        {
            var query = from a in _articleRep.GetAll()
                        join b in UserManager.Users on a.CreateUser equals b.Id
                        select new
                        {
                            a.ID,
                            a.Subject,
                            a.ContentText,
                            b.UserName,
                            a.CreateDate
                        };
            var result = query.FirstOrDefault(c => c.ID == id);
            var article = new ArticleDetailViewModel()
            {
                ID = result.ID,
                Subject = result.Subject,
                ContentText = result.ContentText,
                CreateUser = result.UserName,
                CreateDate = result.CreateDate
            };

            return View(article);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}