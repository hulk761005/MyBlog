using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.Models.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }
        public EFUnitOfWork()
        {
            Context = new ApplicationDbContext();
        }
        public void Dispose()
        {
            this.Context.Dispose();
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}