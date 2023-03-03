using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Admin")]
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


        // POST: RezervacijaAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int rezervacijaID, RezervacijaService rezervacijaService)
        {
            try
            {
                rezervacijaService.DeleteReservation(rezervacijaID);
                TempData["Message"] = "Rezervacija sa ID-em " + rezervacijaID + " uspešno obrisana";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri brisanju rezervacije";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
