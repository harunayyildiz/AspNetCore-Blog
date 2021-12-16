using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var writer = writerManager.TGetByFilter(x => x.WriterMail == User.Identity.Name);
            var values = blogManager.GetBlogListByWriter(writer.WriterId, true);
            return View(values);
        }


    }
}
