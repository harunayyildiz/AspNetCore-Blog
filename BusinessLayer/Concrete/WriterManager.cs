using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterServices
    {
        readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this._writerDal = writerDal;
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
        public Writer GetById(int id)
        {
            return _writerDal.TGetById(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            //Dashboardda Yazarın bilgisini görüntülemek için...
            return _writerDal.GetAllList(x => x.WriterId == id);
        }

        public Writer TGetByFilter(Expression<Func<Writer, bool>> filter)
        {
           return _writerDal.GetByFilter(filter);
        }
    }
}
