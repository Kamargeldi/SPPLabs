using System;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Kamar\Desktop\file.txt", FileMode.Open);
            OSHandle osHandle = new OSHandle(fs.SafeFileHandle.DangerousGetHandle());
            osHandle.Dispose();

            StreamWriter writer = new StreamWriter(fs);
            writer.Write("Hi!");
            writer.Flush();

        }
    }
}
