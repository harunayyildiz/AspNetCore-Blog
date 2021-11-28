using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var results = _blogManager.GetBlogListWithCategory();
            //içindeki sınıfları da getir-> include ile
            //Eager loading amacıyla..
            return View(results);
        }

        public IActionResult BlogReadAll(int id)
        {
            //Comments de de kullanmak için..
            ViewBag.i=id;
            var result = _blogManager.GetBlogById(id);
            return View(result);
        }
    }
}
