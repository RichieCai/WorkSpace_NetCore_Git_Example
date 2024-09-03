using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 觀察者模式.ex1
{
    public interface IObserver
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public void ReceiveAndPrint(GoogleGame g);
    }
}
