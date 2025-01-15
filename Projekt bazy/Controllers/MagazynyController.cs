using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_bazy.Data;
using Projekt_bazy.Models;

namespace Projekt_bazy.Controllers
{
    public class MagazynyController : Controller
    {
        private readonly MagazynDbContext _context;

        public MagazynyController(MagazynDbContext context)
        {
            _context = context;
        }

        // GET: Magazyny
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magazyny.ToListAsync());
        }

        // GET: Magazyny/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny
                .FirstOrDefaultAsync(m => m.IdMagazynu == id);
            if (magazyn == null)
            {
                return NotFound();
            }

            return View(magazyn);
        }

        // GET: Magazyny/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazyny/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMagazynu,Funkcjonalnosc,Lokalizacja")] Magazyn magazyn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazyn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazyn);
        }

        // GET: Magazyny/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny.FindAsync(id);
            if (magazyn == null)
            {
                return NotFound();
            }
            return View(magazyn);
        }

        // POST: Magazyny/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMagazynu,Funkcjonalnosc,Lokalizacja")] Magazyn magazyn)
        {
            if (id != magazyn.IdMagazynu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazyn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazynExists(magazyn.IdMagazynu))
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
            return View(magazyn);
        }

        /// GET: Magazyny/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazyn = await _context.Magazyny
                .FirstOrDefaultAsync(m => m.IdMagazynu == id);
            if (magazyn == null)
            {
                return NotFound();
            }

            return View(magazyn);
        }

        // POST: Magazyny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var magazyn = await _context.Magazyny.FindAsync(id);
                if (magazyn != null)
                {
                    _context.Magazyny.Remove(magazyn);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error deleting magazyn: {ex.Message}");

                TempData["ErrorMessage"] = "Nie można usunąć magazynu, w którym znajdują się sprzęty. Proszę przenieść sprzęty do innego magazynu przed usunięciem.";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool MagazynExists(int id)
        {
            return _context.Magazyny.Any(e => e.IdMagazynu == id);
        }
    }
}
