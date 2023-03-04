using Hotel.Models.Services;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.Middleware;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Hotel.Controllers
{

    [Authorize(Roles = "Admin")]
    public class PonudaAdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public PonudaAdminController(IWebHostEnvironment webHostEnvironment) //Dependency injection of IWebHostEnviorment
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: PonudaAdminController
        public ActionResult Index(PonudaService ponudaService)
        {
            List<PonudaBO> ponude = ponudaService.AllPonude();
            return View(ponude);
        }
        public IActionResult Update(int ponudaID, PonudaService ponudaService)
        {
            PonudaBO ponuda = ponudaService.GetByID(ponudaID);
            return View(ponuda);
        }
        //Handles requests to update an apartment listing, uploads images
        [HttpPost]
        public async Task<IActionResult> Update(PonudaBO ponuda, IFormFile? image_file, PonudaService ponudaService, ImageService imageService)
        {
            //Validate model
            if (!ModelState.IsValid)
            {
                return View("Update", ponuda);
            }

            // If Image wasnt uploaded
            if (image_file != null)
            {
                //Check file type is JPG
                if (Path.GetExtension(image_file.FileName) != ".jpg")
                {
                    ViewBag.ImageError = "Format slike mora biti .jpg";
                    return View("Update", ponuda);
                }
                //Upload the image and return its FileName without extention
                ponuda.Slika = await imageService.UploadAsync(image_file, webHostEnvironment);
            }
            try
            {
                ponudaService.UpdatePonuda(ponuda);
                ViewBag.Message = "Uspešno izmenjena ponuda";
            }
            catch
            {
                ViewBag.Error = "Došlo je do greške, molim Vas pokušajte ponovo";
            }

            return View("Update", ponuda);
        }

        // GET: PonudaAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PonudaAdminController/Create
        [HttpPost]
        public async Task<ActionResult> Create(PonudaBO ponuda, IFormFile? image_file, PonudaService ponudaService, ImageService imageService)
        {
            //Validate model
            ModelState.Remove("Slika");
            if (!ModelState.IsValid)
            {
                return View("Create", ponuda);
            }

            // If Image wasnt uploaded
            if (image_file == null || image_file.Length < 1)
            {
                ViewBag.ImageError = "Morate izabrati sliku";
                return View("Create", ponuda);
            }
            //Check file type is JPG
            if (Path.GetExtension(image_file.FileName) != ".jpg")
            {
                ViewBag.ImageError = "Format slike mora biti .jpg";
                return View("Create", ponuda);
            }

            //Upload the image and return its FileName without extention
            ponuda.Slika = await imageService.UploadAsync(image_file, webHostEnvironment);
            try
            {
                ponudaService.CreatePonuda(ponuda);
                ViewBag.Message = "Uspešno dodata ponuda";
            }
            catch
            {
                ViewBag.Error = "Došlo je do greške, molim Vas pokušajte ponovo";
            }

            return View("Create", ponuda);
        }


        // POST: PonudaAdminController/Delete/5
        [HttpPost]
        public ActionResult Delete(int ponudaID, PonudaService ponudaService)
        {
            try
            {
                ponudaService.RemovePonuda(ponudaID);
                TempData["Message"] = "Ponuda sa ID-em " + ponudaID + " uspešno obrisana";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Došlo je do greške pri brisanju ponude";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
