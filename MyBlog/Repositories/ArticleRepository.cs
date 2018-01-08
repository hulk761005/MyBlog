using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class ArticleRepository : IRepository
    {
        public ApplicationDbContext db { get; set; }
        public ArticleRepository()
        {
            this.db = new ApplicationDbContext();
        }
        public void Commit()
        {
            this.db.SaveChanges();
        }

        public void Create(Article instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Article.Add(instance);
                this.Commit();
            }
        }

        public void Delete(Article instance)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetAll()
        {
            return this.db.Article;
        }

        public Article GetSingle()
        {
            throw new NotImplementedException();
        }

        public void Update(Article instance)
        {
            throw new NotImplementedException();
        }
    }
}