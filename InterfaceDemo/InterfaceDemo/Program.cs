using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {
        interface I1
        {
            void P();
        }

        interface I2
        {
            int P();
        }

        class ConflictInterfaceDemo : I1, I2
        {
            public void P()
            {

            }

            int I2.P()
            {
                return 1;
            }
        }

        interface IMyStruct
        {
            int MyProperty { get; set; }
        }

        struct MyStruct : IMyStruct
        {
            public int MyProperty { get; set; }
        }


        class MijnClass : IDisposable
        {
            void IDisposable.Dispose()
            {
            }
        }

        static void Main(string[] args)
        {
            var disp = new MijnClass();
            
            // Rechtstreeks aanroepen kan niet meer omdat IDisposable excpliciet is geimplementeerd.
            //disp.Dispose();

            // Maar mag dus wel nog via de interface
            ((IDisposable)disp).Dispose();

            // Dit mag omdat MijnClass wel degelijk IDisposable implementeert
            using (new MijnClass())
            {
            }

            // Deze truc is vooral nuttig bij conflicterende interfaces
            new ConflictInterfaceDemo().P();
            Console.WriteLine(((I2)new ConflictInterfaceDemo()).P());

            MyStruct m = new MyStruct();
            m.MyProperty = 4;

            IMyStruct m1 = m;
            IMyStruct m2 = m1;


            // Een struct wordt geboxt als hij in een interface gestopt wordt
            m1.MyProperty = 5;
            Console.WriteLine(m.MyProperty);
            Console.WriteLine(m1.MyProperty);
            Console.WriteLine(m2.MyProperty);

            MyStruct m3 = (MyStruct)m2;
            m2.MyProperty = 7;

            Console.WriteLine(m1.MyProperty);
            Console.WriteLine(m2.MyProperty);
            Console.WriteLine(m3.MyProperty);
        }
    }
}
