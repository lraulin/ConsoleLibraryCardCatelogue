using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
                        catalogue.ListBooks();
                        break;

                    case "2":
                        Console.WriteLine("Adding book...");
                        catalogue.AddBook();
                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        catalogue.Save();
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
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
        private const string DATA_FILENAME = "ConsoleLibraryCardCatalogue.dat";
        private BinaryFormatter formatter;

        public List<Book> Books { get; set; }

        public CardCatelogue()
        {
            formatter = new BinaryFormatter();
            Load();
        }

        // public CardCatelogue(string fileName)
        // {
        // TODO
        // }

        public void ListBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("Press any key to continue.");
        }

        public void AddBook()
        {
            Book book = new Book();
            Console.Write("Title:                 ");
            book.Title = Console.ReadLine();
            Console.Write("\nAuthor:          ");
            book.Author = Console.ReadLine();
            Console.Write("\nNumber of Pages: ");
            // validate
            int.TryParse(Console.ReadLine(), out int numberOfPages);
            book.Pages = numberOfPages;
            Console.Write("\nRating (1~5):    ");
            int.TryParse(Console.ReadLine(), out int rating);
            book.Rating = rating;
            Console.Write("\nYear Published:  ");
            int.TryParse(Console.ReadLine(), out int pubYear);
            book.PublicationYear = pubYear;

            Books.Add(book);
        }

        public void Save()
        {
            Console.WriteLine("Saving file...");
            try
            {
                FileStream writerFileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);
                formatter.Serialize(writerFileStream, Books);
                writerFileStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
        }

        public void Load()
        {
            if (File.Exists(DATA_FILENAME))
            {
                try
                {
                    // Create a FileStream will gain read access to the data file.
                    FileStream readerFileStream = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                    // Reconstruct information of from file.
                    Books = (List<Book>)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("There seems to be a file that contains " +
                        "friends information but somehow there is a problem " +
                        "with reading it.");
                } // end try-catch
            } // end if
            else
            {
                Books = new List<Book>();
            }
        } // end Load()
    }
}

