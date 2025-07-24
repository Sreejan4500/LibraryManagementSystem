

class LibraryManager
{
    /// <summary>
    /// Maximum capacity of the library.
    /// </summary>
    private const int MaxCapacity = 5;
    /// <summary>
    /// Maximum number of books a user can borrow at a time.
    /// </summary>
    private const int MaxBooksBorrowedLimit = 3;
    /// <summary>
    /// Tracks the number of books borrowed by the user.
    /// </summary>
    private static int BooksBorrowed = 0;
    /// <summary>
    /// Dictionary to store the books in the library.
    /// Key: Book title, Value: Availability status (true for available, false for borrowed).
    /// </summary>
    private static Dictionary<string, bool> Books = new();

    static void Main()
    {
        while (true)
        {
            Console.Write("Would you like to add, remove, search, borrow or return a book? (add/remove/search/borrow/return/exit): ");
            string? action = Console.ReadLine()?.ToLower();

            switch (action)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
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
        if (Books.Count >= MaxCapacity)
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

        Books.Add(newBook, true);
    }

    /// <summary>
    /// Removes the book.
    /// </summary>
    private static void RemoveBook()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.Write("Enter the title of the book to remove: ");
        string? removeBook = Console.ReadLine();

        if (!string.IsNullOrEmpty(removeBook) && Books.Remove(removeBook))
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
        if (Books.Count == 0)
        {
            Console.WriteLine("(none)");
        }
        else
        {
            int count = 1;
            foreach (var book in Books)
            {
                Console.WriteLine($"{count++}. {book.Key}");
            }
        }
    }

    /// <summary>
    /// Searches the book.
    /// Checks:
    /// a. Check if there are any books available in the library
    /// b. Checks if the user entered any book title to search for.
    /// c. Checks if the book is available in the library.
    /// </summary>
    private static void SearchBook()
    {
        // a. Check if there are any books available in the library
        if (Books.Count == 0)
        {
            Console.WriteLine("No books available in the library.");
            return;
        }

        Console.Write("Enter the title of the book to search: ");
        string? searchBook = Console.ReadLine();

        // b. Check if the user entered a book title
        if (string.IsNullOrWhiteSpace(searchBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        // c. Check if the book is available in the library
        string? match = Books.Keys.FirstOrDefault(k =>
            string.Equals(k, searchBook, StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrEmpty(match))
        {
            Console.WriteLine($"Book '{searchBook}' not found.");
            return;
        }

        // If all the checks pass, notifies the availability of the book
        Console.WriteLine($"Book '{match}' is {(Books[match] ? "available" : "currently borrowed")}.");
    }

    /// <summary>
    /// Borrows the book.
    /// Checks:
    /// a. Checks if the user has reached the maximum limit of borrowed books.
    /// b. Checks if there are any books available to borrow.
    /// c. Checks if the user entered any book title to borrow.
    /// d. Checks if there is a book with the entered title in the library.
    /// e. Checks if the book is available for borrowing.
    /// </summary>
    private static void BorrowBook()
    {
        // a. Check if the user has reached the maximum limit of borrowed books
        if (BooksBorrowed >= MaxBooksBorrowedLimit) 
        {
            Console.WriteLine("You have reached the maximum limit of borrowed books.");
            return;
        }

        // b. Check if there are any books available to borrow
        if (Books.Count == 0)
        {
            Console.WriteLine("No books available to borrow.");
            return;
        }

        Console.Write("Enter the title of the book to borrow: ");
        string? borrowBook = Console.ReadLine();

        // c. Check if the user entered a book title
        if (string.IsNullOrEmpty(borrowBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        // d. Check if there is a book with the entered title in the library
        string? match = Books.Keys.FirstOrDefault(k =>
            string.Equals(k, borrowBook, StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrEmpty(match))
        {
            Console.WriteLine($"Book '{borrowBook}' not found.");
            return;
        }

        // e. Check if the book is available for borrowing
        if (!Books[match])
        {
            Console.WriteLine($"Book '{borrowBook}' is not available for borrowing at the moment.");
            return;
        }

        // If all checks pass, mark the book as borrowed
        Books[match] = false; 
        Console.WriteLine($"Book '{borrowBook}' borrowed.");
        BooksBorrowed++;
    }

    /// <summary>
    /// Returns the book.
    /// Checks:
    /// a. Checks if the user has any books to return.
    /// b. Checks if there are any books in the library. (if there are no books, user can't return a book)
    /// c. Checks if the user entered any book title to return.
    /// d. Checks if there is any book borrowed.
    /// e. Checks if the book was borrowed.
    /// </summary>
    private static void ReturnBook()
    {
        // a. Check if the user has any books to return
        if (BooksBorrowed == 0) 
        {
            Console.WriteLine("You have no books to return.");
            return;
        }

        // b. Check if there are any books in the library
        if (Books.Count == 0) 
        {
            Console.WriteLine("No books available in the library.");
            return;
        }

        Console.Write("Enter the title of the book to return: ");
        string? returnBook = Console.ReadLine();

        // c. Check if the user entered a book title to return
        if (string.IsNullOrEmpty(returnBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        // d. Check if there is a book with the entered title in the library
        string? match = Books.Keys.FirstOrDefault(k =>
            string.Equals(k, returnBook, StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrEmpty(match)) 
        {
            Console.WriteLine($"Book '{returnBook}' not found in the library.");
            return;
        }

        // e. Check if the book was borrowed
        if (Books[match]) 
        {
            Console.WriteLine($"Book '{returnBook}' was not borrowed.");
            return;
        }

        // If all checks pass, mark the book as available again and decrease the count of borrowed books
        Books[match] = true; 
        Console.WriteLine($"Book '{returnBook}' returned.");
        BooksBorrowed--;
    }

}
