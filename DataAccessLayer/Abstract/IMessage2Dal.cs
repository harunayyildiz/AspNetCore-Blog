using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        //specifics
        List<Message2> GetListWithMessageByWriter(int id);
    }
}
