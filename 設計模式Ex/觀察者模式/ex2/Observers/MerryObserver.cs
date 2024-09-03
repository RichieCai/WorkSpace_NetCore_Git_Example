using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 觀察者模式.ex2.Observers
{
    public  class MerryObserver : IObserver
    {
        public string Name { get; set; }
        public string Msg { get; set; }

        public void Notify()
        {

        }
    }
}
