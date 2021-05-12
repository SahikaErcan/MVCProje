using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepositoryDal<T>
    {
        List<T> List();
        void Insert(T p);
        void Update(T p);
        T Get(Expression<Func<T,bool>> filter); // sileceğimiz değeri bulacağız.
        /* Id si 5 olan yazar dediğimiz zaman bize tek değer döndüren Get metodunu kullanabiliriz.*/
        void Delete(T p);

        List<T> List(Expression<Func<T,bool>> filter); // Şartlı Listeleme
    /* List metodunda komple bir listeyi döndüreceğiz. Örneğin yazarlar içerisinde ismi Ali
     * olan yazarları List metodu ile bulabiliriz.*/
    }
}
 