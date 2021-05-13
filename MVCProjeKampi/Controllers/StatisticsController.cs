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
            // Toplam kategori sayısı
            var value1 = context.Categories.Count().ToString(); 
            ViewBag.sumCategory = value1;
            // Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var value2 = context.Headings.Count(x => x.CategoryID == 8).ToString(); 
            ViewBag.softwareTitle = value2;
            // Yazar adında 'a' harfi geçen yazar sayısı
            var value3 = context.Writers.Count(x => x.WriterName.Contains("a")).ToString(); 
            ViewBag.writerNameLetterA = value3;
            // En fazla başlığa sahip kategori adı
            var value4 = context.Categories.Where(c => c.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault()).Select(n => n.CategoryName).FirstOrDefault(); 
            ViewBag.categoryNameMore = value4;
            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var value5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false); 
            ViewBag.activeCategory = value5;
            return View();
        }
    }
}