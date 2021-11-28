using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment commend);
        // void CommentDelete(Comment commend);
        // void CommentUpdate(Comment commend);
        List<Comment> GetList(int id);
        //Comment GetById(int id);

        //Generic Hale Getirilecek

    }
}
