using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    class Program
    {
        abstract class Persoon
        {
            public string Naam { get; set; }

            public Persoon(string naam)
            {
                Naam = naam;
            }

            public void Print()
            {
                Console.WriteLine("Persoon: {0}", Naam);
            }

            public virtual void PrintVirtual()
            {
                Console.WriteLine("Persoon: {0}", Naam);
                DoeIetsAbstracts();
            }

            public abstract void DoeIetsAbstracts();

        }

        class Student : Persoon
        {
            public Student() : base("unknown")
            {
                Print();
            }

            public new void Print()
            {
                Console.WriteLine("Student: {0}", Naam);
            }

            public override void PrintVirtual()
            {
                base.PrintVirtual();
                Console.WriteLine("Student: {0}", Naam);
            }

            public override void DoeIetsAbstracts()
            {
                Console.WriteLine("Rondjes dansen op het podium en semi interessante dingen doen.");
            }
        }

        static void Main(string[] args)
        {
            Persoon s = new Student();
            s.Print();
            s.PrintVirtual();
        }
    }
}
