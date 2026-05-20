using System.Threading.Tasks;
using Bilet_1_Practice_.DAL;
using Bilet_1_Practice_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet_1_Practice_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members = await _db.Members
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            return View(members);
        }
    }
}
