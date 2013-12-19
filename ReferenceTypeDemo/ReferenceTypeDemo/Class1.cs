using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeDemo
{
    class Persoon : Object
    {
        public Persoon(string naam)
        {
            Naam = naam;
        }
        
        public string Naam { get; set; }

       
        public override string ToString()
        {
            return string.Format("Persoon met naam: {0}", this.Naam);
        }
    }

    class Student : Persoon
    {
        bool _isAfgestudeerd = false;
        DateTime _geboorteDatum = DateTime.Now;

        public const int DIT_IS_EEN_CONSTANTE = 34;

        public readonly Exception myException;

        public Student(string naam, int cijfer) : base(naam)
        {
            Cijfer = cijfer;
            _isAfgestudeerd = false;

            myException = new Exception();
        }


        public int Cijfer { get; set; }
        

        public override string ToString()
        {
            return string.Format("{0} en cijfer: {1}", base.ToString(), this.Cijfer);
        }
    }

    struct MyStruct
    {
        public int X, Y;

        public MyStruct(int x) : this()
        {
            X = x;
        }
    }

    class PrivateConstructorDemo
    {
        private int _field;

        private static readonly int _staticreadonlyfield;

        static PrivateConstructorDemo()
        {
            _staticreadonlyfield = 5;
        }

        private PrivateConstructorDemo()
        {

        }

        public static PrivateConstructorDemo Create()
        {
            var p = new PrivateConstructorDemo();
            
            // Kan dus bij de private fields van de instance!
            p._field = 3;

            return p;
        }

        public override bool Equals(object obj)
        {
            var p2 = obj as PrivateConstructorDemo;
            if (p2 == null)
            {
                return false;
            }

            // Kan dus bij de private fields van een andere instance!
            return this._field == p2._field;

        }
    }

    public class Class1
    {
        static void Main(string[] args)
        {
            var pcd = PrivateConstructorDemo.Create();

            MyStruct s = new MyStruct(5);
            Console.WriteLine(s.X);

            Student p = new Student("Manuel", 7);
            //Print(p);

            object o = 4;
            int i = o as int? ?? -1;

            Console.WriteLine(i is object);

            //string s = "3";
            //object o2 = s;
            //int i2 = (int)o2;
        }

        private static void Print(Persoon p)
        {
            if (p.GetType() == typeof(Student))
            {
                Student s = (Student)p;
                Console.WriteLine(s.Cijfer);
            }

            if (p is Student)
            {
                Student s = (Student)p;
                Console.WriteLine(s.Cijfer);
            }
            Student s2 = p as Student;
            if (s2 != null)
            {
                Console.WriteLine(s2.Cijfer);
            }

            Console.WriteLine(p.ToString());
        }
    }
}
