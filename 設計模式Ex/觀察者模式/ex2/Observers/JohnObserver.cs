using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 觀察者模式.ex2.Observers
{
    public class JohnObserver : IObserver
    {
        public string Name { get; set; }
        public string Msg { get; set; }

        public JohnObserver(string sName, string sMsg)
        {
            this.Name = sName;
            this.Msg = sMsg;
        }
        public void Notify()
        {
            Console.WriteLine($"john,姓名:{this.Name},訊息:{this.Msg}");
        }
    }
}
