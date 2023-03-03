using Hotel.Models.Services;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.Middleware;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PonudaAdminController : Controller
    {
        // GET: PonudaAdminController
        public ActionResult Index(PonudaService ponudaService)
        {
            List<PonudaBO> ponude = ponudaService.AllPonude();
            return View(ponude);
        }
        public IActionResult Update(int ponudaID,PonudaService ponudaService)
        {
            PonudaBO ponuda = ponudaService.GetByID(ponudaID);
            return View(ponuda);
        }

        [HttpPost]
        public IActionResult Update(PonudaBO ponuda, PonudaService ponudaService)
        {
            // TODO Work
            return RedirectToAction("Update");
        }

        // GET: PonudaAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PonudaAdminController/Create
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


        // POST: PonudaAdminController/Delete/5
        [HttpPost]
        public ActionResult Delete(int ponudaID,PonudaService ponudaService)
        {
            try
            {
                ponudaService.RemovePonuda(ponudaID);
                TempData["Message"] = "Ponuda sa ID-em " + ponudaID + " uspešno obrisana";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri brisanju ponude";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
