using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());


        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter inputModel)
        {
            inputModel.MailStatus = true;
            _newsLetterManager.AddNewLetter(inputModel);
            return PartialView();
        }
    }
}
