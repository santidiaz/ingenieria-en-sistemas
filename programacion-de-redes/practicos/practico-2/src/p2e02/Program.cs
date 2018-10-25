using System;
using System.Threading;

namespace p2e02
{
    class Program
    {
        static readonly object[] locker = new object[] { new object(), new object() };
        
        static void Main(string[] args)
        {
            var thread01 = new Thread(() => 
            {
                lock(locker[0])
                {
                    Console.WriteLine("Waiting for thread10");
                    Thread.Sleep(100);
                    lock(locker[1])
                    {
                        Console.WriteLine("This is not gonna happen");
                    }
                }
            });
            
            var thread10 = new Thread(() => 
            {
                lock(locker[1])
                {
                    Console.WriteLine("Waiting for thread01");
                    Thread.Sleep(100);
                    lock(locker[0])
                    {
                        Console.WriteLine("This is not gonna happen either");
                    }
                }
            });

            thread01.Start();
            thread10.Start();
        }
    }
}
