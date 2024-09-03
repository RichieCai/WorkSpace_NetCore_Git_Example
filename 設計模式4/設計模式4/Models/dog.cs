using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 設計模式4.Interface;

namespace 設計模式4.Models
{
    public class dog : ITest
    {
        public string Name { get; set; } = "dog";
        public string DogName = "Mydog";
        public void get()
        {
            Console.WriteLine("I'm a Dog");
        }
    }
}
