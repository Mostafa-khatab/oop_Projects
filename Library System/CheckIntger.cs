using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class CheckIntger : Check
    {
        public override bool CheckInput(object x)
        {
            if (x != null && x.GetType() == typeof(int) && (int)x>=1)
            {
                return true;
            }
            return false;
        }
    }

}
