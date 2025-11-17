using Microsoft.AspNetCore.Mvc;
using arkusz.Models;

namespace arkusz.Controllers
{
    public class HomeController : Controller
    {
        private readonly CityRepo _repo;

        public HomeController(IConfiguration config)
        {
            _repo = new CityRepo(config);
        }

        public IActionResult Index(string filtr)
        {
            List<Miasto> miasta = new();

            if (!string.IsNullOrEmpty(filtr))
            {
                miasta = _repo.GetCitiesByPrefix(filtr);
            }

            ViewBag.Filtr = filtr;
            return View(miasta);
        }
    }
}
