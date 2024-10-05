using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankingSystem
{
    internal class CheckString : Check
    {
        public static Regex regex = new Regex(@"^[a-zA-Z]+$");
        public override bool CheckInput(object name)
        {
            if (name != null && name.GetType() == typeof(string) && regex.IsMatch((string)name)) 
            {
                return true;
            }
            return false;
        }
    }
}
