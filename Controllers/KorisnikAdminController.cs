using Hotel.Middleware;
using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KorisnikAdminController : Controller
    {
        //Handles request for displaying a list(index) of all site users
        public ActionResult Index(KorisnikService korisnikService)
        {
            List<KorisnikBO> korisnici = korisnikService.AllKorisnici();
            return View(korisnici);
        }


        // GET: KorisnikAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KorisnikAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: KorisnikAdminController/Delete/5
        [HttpPost]
        public ActionResult Delete(int korisnikID, KorisnikService korisnikService)
        {
            try
            {
                //Remove the user
                korisnikService.RemoveUser(korisnikID);
                TempData["Message"] = "Korisnik sa ID-em " + korisnikID + " uspešno obrisan";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri brisanju korisnika";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
