using BankingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class BorrowSystem : Book
    {
        public int IdUser { get; set; }

        public void CanIBorrowBook(ref List<Book> books, int id, ref List<BorrowSystem> borrow, int idUser, int quantity)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {

                    Console.WriteLine("The Book Found");

                    if (quantity <= book.Quantity)
                    {
                        BorrowSystem bo = new();
                        bo.IdUser = idUser;
                        bo.SetId(book.Id);
                        bo.SetQuantity(quantity);
                        bo.SetName(book.Name);
                        borrow.Add(bo);
                        Console.WriteLine("The Book Borrowed Sucessful");
                        if (book.Quantity == 1)
                        {
                            books.Remove(book);
                            return;
                        }
                        int rem = (int)book.Quantity - quantity;
                        book.SetQuantity(rem);
                        return;
                    }
                    Console.WriteLine("The Quantity You Need Is Not Available");
                    return;

                }
            }

            Console.WriteLine("The Book Not Found");
        }
        public void ReturnBorrowedBooks(ref List<Book> books, int id, ref List<BorrowSystem> borrow, int idUser, int quantity)
        {
            BorrowSystem? borrowedEntry = borrow.FirstOrDefault(bo => bo.Id == id && bo.IdUser == idUser);

            if (borrowedEntry == null)
            {
                Console.WriteLine("No matching borrowed book entry found for this user and book.");
                return;
            }

            if (borrowedEntry.Quantity > quantity)
            {
                Console.WriteLine("The quantity you are trying to return is less than you borrowed. Please return the full quantity.");
                return;
            }
            else if (borrowedEntry.Quantity < quantity)
            {
                Console.WriteLine($"You are returning more books than borrowed. Only {borrowedEntry.Quantity} will be accepted.");
                quantity = borrowedEntry.Quantity;  
            }

            Console.WriteLine($"The book with Id {borrowedEntry.Id} and Name {borrowedEntry.Name} (Quantity: {borrowedEntry.Quantity}) has been returned by User {borrowedEntry.IdUser}.");

            borrow.Remove(borrowedEntry);

            UpdateBookInventory(ref books, borrowedEntry, quantity);
        }

        private void UpdateBookInventory(ref List<Book> books, BorrowSystem borrowedEntry, int quantity)
        {
            Book? existingBook = books.FirstOrDefault(b => b.Id == borrowedEntry.Id);

            if (existingBook != null)
            {
                existingBook.SetQuantity(existingBook.Quantity + quantity);
            }
            else
            {
                Book newBook = new Book();
                newBook.SetId(borrowedEntry.Id);
                newBook.SetName(borrowedEntry.Name);
                newBook.SetQuantity(quantity);
                books.Add(newBook);
            }
        }
    }
}
