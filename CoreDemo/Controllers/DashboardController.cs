using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var writer = writerManager.TGetByFilter(x => x.WriterMail == User.Identity.Name);
            ViewBag.totalBlogCount = blogManager.GetList().Count.ToString(); //Toplam Blog sayısı
            ViewBag.totalMyBlogCount = blogManager.GetBlogListByWriter(writer.WriterId, null).Count.ToString();  //Blog Sayınız
            ViewBag.totalCommentCount = commentManager.GetList().Count.ToString(); //Toplam Yorum sayısı
            ViewBag.totalCategoryCount = categoryManager.GetList().Count.ToString(); //Toplam Categori sayısı
            return View();
        }
    }
}
