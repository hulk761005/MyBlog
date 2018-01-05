using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Areas.Admin.Models
{
    public class ArticleViewModel
    {

    }
    public class CreateArticleViewModel
    {
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string ContentText { get; set; }
    }
}