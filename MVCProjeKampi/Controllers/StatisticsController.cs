using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var value1 = context.Categories.Count().ToString(); // Toplam kategori sayısı
            ViewBag.sumCategory = value1;
            var value2 = context.Headings.Count(x => x.CategoryID == 8).ToString(); // Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            ViewBag.softwareTitle = value2;
            var value3 = context.Writers.Count(x => x.WriterName.Contains("a")).ToString(); // Yazar adında 'a' harfi geçen yazar sayısı
            ViewBag.writerNameLetterA = value3;
            var value4 = context.Headings.Max(x => x.Category.CategoryName); // En fazla başlığa sahip kategori adı
            ViewBag.categoryNameMore = value4;
            var value5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false); 
            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            ViewBag.activeCategory = value5;
            return View();
        }
    }
}