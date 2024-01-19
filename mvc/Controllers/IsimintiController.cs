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
    public class IsimintiController : Controller
    {
        private readonly darbasContext _context;

        public IsimintiController(darbasContext context)
        {
            _context = context;
        }

        // GET: Isiminti
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var darbasContext = _context.Isiminta.Include(i => i.FkSkelbimas).Include(i => i.FkVartotojas);
            return View(await darbasContext.ToListAsync());
        }

        // GET: Isiminti/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isimintum = await _context.Isiminta
                .Include(i => i.FkSkelbimas)
                .Include(i => i.FkVartotojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isimintum == null)
            {
                return NotFound();
            }

            return View(isimintum);
        }

        // GET: Isiminti/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas");
            return View();
        }

        // POST: Isiminti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,FkSkelbimasid,FkVartotojasid")] Isimintum isimintum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isimintum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", isimintum.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", isimintum.FkVartotojasid);
            return View(isimintum);
        }

        // GET: Isiminti/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isimintum = await _context.Isiminta.FindAsync(id);
            if (isimintum == null)
            {
                return NotFound();
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", isimintum.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", isimintum.FkVartotojasid);
            return View(isimintum);
        }

        // POST: Isiminti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkSkelbimasid,FkVartotojasid")] Isimintum isimintum)
        {
            if (id != isimintum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isimintum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsimintumExists(isimintum.Id))
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
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", isimintum.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", isimintum.FkVartotojasid);
            return View(isimintum);
        }

        // GET: Isiminti/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var isimintum = await _context.Isiminta
                .Include(i => i.FkSkelbimas)
                .Include(i => i.FkVartotojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isimintum == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            return View(isimintum);
        }

        // POST: Isiminti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isimintum = await _context.Isiminta.FindAsync(id);
            _context.Isiminta.Remove(isimintum);
            await _context.SaveChangesAsync();
            TempData["pavyko"] = "Skelbimas sėkmingai pamirštas!";
            return Redirect("/Home");
        }

        private bool IsimintumExists(int id)
        {
            return _context.Isiminta.Any(e => e.Id == id);
        }
    }
}
