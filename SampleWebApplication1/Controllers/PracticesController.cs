using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication1.Models;

namespace SampleWebApplication1.Controllers
{
    public class PracticesController : Controller
    {
        private readonly AppDbContext _context;

        public PracticesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Practices
        public async Task<IActionResult> Index()
        {
              return View(await _context.Practice_1.ToListAsync());
        }

        // GET: Practices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Practice_1 == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practice == null)
            {
                return NotFound();
            }

            return View(practice);
        }

        // GET: Practices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Practices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,mezoszerkesztes,CreateDatabaseInProgramcs,DbContextSzerkesztes,ControllerGeneralas,LayoutGombMegjelenites,AppDbContextSzerkesztes,NemAkaromHogyLatszodjon,NemAkaromHogyLatszodjonBindesResz")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(practice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practice);
        }

        // GET: Practices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Practice_1 == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice_1.FindAsync(id);
            if (practice == null)
            {
                return NotFound();
            }
            return View(practice);
        }

        // POST: Practices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,mezoszerkesztes,CreateDatabaseInProgramcs,DbContextSzerkesztes,ControllerGeneralas,LayoutGombMegjelenites,AppDbContextSzerkesztes,NemAkaromHogyLatszodjon,NemAkaromHogyLatszodjonBindesResz")] Practice practice)
        {
            if (id != practice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracticeExists(practice.Id))
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
            return View(practice);
        }

        // GET: Practices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Practice_1 == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practice == null)
            {
                return NotFound();
            }

            return View(practice);
        }

        // POST: Practices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Practice_1 == null)
            {
                return Problem("Entity set 'AppDbContext.Practice_1'  is null.");
            }
            var practice = await _context.Practice_1.FindAsync(id);
            if (practice != null)
            {
                _context.Practice_1.Remove(practice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracticeExists(int id)
        {
          return _context.Practice_1.Any(e => e.Id == id);
        }
    }
}
