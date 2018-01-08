using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public interface IRepository
    {
        IQueryable<Article> GetAll();
        Article GetSingle();
        void Create(Article instance);
        void Update(Article instance);
        void Delete(Article instance);
        void Commit();
    }
}
