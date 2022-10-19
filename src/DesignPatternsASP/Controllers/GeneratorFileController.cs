using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternsASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly GeneratorConcreteBuilder _generator;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generator)
        {
            _unitOfWork = unitOfWork;
            _generator = generator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Createfile(int optionfile)
        {
            try
            {
                var beer = _unitOfWork.Beers.Get();
                List<string> contet = beer.Select(d => d.Name).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";

                var generateDirector = new GeneratorDirector(_generator);

                if (optionfile == 1)
                {
                    generateDirector.CreateSimpleJsonGenerator(contet, path);
                }
                else
                {
                    generateDirector.CreateSimplePipeGenerator(contet,path);
                }

                var generators = _generator.GetGenerator();

                generators.Save();

                return Json("archivo Generado");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
