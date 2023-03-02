using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class KorisnikAdminController : Controller
    {

        public ActionResult Index(KorisnikService korisnikService)
        {
            List<KorisnikBO> korisnici = korisnikService.AllKorisnici();
            return View(korisnici);
        }

        // GET: KorisnikAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: KorisnikAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KorisnikAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: KorisnikAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KorisnikAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
