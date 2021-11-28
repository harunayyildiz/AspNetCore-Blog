using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAllList(); //Aynı isim farklı parametreler
        List<T> GetAllList(Expression<Func<T, bool>> filter); //Expression [Şartlı sorgulama]
        T GetById(int id);

    }
}
