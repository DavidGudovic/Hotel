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
        public IActionResult Create(RezervacijaService rezervacijaService, KuponService kuponService, int ponuda_id, DateTime checkin, DateTime checkout, int guests, string? coupon)
        {
            //Hasnt set checkin date - other cases validated in frontend
            if (checkin.Date < DateTime.Today.Date)
            {
                TempData["ErrorDate"] = "Morate uneti datum vaše rezervacije!";
                return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
            }

            //Validates if someone reserved the date range during the users reservation
            if (!rezervacijaService.ValidateReservationDate(checkin, checkout, ponuda_id))
            {
                TempData["ErrorDate"] = "Nažalost ovaj period je rezervisan u toku vaše rezervacije, izaberite drugi period";
                return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
            }

            //validate coupon
            if (!String.IsNullOrEmpty(coupon))
            {
                if (coupon.Length != 8)
                {
                    TempData["ErrorCoupon"] = "Uneli ste invalidan kupon";
                    return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
                }
                else
                {
                    if (!kuponService.DoesCouponCodeExists(coupon))
                    {
                        TempData["ErrorCoupon"] = "Kupon koji ste uneli ne postoji";
                        return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
                    }
                    else if (kuponService.IsCouponUsed(coupon))
                    {
                        TempData["ErrorCoupon"] = "Kupon koji ste uneli je već iskorišćen";
                        return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
                    }
                }
            }
            float price = rezervacijaService.CalculateSubTotalPrice(ponuda_id, guests, checkin, checkout);
            try
            {
                string newCoupon = rezervacijaService.CreateReservation(ponuda_id, @User.Identity.Name, checkin, checkout, guests, price, coupon);

                if (String.IsNullOrEmpty(newCoupon))
                {
                    TempData["ThankYou"] = "Vidimo se uskoro u našem hotelu, vaša rezervacija je uspešna";
                }
                else
                {
                    TempData["ThankYou"] = "<p>Vidimo se uskoro u našem hotelu, vaša rezervacija je uspešna</p> <p>Iskoristite kupon <strong>" + newCoupon + "</strong> na vašoj sledećoj rezervaciji za 10% popusta!</p>";
                }
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri rezervaciji, molimo Vas pokušajte ponovo  ";
            }

            return RedirectToAction("Show", "Ponuda", new { ponudaID = ponuda_id });
        }
    }
}
