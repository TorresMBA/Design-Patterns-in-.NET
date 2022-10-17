using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategy
{
    public interface IBeerStrategy
    {
        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork);
    }
}
