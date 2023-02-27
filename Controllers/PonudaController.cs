using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PonudaController : Controller
    {
        public IActionResult Index(PonudaService ponudaService, int? numOfRooms, int? floor, Tip? tip)
        {
            return View(ponudaService.filterPonude(numOfRooms,floor,tip));
        }
    }
}
