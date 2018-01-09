using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyBlog.Models.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        void Save();
    }
}
