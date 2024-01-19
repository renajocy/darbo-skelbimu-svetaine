using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// TODO: Isiminti skelbimai

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly darbasContext _context;

        public HomeController(ILogger<HomeController> logger, darbasContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return Redirect("~/Skelbimas");
        }
        public IActionResult Nerasta()
        {
            return View();
        }


        [HttpGet("prisijungimas")]
        public IActionResult Prisijungimas(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("prisijungimas")]
        public async Task<IActionResult> Validate(string username, string password, string id, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var a = _context.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(username));

            if (a != null)
            {
                bool validate = BCrypt.Net.BCrypt.Verify(password, a.Slaptazodis);
                if (validate == true)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                    claims.Add(new Claim(ClaimTypes.Name, username));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (returnUrl == null)
                        return Redirect("/");
                    return Redirect(returnUrl);
                }
            }

            TempData["Error"] = "Klaida. Vartotojo vardas arba slaptažodis neteisingas.";
            return View("prisijungimas");
        }

        [HttpPost("registracija")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registracija([Bind("Vardas, Slaptazodis, PatvirtintiSlaptazodi, Telefonas, EPastas, Miestas")] Vartotoja user)
        {
            try
            {
                if (_context.Vartotojas.Any(x => x.Vardas == user.Vardas))
                {
                    TempData["Error"] = "Klaida. Toks vartotojo vardas jau naudojamas.";
                    return View("registracija");
                }

                if (_context.Vartotojas.Any(x => x.EPastas == user.EPastas))
                {
                    TempData["Error"] = "Klaida. Toks el. paštas jau naudojamas.";
                    return View("registracija");
                }

                if (ModelState.IsValid)
                {
                    user.Slaptazodis = BCrypt.Net.BCrypt.HashPassword(user.Slaptazodis);
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    TempData["pavyko"] = "Registracija sėkminga! Prašome prisijungti.";
                    return RedirectToAction("prisijungimas");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Nepavyko išsaugoti pakeitimų, jei vis dar kyla problema susisiekite su administratoriumi");
            }
            return View(User);

        }

        [HttpGet("registracija")]
        public ActionResult Registracija()
        {
            Vartotoja user = new Vartotoja();
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Atsijungimas()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
