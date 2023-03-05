using Hotel.Models;
using Hotel.Models.EFRepositories;
using Hotel.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PonudaController : Controller
    {
        //Handles requests for displaying Index of Ponuda resource
        public IActionResult Index(PonudaService ponudaService, int? numOfBeds, int? floor, Tip? tip)
        {
            ViewBag.numOfBeds = numOfBeds;
            ViewBag.floor = floor;
            ViewBag.tip = tip;
            return View(ponudaService.filterPonude(numOfBeds,floor,tip));
        }

        //Handles requests to show a specific Ponuda resource
        [Authorize]
        [HttpGet]
        public IActionResult Show(int ponudaID, PonudaService ponudaService, PonudaRepository ponudaRepository)
        {
            ViewBag.bookedDates = ponudaService.GetUnavailableDates(ponudaID).Select(date => date.ToString("yyyy-MM-dd")).ToList(); 
            return View(ponudaRepository.GetById(ponudaID));
        }
    }
}
