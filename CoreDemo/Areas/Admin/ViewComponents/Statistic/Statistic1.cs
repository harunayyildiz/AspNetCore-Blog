using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var blogCount = c.Blogs.Count();
            var contactCount = c.Contacts.Count(); //System.Linq olduğunu düşünebilmelisin.
            var commentCount=c.Comments.Count();
            ViewBag.blogCount = blogCount;
            ViewBag.contactCount = contactCount;
            ViewBag.commentCount = commentCount;    
            return View();
        }
    }
}
