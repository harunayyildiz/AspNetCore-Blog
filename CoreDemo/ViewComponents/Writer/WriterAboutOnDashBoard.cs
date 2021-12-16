using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var mail = User.Identity.Name;
            var writer = writerManager.TGetByFilter(x => x.WriterMail == mail);
            var result = writerManager.GetWriterById(writer.WriterId);
            return View(result);
        }
    }
}
