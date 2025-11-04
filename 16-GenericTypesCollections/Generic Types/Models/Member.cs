using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Types.Models
{
    internal class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("Maksimum 3 kitab götüre bilersiniz!");
                return;
            }
            BorrowedBooks.Add(book);
            Console.WriteLine($"Kitab götürüldü: {book.Title}");

        }

        public void ReturnBook(int id)
        {
            Book? found = null;
            foreach (var b in BorrowedBooks)
            {
                if (b.Id == id)
                {
                    found = b;
                    break;
                }
            }
            if (found != null)
            {
                BorrowedBooks.Remove(found);
                Console.WriteLine($"Kitab qaytarıldı: {found.Title}");
            }
        }
        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
                return;
            }

            Console.WriteLine($"{Name} terefinden götürülen kitablar:");
            foreach (var book in BorrowedBooks)
            {
                book.DisplayInfo();
            }
        }
    }
}

