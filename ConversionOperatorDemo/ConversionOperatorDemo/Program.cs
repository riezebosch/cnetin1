using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionOperatorDemo
{
    class Program
    {
        class Persoon
        {
            public string Naam { get; set; }

            public override bool Equals(object obj)
            {
                return ((Persoon)obj).Naam == Naam;
            }

            public static bool operator ==(Persoon p1, Persoon p2)
            {
                return p1.Naam == p2.Naam;
            }

            public static bool operator !=(Persoon p1, Persoon p2)
            {
                return !(p1 == p2);
            }
        }

        class Student : Persoon
        {
            public int Nummer { get; set; }

            public override bool Equals(object obj)
            {
                return base.Equals(obj) && ((Student)obj).Nummer == Nummer;
            }

            public static bool operator ==(Student p1, Student p2)
            {
                return p1.Naam == p2.Naam && p1.Nummer == p2.Nummer;
            }

            public static bool operator !=(Student p1, Student p2)
            {
                return !(p1 == p2);
            }

        }

        static void Main(string[] args)
        {
            Student s1 = new Student { Naam = "Manuel", Nummer = 1234 };
            Student s2 = new Student { Naam = "Manuel", Nummer = 4 };

            IsEqual1(s1, s2);
            IsEqual2(s1, s2);
        }

        private static void IsEqual1(Persoon p1, Persoon p2)
        {
            Console.WriteLine("IsEqual1:");
            Console.WriteLine("Equals: {0}", p1.Equals(p2));
            Console.WriteLine("==:     {0}", p1 == p2);
            Console.WriteLine();
        }

        private static void IsEqual2(Student p1, Student p2)
        {
            Console.WriteLine("IsEqual2:");
            Console.WriteLine("Equals: {0}", p1.Equals(p2));
            Console.WriteLine("==:     {0}", p1 == p2);
            Console.WriteLine();
        }
    }
}
