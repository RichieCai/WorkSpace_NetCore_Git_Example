using LazyEx.s1;
using LazyEx.s2;
using LazyEx.s3;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======Main==Start=====");
        //s2_1();
        s2_2();
       // s3();


        Console.WriteLine("======Main==End=====");
        Console.ReadLine();
    }

    public static void s1()
    {
        var services = new ServiceCollection();

        // 添加服务和实现类型的关联
        services.AddSingleton<IMyService, MyServiceImpl>();
        // 构建服务提供程序
        var serviceProvider = services.BuildServiceProvider();
        // 从服务提供程序中获取服务实例
        var myService = serviceProvider.GetRequiredService<IMyService>();
        Console.WriteLine("我還沒執行lazy");
        // 使用服务实例
        myService.DoSomething();
    }

    public static void s2_1()
    {
        Lazy<Data> lazyd = new Lazy<Data>(() =>
        {
            Console.WriteLine("委派 new date");
            return new Data();
        });

        Console.WriteLine("lazy start");
        lazyd.Value.Print();
        Console.WriteLine("lazy end");
    }
    public static void s2_2()
    {
        var Customer = new Customer("123");
        Console.WriteLine("lazy start");
        string sCustomerID=Customer.MyOrders.GetCustomerID();
        Console.WriteLine("Customer id:"+ sCustomerID);
        Console.WriteLine("lazy end");
    }

    public static void s3()
    {
        var services1 = new ServiceCollection();
        services1.AddScoped<Lazy<B>>();
        services1.AddSingleton<A>();

        var provider =services1.BuildServiceProvider();
        var a=provider.GetRequiredService<A>();
        a.MethodTwo();
        a.MethodThree();
        Console.WriteLine("prepare call methodone..");
        a.MethodOne();
    }
}
