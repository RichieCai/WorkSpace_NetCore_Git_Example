using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmEx6.BinarySearchTree2
{
    public class Employee:IComparable<Employee>
    {
        private string Name { get; set; }
        private int Salary { get; set; }

        private int Hour { get; set; }

        public Employee(string name, int salary, int hour)
        { 
            this.Name=name;
            this.Salary=salary;
            this.Hour=hour;
        }

        public override string ToString()
        {
            return $"{this.Name} 的薪水為: {this.Hour * this.Salary} 元";
        }

        public int CompareTo(Employee other)
        {
            if (this.Hour * this.Salary == other.Salary * other.Hour) { return 0; }
            if (this.Hour * this.Salary > other.Salary * other.Hour) { return 1; }
            return -1;
        }
    }
}
