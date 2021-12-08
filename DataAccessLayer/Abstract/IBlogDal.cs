using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        //İhtiyacımız olan methodları ilgili interface içinde kullanabiliriz.
        
        //Generic yapıya ek olarak sadece ilgili entity'e ait methodlar...
        
        //Bağlı bulunduğu ef folder implement no forget!..

        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int writerId); //Yazarın blog listesini ve categorisini getirir.

    }
}
