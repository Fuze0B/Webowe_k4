using Perfumy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Perfumy.Controllers
{
    public class MyPerfumesController : Controller
    {
        private IPerfumesRepo _perfumesRepo;
        // GET: MyPerfumeController
        public ActionResult GetAll()
        {
            _perfumesRepo = new FilePerfumesRepo();
            var perfumes = _perfumesRepo.Perfumes;
            return View(perfumes);
        }

        [HttpGet]
        public IActionResult AddPerfume()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerfume(Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                _perfumesRepo = new FilePerfumesRepo();
                _perfumesRepo.AddPerfume(perfume);
                return RedirectToAction("GetAll");
            }
            return View();
        }

          public IActionResult DeletePerfume(int id)
        {
            var _perfumesRepo = new FilePerfumesRepo();
            _perfumesRepo.RemovePerfume(id);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult EditPerfume(int id)
        {
            var _perfumesRepo = new FilePerfumesRepo();
            var perfumeToEdit = _perfumesRepo.GetPerfume(id);
            if(perfumeToEdit != null)
            {
                return View(perfumeToEdit);
            }   
            return RedirectToAction("GetAll");
        }
        [HttpPost]
        public IActionResult EditPerfume(Perfume perfume)
        {
             if (ModelState.IsValid)
            {
                var _perfumesRepo = new FilePerfumesRepo();
                _perfumesRepo.UpdatePerfume(perfume);
                return RedirectToAction("GetAll");
            }
            return View();
        }

    }
}
