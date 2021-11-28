using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comments
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository()); 
        public IViewComponentResult Invoke(int id)
        {
            var result = commentManager.GetList(id);
            return View(result);
        }
    }
}
