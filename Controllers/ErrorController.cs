using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Denied()
        {
            return View();
        }
    }
}
