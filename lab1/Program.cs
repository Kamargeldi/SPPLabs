using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookCollectionService service = new BookCollectionService();

            Book book = new Book(new CultureInfo("zh-HK"));
            book.Name = "CLR via C#";
            book.ISBN = 9780735621633;
            book.Price = 45.1;
            book.Publisher = "Piter";
            book.Author = "Jeffrey Richter";

            Book book2 = new Book(new CultureInfo("en-US"));
            book2.Name = "AutoCad for dummies";
            book2.ISBN = 4780531623633;
            book2.Price = 21.6;
            book2.Publisher = "Piter";
            book2.Author = "Bill Feyn";

            Book book3 = new Book(new CultureInfo("zh-HK"));
            book3.Name = "AutoCad 2020 Beginners Guide";
            book3.ISBN = 9780368574632;
            book3.Price = 30.12;
            book3.Publisher = "Piter";
            book3.Author = "-";

            Book book4 = new Book(new CultureInfo("zh-HK"));
            book4.Name = "Современные операционные системы";
            book4.ISBN = 4582168974526;
            book4.Price = 60;
            book4.Publisher = "Piter";
            book4.Author = "Эндрю Таненбаум";


            service.Add(book);
            service.Add(book2);
            service.Add(book3);
            service.Add(book4);

            service.Save(@"C:\Users\Kamar\Desktop\bookcollection.csharpobj");
            Console.WriteLine(service);

            service.Remove(book);
            service.Remove(book2);
            service.Remove(book3);
            service.Remove(book4);

            Console.WriteLine(service);

            service.ParseBookCollectionFromFile(@"C:\Users\Kamar\Desktop\bookcollection.csharpobj");

            Console.WriteLine(service);
            Console.ReadKey();            
        }
    }
}
