using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tools;

namespace DesignPatternsASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Beer> _beer;

        public HomeController(ILogger<HomeController> logger, IRepository<Beer> beer)
        {
            _logger = logger;
            _beer = beer;
        }

        public IActionResult Index()
        {
            Log.GetInstance("log.txt").Save("entro a index");

            IEnumerable<Beer> lst = _beer.Get();

            return View("Index", lst);
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