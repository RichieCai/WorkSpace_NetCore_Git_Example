using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyEx.s2
{
    public class Data
    {
        public Data()
        {
            Console.WriteLine("Data::.ctor->Initialized");
        }

        public void Print()
        {
            Console.WriteLine("Data::Print->println");
        }
    }
}
