namespace Module14;

internal class Program
{
    const int ItemsPerPage = 2;

    static readonly List<Contact> phoneBook = new List<Contact>();
        

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

        Run();
    }

    static void Run()
    {
        var sortedPhoneBook = phoneBook.OrderBy(contact => contact.Name).ThenBy(contact => contact.LastName);

        bool run = true;
        int pageCount = phoneBook.Count < ItemsPerPage ? 1 : phoneBook.Count / 2;
        while (run)
        {
            Console.Write("Enter page number or \"e\" for terminate program: ");
            string? command = Console.ReadLine()?.ToLower();
            if (command != "e")
            {
                Console.Clear();
                int page = default;
                if (int.TryParse(command, out page) && page > 0 && page <= pageCount)
                {
                    var pageView = sortedPhoneBook.Skip(ItemsPerPage * (page - 1)).Take(ItemsPerPage);
                    Console.WriteLine($"Page {page} of {pageCount}");
                    Console.WriteLine("-------------------------------");
                    foreach (var item in pageView)
                    {
                        Console.WriteLine($"{item.Name} {item.LastName} {item.PhoneNumber} {item.Email}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Page Number.");
                }
            }
            else
            {
                run = false;
            }
        }
    }
}