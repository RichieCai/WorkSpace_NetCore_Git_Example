using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠3.Interface;
using 抽象工廠3.Model;

namespace 抽象工廠3.Factory
{
    public class BirdFactory : IAnimalFactory<Bird>
    {
        public Bird CreateAnimal()
        {
            return new Bird();
        }
    }
}
