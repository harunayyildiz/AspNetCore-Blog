using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Helper;
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

        public void TAdd(Blog t)
        {
            if (t.BlogTitle.Length > 45)
            {
                _blogDal.Insert(t);
            }

        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            if (t.BlogTitle.Length > 45)
            {
                _blogDal.Update(t);
            }

        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAllList();
        }

        public Blog GetById(int id)
        {
            return _blogDal.TGetById(id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory().OrderByDescending(x => x.BlogCreatedAt).ToList();   //Son Bloglardan getirmeye başlar
                                                                                                      ////Blog kısmında index
            ///Yazar kısmında dashboard kullanır
        }
        public List<Blog> GetListWithCategoryByWriterBm(int writerId)
        {
            return _blogDal.GetListWithCategoryByWriter(writerId);
        }

        public List<Blog> GetBlogById(int id)
        {
            //ID göre Blog Listesi getir
            return _blogDal.GetAllList(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListByWriter(int id, bool? isTake)
        {
            if (isTake.HasValue && isTake == true)
            {
                return _blogDal.GetAllList(x => x.WriterId == id).TakeLast(3).ToList(); //writerId göre Blogları listele son 3 adet getir
            }
            else
            {
                return _blogDal.GetAllList(x => x.WriterId == id);
            }

        }

        public List<Blog> GetLast2Blog()
        {
            return _blogDal.GetAllList().TakeLast(2).ToList();
        }
    }
}
