using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test
{
    internal class CheckEmployeeInformations
    {
        public static Regex regex = new Regex(@"^[a-zA-Z]+$");
        public bool valid(string _name)
        {

            try
            {
                if (!regex.IsMatch(_name))
                {
                    throw new ArgumentException("invalid Name please write a valid name");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
           
        }
        public bool valid(int age)
        {
            try
            {
                if (age <= 0)
                {
                    throw new ArgumentException("invalid Input please write a valid number");
                }
                else if (age > 80 || age < 20)
                {
                    throw new ArgumentException("sorry you dont satisfy the requairment");
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true ;

        }
        public bool valid(double _salary)
        {
            try
            {
                if (_salary < 1000)
                {
                    throw new ArgumentException("invalid Input please write a valid number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false ;
            }
            return true;

        }
    }
}
