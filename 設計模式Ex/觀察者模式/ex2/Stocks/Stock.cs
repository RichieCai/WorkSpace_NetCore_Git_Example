using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 觀察者模式.ex2.Observers;

namespace 觀察者模式.ex2.Stocks
{
    public abstract class Stock
    {
        public List<IObserver> _listobserver = new List<IObserver>();
        public Stock() { 
        
        }

        public void Add(IObserver o) {
            if (!this._listobserver.Contains(o))
            { 
                this._listobserver.Add(o);
            }
        }
        public void Remove(IObserver o)
        {
            if (this._listobserver.Contains(o))
            {
                this._listobserver.Remove(o);
            }

        }

        public void Update() {
            foreach (IObserver o in this._listobserver)
            {
                o.Notify();
            }
        }
    }
}
