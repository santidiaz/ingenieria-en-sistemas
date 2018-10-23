using System;
using System.Threading;
using System.Threading.Tasks;

namespace p1e04
{
    class Program
    {
        static void Main(string[] args)
        {
            // * Primer enfoque
            //      Utilizando tasks
            
            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++) Console.Write(0);
            });

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("El thread terminó de imprimir los 100 ceros");
            
            // * Segundo enfoque
            //      Utilizando threads (join)

            Thread thread = new Thread(() => 
            {
                for (int i = 0; i < 100; i++) Console.Write(0);
            });

            thread.Start();

            thread.Join();

            Console.WriteLine();
            Console.WriteLine("El thread terminó de imprimir los 100 ceros");
        }
    }
}
