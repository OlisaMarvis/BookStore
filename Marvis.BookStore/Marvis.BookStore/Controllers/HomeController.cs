using Marvis.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Marvis";

            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Marvis";

            ViewBag.Data = data;

            ViewBag.Type = new BookModel() { Id = 5, Author = "This is author" };
            return View();
            //return View("TempView/MarvisTemp.cshtml");
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
