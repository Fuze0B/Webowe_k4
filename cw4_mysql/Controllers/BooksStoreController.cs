using cw4_mysql.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Iana;

namespace cw4_mysql.Controllers
{
    public class BooksStoreController : Controller
    {
        private BookRepo _db;
        public BooksStoreController(IConfiguration config)
        {
            _db = new BookRepo(config);
        }

        // GET: BooksStoreController
        public ActionResult Index()
        {
            var books = _db.GetBooks();
            return View(books);
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.AddBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
            //pobranie z bazy
            return View();
        }
        public IActionResult Edit(Book book)
        {
            //zapis do bazy
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
