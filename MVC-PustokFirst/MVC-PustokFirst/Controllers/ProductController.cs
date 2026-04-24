using Microsoft.AspNetCore.Mvc;

namespace MVC_PustokFirst.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
