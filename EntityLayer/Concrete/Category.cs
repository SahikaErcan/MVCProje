using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        /* İlişkili tablolarda silme işlemi kullanmayacağız onun yerine durumu aktif ya da
        pasif yapma işlemini tercih edeceğiz. Çünkü örneğin yazılım kategorisini sildiğimizde
        CodeFirst yaklaşımında bizim uyguladığımız yöntemler üzerinde silme işlemi uyguladığımızda
        kategorisi yazılım olan heading ler de silinecek başlıklar silinince doğal olarak içerikler
        de silinecektir. Bu sebeple kaldırmak yerine durumunu aktif-pasif hale getiririz.
        */

        public ICollection<Heading> Headings { get; set; }
    }
}
