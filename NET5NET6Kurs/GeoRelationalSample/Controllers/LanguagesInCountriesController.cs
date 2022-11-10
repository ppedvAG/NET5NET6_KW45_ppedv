using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoRelationalSample.Data;
using GeoRelationalSample.Models;

namespace GeoRelationalSample.Controllers
{
    public class LanguagesInCountriesController : Controller
    {
        private readonly GeoDbContext _context;

        public LanguagesInCountriesController(GeoDbContext context)
        {
            _context = context;
        }

        // GET: LanguagesInCountries
        public async Task<IActionResult> Index()
        {
            var geoDbContext = _context.LanguagesInCountries.Include(l => l.CountryRef).Include(l => l.LanguagesRef);
            return View(await geoDbContext.ToListAsync());
        }

        // GET: LanguagesInCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LanguagesInCountries == null)
            {
                return NotFound();
            }

            var languagesInCountry = await _context.LanguagesInCountries
                .Include(l => l.CountryRef)
                .Include(l => l.LanguagesRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languagesInCountry == null)
            {
                return NotFound();
            }

            return View(languagesInCountry);
        }

        // GET: LanguagesInCountries/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            return View();
        }

        // POST: LanguagesInCountries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryId,LanguageId,Percent")] LanguagesInCountry languagesInCountry)
        {
            ModelState.Remove("LanguagesRef");
            ModelState.Remove("CountryRef");


            if (ModelState.IsValid)
            {
                _context.Add(languagesInCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languagesInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languagesInCountry.LanguageId);
            return View(languagesInCountry);
        }

        // GET: LanguagesInCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LanguagesInCountries == null)
            {
                return NotFound();
            }

            var languagesInCountry = await _context.LanguagesInCountries.FindAsync(id);
            if (languagesInCountry == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languagesInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languagesInCountry.LanguageId);
            return View(languagesInCountry);
        }

        // POST: LanguagesInCountries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryId,LanguageId,Percent")] LanguagesInCountry languagesInCountry)
        {
            if (id != languagesInCountry.Id)
            {
                return NotFound();
            }


            ModelState.Remove("LanguagesRef");
            ModelState.Remove("CountryRef");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languagesInCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguagesInCountryExists(languagesInCountry.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languagesInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", languagesInCountry.LanguageId);
            return View(languagesInCountry);
        }

        // GET: LanguagesInCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LanguagesInCountries == null)
            {
                return NotFound();
            }

            var languagesInCountry = await _context.LanguagesInCountries
                .Include(l => l.CountryRef)
                .Include(l => l.LanguagesRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languagesInCountry == null)
            {
                return NotFound();
            }

            return View(languagesInCountry);
        }

        // POST: LanguagesInCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LanguagesInCountries == null)
            {
                return Problem("Entity set 'GeoDbContext.LanguagesInCountries'  is null.");
            }
            var languagesInCountry = await _context.LanguagesInCountries.FindAsync(id);
            if (languagesInCountry != null)
            {
                _context.LanguagesInCountries.Remove(languagesInCountry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguagesInCountryExists(int id)
        {
          return _context.LanguagesInCountries.Any(e => e.Id == id);
        }
    }
}
