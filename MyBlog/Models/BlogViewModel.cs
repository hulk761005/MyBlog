using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class BlogViewModel
    {
        public string ID { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}