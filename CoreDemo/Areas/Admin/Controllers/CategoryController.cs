using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")] //Bu controllerdaki actionlar Area'dan gelmektedir.
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category inputModel)
        {
            CategoryValidator categoryValid = new CategoryValidator();
            ValidationResult result = categoryValid.Validate(inputModel);
            if (result.IsValid)
            {
                inputModel.CategoryStatus = false;
                categoryManager.TAdd(inputModel);
                return RedirectToAction("Index", "Category");
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

        public IActionResult PassiveCategory(int id)
        {
            var value = categoryManager.GetById(id);
            value.CategoryStatus = false;
            categoryManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
