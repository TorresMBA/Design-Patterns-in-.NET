using DesignPattern.RepositoryPattern;
using PatronesDisenio.DependencyInjection;
using PatronesDisenio.FactoryMethod;
using PatronesDisenio.Models;
using PatronesDisenio.Repository;
using PatronesDisenio.Repository.Models;
using PatronesDisenio.Strategy;
using PatronesDisenio.UnitOfWork;
using System.Collections.Generic;

namespace PatronesDisenio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Singleton
            //var singleton = Singleton.Singleton.Instance;
            //var log = Singleton.Log.Instance;
            //log.Save("a");
            //log.Save("b");
            #endregion

            #region Factory Method
            //SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            //SaleFactory internetSaleFactory = new InternetSaleFactory(5);

            //ISale sale1 = storeSaleFactory.GetSale();
            //sale1.Sell(15);

            //ISale sale2 = internetSaleFactory.GetSale();
            //sale2.Sell(20);
            #endregion

            #region Dependency Injection
            //var beer = new BeerDI("Cristal", "Cusqueña");
            //var drink = new DrinkWithBear(10, 1, beer);
            //drink.Build();
            #endregion

            #region Uso Entity Framework
            using (var context = new DesignPatternsContext())
            {
                var list = context.Beers.ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
            #endregion

            #region Repository
            //using (var context = new DesignPatternsContext())
            //{
            //    //Usando Repoistory por Tipos de clase en duro
            //    var beerRepository = new BeerRepository(context);
            //    var berr = new Beer();
            //    berr.Name = "Corona";
            //    berr.Style = "Pilsner";

            //    beerRepository.Add(berr);
            //    beerRepository.Save();

            //    foreach (var item in beerRepository.Get())
            //    {
            //        Console.WriteLine(item.Name);
            //    }

            //    //Usando repository Generic
            //    var repository = new Repository<Beer>(context);
            //    var beer = new Beer() { Name = "Fuller", Style = "Strong Ale" };

            //    repository.Add(beer);
            //    repository.Save();

            //    foreach (var item in repository.Get())
            //    {
            //        Console.WriteLine($"{item.BeerId} - {item.Name}");
            //    }
            //}
            #endregion

            #region UnitOfWork
            using (var context = new DesignPatternsContext())
            {
                var unitOfWork = new UnitOfWorkC(context);

                var beers = unitOfWork.Beers;
                var beer = new Beer() { Name = "Fuller", Style = "Porter" };

                beers.Add(beer);

                //var brands = unitOfWork.Brands;
                //var brand = new Brand() { };

                //brands.Add(brand);

                unitOfWork.Save();
            }
            #endregion

            #region Strategy
            var context = new Context(new CarStrategy());
            context.Run();
            context.Strategy = new MotoStrategy();
            context.Run();

            #endregion
        }
    }
}