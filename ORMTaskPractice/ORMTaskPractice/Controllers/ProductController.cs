using Microsoft.AspNetCore.Mvc;

namespace ORMTaskPractice.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
