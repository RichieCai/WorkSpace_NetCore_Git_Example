using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEx
{
    /// <summary>
    /// 測試func 結合Linq執行
    /// </summary>
    public class FuncTaskTest
    {
        public FuncTaskTest()
        { 
        }

        public async Task Init()
        {
            //非同步 多function 測試
            ////Testfunction1
            Console.WriteLine("Testfunction1 start");
            Func<Task>[] asyncActions = {
            async () => await Task.Delay(1000),
            async () => await Task.Delay(2000),
            async () => await Task.Delay(3000)
        };

            await Task.WhenAll(asyncActions.Select(a => a()));
            Console.WriteLine("Testfunction1 end");


            ////Testfunction2
            Console.WriteLine("Testfunction2 start");
            Func<Task>[] asyncActions2 = {
            () =>t1(), () =>t2(),() => t3()
        };
            await Task.WhenAll(asyncActions2.Select(a => a()));
            Console.WriteLine("Testfunction2 end");


            ////Testfunction3
            Console.WriteLine("Testfunction3 start");
            Func<Task> asyncActions3 = () => t2();
            await Task.Run(asyncActions3);
            Console.WriteLine("Testfunction3 end");


            ////Testfunction4
            Console.WriteLine("Testfunction4 start");
            Func<Task>[] asyncActions4 = {
            async () => {
                Console.WriteLine("Testfunction4 Starting async action 1");
                await Task.Delay(1000);
                Console.WriteLine("Testfunction4 Completed async action 1");
            },
            async () => {
                Console.WriteLine("Testfunction4 Starting async action 2");
                await Task.Delay(2000);
                Console.WriteLine("Testfunction4 Completed async action 2");
            },
            async () => {
                Console.WriteLine("Testfunction4 Starting async action 3");
                await Task.Delay(3000);
                Console.WriteLine("Testfunction4 Completed async action 3");
            }
        };

            //foreach (var action in asyncActions4)
            //{
            //    await action();
            //}
            var tasks = asyncActions4.Select(action => action());
            await Task.WhenAll(tasks);

            Console.WriteLine("Testfunction4 end");




            async Task t1()
            {
                Console.WriteLine(" action t1 before");
                await Task.Delay(9000);
                Console.WriteLine(" action t1 after");
            }
            async Task t2()
            {
                Console.WriteLine(" action t2 before");
                await Task.Delay(3000);
                Console.WriteLine(" action t2 after");
            }
            async Task t3()
            {
                Console.WriteLine(" action t3 before");
                await Task.Delay(1000);
                Console.WriteLine(" action t3 after");
            }
        }
    }
}
