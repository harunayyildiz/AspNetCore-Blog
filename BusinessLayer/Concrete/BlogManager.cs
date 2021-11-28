using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogServices
    {
        private readonly IBlogDal _blogDal;
        //Bağımlılıkları minimize etmek için interfaceler kullanıldı.

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
            if (blog.BlogTitle.Length > 45)
            {
                _blogDal.Insert(blog);
            }

        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            if (blog.BlogTitle.Length > 45)
            {
                _blogDal.Update(blog);
            }

        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAllList();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogById(int id)
        {
            //ID göre Blog getir
            return _blogDal.GetAllList(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAllList(x => x.WriterId == id).TakeLast(3).ToList(); //writerId göre Blogları listele son 3 adet getir
        }

        public List<Blog> GetLast2Blog()
        {
            return _blogDal.GetAllList().TakeLast(2).ToList();
        }
    }
}
