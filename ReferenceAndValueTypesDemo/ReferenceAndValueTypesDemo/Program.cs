using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueTypesDemo
{
    class Program
    {
        class Persoon
        {
            public int Leeftijd { get; set; }
            public string Naam { get; set; }

            public override string ToString()
            {
                return "Leeftijd: " + Leeftijd + ", Naam: " + Naam;
            }
        }

        static void Main(string[] args)
        {
            Persoon p = new Persoon { Leeftijd = 31, Naam = "Manuel" };
            PasPersoonAan(ref p);

            Console.WriteLine(p.Leeftijd);

            int q;
            OutDemo(out q);
            Console.WriteLine(q);

            long[] items = new long[5];
            items[0] = 23;
            items[1] = 3;
            items[2] = 4;
            items[3] = 123;
            items[4] = 3423;

            long[] items2 = new long[] { 23, 3, 4, 123, 3423 };

            ParamsDemo(23, new long[] { 23, 3, 4, 123, 3423 });
            ParamsDemo(23, items);
            ParamsDemo(23, 3, 4, 123, 3423);

            Console.WriteLine("{0} asdf {1} fsdf {0} sdfd {2}", 23, "asdf", new Persoon() { Leeftijd = 21, Naam = "Manuel" });

            Console.WriteLine(Fac(042972));
        }

        private static int Fac(int p)
        {
            if (p == 1)
            {
                return 1;
            }

            return Fac(p - 1) * p;
        }




        private static void PasPersoonAan(ref Persoon j)
        {
            //j = new Persoon { Naam = "Piet", Leeftijd = 14 };
            j.Leeftijd++;

            //j = new Persoon { Naam = "Pietje", Leeftijd = 14 };
        }

        private static void OutDemo(out int n)
        {
            n = 5;
        }

        private static void ParamsDemo(long l12, params long[] v)
        {
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }

        private static int Add(int a = 0, int b = 0)
        {
            return a + b;
        }

        //private static int Add(int a)
        //{
        //    return Add(a, 0);
        //}

        //private static int Add()
        //{
        //    return Add(0, 0);
        //}
    }
}
