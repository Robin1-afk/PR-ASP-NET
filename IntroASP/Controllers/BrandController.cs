using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {
        private readonly ASP_Context _context;

        public BrandController(ASP_Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
            => View(await _context.Brands.ToListAsync());

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand()
                {
                    Name = model.Name,
                };
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.Name);
            return View();
        }
    }
}
