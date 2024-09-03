using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式
{
    public class Decorator: Car
    {
        protected  Car _car1 ;
        public Decorator(Car car1)
        {
            this._car1 = car1;
        }
        public override void Renovation()
        {
            if (this._car1 != null)
            {
                this._car1.Renovation();
            }
        }
    }
}
