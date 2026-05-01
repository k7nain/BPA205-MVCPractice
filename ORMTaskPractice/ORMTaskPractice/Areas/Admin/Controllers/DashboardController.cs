using Microsoft.AspNetCore.Mvc;

namespace ORMTaskPractice.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
