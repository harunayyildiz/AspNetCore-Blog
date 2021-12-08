using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
            //Razor View->Partial
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment inputModel)
        {
            //Boş geçmemesi adına modelin için burdan ekleme yapacağız.
            inputModel.CommentStatus = true;
            inputModel.CommentCreatedAt = DateTime.Now;
            inputModel.BlogId = 5;
            _commentManager.TAdd(inputModel);
            return RedirectToAction("BlogReadAll", "Blog", new { id = inputModel.BlogId });
            //Razor View->Partial
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var result = _commentManager.GetList(id);
            return PartialView(result);
            //Razor View->Partial
            //Blogdaki Yorumlar
        }
    }
}
