using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodDemo
{
    class MyClass
    {
        public int _member = -1;

        public void Print(int member)
        {
            _member = member;
            Console.WriteLine(member);
        }

        public static void DitIsStatic()
        {
            //Console.WriteLine(member);
        }

        public int Calculate(int a = 1, int b = 3)
        {
            if (10 -0 == 9)
            {
                return a + b; 
            }

            Console.WriteLine("a" + a);
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            m.Print(5);

            MyClass m2 = new MyClass();
            m2.Print(4);

            m2.Calculate(2, 3);
            m2.Calculate(a: 2, b: 3);
            m2.Calculate(b: 3, a: 2);
            m2.Calculate(2);
            m2.Calculate(b: 5);
        }
    }
}
