using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    //[Authorize] //: Yetkisiz erişimleri engellemek için kullanılır [Controller seviyesinde bütün viewler etkilenir.]
    //[Proje seviyesinde startup.cs içersinde config yapıldı-Bütün yapılar kitlendi ->
    //[AllowAnonymus] attribute ile Proje seviyesindeki bütün kurallarda muaf olacaktır.]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();   
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
