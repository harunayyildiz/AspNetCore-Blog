using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager _messageManager = new Message2Manager(new EfMessage2Repository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IActionResult InBox()
        {
            var writer = writerManager.TGetByFilter(x => x.WriterMail == User.Identity.Name);
            int id = writer.WriterId;
            var result = _messageManager.GetInboxByWriter(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult MessageDetail(int id)
        {

            var messageValue = _messageManager.GetById(id);
            return View(messageValue);

        }
    }
}
