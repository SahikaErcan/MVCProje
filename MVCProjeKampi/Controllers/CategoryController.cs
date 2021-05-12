using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet] // Sayfa yüklendiği zaman çalışır.
        public ActionResult AddCategory()
        {
            return View(); // sayfayı geri döndürür. Böylece sayfa yüklenir yüklenmez veri kayıt etme işlemi olmamış olur.
        }
        [HttpPost] // Sayfada bir butona tıkladığımız da ya da sayfada bir şey post edildiği zaman çalışır.
        public ActionResult AddCategory(Category category)
        {
            //categoryManager.CategoryAddBL(category);
            CategoryValidator categoryValidatior = new CategoryValidator();
            ValidationResult validationResult = categoryValidatior.Validate(category);
            // categoryValidatior da olan değerlere göre parametreden gelen değerin doğruluk kontrolünü gerçekleştir.
            // .Validate : geçerliliğini kontrol etme

            if (validationResult.IsValid)  // Sonuc validasyona uygunsa yani geçerliyse
            { // Ekleme işleminin gerçekleşmesi için validationResult un doğrulanmış olması gerekiyor.
             // Kategory adı boş olmayacak, en az 3 karakter olacak, Açıklama boş olmayacak gibi...
                categoryManager.CategoryAdd(category);
                return View("GetCategoryList"); // GetCategoryList Aksiyonuna yönlendirmesini istiyoruz.
            }
            else
            { // Hata mesajlarını tutacağımız bir dizi oluşturuyoruz.
                foreach (var item in validationResult.Errors)  // validationResult dan gelen erorları kullanarak
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
              //Modelin Durumuna hataları ekle, bu hatalar özelliğin adı ve hata mesajı şeklinde kaydedilir.
                }
            }

            return View(); 
        }
    }
}