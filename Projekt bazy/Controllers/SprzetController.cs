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
    public class SprzetController : Controller
    {
        private readonly MagazynDbContext _context;

        public SprzetController(MagazynDbContext context)
        {
            _context = context;
        }

        // GET: Sprzet
        public async Task<IActionResult> Index()
        {
            var magazynDbContext = _context.Sprzety.Include(s => s.Magazyn);
            return View(await magazynDbContext.ToListAsync());
        }

        // GET: Sprzet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety
                .Include(s => s.Magazyn)
                .FirstOrDefaultAsync(m => m.IdSprzetu == id);
            if (sprzet == null)
            {
                return NotFound();
            }

            return View(sprzet);
        }

        // GET: Sprzet/Create
        public IActionResult Create()
        {
            ViewData["MagazynId"] = new SelectList(_context.Magazyny, "IdMagazynu", "Funkcjonalnosc");
            return View();
        }

        // POST: Sprzet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSprzetu,NazwaSprzetu,DataWstawienia,MagazynId")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MagazynId"] = new SelectList(_context.Magazyny, "IdMagazynu", "Funkcjonalnosc", sprzet.MagazynId);
            return View(sprzet);
        }

        // GET: Sprzet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety.FindAsync(id);
            if (sprzet == null)
            {
                return NotFound();
            }
            ViewData["MagazynId"] = new SelectList(_context.Magazyny, "IdMagazynu", "Funkcjonalnosc", sprzet.MagazynId);
            return View(sprzet);
        }

        // POST: Sprzet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSprzetu,NazwaSprzetu,DataWstawienia,MagazynId")] Sprzet sprzet)
        {
            if (id != sprzet.IdSprzetu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprzet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprzetExists(sprzet.IdSprzetu))
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
            ViewData["MagazynId"] = new SelectList(_context.Magazyny, "IdMagazynu", "Funkcjonalnosc", sprzet.MagazynId);
            return View(sprzet);
        }

        // GET: Sprzet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety
                .Include(s => s.Magazyn)
                .FirstOrDefaultAsync(m => m.IdSprzetu == id);
            if (sprzet == null)
            {
                return NotFound();
            }

            return View(sprzet);
        }

        // POST: Sprzet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprzet = await _context.Sprzety.FindAsync(id);
            if (sprzet != null)
            {
                _context.Sprzety.Remove(sprzet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprzetExists(int id)
        {
            return _context.Sprzety.Any(e => e.IdSprzetu == id);
        }
    }
}
