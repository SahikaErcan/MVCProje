using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; // _object T değerine karşılık gelen sınıfı tutuyor.

        public GenericRepository()
        {
            _object = c.Set<T>(); //CONTEXT e bağlı olan T değerini " _object " ifadesine atıyoruz. 
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
        /* SingleOrDefault : Bir dizide veya listede sadece bir tane değer
         * göndermek için kullanılan EntityFramework Linq metodudur. */
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
