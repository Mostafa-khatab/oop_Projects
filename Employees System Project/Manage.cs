using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Manage
    {
        public void AddEmployee (Employee employee , ref List<Employee> employees)
        {
            employees.Add (employee);
        }
        public void Update(string name, double _newSalary, ref List<Employee> employees)
        {
            
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name == name)
                {
                    employees[i].Salary = _newSalary;
                    break;
                }
            }
            
        }
        public void Delete(int min_age , int max_age , ref List<Employee>employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Age >= min_age && employees[i].Age <= max_age)
                {
                    employees.Remove(employees[i]);
                }
            }
        }
        public void Show(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"The employee name is : {employee.Name} and age : {employee.Age} and the salary is : {employee.Salary}");
            }
        }
    }
}
