﻿using System;
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
    public class CountriesController : Controller
    {
        private readonly GeoDbContext _context;

        public CountriesController(GeoDbContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            var geoDbContext = _context.Countries.Include(c => c.ContinentRef);
            return View(await geoDbContext.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.ContinentRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name");
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContinentId,Name")] Country country)
        {
            ModelState.Remove("ContinentRef");
            ModelState.Remove("LanguagesInCountry");
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContinentId,Name")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }
            ModelState.Remove("ContinentRef");
            ModelState.Remove("LanguagesInCountry");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.ContinentRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'GeoDbContext.Countries'  is null.");
            }
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
          return _context.Countries.Any(e => e.Id == id);
        }
    }
}
