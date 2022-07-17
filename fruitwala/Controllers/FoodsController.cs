#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fruitwala.Data;
using fruitwala.Models;
using System.Security.Claims;

namespace fruitwala.Controllers
{
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Filter(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewBag.foods = _context.Foods.Where(b => b.Name!.Contains(SearchString))
                .Include(c => c.FoodTypes);
            }
            return View();
        }

            // GET: Foods
            public async Task<IActionResult> Index()
        {
            var ID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.User = _context.ApplicationUsers.Single(b => b.Id == ID);
            var applicationDbContext = _context.Foods.Include(f => f.FoodTypes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foods = await _context.Foods
                .Include(f => f.FoodTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.comments = _context.Comment.Where(b => b.FoodTypeId == id)
                .Include(c => c.FoodTypes)
                .Include(c => c.User);
            ViewBag.foods = foods; 
            ViewBag.usrID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.User = _context.ApplicationUsers.Single(b => b.Id == ID);
            if (foods == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "FoodType");
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Image,isAvailable,FoodTypeId")] Foods foods)
        {
            //if (ModelState.IsValid)
            if (true)
            {
                _context.Add(foods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "FoodType", foods.FoodTypeId);
            return View(foods);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foods = await _context.Foods.FindAsync(id);
            if (foods == null)
            {
                return NotFound();
            }
            ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "FoodType", foods.FoodTypeId);
            return View(foods);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Image,isAvailable,FoodTypeId")] Foods foods)
        {
            if (id != foods.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(foods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodsExists(foods.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "FoodType", foods.FoodTypeId);
            return View(foods);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foods = await _context.Foods
                .Include(f => f.FoodTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foods == null)
            {
                return NotFound();
            }

            return View(foods);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foods = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(foods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodsExists(int id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }
    }
}
