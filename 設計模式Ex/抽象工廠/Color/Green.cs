﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Interface;

namespace 抽象工廠.Color
{
    public class Green : IColor
    {
        public void fill()
        {
            Console.WriteLine("Inside Green::fill() method.");
        }
    }
}
