using Hotel.Models;
using Hotel.Models.EFRepositories;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        #region Login
        //Display login page
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //Attempt login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password,string returnUrl, KorisnikRepository korisnikRepository)
        {
            KorisnikBO korisnik = korisnikRepository.GetKorisnikByUsername(username);

            //Wrong username
            if (korisnik == null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewBag.Error = "Uneli ste pogrešno korisničko ime!";
                return View();
              
            }
            //Wrong password
            if(!BCrypt.Net.BCrypt.Verify(password, korisnik.Password))
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewBag.Error = "Uneli ste pogrešnu šifru!";
                return View();
            }

            //Set User Claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(Role), (int)korisnik.Rola)),
                new Claim("Username", username),
                new Claim("Role", korisnik.Rola.ToString())
            };

            //Set the cookie, login
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
;           ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            if (String.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home"); else return Redirect(returnUrl);
        }
        #endregion

        #region Register
        //Display Register page
        public IActionResult Register()
        {
            return View();
        }

        //Register a user
        [HttpPost]
        public IActionResult Register(KorisnikBO korisnik, KorisnikService korisnikService)
        {      
            //validate input
            if(!ModelState.IsValid)
            {
                return View(korisnik);
            }
            //Add entity to database
            try
            {
                korisnikService.Register(korisnik);
                return RedirectToAction("Login", "Account");
            } catch(Exception ex) // Unique Index violation
            {
                ViewBag.Error = "Korisnik već postoji!";
                return View();
            }
            
           
        }
        #endregion

        //Destroy Auth cookie
        #region Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
