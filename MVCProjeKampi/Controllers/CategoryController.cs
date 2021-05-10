using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            return RedirectToAction("GetCategoryList"); // ekleme işlemini gerçekleştirdikten sonra beni ilgili metoda yönlendir.
        }
    }
}