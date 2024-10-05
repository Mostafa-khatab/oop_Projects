using BankingSystem;
using LibrarySystem;
using System.Xml.Linq;

List<Book> books = new List<Book>();
List<BorrowSystem> borows = new List<BorrowSystem>();
List<Users> users = new List<Users>();
Dictionary<int,bool>IdTakenForBook = new Dictionary<int, bool>();
Dictionary<int,bool>IdTakenForUser = new Dictionary<int, bool>();
while (true)
{
    Console.WriteLine("1) Add book");
    Console.WriteLine("2) Print library books");
    Console.WriteLine("3) Searching for books by name.");
    Console.WriteLine("4) Add user");
    Console.WriteLine("5) Borrow book");
    Console.WriteLine("6) Return book");
    Console.WriteLine("7) Print users borrowed book");
    Console.WriteLine("8) Print users");
    int op = int.Parse(Console.ReadLine());
    if (op == 1)
    {
        int id, q;
        string name;
        Console.WriteLine("Enter The Id For Book");
        id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Name For Book");
        name = Console.ReadLine();
        Console.WriteLine("Enter The Quantity For Book");
        q = int.Parse(Console.ReadLine());
        Book b = new Book();
        if (IdTakenForBook.TryGetValue(id, out bool isTaken) && isTaken)
        {
            Console.WriteLine("This ID is already taken.");
            continue;
        }

        b.SetId(id);
        b.SetName(name);
        b.SetQuantity(q);
        CheckIntger ch1 = new();
        CheckString ch2 = new();
        if (!ch1.CheckInput(id) || !ch2.CheckInput(name) || !ch1.CheckInput(q)) continue;
        IdTakenForBook[id] = true;
        books.Add(b);
    }
    else if (op == 2)
    {
        foreach (var book in books)
        {
            Console.WriteLine($"the book id is {book.Id} and book name is {book.Name} and the quantity is {book.Quantity}");

        }
    }
    else if (op == 3)
    {
        Console.WriteLine("Enter The Name For Book");
        string _name = Console.ReadLine();
        SearchForBook book = new SearchForBook();
        book.SearchBooks(ref books, _name);
    }
    else if (op == 4)
    {
        Console.WriteLine("Enter The Id For User");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Name For User");
        string name = Console.ReadLine();
        Users user = new Users();
        if (IdTakenForUser.TryGetValue(id, out bool isTaken) && isTaken)
        {
            Console.WriteLine("This ID is already taken.");
            continue;
        }
        user.SetId(id);
        user.SetName(name);
        CheckIntger ch1 = new();
        CheckString ch2 = new();
        if (!ch1.CheckInput(id) || !ch2.CheckInput(name)) continue;
        IdTakenForUser[id] = true;
        users.Add(user);
    }
    else if (op == 5)
    {
        Console.WriteLine("Enter The Id Of The Book");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Id Of The User Who`s Borrow The Book");
        int idUesr = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Quantity You Need");
        int quantity = int.Parse(Console.ReadLine());
        BorrowSystem borrow = new BorrowSystem();
        Users user = new Users();
        if (IdTakenForUser.TryGetValue(id, out bool isTaken) && isTaken)
        {
            if (IdTakenForBook.TryGetValue(id, out bool isTaken2) && isTaken2)
            {
                borrow.SetId(id);
                CheckIntger ch1 = new();
                if (!ch1.CheckInput(id) || !ch1.CheckInput(idUesr)) continue;
                borrow.CanIBorrowBook(ref books, id, ref borows, idUesr, quantity);
            }
            else
            {
                Console.WriteLine($"There No book With Id {id}");
            }
        }
        else
        {
            Console.WriteLine($"There No User With Id {idUesr}");
        }
    }
    else if (op == 6)
    {
        Console.WriteLine("Enter The Id Of The Book");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Id Of The User Who`s Borrow The Book");
        int idUesr = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The Quantity You Need");
        int quantity = int.Parse(Console.ReadLine());
        BorrowSystem borrow = new BorrowSystem();
        if (IdTakenForUser.TryGetValue(id, out bool isTaken) && isTaken)
        {
            if (IdTakenForBook.TryGetValue(id, out bool isTaken2) && isTaken2)
            {
                borrow.SetId(id);
                CheckIntger ch1 = new();
                CheckString ch2 = new();
                if (!ch1.CheckInput(id) || !ch1.CheckInput(idUesr)) continue;
                borrow.ReturnBorrowedBooks(ref books, id, ref borows, idUesr, quantity);
            }
            else
            {
                Console.WriteLine($"There No book With Id {id}");
            }
        }
        else
        {
            Console.WriteLine($"There No User With Id {idUesr}");
        }
    }
    else if (op == 7)
    {
        foreach (var _userborrow in borows)
        {
            Console.WriteLine($"The User With Id {_userborrow.Id} And Name {_userborrow.Name}");
        }
    }
    else if (op == 8)
    {
        foreach(var user in users)
        {
            Console.WriteLine($"The User With Id {user.Id} And Name {user.Name}");
        }
    }
}
