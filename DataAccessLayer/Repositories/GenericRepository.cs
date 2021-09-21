using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using var cx = new Context();
            cx.Add(t);
            cx.SaveChanges();
        }

        public void Delete(T t)
        {
            using var cx = new Context();
            cx.Remove(t);
            cx.SaveChanges();
        }

        public void Update(T t)
        {
            using var cx = new Context();
            cx.Update(t);
            cx.SaveChanges();
        }

        public List<T> GetAllList()
        {
            using var cx = new Context();
            return cx.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            using var cx = new Context();
            return cx.Set<T>().Find(id);
        }
    }
}
