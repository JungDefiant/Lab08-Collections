using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab08_Collections.Classes;

namespace Lab08_Collections
{
    internal enum Genre {  Horror, Romance, Adventure, Fantasy, Action, Detective }
    
    internal class Program
    {
        public static Library<Book> Library { get; set; }
        public static List<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();

            LoadBooks();
            UserInterface();
        }

        static void UserInterface()
        {
            bool run = true;

            Console.WriteLine("Welcome to Phil's Library!");

            while(run)
            {
                Console.WriteLine(@"Choose an option from below:
                
                1.) View all Books
                2.) Add a Book
                3.) Borrow a book
                4.) Return a book
                5.) View Book Bag

                Press any other key to Exit");

                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        ViewAllBooks();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        ViewBookBag();
                        break;
                    default:
                        run = false;
                        Console.WriteLine("Thank you for coming to the library. Goodbye!");
                        break;
                }
                    //View all Books
                    //Add a Book
                    //Borrow a book
                    //Return a book
                    //View Book Bag
                    //Exit
            }
        }

        static void LoadBooks()
        {
            AddABook("Underwater Basket-Weaving For Dummies", "Orville", "Doopie", 420, Genre.Action );
            AddABook("Dank Memes", "Griffin", "McElroy", 420, Genre.Romance );
            AddABook("History of Memeology", "Sonic", "Heghog", 360, Genre.Detective );
            AddABook("Chicken Memes For the Soul", "Jeff", "Goldblum", 8, Genre.Fantasy);
            AddABook("Das Meme-ital", "Charlie", "Memelord", 241, Genre.Adventure );
        }

        static void ViewAllBooks()
        {
            Console.WriteLine("\nThese are all the books in the library.");
            
            for (int i = 0; i < Library.Count(); i++)
            {
                Console.WriteLine("--> " + Library.ElementAt(i).Title 
                    + " by " + Library.ElementAt(i).Author.FirstName 
                    + " " + Library.ElementAt(i).Author.LastName);
            }
        }

        static void ViewBookBag()
        {
            Console.WriteLine("\nThese are all the books in your book bag.");

            for (int i = 0; i < BookBag.Count; i++)
            {
                Console.WriteLine("--> " + BookBag[i].Title 
                    + " by " + Library.ElementAt(i).Author.FirstName
                    + " " + Library.ElementAt(i).Author.LastName);
            }
        }

        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };

            Library.Add(book);
        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }
    }
}
