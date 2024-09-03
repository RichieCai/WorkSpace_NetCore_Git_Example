using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 觀察者模式.ex1
{
    /// <summary>
    /// 觀察者 訂閱者
    /// </summary>
    public class Subscriber: IObserver
    {
        public string Name { get; set; }

        public string Position { get; set; }
        public Subscriber(string name,string position)
        {
            this.Name = name;
            this.Position = position;
        }

        public void ReceiveAndPrint(GoogleGame g)
        {
            Console.WriteLine($"我是訂閱人:{Name},職位:{Position},遊戲名稱:{g.GName},遊戲說明:{g.Info}");
        }


    }
}
