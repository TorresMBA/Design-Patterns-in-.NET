using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.Strategy
{
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("soy una motocicleta y me muevo con dos llantas");
        }
    }
}
