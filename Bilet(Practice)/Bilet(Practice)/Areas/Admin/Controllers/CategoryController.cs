using Bilet_Practice_.Areas.Admin.ViewModels;
using Bilet_Practice_.Areas.Admin.ViewModels.Category;
using Bilet_Practice_.DAL;
using Bilet_Practice_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet_Practice_.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Superadmin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _db.Categories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM gameVM)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category category = new Category
            {
                Name = gameVM.Name,
            };
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return NotFound();


            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return NotFound();

            category.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return NotFound();


            category.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);


            if (category == null) return NotFound();

            UpdateCategoryVM categoryVM = new UpdateCategoryVM
            {
                Name = category.Name,
            };

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdateCategoryVM categoryVM)
        {

            if ( categoryVM.Id == null) return NotFound();

            Category category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == categoryVM.Id);

            if (category == null) return NotFound();

            category.Name = categoryVM.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
