using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogServices
    {

        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> GetList();
        Blog GetById(int id);
        List<Blog> GetBlogListWithCategory(); //specifics methods added [DataAccessLayer->EfBlogRepository]
        List<Blog> GetBlogById(int id); //blog readall
        List<Blog> GetBlogListByWriter(int id); //Yazarların Blogları
    }
}
