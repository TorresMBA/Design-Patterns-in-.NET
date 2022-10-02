using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        private LocalEarnFactory _localEarnFactory;

        public ProductDetailController(LocalEarnFactory localEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
        }

        public IActionResult Index(decimal total)
        {
            // factories
            //LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m); Reemplazado por Inyección de dependencia

            // products
            var localEarn = _localEarnFactory.GetEarnFactory();

            // total
            ViewBag.totalLocal = total + localEarn.Earn(total);

            return View();
        }
    }
}
