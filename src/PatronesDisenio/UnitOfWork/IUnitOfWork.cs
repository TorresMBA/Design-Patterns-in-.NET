using DesignPattern.RepositoryPattern;
using PatronesDisenio.Models;
using PatronesDisenio.Repository.Models;

namespace PatronesDisenio.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }

        public IRepository<Brand> Brands { get; }

        public void Save();
    }
}
