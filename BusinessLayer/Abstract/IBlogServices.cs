using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogServices : IGenericService<Blog>
    {

        List<Blog> GetBlogListWithCategory(); //specifics methods added [DataAccessLayer->EfBlogRepository]
        List<Blog> GetBlogById(int id); //blog readall
        List<Blog> GetBlogListByWriter(int id); //Yazarların Blogları
        List<Blog> GetListWithCategoryByWriterBm(int writerId); //Yazarın blog listesini ve categorisini getirir.
    }
}
