using System;
using System.Collections.Generic;

namespace ConsoleLibraryCardCatelogue
{
    class Program
    {
        static void Main(string[] args)
        {
            CardCatelogue catalogue = new CardCatelogue();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. List all books");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Save and exit");
                String choice = Console.ReadLine();
                Console.WriteLine(choice);
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Listing books...");
                        break;

                    case "2":
                        Console.WriteLine("Adding book...");
                        catalogue.AddBook();
                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
    }

    [Serializable]
    public class Book
    {
        public String Title { get; set; }
        public String Author { get; set; }
        public int Pages { get; set; }
        public int Rating { get; set; }
        public List<String> Tags { get; set; }
        public int PublicationYear { get; set; }
    }

    [Serializable]
    public class CardCatelogue
    {
        public String Filename { get; set; }
        public List<Book> Books { get; set; }
        // public CardCatelogue(string fileName)
        // {
        // TODO
        // }

        public void ListBooks()
        {
            System.Console.WriteLine("Here is the list of books.");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to continue.");
        }

        public void AddBook()
        {
            Book book = new Book();
            Console.Write("Title:                 ");
            book.Title = Console.ReadLine();
            Console.WriteLine("\nAuthor:          ");
            book.Author = Console.ReadLine();
            Console.WriteLine("\nNumber of Pages: ");
            // validate
            book.Pages = int.Parse(Console.ReadLine());
            Console.WriteLine("\nRating (1~5):    ");
            book.Rating = int.Parse(Console.ReadLine());
            Console.WriteLine("\nYear Published:  ");
            book.PublicationYear = int.Parse(Console.ReadLine());
            Books.Add(book);
        }

        public void Save()
        {
            System.Console.WriteLine("Saving file...");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to continue.");
        }
    }
}

