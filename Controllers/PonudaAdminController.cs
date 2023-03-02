using Hotel.Models.Services;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PonudaAdminController : Controller
    {
        // GET: PonudaAdminController
        public ActionResult Index(PonudaService ponudaService)
        {
            List<PonudaBO> ponude = ponudaService.AllPonude();
            return View(ponude);
        }

        // GET: PonudaAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PonudaAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PonudaAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PonudaAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PonudaAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PonudaAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PonudaAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
