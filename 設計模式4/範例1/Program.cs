// See https://aka.ms/new-console-template for more information
using 範例1.Input;
using 範例1.Model;
using 範例1.Models;
using 範例1.Service;

Console.WriteLine("Hello, World!1");


ZoomService zoomService = new ZoomService();

InputData input = new InputData();
input.name = "小黃";

Dog d=new Dog();
List<Dog> listDog= zoomService.getData(input,d);
foreach (Dog dd in listDog)
{ 
Console.WriteLine($"name:{dd.name},age:{dd.age},run:{dd.run},call:{dd.call}");
}

Bird b=new Bird();
input.name = "藍藍";
List<Bird> listBird = zoomService.getData(input, b);
foreach (Bird bb in listBird)
{
    Console.WriteLine($"name:{bb.Name},age:{bb.Age},run:{bb.Fly}");
}

Console.ReadLine();