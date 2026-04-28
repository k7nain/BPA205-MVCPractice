using Microsoft.AspNetCore.Mvc;
using ORMTaskPractice.DAL;
using ORMTaskPractice.Models;

namespace ORMTaskPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {

            List<Product> products = _db.Products.ToList();

            return View(products);
        }
    }
}
