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
    public class PersonelController : Controller
    {
        private readonly MagazynDbContext _context;

        public PersonelController(MagazynDbContext context)
        {
            _context = context;
        }

        // GET: Personel
        public async Task<IActionResult> Index()
        {
            var magazynDbContext = _context.Personel.Include(p => p.Magazyn);
            return View(await magazynDbContext.ToListAsync());
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .Include(p => p.Magazyn)
                .FirstOrDefaultAsync(m => m.IdPersonelu == id);
            if (personel == null)
            {
                return NotFound();
            }
            var magazynInfo = $"{personel.Magazyn.Funkcjonalnosc} - {personel.Magazyn.Lokalizacja}";
            ViewData["MagazynInfo"] = magazynInfo;

            return View(personel);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            ViewData["Przynaleznosc"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName"
            );
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonelu,Imie,Nazwisko,Stopien,NumerOdznaki,Przynaleznosc")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Przynaleznosc"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName"
            );
            return View(personel);
        }

        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            ViewData["Przynaleznosc"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName",
                personel.Przynaleznosc
            );
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonelu,Imie,Nazwisko,Stopien,NumerOdznaki,Przynaleznosc")] Personel personel)
        {
            if (id != personel.IdPersonelu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.IdPersonelu))
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
            ViewData["Przynaleznosc"] = new SelectList(_context.Magazyny, "IdMagazynu", "Funkcjonalnosc", personel.Przynaleznosc);
            return View(personel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personel
                .Include(p => p.Magazyn)
                .FirstOrDefaultAsync(m => m.IdPersonelu == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personel.FindAsync(id);
            if (personel != null)
            {
                _context.Personel.Remove(personel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return _context.Personel.Any(e => e.IdPersonelu == id);
        }
    }
}
