using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{
    //[Authorize] //: Yetkisiz erişimleri engellemek için kullanılır [Controller seviyesinde bütün viewler etkilenir.]
    //[Proje seviyesinde startup.cs içersinde config yapıldı-Bütün yapılar kitlendi ->
    //[AllowAnonymus] attribute ile Proje seviyesindeki bütün kurallarda muaf olacaktır.]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var mail = User.Identity.Name;
            ViewBag.v = mail;
            var writerName = writerManager.TGetByFilter(x => x.WriterMail == mail);
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writer = writerManager.TGetByFilter(x=>x.WriterMail==User.Identity.Name);
            var writerValues = writerManager.GetById(writer.WriterId);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer inputModel)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(inputModel);
            if (result.IsValid)
            {
                writerManager.TUpdate(inputModel);
                return RedirectToAction("Index", "Dashboard"); //"View" sonra "Controller"!
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        //Yazar tarafı için kullanılıyor.
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writerModel = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", imageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writerModel.WriterImage = imageName;
            }
            writerModel.WriterMail = p.WriterMail;
            writerModel.WriteName = p.WriteName;
            writerModel.WriterPassword = p.WriterPassword;
            writerModel.WriterRePassword = p.WriterRePassword;
            writerModel.WriterStatus = true;
            writerModel.WriteAbout = p.WriteAbout;
            writerManager.TAdd(writerModel);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
