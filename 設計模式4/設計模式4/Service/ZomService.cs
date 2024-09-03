using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 設計模式4.Interface;

namespace 設計模式4.Service
{
    internal class ZomService
    {
        public ZomService()
        { 
        }
        public static IEnumerable<T> Test<T>(string s) where T : ITest, new()
        {
            T item = new T();
            item.get();

            var newresult = from x in new List<T>() { item, item }
                            //where x.Name == "dog"
                            select item;
            return newresult;

        }
    }
}
