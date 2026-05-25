using Bilet_Practice_.DAL;
using Bilet_Practice_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet_Practice_.Controllers
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
            List<Game> games = await _db.Games.
                Where(g => !g.IsDeleted)
                .Include(g => g.Category)
                .ToListAsync();
            return View(games);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            Game game = await _db.Games.
                Where(g => !g.IsDeleted)
                .Include(g => g.Category)
                .FirstOrDefaultAsync(g => g.Id == id);
            return View(game);
        }
    }
}
