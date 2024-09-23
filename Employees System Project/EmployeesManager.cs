using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class EmployeesManager : Manage
    {
        public bool FindEmployeeByName(string name , List<Employee>employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name == name) 
                {   
                    return true; 
                }
            }
            
            return false;
        }
    }
}
