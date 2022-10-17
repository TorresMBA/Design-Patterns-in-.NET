using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategy
{
    public class BeerContextStrategy
    {
        private IBeerStrategy _strategy;

        public IBeerStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        public BeerContextStrategy(IBeerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {
            _strategy.Add(formViewModel, unitOfWork);
        }
    }
}
