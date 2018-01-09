using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.Admin.Models
{
    public class ArticleViewModel
    {

    }
    public class ArticleCreateViewModel
    {
        [Display(Name = "標題")]
        public string Subject { get; set; }
        [Display(Name = "簡介")]
        public string Summary { get; set; }
        [Display(Name = "內容")]
        [UIHint("Html")]
        [AllowHtml]
        public string ContentText { get; set; }
    }
}