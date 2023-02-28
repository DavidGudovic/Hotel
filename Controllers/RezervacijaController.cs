using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RezervacijaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RezervacijaService rezervacijaService, int ponuda_id, DateTime checkin, DateTime checkout, int guests, string? coupon)
        {
            //TODO validation
            rezervacijaService.CreateReservation(ponuda_id, @User.Identity.Name, checkin, checkout, guests, coupon);
            return RedirectToAction("Show/?" + ponuda_id, "Ponuda");
        }
    }
}
