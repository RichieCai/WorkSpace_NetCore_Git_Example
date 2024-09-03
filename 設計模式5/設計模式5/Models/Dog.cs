using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 設計模式5.Interfaces;

namespace 設計模式5.Models
{
    public class Dog : IZoom
    {
        public string name { get; set; }
        public int age { get; set; }
        public int run { get; set; }
        public string call { get; set; }
    }
}
