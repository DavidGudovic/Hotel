using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.Admin
{
    public class KorisniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
