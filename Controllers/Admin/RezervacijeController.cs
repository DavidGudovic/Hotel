using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.Admin
{
    public class RezervacijeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
