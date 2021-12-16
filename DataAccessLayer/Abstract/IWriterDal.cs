using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal : IGenericDal<Writer>
    {
        Writer GetByFilter(Expression<Func<Writer, bool>> filter = null); //Yazar bilgisini çekmek için genele alınabilir gerektiğinde...
    }
}
