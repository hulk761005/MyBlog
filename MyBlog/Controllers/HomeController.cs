using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var listBlog = new List<BlogViewModel>();
            var query = from a in db.Article
                        join b in db.Users on a.CreateUser equals b.Id
                        select new
                        {
                            a.ID,
                            a.Subject,
                            a.Summary,
                            b.UserName,
                            a.CreateDate
                        };
            foreach (var item in query.OrderByDescending(a => a.CreateDate).ToList())
            {
                var blog = new BlogViewModel()
                {
                    ID = item.ID,
                    Subject = item.Subject,
                    Summary = item.Summary,
                    CreateUser = item.UserName,
                    CreateDate = item.CreateDate
                };
                listBlog.Add(blog);
            }
            return View(listBlog);
        }
        public ActionResult Detail(string id)
        {
            var query = from a in db.Article
                        join b in db.Users on a.CreateUser equals b.Id
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