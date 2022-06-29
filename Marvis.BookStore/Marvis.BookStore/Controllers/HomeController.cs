using Marvis.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            Title = "Home page from controller";
            CustomProperty = "Custom value";
            Book = new BookModel() { Id = 1, Title = "Asp.Net Core Tutorial" };
            return View();
            //return View("TempView/MarvisTemp.cshtml");
        }

        public ViewResult AboutUs()
        {
            Title = "About page from controller";

            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
