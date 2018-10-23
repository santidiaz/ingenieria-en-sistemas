using System;
using System.Threading;

namespace p1e03
{
    class Program
    {
        static bool firstThread = true;
        static readonly object firstThreadLock = new object();

        static void Main(string[] args)
        {
            for (int i  = 0; i < new Random().Next(10, 20); i++)
            {
                Thread thread = new Thread((n) =>
                {
                    lock(firstThreadLock)
                    {
                        if (firstThread)
                        {
                            Console.WriteLine("Bienvenidos a Programación de Redes 2018");
                        }
                        
                        firstThread = false;
                    }
                });

                thread.Start(i);
            }
        }
    }
}
