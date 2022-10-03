using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.DependencyInjection
{
    public class DrinkWithBear
    {
        private BeerDI _beer;

        private decimal _water;

        private decimal _sugar;

        public DrinkWithBear(decimal water, decimal sugar, BeerDI beer)
        {
            _beer = beer;
            _water = water;
            _sugar = sugar;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water}, azúcar {_sugar} y Cerveza {_beer.Name}");
        }
    }
}
