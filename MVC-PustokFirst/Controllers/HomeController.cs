using Microsoft.AspNetCore.Mvc;

namespace MVC_PustokFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
