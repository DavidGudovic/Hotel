using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RezervacijaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
