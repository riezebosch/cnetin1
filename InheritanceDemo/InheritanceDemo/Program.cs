using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Program
    {
        class Persoon
        {
            public string Naam { get; set; }

            public Persoon(string naam)
            {

            }
        }

        class Student : Persoon
        {
            public string Naam { get; set; }
            int IANameButAnotherType.Naam { get; set; }
        }

        static void Main(string[] args)
        {
            Student p = new Student();
            
            ((ISomethingWithAName)p).Naam = "Manuel";
            ((IANameButAnotherType)p).Naam = 31;

            Console.WriteLine("{0} {1}", ((ISomethingWithAName)p).Naam, ((IANameButAnotherType)p).Naam);
        }
    }
}
