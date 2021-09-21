using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        readonly EfCategoryRepository efCategoryRepository;

        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();
        }


        public void CategoryAdd(Category category)
        {
            if (category.CategoryName != "" && category.CategoryDescription != "" && category.CategoryStatus == true)
            {
                //categoryRepository.AddCategory(category);
                efCategoryRepository.Add(category);

            }
        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public List<Category> GetList()
        {
            return efCategoryRepository.GetAllList();
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }
    }
}

//Bussiness katmanında Abstract katmanınında yer alan Interfaceler:Service olarak adlandırılır.
//Bussiness katmanında Concrete katmanınında yer alan Interfaceler:Manager olarak adlandırılır.