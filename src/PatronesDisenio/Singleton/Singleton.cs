using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.Singleton
{
    public class Singleton
    {
        private readonly static Singleton _singleton = new Singleton();

        public static Singleton Instance 
        { 
            get
            {
                return _singleton;
            }
        }

        private Singleton() { }
    }
}
