using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工廠2.Interface
{
    public interface IAnimalFactory<T>
    {
        T CreateAnimal();
    }
}
