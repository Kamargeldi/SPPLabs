using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace ExportClass
{
    [ExportClass]
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            foreach (string s in args)
            {
                if (File.Exists(s) && (Path.GetExtension(s) == ".dll" || Path.GetExtension(s) == ".exe"))
                {
                    Assembly asm = Assembly.LoadFrom(s);
                    Console.WriteLine();
                    Console.WriteLine($"Assembly:  {asm.FullName}");
                    var types = asm.GetTypes().Where(x => x.IsPublic).Where(x => x.GetCustomAttributes<ExportClassAttribute>().Count() > 0);
                    foreach (Type t in types)
                        Console.WriteLine($"----- {t.FullName}");
                }
            }



            Console.ReadKey();
        }

    }
}
