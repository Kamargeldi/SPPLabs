using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(new CultureInfo("zh-HK"));
            book.Name = "C# in a Nutsheel";
            book.ISBN = 123;
            book.Price = 45.1;
            book.Publisher = "Piter";
            book.Author = "Ben Joseph Albahari";
            Console.WriteLine(book.ToString());
            Console.ReadKey();
        }
    }
}
