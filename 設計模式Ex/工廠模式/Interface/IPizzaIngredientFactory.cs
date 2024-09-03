using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 工廠模式.Models;

namespace 工廠模式.Interface
{
    public interface IPizzaIngredientFactory
    {
        public Dough createDough();
        public Sauce createSauce();
        public Veggies[] createVeggies();

        public Pepperoni createPepperoni();
        public Cheese createCheese();
    }
}
