using System.Threading.Tasks;
using Bilet_1_Practice_.Areas.Admin.ViewModels.Member;
using Bilet_1_Practice_.DAL;
using Bilet_1_Practice_.Models;
using Bilet_1_Practice_.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet_1_Practice_.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public MemberController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members = await _db.Members
                .ToListAsync();
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberVM memberVM)
        {
            if (memberVM.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required..");
                return View();
            }
            else
            {
                if (!memberVM.ImageFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("ImageFile", "ImageFile must be an image..");
                    return View();
                }
                if (memberVM.ImageFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("ImageFile", "ImageFile size must be 2 MB..");
                    return View();
                }
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            Member member = new Member
            {
                Name = memberVM.Name,
                Surname = memberVM.Surname,
                Position = memberVM.Position,
                ImageUrl = memberVM.ImageFile.SaveImage(_env, "uploads/members")
            };

            await _db.Members.AddAsync(member);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> HardDelete(int? id)
        {
            if (id == null) return BadRequest();

            Member member = await _db.Members.FindAsync(id);

            if (member == null) return NotFound();

            _db.Members.Remove(member);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int? id)
        {
            if (id == null) return BadRequest();

            Member member = await _db.Members.FindAsync(id);

            if (member == null) return NotFound();

            member.IsDeleted = true;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return BadRequest();

            Member member = await _db.Members.FindAsync(id);

            if (member == null) return NotFound();

            member.IsDeleted = false;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Member member = await _db.Members.FindAsync(id);

            if (member == null) return NotFound();

            UpdateMemberVM memberVM = new UpdateMemberVM
            {
                Name = member.Name,
                Surname = member.Surname,
                Position = member.Position
            };

            return View(memberVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMemberVM memberVM)
        {
            if (memberVM.Id == null) return BadRequest();

            Member member = await _db.Members.FindAsync(memberVM.Id);

            if (member == null) return NotFound();

            member.Name = memberVM.Name;
            member.Surname = memberVM.Surname;
            member.Position = memberVM.Position;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
