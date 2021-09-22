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


        public void CategoryAdd(Category category)
        {
            if (category.CategoryName != "" && category.CategoryDescription != "" && category.CategoryStatus == true)
            {
                _categoryDal.Insert(category);

            }
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetAllList();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}

//Bussiness katmanında Abstract katmanınında yer alan Interfaceler:Service olarak adlandırılır.
//Bussiness katmanında Concrete katmanınında yer alan Interfaceler:Manager olarak adlandırılır.