using Generic_Types.Models;

static void Main(string[] args)
{
    Console.WriteLine("=== 1. Kitablar yaradılır ===");
    // 1. Kitablar
    Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
    Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
    Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
    Book book4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
    Book book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

    List<Book> allBooks = new List<Book> { book1, book2, book3, book4, book5 };
    foreach (var book in allBooks)
    {
        book.DisplayInfo();
    }

    Console.WriteLine("\n=== 2. Generic Library<T> test ===");
    Library<Book> library = new Library<Book>("Milli Kitabxana");

    // Kitab əlavə et
    foreach (var book in allBooks)
    {
        library.Add(book);
    }

    Console.WriteLine($"Kitab sayı: {library.Count()}");

    // İndeks 0 və 2
    Console.WriteLine("İndeks 0:");
    library.FindByIndex(0)?.DisplayInfo();

    Console.WriteLine("İndeks 2:");
    library.FindByIndex(2)?.DisplayInfo();

    // Bütün kitablar
    Console.WriteLine("\nBütün kitablar:");
    foreach (var b in library.GetAll())
    {
        b.DisplayInfo();
    }

    Console.WriteLine("\n=== 3. Üzvlər (List<T>) ===");
    List<Member> members = new List<Member>
            {
                new Member(1, "Ali Məmmədov", "ali@mail.com"),
                new Member(2, "Leyla Həsənova", "leyla@mail.com"),
                new Member(3, "Vüqar Əliyev", "vuqar@mail.com")
            };

    // 2 kitab götürsün
    members[0].BorrowBook(book1);
    members[0].BorrowBook(book2);
    members[0].DisplayBorrowedBooks();

    // 1 kitabı qaytarır
    members[0].ReturnBook(1);
    members[0].DisplayBorrowedBooks();

    // 3 kitab götürsün, 4-cü kitab limit xəbərdarlığı
    members[0].BorrowBook(book3);
    members[0].BorrowBook(book4);
    members[0].BorrowBook(book5); // 4-cü kitab, xəbərdarlıq olacaq
    members[0].DisplayBorrowedBooks();

    Console.WriteLine("\n=== 4. Dictionary<TKey,TValue> - Müəllifə görə axtarış ===");
    BookManager manager = new BookManager();
    foreach (var book in allBooks)
    {
        manager.AddBook(book);
    }

    var orwellBooks = manager.GetBooksByAuthor("George Orwell");
    Console.WriteLine("George Orwell-in kitabları:");
    foreach (var b in orwellBooks) b.DisplayInfo();

    var aytmatovBooks = manager.GetBooksByAuthor("Cingiz Aytmatov");
    Console.WriteLine("Cingiz Aytmatov-un kitabları:");
    foreach (var b in aytmatovBooks) b.DisplayInfo();

    var londonBooks = manager.GetBooksByAuthor("Jack London");
    Console.WriteLine("Jack London-un kitabları:");
    foreach (var b in londonBooks) b.DisplayInfo();

    var dostoyevskiBooks = manager.GetBooksByAuthor("Dostoyevski");
    Console.WriteLine("Dostoyevski-nin kitabları: " + dostoyevskiBooks.Count);

    Console.WriteLine("\n=== 5. Queue<T> - Növbə ===");
    manager.AddToWaitingQueue("Nigar");
    manager.AddToWaitingQueue("Rəşad");
    manager.AddToWaitingQueue("Səbinə");
    Console.WriteLine($"Növbədə: {manager.WaitingQueue.Count} nəfər");

    manager.ServeNextInQueue();
    Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");

    manager.ServeNextInQueue();
    Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");

    manager.ServeNextInQueue();
    Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");

    Console.WriteLine("\n=== 6. Stack<T> - Son qaytarılan kitablar ===");
    manager.ReturnBook(book1);
    manager.ReturnBook(book2);
    manager.ReturnBook(book3);
    Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");

    Console.WriteLine($"Son qaytarılan kitab: {manager.GetLastReturnedBook()?.Title}");

    // Stack-dən 1 kitab çıxarırıq
    manager.RecentlyReturned.Pop();
    Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");
    Console.WriteLine($"Son qaytarılan kitab: {manager.GetLastReturnedBook()?.Title}");

    Console.WriteLine("\n=== 7. Axtarış testi ===");
    Book search1 = manager.SearchByTitle("1984");
    if (search1 != null)
        search1.DisplayInfo();
    else
        Console.WriteLine("Kitab tapılmadı");

    Book search2 = manager.SearchByTitle("Harry Potter");
    if (search2 != null)
        search2.DisplayInfo();
    else
        Console.WriteLine("Kitab tapılmadı");

    Console.WriteLine("\n=== 8. Statistika ===");
    Console.WriteLine($"Ümumi kitab sayı: {manager.Books.Count}");
    Console.WriteLine($"Ümumi üzv sayı: {members.Count}");
    Console.WriteLine($"Növbədə nəfər sayı: {manager.WaitingQueue.Count}");
    Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");

    // Ən köhnə və ən yeni kitab
    int minYear = int.MaxValue;
    int maxYear = int.MinValue;
    foreach (var b in manager.Books)
    {
        if (b.Year < minYear) minYear = b.Year;
        if (b.Year > maxYear) maxYear = b.Year;
    }
    Console.WriteLine($"Ən köhnə kitabın ili: {minYear}");
    Console.WriteLine($"Ən yeni kitabın ili: {maxYear}");
}

