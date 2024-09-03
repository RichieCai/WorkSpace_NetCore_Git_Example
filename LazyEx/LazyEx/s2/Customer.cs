using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyEx.s2
{
    public class Customer
    {
        private Lazy<Orders> _orders;

        public string CustomerID { get; private set; }
        public Customer(string id) 
        {
            Console.WriteLine("Customer init");
            CustomerID = id;
            _orders=new Lazy<Orders>(() => { 
                return new Orders(this.CustomerID);
            });
        }

        public Orders MyOrders { get { 
            return _orders.Value;
            } }
    }
}
