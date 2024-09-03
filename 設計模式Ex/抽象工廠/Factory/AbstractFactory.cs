using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Interface;

namespace 抽象工廠.Factory
{
    public abstract class AbstractFactory
    {
        public abstract IColor getColor(String color);
        public abstract IShape getShape(String shape);
    }
}
