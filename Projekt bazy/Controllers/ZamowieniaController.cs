using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_bazy.Data;
using Projekt_bazy.Models;

namespace Projekt_bazy.Controllers
{
    [Authorize]
    public class ZamowieniaController : Controller
    {
        private readonly MagazynDbContext _context;

        public ZamowieniaController(MagazynDbContext context)
        {
            _context = context;
        }

        // GET: Zamowienia
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var magazynDbContext = _context.Zamowienia.Include(z => z.Magazyn).Include(z => z.Zamawiajacy);
            return View(await magazynDbContext.ToListAsync());
        }

        // GET: Zamowienia/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .Include(z => z.Magazyn)
                .Include(z => z.Zamawiajacy)
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienia == null)
            {
                return NotFound();
            }
            var zamawiajacyInfo = $"{zamowienia.Zamawiajacy.Imie} {zamowienia.Zamawiajacy.Nazwisko} Odznaka:{zamowienia.Zamawiajacy.NumerOdznaki}";
            var magazynInfo = $"{zamowienia.Magazyn.Funkcjonalnosc} - {zamowienia.Magazyn.Lokalizacja}";

            ViewData["ZamawiajacyInfo"] = zamawiajacyInfo;
            ViewData["MagazynInfo"] = magazynInfo;

            return View(zamowienia);
        }

        // GET: Zamowienia/Create
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ZamawiajacyId"] = new SelectList(
                _context.Personel.Select(p => new
                {
                    IdPersonelu = p.IdPersonelu,
                    DisplayName = $"{p.Imie} {p.Nazwisko} Nr odznaki: {p.NumerOdznaki}"
                }),
                "IdPersonelu",
                "DisplayName"
            );
            ViewData["MagazynId"] = new SelectList(
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

        // POST: Zamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IdZamowienia,NazwaSprzetu,DataZamowienia,ZamawiajacyId,MagazynId")] Zamowienia zamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MagazynId"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName",
                zamowienia.MagazynId
            );

            ViewData["ZamawiajacyId"] = new SelectList(
                _context.Personel.Select(p => new
                {
                    IdPersonelu = p.IdPersonelu,
                    DisplayName = $"{p.Imie} {p.Nazwisko} Nr odznaki: {p.NumerOdznaki}"
                }),
                "IdPersonelu",
                "DisplayName",
                zamowienia.ZamawiajacyId
            );

            return View(zamowienia);
        }

        // GET: Zamowienia/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            ViewData["MagazynId"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName",
                zamowienia.MagazynId
            );

            ViewData["ZamawiajacyId"] = new SelectList(
                _context.Personel.Select(p => new
                {
                    IdPersonelu = p.IdPersonelu,
                    DisplayName = $"{p.Imie} {p.Nazwisko} Nr odznaki: {p.NumerOdznaki}"
                }),
                "IdPersonelu",
                "DisplayName",
                zamowienia.ZamawiajacyId
            );

            return View(zamowienia);
        }

        // POST: Zamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("IdZamowienia,NazwaSprzetu,DataZamowienia,ZamawiajacyId,MagazynId")] Zamowienia zamowienia)
        {
            if (id != zamowienia.IdZamowienia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowieniaExists(zamowienia.IdZamowienia))
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

            ViewData["MagazynId"] = new SelectList(
                _context.Magazyny.Select(m => new
                {
                    IdMagazynu = m.IdMagazynu,
                    DisplayName = $"{m.Funkcjonalnosc} - {m.Lokalizacja}"
                }),
                "IdMagazynu",
                "DisplayName",
                zamowienia.MagazynId
            );

            ViewData["ZamawiajacyId"] = new SelectList(
                _context.Personel.Select(p => new
                {
                    IdPersonelu = p.IdPersonelu,
                    DisplayName = $"{p.Imie} {p.Nazwisko} Nr odznaki: {p.NumerOdznaki}"
                }),
                "IdPersonelu",
                "DisplayName",
                zamowienia.ZamawiajacyId
            );

            return View(zamowienia);
        }

        // GET: Zamowienia/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .Include(z => z.Magazyn)
                .Include(z => z.Zamawiajacy)
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // POST: Zamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia != null)
            {
                _context.Zamowienia.Remove(zamowienia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowieniaExists(int id)
        {
            return _context.Zamowienia.Any(e => e.IdZamowienia == id);
        }
    }
}
