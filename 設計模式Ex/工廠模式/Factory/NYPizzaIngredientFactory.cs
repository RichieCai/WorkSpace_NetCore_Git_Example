using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 工廠模式.Interface;
using 工廠模式.Models;

namespace 工廠模式.Factory
{
    public class NYPizzaIngredientFactory: IPizzaIngredientFactory
    {
        public Dough createDough() {
            return new ThinCrustDough();
        }
        public Sauce createSauce() {
            return new MarinaraSauce();
        }
        public Veggies[] createVeggies() {
            return new ReggianoChess();
        }

        public Pepperoni createPepperoni()
        {
            return new ThinCrustDough();
        }
        public Cheese createCheese() {
            return new ThinCrustDough();
        }
    }
}
