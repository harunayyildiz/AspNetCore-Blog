using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

//Ef bağımlılığını minimize ediyoruz ctor aracılığıyla veriyoruz
namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public void TAdd(Category t)
        {
            if (t.CategoryName != "" && t.CategoryDescription != "" && t.CategoryStatus == true)
            {
                _categoryDal.Insert(t);

            }
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetAllList();
        }

        public Category GetById(int id)
        {
            return _categoryDal.TGetById(id);
        }
    }
}

//Bussiness katmanında Abstract katmanınında yer alan Interfaceler:Service olarak adlandırılır.
//Bussiness katmanında Concrete katmanınında yer alan Interfaceler:Manager olarak adlandırılır.