using Microsoft.AspNetCore.Mvc;

namespace MVC_PustokFirst.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
