using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeDemo
{
    class Persoon
    {
        public string Naam { get; set; }

        public static bool operator == (Persoon p1, Persoon p2)
        {
            Console.WriteLine("Persoon==Persoon");
            return p1.Naam == p2.Naam;
        }

        public static bool operator !=(Persoon p1, Persoon p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            return this.Naam == ((Persoon)obj).Naam;
        }
    }

    class Student : Persoon
    {
        public int Cijfer { get; set; }
        public static bool operator ==(Student p1, Persoon p2)
        {
            Console.WriteLine("Student==Persoon");
            return p1.Naam == p2.Naam;
        }

        public static bool operator !=(Student p1, Persoon p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {

            if (!(obj is  Student))
            {
                return false;
            }

            Student s2 = (Student)obj;
            return this.Naam == s2.Naam && s2.Cijfer == this.Cijfer;
        }
    }

    public class Class1
    {
        static void Main(string[] args)
        {
            var p1 = new Persoon { Naam = "Manue" };
            var p2 = new Persoon { Naam = "Manuel" };
            
            p1.Naam += Console.ReadLine();

            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Naam == p2.Naam);
            Console.WriteLine(p1.Naam.Equals(p2.Naam));
            Console.WriteLine(p1.Equals(p2));

            //Console.WriteLine(string.Equals(p1, p2, StringComparison.InvariantCultureIgnoreCase));
            
            Student st1 = new Student { Naam = "Manuel" };
            Console.WriteLine("p1.Equals: {0}, st1.Equals: {1}, p1 == st1: {2}, st1 == p1: {3}", 
                p1.Equals(st1),
                st1.Equals(p1), 
                p1 == st1,
                st1 == p1);

            Persoon st2 = new Student { Naam = "Manuel" };
            Console.WriteLine("p1.Equals: {0}, st2.Equals: {1}, p1 == st2: {2}, st2 == p1: {3}",
                p1.Equals(st2),
                st2.Equals(p1),
                p1 == st2,
                st2 == p1);


            string demostring = "mijn demo string" + 6 + "nog wat er achter aan";
            Console.WriteLine(demostring[5]);

            StringBuilder sb = new StringBuilder();
            sb.Append("mijn demo string");
            sb.Append(6);
            sb.Append("nog wat er achter aan");
            sb.Insert(3, "extraaaa");
            Console.WriteLine(sb.ToString());

            var s2 = string.Format("mijn demo string {0} nog wat er achter aan", 6);
            
        }
    }
}
