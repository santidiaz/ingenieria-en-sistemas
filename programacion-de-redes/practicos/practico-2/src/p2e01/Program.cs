using System;
using System.Threading;

namespace p2e01
{
    class Program
    {
        static readonly object locker = new object();
        
        static void Main(string[] args)
        {
            var xThread = new Thread(() => Print20("x"));
            var oThread = new Thread(() => Print20("o"));

            xThread.Start();
            oThread.Start();
        }

        static void Print20(string str)
        {
            lock(locker)
            {
                for (int i = 0; i < 20; i++) 
                {
                    Console.Write(str);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
