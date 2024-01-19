using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Controllers
{
    public class KomentarasController : Controller
    {
        private readonly darbasContext _context;

        public KomentarasController(darbasContext context)
        {
            _context = context;
        }

        // GET: Komentaras
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var darbasContext = _context.Komentaras.Include(k => k.FkSkelbimas).Include(k => k.FkVartotojas);
            return View(await darbasContext.ToListAsync());
        }

        // GET: Komentaras/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentara = await _context.Komentaras
                .Include(k => k.FkSkelbimas)
                .Include(k => k.FkVartotojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentara == null)
            {
                return NotFound();
            }

            return View(komentara);
        }

        // GET: Komentaras/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas");
            return View();
        }

        // POST: Komentaras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Komentaras,Id,FkVartotojasid,FkSkelbimasid")] Komentara komentara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komentara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", komentara.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", komentara.FkVartotojasid);
            return View(komentara);
        }

        // GET: Komentaras/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentara = await _context.Komentaras.FindAsync(id);
            if (komentara == null)
            {
                return NotFound();
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", komentara.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", komentara.FkVartotojasid);
            return View(komentara);
        }

        // POST: Komentaras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Komentaras,Id,FkVartotojasid,FkSkelbimasid")] Komentara komentara)
        {
            if (id != komentara.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentaraExists(komentara.Id))
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
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", komentara.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", komentara.FkVartotojasid);
            return View(komentara);
        }

        // GET: Komentaras/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentara = await _context.Komentaras
                .Include(k => k.FkSkelbimas)
                .Include(k => k.FkVartotojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentara == null)
            {
                return NotFound();
            }

            return View(komentara);
        }

        // POST: Komentaras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komentara = await _context.Komentaras.FindAsync(id);
            _context.Komentaras.Remove(komentara);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentaraExists(int id)
        {
            return _context.Komentaras.Any(e => e.Id == id);
        }
    }
}
