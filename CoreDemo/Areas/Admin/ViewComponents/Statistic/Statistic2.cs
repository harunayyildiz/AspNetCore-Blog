﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var lastBlogName = c.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.LastBlogName = lastBlogName;
            return View();
        }
    }
}
