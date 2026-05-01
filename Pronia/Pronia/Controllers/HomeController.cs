using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace Pronia.Controllers
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
            List<Product> products = _db.Products
                .Include(p => p.Images)
                .ToList();
            List<Slider> sliders = _db.Sliders.ToList();

            HomeVM vM = new HomeVM 
            {
                Products = products,
                Sliders = sliders
            }
            ; 

            return View(vM);
        }

        public IActionResult Details(int id)
        {
            Product products = _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);
            return View(products);
        }
    }
}
