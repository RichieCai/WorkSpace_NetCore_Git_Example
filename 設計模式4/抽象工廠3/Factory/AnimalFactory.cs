using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠3.Input;
using 抽象工廠3.Interface;

namespace 抽象工廠3.Factory
{
    public abstract class AnimalFactory<T> where T : class
    {
        public abstract List<T> GetData(InputData input);
        public abstract IAnimalFactory<T> GetFactory();
        public abstract T CreateAnimalWithCommonProperties(IAnimalFactory<T> factory, object source);
    }
}
