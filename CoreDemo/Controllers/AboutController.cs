using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        readonly AboutManager _aboutManager = new(new EfAboutReposityory());
        public IActionResult Index()
        {

            var result = _aboutManager.GetList();
            return View(result);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
