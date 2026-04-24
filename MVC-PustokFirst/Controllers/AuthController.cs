using Microsoft.AspNetCore.Mvc;

namespace MVC_PustokFirst.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
