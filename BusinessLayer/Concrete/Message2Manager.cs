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
    public class Message2Manager : IMessage2Services
    {
        readonly IMessage2Dal message2Dal;

        public Message2Manager(IMessage2Dal _message2Dal)
        {
            message2Dal = _message2Dal;
        }
        public Message2 GetById(int id)
        {
            return message2Dal.TGetById(id);
        }

        public List<Message2> GetInboxByWriter(int id)
        {
            return message2Dal.GetListWithMessageByWriter(id); //Message ye göre Yazarı getirir. [alıcı : receiver durumunda]
        }

        public List<Message2> GetList()
        {
            return message2Dal.GetAllList();
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
