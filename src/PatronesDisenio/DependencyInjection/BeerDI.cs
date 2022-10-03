using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.DependencyInjection
{
    public class BeerDI
    {
        private string _name;

        private string _brand;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public BeerDI(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }
    }

}
