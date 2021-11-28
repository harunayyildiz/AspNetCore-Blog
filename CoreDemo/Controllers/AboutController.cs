using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        readonly AboutManager aboutManager = new(new EfAboutReposityory());
        public IActionResult Index()
        {

            var result = aboutManager.GetList();
            return View(result);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
