using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class ContactController : Controller
    {
        readonly ContactManager _contactManager = new ContactManager(new EfContactReposityory());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact inputModel)
        {
            inputModel.ContactCreatedAt = DateTime.Now;
            inputModel.ContactStatus = true;
            _contactManager.TAdd(inputModel);
            return RedirectToAction("Index","Blog");
        }
    }
}
