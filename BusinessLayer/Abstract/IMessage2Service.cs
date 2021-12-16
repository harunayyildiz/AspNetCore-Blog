using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Services : IGenericService<Message2>
    {
        List<Message2> GetInboxByWriter(int id); //Dashboardda Yazarın Messageleri
    }
}
