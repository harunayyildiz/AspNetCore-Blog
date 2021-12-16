using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageServices
    {
        readonly IMessageDal messageDal;

        public MessageManager(IMessageDal _messageDal)
        {
            messageDal = _messageDal;
        }

        public Message GetById(int id)
        {
            return messageDal.TGetById(id);
        }

        public List<Message> GetList()
        {
            return messageDal.GetAllList();
        }

        public List<Message> GetInboxByWriter(string email)
        {
            return messageDal.GetAllList(x => x.Receiver == email);//alıcı biz isek...
        }

        public void TAdd(Message t)
        {
            messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            messageDal.Delete(t);
        }

        public void TUpdate(Message t)
        {
            messageDal.Update(t);
        }
    }
}
