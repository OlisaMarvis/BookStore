using Marvis.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["property1"] = "Olisa Marvis";

            ViewData["book"] = new BookModel() { Author = "Marvis", Id = 1 };
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
