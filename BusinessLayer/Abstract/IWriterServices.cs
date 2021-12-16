using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterServices : IGenericService<Writer>
    {
        List<Writer> GetWriterById(int id);
        Writer TGetByFilter(Expression<Func<Writer, bool>> filter);
    }
}
