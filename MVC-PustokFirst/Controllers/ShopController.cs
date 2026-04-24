using Microsoft.AspNetCore.Mvc;

namespace MVC_PustokFirst.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
