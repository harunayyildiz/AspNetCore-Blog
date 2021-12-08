using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private readonly CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
            ViewBag.i = id;
            var result = _blogManager.GetBlogById(id);
            return View(result);
        }
        //Yazarlarla İlişkili.
        public IActionResult BlogListByWriter()
        {
            var result = _blogManager.GetListWithCategoryByWriterBm(1);
            return View(result);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            getCategoryValues();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog inputModel)
        {
            getCategoryValues();
            BlogValidator blogValid = new BlogValidator();
            ValidationResult result = blogValid.Validate(inputModel);
            if (result.IsValid)
            {
                inputModel.BlogStatus = true;
                inputModel.BlogCreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
                inputModel.WriterId = 1; //sessiondan çekilecek.....
                _blogManager.TAdd(inputModel);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    //Modele hatayı veren properies adı ve  hatası
                }

            }
            return View();
        }

        public void getCategoryValues() //Get ve Postta da kullanıldığından method haline getirildi
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
        }

        public IActionResult DeletedBlog(int id)
        {
            var blogValue = _blogManager.GetById(id);
            if (blogValue != null)
            {
                _blogManager.TDelete(blogValue);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                return RedirectToAction("404 page atanacak");
            }

        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {

            var blogValue = _blogManager.GetById(id);

            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            if (blogValue != null)
            {
                return View(blogValue);
            }
            else
            {
                return RedirectToAction("404 page atanacak");
            }

        }
        [HttpPost]
        public IActionResult EditBlog(Blog inputModel)
        {
            //Update olan kısımda yollanmayan değerler için null atanabilir Dikkat et
            var value = _blogManager.GetById(inputModel.BlogId);
            inputModel.WriterId = value.WriterId;
            inputModel.BlogCreatedAt = value.BlogCreatedAt;
            inputModel.BlogStatus = value.BlogStatus;
            _blogManager.TUpdate(inputModel);
            return RedirectToAction("BlogListByWriter");

        }
    }
}
