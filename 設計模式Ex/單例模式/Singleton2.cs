using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 單例模式
{
    public sealed class Singleton2
    {
        private static readonly Lazy<Singleton2> lazy = 
            new Lazy<Singleton2>(()=>new Singleton2());

        public static Singleton2 Instance { get { return lazy.Value; } }

        private Singleton2() { }

    }
}
