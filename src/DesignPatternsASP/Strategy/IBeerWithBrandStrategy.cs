using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategy
{
    public class IBeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {
            var beer = new Beer() { Name = formViewModel.Name, Style = formViewModel.Style };

            var brand = new Brand() { Name = formViewModel.OtherBrand };
            brand.Id = Guid.NewGuid();

            beer.BrandId = brand.Id;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);

            unitOfWork.Save();
        }
    }
}
