using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEx
{
    public class 多線程資源競爭示範
    {
        public 多線程資源競爭示範()
        {
        }

        public void 資源競爭示範()
        {
            int counter = 0;

            void IncrementCounter()
            {
                for (int i = 0; i < 100000; i++)
                {
                    counter++; // 這一行可能會發生競爭條件
                }
            }

            Thread t1 = new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(counter); // 預期的結果應該是 200000，但實際上可能不是
        }

        public void 使用Concurrent解決資源競爭()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            void AddToBag()
            {
                for (int i = 0; i < 100000; i++)
                {
                    bag.Add(i);
                }
            }

            Thread t1 = new Thread(AddToBag);
            Thread t2 = new Thread(AddToBag);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(bag.Count); // 正確的結果應該是 200000
        }
    }
}
