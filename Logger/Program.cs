using System;
using System.Threading;
using System.IO;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _running = true;
            FileStream fs = new FileStream(@"C:\Users\Kamar\Desktop\sppSample.txt", FileMode.Create);

            LogBuffer logger = new LogBuffer(fs);
            while (_running)
            {
                logger.Add($"Thread: {Thread.CurrentThread.ManagedThreadId}  Time: {DateTime.Now}", true);

                var info = Console.ReadKey();
                if (info.Key == ConsoleKey.Q)
                    _running = false;
            }

            logger.FlushAsync();
            Thread.Sleep(1000);
            logger.Dispose();
            Console.ReadKey();
        }
    }
}
