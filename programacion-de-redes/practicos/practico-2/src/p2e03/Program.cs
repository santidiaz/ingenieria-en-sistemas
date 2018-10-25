using System;
using System.Collections.Generic;
using System.Threading;

namespace p2e03
{
    class Program
    {
        private static readonly object locker = new object();

        static List<Person> persons = new List<Person>();
        
        static void Main(string[] args)
        {
            var random = new Random();
            var thread0 = new Thread((n) => CreatePersons((int)n, random.Next(10, 20)));
            var thread1 = new Thread((n) => CreatePersons((int)n, random.Next(10, 20)));

            thread0.Start(0);
            thread1.Start(1);
        }

        static void CreatePersons(int threadId, int amount) 
        {
            while (amount-- >= 0)
            {
                var person = new Person()
                {
                    CI = new Random().Next(0, 30).ToString(),
                    Nombre = "John",
                    Email = "john@earth.org",
                    Tel = "12345678"
                };

                lock (locker)
                {
                    if (persons.Find(p => p.CI.Equals(person.CI)) != null)
                    {
                        throw new Exception($"[{threadId}] ERROR: There is already a person with CI {person.CI}");
                    }

                    persons.Add(person);
                }
                    
                Console.WriteLine($"[{threadId}] The person with CI {person.CI} was added");

                Thread.Sleep(1); // Para poder apreciar mejor lo que está pasando
            }
        }
    }
}
