using System;
namespace test
{
    
    class Program
    {
        
        static void Main()
        {
            List<Employee> employees = new();
            EmployeesManager employeesManager = new EmployeesManager();
            CheckEmployeeInformations check = new CheckEmployeeInformations();
            while (true)
            {

                Console.WriteLine("1 - Adding new employees.");
                Console.WriteLine("2 - listing existing employees.");
                Console.WriteLine("3 - Deleting employees based on age range.");
                Console.WriteLine("4 - Updating employee salaries by name.");
                Console.WriteLine("5 - Find an employee by their name.");
                Console.WriteLine("press another key to exit.");
                int op;
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    string name;
                    int age;
                    double salary;
                    Console.WriteLine("Write the Name");
                    name = Console.ReadLine().Trim();
                    if (!check.valid(name)) continue;
                    Console.WriteLine("Write the age");
                    age = int.Parse(Console.ReadLine());
                    if (!check.valid(age)) continue;
                    Console.WriteLine("Write the salary");
                    salary = double.Parse(Console.ReadLine());
                    if (!check.valid(salary))continue;
                    Employee e = new(name, age, salary);
                    employeesManager.AddEmployee(e, ref employees);
                    Console.WriteLine("The Employee Added sucessfuly");
                }
                else if (op == 2)
                {
                    employeesManager.Show(employees);
                }
                else if (op == 3)
                {
                    int min_age, max_age;
                    Console.WriteLine("Enter the min age");
                    min_age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the max age");
                    max_age = int.Parse(Console.ReadLine());
                    employeesManager.Delete(min_age, max_age, ref employees);
                    Console.WriteLine("The Employee deleted sucessfuly");
                }
                else if(op == 4)
                {
                    Console.WriteLine("Enter the name");
                    string name;
                    name = Console.ReadLine();
                    if (!check.valid(name)) continue;
                    if (!employeesManager.FindEmployeeByName(name, employees))
                    {
                        Console.WriteLine("The name not found in database");
                        continue;
                    }
                    Console.WriteLine("Enter the salary");
                    double _newSalary;
                    _newSalary = double.Parse(Console.ReadLine());
                    if (!check.valid(_newSalary))continue;
                    employeesManager.Update(name, _newSalary, ref employees);
                    Console.WriteLine("The Employee updated sucessfuly");
                    
                }
                else if (op == 5)
                {
                    Console.WriteLine("Enter the name");
                    string name;
                    name = Console.ReadLine();
                    if (employeesManager.FindEmployeeByName(name, employees))
                    {
                        Console.WriteLine("Employee found");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found");
                    }
                }
                else
                {
                    break;
                }
            }
        }

        
    }
    
}
