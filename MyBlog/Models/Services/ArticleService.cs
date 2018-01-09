using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Models.Repositories;
using MyBlog.Areas.Admin.Models;
using Microsoft.Security.Application;

namespace MyBlog.Models.Services
{
    public class ArticleService
    {
        private readonly IRepository<Article> _articleRep;
        private readonly IRepository<ApplicationUser> _userRep;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _articleRep = new Repository<Article>(unitOfWork);
            _userRep = new Repository<ApplicationUser>(unitOfWork);
        }
        public IEnumerable<ArticleViewModel> LookUp()
        {
            var query = from a in _articleRep.GetAll()
                        join b in _userRep.GetAll() on a.CreateUser equals b.Id
                        select new ArticleViewModel()
                        {
                            ID = a.ID,
                            Subject = a.Subject,
                            Summary = a.Summary,
                            CreateUser = b.UserName,
                            CreateDate = a.CreateDate
                        };
            return query;
        }
        public void Create(ArticleCreateViewModel articleData, string userId)
        {
            var article = new Article()
            {
                ID = Guid.NewGuid().ToString(),
                Subject = articleData.Subject,
                Summary = articleData.Summary,
                ContentText = Sanitizer.GetSafeHtmlFragment(articleData.ContentText),
                ViewCount = 0,
                CreateUser = userId,
                CreateDate = DateTime.Now,
                UpdateUser = userId,
                UpdateDate = DateTime.Now
            };
            _articleRep.Create(article);
        }
        public ArticleDetailViewModel GetDetail(string id)
        {
            var query = _articleRep.GetAll().Join(_userRep.GetAll(),
                a => a.CreateUser,
                b => b.Id,
                (a, b) => new ArticleDetailViewModel()
                {
                    ID = a.ID,
                    Subject = a.Subject,
                    ContentText = a.ContentText,
                    CreateUser = b.UserName,
                    CreateDate = a.CreateDate
                }).FirstOrDefault(a => a.ID == id);
            return query;
        }
        public void Save()
        {
            _articleRep.Commit();
        }
        public void Dispose()
        {
            _articleRep.Dispose();
        }
    }
}