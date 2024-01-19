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
    public class VartotojasController : Controller
    {
        private readonly darbasContext _context;

        public VartotojasController(darbasContext context)
        {
            _context = context;
        }

        // GET: Vartotojas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vartotojas.ToListAsync());
        }

        // GET: Vartotojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var vartotoja = await _context.Vartotojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vartotoja == null)
            {
                return Redirect("~/Home/Nerasta");
            }
            return View(vartotoja);
        }

        // GET: Vartotojas/Isiminti/5
        [Authorize]
        public IActionResult Isiminti()
        {
            return View();
        }

        // GET: Vartotojas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vartotojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Vardas,Slaptazodis,Telefonas,EPastas,Miestas,Id")] Vartotoja vartotoja)
        {
            if (ModelState.IsValid)
            {
                vartotoja.Slaptazodis = BCrypt.Net.BCrypt.HashPassword(vartotoja.Slaptazodis);
                _context.Add(vartotoja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vartotoja);
        }

        // GET: Vartotojas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var vartotoja = await _context.Vartotojas.FindAsync(id);
            if (vartotoja == null)
            {
                return Redirect("~/Home/Nerasta");
            }
            return View(vartotoja);
        }

        // POST: Vartotojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Vardas,Slaptazodis,Telefonas,EPastas,Miestas,Id")] Vartotoja vartotoja)
        {
            if (id != vartotoja.Id)
            {
                return Redirect("~/Home/Nerasta");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vartotoja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VartotojaExists(vartotoja.Id))
                    {
                        return Redirect("~/Home/Nerasta");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vartotoja);
        }

        // GET: Vartotojas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var vartotoja = await _context.Vartotojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vartotoja == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            return View(vartotoja);
        }

        // POST: Vartotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vartotoja = await _context.Vartotojas.FindAsync(id);
            _context.Vartotojas.Remove(vartotoja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VartotojaExists(int id)
        {
            return _context.Vartotojas.Any(e => e.Id == id);
        }
    }
}
