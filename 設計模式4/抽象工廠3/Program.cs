// See https://aka.ms/new-console-template for more information
using 抽象工廠3.Input;
using 抽象工廠3.Model;
using 抽象工廠3.Models;
using 抽象工廠3.Service;

ZoomServiceManager zoomService = new ZoomServiceManager();

InputData input = new InputData();
input.DataType = "Dog";

List<Dog> listDog = zoomService.getData<Dog>(input);
foreach (Dog dd in listDog)
{
    Console.WriteLine($"name:{dd.name},age:{dd.age},run:{dd.run},call:{dd.call}");
}


input.DataType = "Bird";
List<Bird> listBird = zoomService.getData<Bird>(input);
foreach (Bird bb in listBird)
{
    Console.WriteLine($"name:{bb.Name},age:{bb.Age},run:{bb.Fly}");
}

Console.ReadLine();