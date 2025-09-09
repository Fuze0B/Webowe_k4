using Microsoft.AspNetCore.Mvc;

namespace zad1.Controllers
{
    public class NewController : Controller
    {
        // GET: NewController
        public ActionResult Index()
        {
            string new_string = "Nowe info";
            ViewBag.new_string = new_string;
            return View("Index");
        }

    }
}
