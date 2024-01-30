using DZ_29_01;
using System.Reflection;
using System.Threading.Channels;

static void LoginMenu()
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var bookService = new BookRepository(db);
        bookService.EsurePopulate();
        while (true)
        {
            Console.WriteLine("1. Show all Books\n2. Get Books by Id\n3. Log out");
            string choice=Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    {
                        BookShow(bookService);
                        break;
                    }
                case "2":
                    {
                        Console.Write("Enter book Id: ");
                        int bookId=int.Parse(Console.ReadLine());
                        var currentBook=bookService.GetBook(bookId);
                        Console.WriteLine(currentBook);
                        break;
                    }
                case "3":
                    {
                        return;
                    }
                    default:
                    Console.WriteLine("Error imput!");
                    break;
            }
        }
    }
}

static void BookShow(BookRepository bookService, int page=1)
{
    Console.WriteLine($"Page number: {page}");
    var allBooks = bookService.GetBooks(page);
    DisplayTable(allBooks.ToList());
    Console.Write("1. Next page ");
    if (page>1)
    {
        Console.Write(" 2. Previous page ");
    }
    Console.Write(" 3. Back ");
    int input=int.Parse(Console.ReadLine());
    if (input>=3)
    {
        return;
    }
    BookShow(bookService, page+=input==1?1:-1);
}

static void DisplayTable<T>(List<T> collection, string[]? excludeProperties = null)
{
    PropertyInfo[] properties = excludeProperties is null ? typeof(T).GetProperties():
        typeof(T).GetProperties().Where(e=>!excludeProperties.Contains(e.Name)).ToArray();

    Console.WriteLine(new string('-', properties.Length*19+1));
    foreach(var property in properties)
    {
        Console.Write($"| {property.Name,-15}");
    }
    Console.WriteLine("|");
    Console.WriteLine(new string('-', properties.Length * 19 + 1));

    foreach (var product in collection)
    {
        foreach (var property in properties)
        {
            Console.Write($"| {property.GetValue(product),-15}");
        }
        Console.WriteLine("|");
    }
    Console.WriteLine(new string('-', properties.Length * 19 + 1));
}

using (ApplicationContext db=new ApplicationContext())
{
    //db.Database.EnsureDeleted();
    //db.Database.EnsureCreated();
    var userService=new UserRepository(db);
    while (true)
    {
        Console.WriteLine("1. Register\n2. Login\n3. Exit");
        string chois=Console.ReadLine();
        switch (chois) 
        {
            case "1":
                {
                    Console.Write("Enter userName: ");
                    string userName=Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if(userService.RegisterUser(userName, password))
                    {
                        Console.WriteLine("Good");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    break;
                }
            case "2":
                {
                    Console.Write("Enter userName: ");
                    string userName = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if (userService.AutorizeUser(userName, password))
                    {
                        LoginMenu();
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    break;
                }
            case "3":
                {
                    return;                    
                }
            default:
                Console.WriteLine("Error imput!");
                break;
        }
    }
}