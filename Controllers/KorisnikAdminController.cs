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

        //Handles requests to show user update form
        public ActionResult Update(KorisnikService korisnikService, int korisnikID)
        {
            KorisnikBO korisnik = korisnikService.GetKorisnik(korisnikID);
            return View(korisnik);
        }

        //Handles request to update user information
        [HttpPost]
        public ActionResult Update(KorisnikBO korisnik, KorisnikService korisnikService, string? new_password)
        {
            ModelState.Remove("Password"); // Password doesnt need to be validated for administrators
            if (!ModelState.IsValid)
            {
                return View("Update", korisnik);
            }

            if (!String.IsNullOrEmpty(new_password))
            {
                korisnik.Password = new_password;
            }


            try
            {
                KorisnikBO new_korisnik = korisnikService.UpdateKorisnik(korisnik, String.IsNullOrEmpty(new_password));
                TempData["Message"] = "Korisnik uspešno izmenjen";
                return View("Update", new_korisnik);
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri izmeni korisnika, korisničko ime ili email verovatno postoje";
                return View("Update", korisnik);
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
