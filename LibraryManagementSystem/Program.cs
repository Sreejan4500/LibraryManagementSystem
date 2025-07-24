

class LibraryManager
{
    private const int MaxCapacity = 5;
    private const int MaxBooksBorrowedLimit = 3;
    private static int BooksBorrowed = 0;
    private static Dictionary<string, bool> books = new();

    static void Main()
    {
        while (true)
        {
            Console.Write("Would you like to add, remove, display, search, borrow or return a book? (add/remove/search/borrow/return/exit): ");
            string? action = Console.ReadLine()?.ToLower();

            switch (action)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
                    break;
                case "display":
                    DisplayBooks();
                    break;
                case "search":
                    SearchBook();
                    break;
                case "borrow":
                    BorrowBook();
                    break;
                case "return":
                    ReturnBook();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'display', 'search', 'borrow', 'return' or 'exit'.");
                    break;
            }

            DisplayBooks();
        }
    }

    /// <summary>
    /// Adds the book.
    /// </summary>
    private static void AddBook()
    {
        if (books.Count >= MaxCapacity)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.Write("Enter the title of the book to add: ");
        string? newBook = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newBook))
        {
            Console.WriteLine("Invalid title.");
            return;
        }

        books.Add(newBook, true);
    }

    /// <summary>
    /// Removes the book.
    /// </summary>
    private static void RemoveBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.Write("Enter the title of the book to remove: ");
        string? removeBook = Console.ReadLine();

        if (!string.IsNullOrEmpty(removeBook) && books.Remove(removeBook))
        {
            Console.WriteLine($"Book '{removeBook}' removed.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    /// <summary>
    /// Displays the books.
    /// </summary>
    private static void DisplayBooks()
    {
        Console.WriteLine("Available books:");
        if (books.Count == 0)
        {
            Console.WriteLine("(none)");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }

    /// <summary>
    /// Searches the book.
    /// </summary>
    private static void SearchBook()
    {
        Console.Write("Enter the title of the book to search: ");
        string? searchBook = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(searchBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        if (books.ContainsKey(searchBook))
        {
            Console.WriteLine($"Book '{searchBook}' is available.");
        }
        else
        {
            Console.WriteLine($"Book '{searchBook}' not found.");
        }
    }

    /// <summary>
    /// Borrows the book.
    /// </summary>
    private static void BorrowBook()
    {
        if(BooksBorrowed >= MaxBooksBorrowedLimit) 
        {
            Console.WriteLine("You have reached the maximum limit of borrowed books.");
            return;
        }
        
        if (books.Count == 0)
        {
            Console.WriteLine("No books available to borrow.");
            return;
        }

        Console.Write("Enter the title of the book to borrow: ");
        string? borrowBook = Console.ReadLine();

        if(string.IsNullOrEmpty(borrowBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        if(books.ContainsKey(borrowBook) && books[borrowBook])
        {
            books[borrowBook] = false; // Mark the book as borrowed
            Console.WriteLine($"Book '{borrowBook}' borrowed.");
            BooksBorrowed++;
        }
        else if (!books[borrowBook])
        {
            Console.WriteLine($"Book '{borrowBook}' is not available for borrowing at the moment.");
        }
        else
        {
            Console.WriteLine($"Book '{borrowBook}' not found.");
        }
    }

    /// <summary>
    /// Returns the book.
    /// </summary>
    private static void ReturnBook()
    {
        Console.Write("Enter the title of the book to return: ");
        string? returnBook = Console.ReadLine();

        if (string.IsNullOrEmpty(returnBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        if (BooksBorrowed > 0 && books.ContainsKey(returnBook) && !books[returnBook]) // Check if the book was borrowed
        {
            books[returnBook] = true; // Mark the book as available again
            Console.WriteLine($"Book '{returnBook}' returned.");
            BooksBorrowed--;
        }
        else if (!books.ContainsKey(returnBook)) // Check if the book exists in the library
        {
            Console.WriteLine($"Book '{returnBook}' not found in the library.");
        }
        else if(books[returnBook]) // Check if the book was not borrowed
        {
            Console.WriteLine($"Book '{returnBook}' was not borrowed.");
        }
        else // If the user tries to return a book they haven't borrowed
        {
            Console.WriteLine("You have no books to return.");
        }
    }

}
