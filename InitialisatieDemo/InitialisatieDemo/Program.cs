using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialisatieDemo
{
    class Persoon
    {
        public string Naam { get; set; }
    }

    struct MyStruct
    {
        public void Print()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            //Persoon p;
            //InitializePersoon(out p);
            //Console.WriteLine(p.Naam);

            MyStruct s;
            s.Print();
        }

        private static void Square(object j)
        {
            j = (int)j * (int)j;
        }

        static void InitializePersoon(out Persoon p)
        {
            p = new Persoon { Naam = "Manuel" };
        }
    }
}
