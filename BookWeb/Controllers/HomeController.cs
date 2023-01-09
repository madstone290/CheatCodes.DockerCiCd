using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<Book> _hiddenBooks = new();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;

            var bookList = configuration.GetSection("HiddenBookList").Get<List<Book>>();
            _hiddenBooks.AddRange(bookList);
        }

        public IActionResult Index()
        {
            ViewBag.HiddenBooks = _hiddenBooks;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}