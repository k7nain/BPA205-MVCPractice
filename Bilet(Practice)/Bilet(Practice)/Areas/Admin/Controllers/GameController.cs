using Bilet_Practice_.Areas.Admin.ViewModels.Game;
using Bilet_Practice_.DAL;
using Bilet_Practice_.Models;
using Bilet_Practice_.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet_Practice_.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Superadmin")]
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public GameController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Game> games = await _db.Games
                .Include(g => g.Category)
                .ToListAsync();
            return View(games);
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGameVM gameVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();

            if (gameVM.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Please correct the errors and try again");
                return View();
            }
            else
            {
                if (!gameVM.ImageFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("ImageFile", "ImageFile must be an image");
                    return View();
                }
                if (gameVM.ImageFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("ImageFile", "ImageFile size must be 2MB");
                    return View();
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            Game game = new Game
            {
                Name = gameVM.Name,
                Discount = gameVM.Discount,
                Price = gameVM.Price,
                Description = gameVM.Description,
                ImageUrl = gameVM.ImageFile.SaveImage(_env, "uploads/games"),
                CategoryId = gameVM.CategoryId,
            };

            await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(int? id)
        {
            if (id == null) return NotFound();

            Game game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (game == null) return NotFound();

            game.ImageUrl.DeleteImage(_env, "uploads/games");

            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int? id)
        {
            if (id == null) return NotFound();

            Game game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (game == null) return NotFound();

            game.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return NotFound();

            Game game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (game == null) return NotFound();

            game.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();


            if (id == null) return NotFound();

            Game game = await _db.Games.FindAsync(id);

            if (game == null) return NotFound();

            UpdateGameVM gameVM = new UpdateGameVM
            {
                Name = game.Name,
                Discount = game.Discount,
                Price = game.Price,
                Description = game.Description,
                CategoryId = game.CategoryId,
                ImageUrl = game.ImageUrl,
            };

            return View(gameVM);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdateGameVM gameVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();

            if (gameVM.Id == null) return NotFound();

            Game game = await _db.Games.FindAsync(gameVM.Id);

            if (game == null) return NotFound();

            game.Name = gameVM.Name;
            game.Discount = gameVM.Discount;
            game.Price = gameVM.Price;
            game.Description = gameVM.Description;
            game.CategoryId = gameVM.CategoryId;

            if (gameVM.ImageFile is not null)
            {
                game.ImageUrl = gameVM.ImageFile.SaveImage(_env, "uploads/games");
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
