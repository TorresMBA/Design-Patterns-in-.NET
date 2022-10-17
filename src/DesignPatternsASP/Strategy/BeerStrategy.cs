using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategy
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {
            var beer = new Beer() { Name = formViewModel.Name, Style = formViewModel.Style };

            beer.BrandId = (Guid)formViewModel.BrandId;

            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
