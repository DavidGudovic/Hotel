using Hotel.Models;
using Hotel.Models.EFRepositories;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hotel.Controllers
{
    public class KorisnikController : Controller
    {
        //Return a user information index page
        public IActionResult Index(KorisnikRepository korisnikRepository)
        {
            KorisnikBO korisnik = korisnikRepository.GetKorisnikByUsername(User.Identity.Name);
            return View(korisnik);
        }

        //Handles requests to update users data
        [HttpPost]
        public async Task<IActionResult> Update(KorisnikBO korisnik, KorisnikService korisnikService, string? new_password)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return View("Index", korisnik);
            }

            //Verify current password 
            if (!korisnikService.VerifyPassword(korisnik.Password, korisnik.KorisnikID))
            {
                ViewBag.ErrorPassword = "Uneli ste pogrešan password!";
                return View("Index");
            }

            // Change password
            if (!String.IsNullOrEmpty(new_password))
            {
                //new pass validation
                if (new_password.Length < 8)
                {
                    ViewBag.ErrorNewPassword = "Nova šifra mora biti duža od 8 karaktera";
                    return View("Index", korisnik);
                }
                korisnik.Password = new_password;
            }

            // Try updating the user if all validation passes

            try
            {
                KorisnikBO izmenjenKorisnik = korisnikService.UpdateKorisnik(korisnik);
                //Modify the users claims
                List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, izmenjenKorisnik.KorisnickoIme),
                new Claim(ClaimTypes.NameIdentifier, izmenjenKorisnik.KorisnickoIme),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(Role), (int)korisnik.Rola)),
                new Claim("Username", izmenjenKorisnik.KorisnickoIme),
                new Claim("Role", korisnik.Rola.ToString())
                 };
                //Relogin user
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ; ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                //return him to the Info page
                return View("Index", izmenjenKorisnik);
            }
            catch
            {
                ViewBag.Error = "Email ili Korisničko ime su zauzeti!";
                return View("Index");
            }

        }
        // Handles requests to delete the signed in user
        [HttpPost]
        public async Task<IActionResult> Delete(int korisnikID, KorisnikService korisnikService, string password = "")
        { 
            //Verify password
            if(!korisnikService.VerifyPassword(password, korisnikID))
            {
                ViewBag.DeleteError = "Uneli ste pogrešnu šifru!";
                return View("Index");
            }
            //Sign the user out and delete him
            await HttpContext.SignOutAsync();
            korisnikService.DeleteKorisnik(korisnikID);
            return RedirectToAction("Index", "Home");
        }
    }
}
