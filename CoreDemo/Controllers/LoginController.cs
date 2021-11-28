using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Writer inputModel)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == inputModel.WriterMail &&
            x.WriterPassword == inputModel.WriterPassword);
            if (dataValue != null) //TODO: Aktif olmayan yazar giriş yapamaz.
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,inputModel.WriterMail)
                };

                var userIdentity = new ClaimsIdentity(claims, "x");
                //"x": Startupda belirledigimiz authenticationsheme alması gerekiyor yani cookie yetkilendirmesini yapmamizi sağlıyor
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal); //Şifreli formatta Cookie oluşturması için
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }
}

//Claimler; rollerin dışında kullanıcı hakkında bilgi tutmamızı ve bu bilgilere göre yetkilendirme yapmamızı sağlayan yapılardır.

//Context c = new Context();
//var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == inputModel.WriterMail &&
//x.WriterPassword == inputModel.WriterPassword);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", inputModel.WriterMail); //key, value
//    return RedirectToAction("Index", "Writer");

//}
//else
//{
//    return View();
//}