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
    public class AdminManager : IAdminServices
    {
        readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this._adminDal = adminDal;
        }

        public Admin GetById(int id)
        {
            return _adminDal.TGetById(id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetAllList();
        }

        public void TAdd(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _adminDal.Update(t);
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
