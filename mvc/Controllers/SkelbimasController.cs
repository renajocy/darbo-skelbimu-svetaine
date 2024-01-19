using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace mvc.Models
{
    public class SkelbimasController : Controller
    {
        private readonly darbasContext _context;

        public SkelbimasController(darbasContext context)
        {
            _context = context;
        }

        // GET: Skelbimas
        public async Task<IActionResult> Index(string sortOrder, string Raktazodis, int? puslapis, string currentFilter, string kategorija)
        {
            var darbasContext = _context.Skelbimas.Include(s => s.FkKategorija).Include(s => s.FkVartotojas).Include(s => s.MokejimoBudasNavigation);
            if (Raktazodis != null)
            {
                puslapis = 1;
            }
            else
            {
                Raktazodis = currentFilter;
            }
            ViewData["CurrentFilter"] = Raktazodis;
            ViewData["Kategorija"] = kategorija;
            var skelbimai = from s in _context.Skelbimas select s;

            if (!String.IsNullOrEmpty(Raktazodis))
            {
                skelbimai = skelbimai.Where(s => s.Pavadinimas.Contains(Raktazodis));
            }
            if (!String.IsNullOrEmpty(kategorija))
            {
                skelbimai = skelbimai.Where(s => s.FkKategorija.Pavadinimas.Contains(kategorija));
            }

            int pageSize = 5;
            return View(await PaginatedList<Skelbima>.CreateAsync(skelbimai.AsNoTracking().Include(d => d.FkVartotojas), puslapis ?? 1, pageSize));
        }

        // GET: Skelbimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["ID"] = id;
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var skelbima = await _context.Skelbimas
                .Include(s => s.FkKategorija)
                .Include(s => s.FkVartotojas)
                .Include(s => s.MokejimoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skelbima == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var komentarai = _context.Komentaras.Where(a => a.FkSkelbimasid == id).ToList();
            foreach (Komentara c in komentarai)
            {
                var user = await _context.Vartotojas.FirstOrDefaultAsync(z => z.Id == c.FkVartotojasid);
                c.FkVartotojas.Vardas = user.Vardas;
                skelbima.Komentaras.Add(c);
            }

            return View(skelbima);
        }

        // GET: Skelbimas/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["FkKategorijaid"] = new SelectList(_context.Kategorijas, "Id", "Pavadinimas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas");
            ViewData["MokejimoBudas"] = new SelectList(_context.Apmokejimas, "Id", "Name");
            return View();
        }

        // POST: Skelbimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Pavadinimas,Aprasymas,Adresas,Uzmokestis,Data,MokejimoBudas,Id,FkVartotojasid,FkKategorijaid")] Skelbima skelbima)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
                skelbima.Data = DateTime.Now;
                skelbima.FkVartotojasid = user.Id;
                _context.Add(skelbima);
                await _context.SaveChangesAsync();
                TempData["pavyko"] = "Skelbimas buvo sėkmingai sukurtas!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkKategorijaid"] = new SelectList(_context.Kategorijas, "Id", "Pavadinimas", skelbima.FkKategorijaid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas", skelbima.FkVartotojasid);
            ViewData["MokejimoBudas"] = new SelectList(_context.Apmokejimas, "Id", "Name", skelbima.MokejimoBudas);
            return View(skelbima);
        }

        // GET: Skelbimas/Prisiminti
        [Authorize]
        public IActionResult Prisiminti(int id)
        {
            ViewData["ID"] = id;
            var user = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
            var isiminti = _context.Isiminta.Count(x => x.FkSkelbimasid == id);
            var isi = _context.Isiminta.Where(y => y.FkSkelbimasid == id).ToList();
            foreach (var i in isi)
            {
                if (i.FkVartotojasid == user.Id)
                {
                    TempData["Error"] = "Klaida! Jūs šį skelbimą jau esate įsiminę!";
                    return Redirect("~/Home");
                }
            }
            ViewData["FkKategorijaid"] = new SelectList(_context.Kategorijas, "Id", "Pavadinimas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas");
            ViewData["MokejimoBudas"] = new SelectList(_context.Apmokejimas, "Id", "Name");
            return View();
        }

        // POST: Skelbimas/Prisiminti
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> Prisiminti([Bind("FkSkelbimasid,FkVartotojasid")] Isimintum isimintum, int id)
        {
            var isiminti = _context.Isiminta.Count(x => x.FkSkelbimasid == id);
            if (ModelState.IsValid)
            {
                var user = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
                isimintum.FkSkelbimasid = id;
                isimintum.FkVartotojasid = user.Id;
                _context.Add(isimintum);
                await _context.SaveChangesAsync();
                TempData["pavyko"] = "Skelbimas buvo sėkmingai prisimintas!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Aprasymas", isimintum.FkSkelbimasid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "EPastas", isimintum.FkVartotojasid);
            return View(isimintum);
        }

        // GET: Skelbimas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var skelbima = await _context.Skelbimas
                .Include(s => s.FkKategorija)
                .Include(s => s.FkVartotojas)
                .Include(s => s.MokejimoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (skelbima == null)
            {
                return Redirect("~/Home/Nerasta");
            }
            ViewData["FkKategorijaid"] = new SelectList(_context.Kategorijas, "Id", "Pavadinimas", skelbima.FkKategorijaid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas", skelbima.FkVartotojasid);
            ViewData["MokejimoBudas"] = new SelectList(_context.Apmokejimas, "Id", "Name", skelbima.MokejimoBudas);
            return View(skelbima);
        }

        // POST: Skelbimas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Pavadinimas,Aprasymas,Adresas,Uzmokestis,Data,MokejimoBudas,Id,FkVartotojasid,FkKategorijaid")] Skelbima skelbima)
        {
            if (id != skelbima.Id)
            {
                return Redirect("~/Home/Nerasta");
            }

            if (ModelState.IsValid)
            {
                var user = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
                skelbima.FkVartotojasid = user.Id;
                skelbima.Data = DateTime.Now;
                try
                {
                    _context.Update(skelbima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkelbimaExists(skelbima.Id))
                    {
                        return Redirect("~/Home/Nerasta");
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["pavyko"] = "Skelbimas buvo sėkmingai atnaujintas!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkKategorijaid"] = new SelectList(_context.Kategorijas, "Id", "Pavadinimas", skelbima.FkKategorijaid);
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas", skelbima.FkVartotojasid);
            ViewData["MokejimoBudas"] = new SelectList(_context.Apmokejimas, "Id", "Name", skelbima.MokejimoBudas);
            return View(skelbima);
        }

        // GET: Skelbimas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            var skelbima = await _context.Skelbimas
                .Include(s => s.FkKategorija)
                .Include(s => s.FkVartotojas)
                .Include(s => s.MokejimoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skelbima == null)
            {
                return Redirect("~/Home/Nerasta");
            }

            return View(skelbima);
        }

        // POST: Skelbimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skelbima = await _context.Skelbimas
                .Include(s => s.FkKategorija)
                .Include(s => s.FkVartotojas)
                .Include(s => s.MokejimoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            _context.Skelbimas.Remove(skelbima);
            foreach (var isi in _context.Isiminta)
            {
                if (isi.FkSkelbimasid == id)
                {
                    _context.Isiminta.Remove(isi);
                }
            }
            foreach (var kom in _context.Komentaras)
            {
                if (kom.FkSkelbimasid == id)
                {
                    _context.Komentaras.Remove(kom);
                }
            }
            await _context.SaveChangesAsync();
            TempData["pavyko"] = "Skelbimas buvo sėkmingai panaikintas!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Skelbimas/Create
        [Authorize]
        public IActionResult Komentuoti(int id)
        {
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Pavadinimas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas");
            return View();
        }

        // POST: Skelbimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Komentuoti(int id, [Bind("Komentaras,FkVartotojasid,FkSkelbimasid")] Komentara kom)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
                kom.FkVartotojasid = user.Id;
                kom.FkSkelbimasid = id;
                _context.Add(kom);
                await _context.SaveChangesAsync();
                TempData["pavyko"] = "Skelbimas sėkmingai pakomentuotas!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkelbimasid"] = new SelectList(_context.Skelbimas, "Id", "Pavadinimas");
            ViewData["FkVartotojasid"] = new SelectList(_context.Vartotojas, "Id", "Vardas");
            return View(kom);
        }

        private bool SkelbimaExists(int id)
        {
            return _context.Skelbimas.Any(e => e.Id == id);
        }
    }
}
