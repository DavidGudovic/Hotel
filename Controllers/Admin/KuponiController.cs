using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.Admin
{
    public class KuponiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
