using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠3.Interface;
using 抽象工廠3.Models;

namespace 抽象工廠3.Factory
{
    public class DogFactory : IAnimalFactory<Dog>
    {
        public Dog CreateAnimal()
        {
            return new Dog();
        }
    }
}
