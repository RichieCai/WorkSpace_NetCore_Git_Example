using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 觀察者模式.ex1
{
    public abstract class GoogleGame
    {
        private List<IObserver> observers = new List<IObserver>();

        public string GName { get; set; }
        public string Info { get; set; }

        public GoogleGame(string gName, string info)
        {
            this.GName = gName;
            this.Info = info;
        }

        public  void Add(IObserver ob)
        {
            if (!observers.Contains(ob))
                observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            if (observers.Contains(ob))
                observers.Remove(ob);
        }

        public void update()
        {
            foreach (var ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }

    }
}
