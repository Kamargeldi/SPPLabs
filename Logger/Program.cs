using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            /*bool _running = true;
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
            logger.Dispose();*/


            object _locker = new object();
            List<Action> actionList = new List<Action>();

            for (int i = 0; i < 10; i++)
            {
                actionList.Add(() => 
                {
                    lock (_locker)
                    {
                        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
            

            actionList.ToArray().WaitAll();

            Console.WriteLine("Finished all tasks.");
            
            Console.ReadKey();
        }
    }
}
