using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test
{
    internal class Employee
    {
        public string Name {  get;  set; }
        public int Age { get;  set; }
        public double Salary { get;  set; }
        public Employee(string name , int age,double salary) 
        {    
            this.Name = name;
            this.Age = age;
            this.Salary = salary;
            
        }

    }
}
