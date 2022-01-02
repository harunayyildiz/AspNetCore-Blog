using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = c.Admins.Where(x => x.AdminId == 1).Select(x => x.UserName).FirstOrDefault();
            ViewBag.AdminImage = c.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.AdminDesc = c.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();
            ViewBag.AdminRole = c.Admins.Where(x => x.AdminId == 1).Select(x => x.Role).FirstOrDefault();
            return View();
        }
    }
}
