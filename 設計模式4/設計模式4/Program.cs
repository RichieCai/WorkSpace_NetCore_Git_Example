// See https://aka.ms/new-console-template for more information
using 設計模式4.Models;
using 設計模式4.Service;

Console.WriteLine("2");


var result = ZomService.Test<dog>("3");

foreach (var element in result)
{
    Console.WriteLine(element.DogName);
    Console.WriteLine(element.Name);
}

Console.ReadLine();