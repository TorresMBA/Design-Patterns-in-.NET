using DesignPatternsASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tools;

namespace DesignPatternsASP.Controllers
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
            Log.GetInstance("log.txt").Save("entro a index");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance("log.txt").Save("entro a privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}