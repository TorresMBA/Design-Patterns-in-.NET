using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.Strategy
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("soy un carro y me muevo con 4 ruedas");
        }
    }
}
