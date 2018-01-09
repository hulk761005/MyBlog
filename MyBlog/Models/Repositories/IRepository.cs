using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; set; }
        IQueryable<T> GetAll();
        T GetSingle(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Delete(T entity);
        void Commit();
        void Dispose();
    }
}
