using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.Builder
{
    public class PreparedDrink
    {
        public int Water { get; set; }

        public int Milk { get; set; }

        public decimal Alcohol { get; set; }

        public string Result { get; set; }

        public List<string> Ingredients { get; set; }

        //public PreparedDrink(int water, int milk, decimal alcohol, string result, List<string> ingredients)
        //{
        //    Water = water;
        //    Milk = milk;
        //    Alcohol = alcohol;
        //    Result = result;
        //    Ingredients = ingredients;
        //}
    }
}
