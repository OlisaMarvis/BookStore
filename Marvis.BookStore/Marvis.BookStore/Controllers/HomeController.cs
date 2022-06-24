using Microsoft.AspNetCore.Mvc;

namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Marvis";
        }
    }
}
