using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueEntities;
using CatalogueManagement;
using CatalogueModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unit testing
            ICatalogueManager bookCatalogueManager = new CatalogueManager(new CatalogueModel.CatalogueModel()); // Use IoC

            bookCatalogueManager.AddAnItem(Log(new Book(title: "Coach yourself 1", category: Category.SELF_HELP, soldCount: 10, authorName:"Sam")));
            bookCatalogueManager.AddAnItem(Log(new Book(title: "Coach yourself 2", category: Category.SELF_HELP, soldCount: 20, authorName:"anand")));
            bookCatalogueManager.AddAnItem(Log(new Book(title: "Coach yourself 3", category: Category.SELF_HELP, soldCount: 30, authorName: "anandhi")));
            bookCatalogueManager.AddAnItem(Log(new Book(title: "Steve Jobs", category: Category.BIOGRAPHY, soldCount: 10, authorName: "Steve")));
            Console.WriteLine();

            // exact match with category or with author name
            Book[] books2 = bookCatalogueManager.GetMostSoldItems("Anand", 10) as Book[];
            Console.WriteLine("Top 10 most sold book filtered by 'Anand'");
            printBooks(books2);
            Console.WriteLine();

            Book[] books3 = bookCatalogueManager.GetMostSoldItems("SELF_HELP", 10) as Book[];
            Console.WriteLine("Top 10 most sold book filtered by 'SELF_HELP'");
            printBooks(books3);
            Console.WriteLine();

            Console.ReadLine();
        }

        private static Book Log(Book book)
        {
            Console.WriteLine("Adding new book:");
            Console.WriteLine(book.ToString());
            return book;
        }

        private static void printBooks(Book[] books)
        {
            foreach (Book book in books) {
                Console.WriteLine(book.ToString());
            }
        }

    }
}
