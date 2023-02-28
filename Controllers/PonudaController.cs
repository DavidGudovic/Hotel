using Hotel.Models;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PonudaController : Controller
    {
        public IActionResult Index(PonudaService ponudaService, int? numOfRooms, int? floor, Tip? tip)
        {
            ViewBag.numOfRooms = numOfRooms;
            ViewBag.floor = floor;
            ViewBag.tip = tip;
            return View(ponudaService.filterPonude(numOfRooms,floor,tip));
        }

        [Authorize]
        public IActionResult Show(int ponudaID)
        {
            return View();
        }
    }
}
