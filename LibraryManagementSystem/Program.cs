
string? bookTitle1 = "", bookTitle2 = "", bookTitle3 = "", bookTitle4 = "", bookTitle5 = "";

while (true)
{
    Console.WriteLine("Welcome to the Library Management System!\n" +
        "1. Type \"add\" to add new book title.\n" +
        "2. Type \"remove\" to remove any book title.\n" +
        "3. Type \"display\" to display the list of books in the library.");

    string choice = Console.ReadLine()?.ToLower() ?? "";

    switch(choice)
    {
        case "add":
            AddBookTitle();
            break;
        case "remove":
            RemoveBookTitle();
            break;
        case "display":
            DisplayBooks();
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine("Do you want to continue? (yes/no)");
    string continueChoice = Console.ReadLine()?.ToLower() ?? "yes";

    if (continueChoice.Equals("no"))
    {
        Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
        break;
    }
}

void DisplayBooks()
{
    Console.WriteLine("Books in the library:");
    int iterator = 1;
    if (!string.IsNullOrEmpty(bookTitle1))
    {
        Console.WriteLine($"{iterator++}. {bookTitle1}");
    }

    if (!string.IsNullOrEmpty(bookTitle2))
    {
        Console.WriteLine($"{iterator++}. {bookTitle2}");
    }

    if (!string.IsNullOrEmpty(bookTitle3))
    {
        Console.WriteLine($"{iterator++}. {bookTitle3}");
    }

    if (!string.IsNullOrEmpty(bookTitle4))
    {
        Console.WriteLine($"{iterator++}. {bookTitle4}");
    }

    if (!string.IsNullOrEmpty(bookTitle5))
    {
        Console.WriteLine($"{iterator++}. {bookTitle5}");
    }
}

void RemoveBookTitle()
{
    Console.WriteLine("Enter the title of the book to remove:");
    string? titleToRemove = Console.ReadLine();

    if (string.IsNullOrEmpty(titleToRemove))
    {
        Console.WriteLine("No book title entered. Please try again.");
    }
    else
    {
        if (bookTitle1 == titleToRemove)
        {
            bookTitle1 = "";
            Console.WriteLine($"Book '{titleToRemove}' has been removed.");
        }
        else if (bookTitle2 == titleToRemove)
        {
            bookTitle2 = "";
            Console.WriteLine($"Book '{titleToRemove}' has been removed.");
        }
        else if (bookTitle3 == titleToRemove)
        {
            bookTitle3 = "";
            Console.WriteLine($"Book '{titleToRemove}' has been removed.");
        }
        else if (bookTitle4 == titleToRemove)
        {
            bookTitle4 = "";
            Console.WriteLine($"Book '{titleToRemove}' has been removed.");
        }
        else if (bookTitle5 == titleToRemove)
        {
            bookTitle5 = "";
            Console.WriteLine($"Book '{titleToRemove}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Book '{titleToRemove}' not found in the library.");
        }
    }
}

void AddBookTitle()
{
    Console.WriteLine("Enter the title of the book:");

    string? title = Console.ReadLine();

    if (string.IsNullOrEmpty(bookTitle1))
    {
        bookTitle1 = title;
    }
    else if (string.IsNullOrEmpty(bookTitle2))
    {
        bookTitle2 = title;
    }
    else if (string.IsNullOrEmpty(bookTitle3))
    {
        bookTitle3 = title;
    }
    else if (string.IsNullOrEmpty(bookTitle4))
    {
        bookTitle4 = title;
    }
    else if (string.IsNullOrEmpty(bookTitle5))
    {
        bookTitle5 = title;
    }
    else
    {
        Console.WriteLine("You have already entered 5 book titles. Book slots are full. No more books can be added.");
    }
}