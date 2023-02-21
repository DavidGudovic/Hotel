using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PonudaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
