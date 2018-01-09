using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyBlog.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }
        private DbSet<T> _Objectset;

        public DbSet<T> Objectset
        {
            get
            {
                if (_Objectset == null)
                {
                    _Objectset = UnitOfWork.Context.Set<T>();
                }
                return _Objectset;
            }
        }
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void Commit()
        {
            UnitOfWork.Save();
        }

        public void Create(T entity)
        {
            Objectset.Add(entity);
        }

        public void Delete(T entity)
        {
            Objectset.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Objectset;
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return Objectset.SingleOrDefault(filter);
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}