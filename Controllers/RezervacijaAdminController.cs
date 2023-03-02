using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RezervacijaAdminController : Controller
    {
        // GET: RezervacijaAdminController
        public ActionResult Index(RezervacijaService rezervacijaService)
        {
            List<RezervacijaBO> rezervacije = rezervacijaService.AllRezervacije();
            return View(rezervacije);
        }

        // GET: RezervacijaAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RezervacijaAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RezervacijaAdminController/Create
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

        // GET: RezervacijaAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RezervacijaAdminController/Edit/5
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

        // GET: RezervacijaAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RezervacijaAdminController/Delete/5
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
