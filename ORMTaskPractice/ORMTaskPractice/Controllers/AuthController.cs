using Microsoft.AspNetCore.Mvc;

namespace ORMTaskPractice.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
