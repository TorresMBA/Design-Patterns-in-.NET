using PatronesDisenio.DependencyInjection;
using PatronesDisenio.FactoryMethod;

namespace PatronesDisenio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Singleton
            //var singleton = Singleton.Singleton.Instance;
            var log = Singleton.Log.Instance;
            log.Save("a");
            log.Save("b");
            #endregion

            #region Factory Method
            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(5);

            ISale sale1 = storeSaleFactory.GetSale();
            sale1.Sell(15);

            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(20);
            #endregion

            #region Dependency Injection
            var beer = new Beer("Cristal", "Cusqueña");
            var drink = new DrinkWithBear(10, 1, beer);
            drink.Build();
            #endregion

            Console.WriteLine();
            foreach (var s in args)
            {
                Console.Write(s);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}