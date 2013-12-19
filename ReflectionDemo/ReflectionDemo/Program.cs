using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        abstract class Persoon
        {

            public string Naam { get; set; }

            private int _leeftijd;
            public int Leeftijd { get { return _leeftijd; } } //set { _leeftijd = value; }


            public Persoon(int leeftijd)
            {
                _leeftijd = leeftijd;
            }

            public void VerhoogDeLeeftijd()
            {
                _leeftijd++;
            }

            public override string ToString()
            {
                return "Leeftijd: " + _leeftijd.ToString();
            }

            public void Reinitialize()
            {
                // Dit mag niet bij classes
                //this = new Persoon(12345);
            }

            public abstract void Print();
        }

        class Docent : Persoon
        {
            public override void Print()
            {
                
            }
        }

        class Student : Persoon
        {
            public override void Print()
            {

            }
        }

        struct MyDemoStruct
        {
            public int Data ;

            public MyDemoStruct(int data)
            {
                Data = data;
            }

            public void Reinitialize()
            {
                this = new MyDemoStruct(7);
            }
        }

        static void Main(string[] args)
        {
            var persoon = new Student();
            persoon.VerhoogDeLeeftijd();
            persoon.VerhoogDeLeeftijd();
            persoon.VerhoogDeLeeftijd();
            persoon.VerhoogDeLeeftijd();

            var field = persoon.GetType().GetField("_leeftijd", BindingFlags.NonPublic | BindingFlags.Instance);
            var value = field.GetValue(persoon);

            Console.WriteLine(value);

            Persoon p2 = new Persoon(123);
            foreach (var f in p2.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object v = f.GetValue(persoon);
                f.SetValue(p2, v);
            }

            Console.WriteLine(p2);

            Persoon p3 = new Persoon(23123);
            p3.Reinitialize();

            MyDemoStruct st = new MyDemoStruct(4);
            st.Reinitialize();

            Console.WriteLine(st.Data);
        }
    }
}
