using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyEx.s2
{
    public class Orders
    {
        public Orders(string sCustomerID) {
            Console.WriteLine("Orders init");
            CustomerID = sCustomerID;
        }
        public string GetCustomerID()
        {
            Console.WriteLine("GetCustomerID");
            return this.CustomerID;
        }
        public string Id { get; set; }
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
