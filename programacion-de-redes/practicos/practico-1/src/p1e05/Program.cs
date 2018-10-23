using System;
using System.Threading;

namespace p1e05
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumaDos = 0;
            int sumaTres = 0;

            Thread sumaDosThread = new Thread(() => sumaDos = SumaDos(1, 2));
            Thread sumaTresThread = new Thread(() => sumaTres = SumaTres(3, 4, 5));

            sumaDosThread.Start();
            sumaTresThread.Start();

            sumaDosThread.Join();
            sumaTresThread.Join();

            Console.WriteLine($"Suma total: {sumaDos + sumaTres}");
        }

        static int SumaDos(int a, int b)
        {
            return a + b;
        }

        static int SumaTres(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
