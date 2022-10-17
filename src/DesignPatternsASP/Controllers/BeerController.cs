using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;
using DesignPatternsASP.Strategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternsASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from p in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   Id = p.BeerId,
                                                   Name = p.Name,
                                                   Style = p.Style,
                                               };
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            GetBrandsData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                GetBrandsData();
                return View("Add", formViewModel);
            }

            var context = formViewModel.BrandId == null ? 
                        new BeerContextStrategy(new IBeerWithBrandStrategy()) :
                        new BeerContextStrategy(new BeerStrategy());

            context.Add(formViewModel, _unitOfWork);

            return RedirectToAction("Index");
        }

        #region HELPERS
        private void GetBrandsData()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }
        #endregion
    }
}
