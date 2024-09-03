using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 泛型.Interface;

namespace 泛型.models
{
    internal class Motorcycle : Transportation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }
    }
}
