using Microsoft.AspNet.Identity.Owin;
using MyBlog.Models;
using MyBlog.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.Services;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
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
        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _articleSvc = new ArticleService(unitOfWork);
        }
        public ActionResult Index()
        {
            return View(_articleSvc.LookUp().OrderByDescending(a => a.CreateDate).ToList());
        }
        public ActionResult Detail(string id)
        {
            return View(_articleSvc.GetDetail(id));
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