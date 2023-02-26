using Hotel.Models;
using Hotel.Models.EFRepositories;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class KorisnikController : Controller
    {
        //Return a user information index page
        [Authorize(Roles = "Admin")]
        public IActionResult Index(KorisnikRepository korisnikRepository)
        {
            KorisnikBO korisnik = korisnikRepository.GetKorisnikByUsername(User.Identity.Name);
            return View(korisnik);
        }

        [HttpPost]
        public IActionResult Update(KorisnikBO korisnik, KorisnikService korisnikService)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Korisnik");
            }

            korisnikService.UpdateKorisnik(korisnik, korisnik.KorisnikID);
            return Ok();
        }
    }
}
