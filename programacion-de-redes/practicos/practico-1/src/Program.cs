using System;
using System.Threading;

namespace practico_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i  = 0; i < new Random().Next(10, 20); i++)
            {
                Thread thread = new Thread((n) =>
                {
                    Console.WriteLine($"Bienvenidos a Programación de Redes 2018 – Thread {n}");
                });

                thread.Start(i);
            }
        }
    }
}
