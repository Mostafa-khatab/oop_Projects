using BankingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class SearchForBook
    {
        public void SearchBooks(ref List<Book> books , string _name) 
        {
            foreach (Book book in books)
            {
                if(book.Name == _name)
                {
                    Console.WriteLine("The Book Found");
                    Console.WriteLine($"The Book id is {book.Id} and name is {book.Name} and quantity is {book.Quantity}");
                    return;
                }
            }
            Console.WriteLine("The Book Not Found");
        }
        
    }
}
