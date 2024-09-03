// See https://aka.ms/new-console-template for more information
using 抽象類別基本用法;
using 工廠模式2.Factory;
using 工廠模式2.Interface;
using 抽象工廠;
using 抽象工廠.Factory;
using 裝飾者模式;
using 裝飾者模式.CarType;
using 裝飾者模式.Fun;
using 觀察者模式.ex1;
using 觀察者模式.ex2.Observers;
using IObserver = 觀察者模式.ex2.Observers.IObserver;
using 觀察者模式.ex2.Stocks;
using 單例模式;
using System.Threading.Tasks;




//工廠模式();

//Console.WriteLine("==============================抽象工廠模式 start==========================");
//抽象工廠模式();
//Console.WriteLine("==============================抽象工廠模式 end================================");

//Console.WriteLine("==============================裝飾者模式 start================================");
//裝飾者模式();
//Console.WriteLine("==============================裝飾者模式 end================================");

//Console.WriteLine("==============================觀察者模式 start================================");
//觀察者模式();
//Console.WriteLine("==============================觀察者模式 end================================");

//Console.WriteLine("==============================觀察者模式2 start================================");
//觀察者模式2();
//Console.WriteLine("==============================觀察者模式2 end================================");


Console.WriteLine("==============================單例模式 start================================");
//單例模式();
單例模式2();
Console.WriteLine("==============================單例模式 end================================");



Console.ReadLine();

static void 工廠模式()
{
    工廠模式2.Factory.ShapeFactory shapeFactory = new 工廠模式2.Factory.ShapeFactory();
    //圓形
    IShape circle = shapeFactory.getShape("CIRCLE");
    circle.draw();

    IShape Rectangle = shapeFactory.getShape("RECTANGLE");
    Rectangle.draw();

    IShape Square = shapeFactory.getShape("SQUARE");
    Square.draw();
}

static void 抽象工廠模式()
{
    AbstractFactory shapeFactory = FactoryProducer.getFactory("SHAPE");
    抽象工廠.Interface.IShape shapeCIRCLE = shapeFactory.getShape("CIRCLE");
    shapeCIRCLE.draw();

    //圓形
    抽象工廠.Interface.IShape shapeRECTANGLE = shapeFactory.getShape("RECTANGLE");
    shapeRECTANGLE.draw();

    AbstractFactory colorFactory = FactoryProducer.getFactory("COLOR");
    抽象工廠.Interface.IColor color = colorFactory.getColor("RED");
    color.fill();

}


static void 基本抽象類別用法()
{
    Teacher pteacher = new Teacher("dora", 30);

    pteacher.action();
    pteacher.eat();
    pteacher.Jump();
    pteacher.Skill();
    pteacher.上課();

    Console.WriteLine("doctor");
    doctor pdoctor = new doctor("danny", 30);
    pdoctor.action();
    pdoctor.eat();
    pdoctor.Jump();
    pdoctor.Skill();
    //pdoctor.開刀();
    Console.WriteLine("");
}

////適合用來處理有多組零件裝飾累加處理
static void 裝飾者模式()
{
    Console.WriteLine("*Ferrari*");

    //同一台車裝了三個東西
    Console.WriteLine("********************************");
    Console.WriteLine("*Lamborghini*");
    Car LamborghiniCarRichie = new LamborghiniCar();
    LamborghiniCarRichie.Renovation();
    Console.WriteLine("~~~~~~~~~~~~~~");
    Decorator dLamborghiniCarRichieAutopilot = new Autopilot(LamborghiniCarRichie);
    Decorator dLamborghiniCarRichieFireEngine = new FireEngine(dLamborghiniCarRichieAutopilot);
    Decorator dLamborghiniCarRichieSatellitePositioning = new SatellitePositioning(dLamborghiniCarRichieFireEngine);
    dLamborghiniCarRichieSatellitePositioning.Renovation();

}


///
static void 觀察者模式() {

    GoogleGame g = new DoTa("super dota","10 vs 10");
    觀察者模式.ex1.IObserver subJanny = new Subscriber("janny","設計師");
    觀察者模式.ex1.IObserver subKen = new Subscriber("ken", "醫生");
    g.Add(subJanny);
    g.Add(subKen);
    g.Add(new Subscriber("Daiken", "寵物飼養員"));

    g.update();
}

static void 觀察者模式2()
{
    Stock stock= new FacebookStock();
    IObserver daken = new DakenObserver("戴肯","小遊戲");
    IObserver john = new JohnObserver("小強", "漫步旅行");
    stock.Add(daken);
    stock.Add(john);

    stock.Update();
}

static void 單例模式()
{
    List<Task> tasks = new List<Task>();

    for (int i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run (() =>
        {
            Singleton instance = Singleton.Instance;
            Console.WriteLine($"Instance hash code: {instance.GetHashCode()}");
        }));
    }
    Task.WaitAll(tasks.ToArray());

}
static void 單例模式2()
{
    List<Task> tasks = new List<Task>();

    for (int i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run(() =>
        {
            Singleton2 instance = Singleton2.Instance;
            Console.WriteLine($"Instance hash code: {instance.GetHashCode()}");
        }));
    }
    Task.WaitAll(tasks.ToArray());

}