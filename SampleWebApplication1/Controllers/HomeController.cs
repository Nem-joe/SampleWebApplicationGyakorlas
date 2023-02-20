using Microsoft.AspNetCore.Mvc;
using SampleWebApplication1.Models;
using System.Diagnostics;

namespace SampleWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //... szerver oldali logikak
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Address()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}