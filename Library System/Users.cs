using BankingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Users
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        CheckIntger ch1 = new();
        CheckString ch2 = new();
        public void SetId(object id)
        {
            try
            {
                if (ch1.CheckInput(id))
                {

                    this.Id = (int)id;
                }
                else
                {
                    throw new ArgumentException("invalid id please write a valid id");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

        }
        public void SetName(object name)
        {
            try
            {
                if (ch2.CheckInput(name))
                {
                    this.Name = (string)name;
                }
                else
                {
                    throw new ArgumentException("invalid name please write a valid name");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
