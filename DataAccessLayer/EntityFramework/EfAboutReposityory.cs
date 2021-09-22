using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
   public class EfAboutReposityory:GenericRepository<About>,IAboutDal
    {
    }
}

//Şuanki kullandığımız teknolojiyi(Ef) mevcut yapı içerisindeki bağımlılıkları minimize etmek için bu yapıyı uyguladık.
