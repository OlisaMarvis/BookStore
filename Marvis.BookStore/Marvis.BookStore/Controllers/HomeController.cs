using Microsoft.AspNetCore.Mvc;

namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
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
