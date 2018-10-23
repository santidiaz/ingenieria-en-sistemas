using System;
using System.Threading;

namespace p1e02
{
    class Program
    {
        static bool firstThread = true;

        static void Main(string[] args)
        {
            for (int i  = 0; i < new Random().Next(10, 20); i++)
            {
                Thread thread = new Thread((n) =>
                {
                    // Como no hay lock en la variable `firstThread` puede
                    // que algún thread llegue a leer firstThread antes de que
                    // el primero la establezca en `true` y por ende más de un
                    // thread imprima el string "Bienvenidos a ..."
                    if (firstThread)
                    {
                        Console.WriteLine("Bienvenidos a Programación de Redes 2018");
                    }
                    
                    firstThread = false;
                });

                thread.Start(i);
            }
        }
    }
}
