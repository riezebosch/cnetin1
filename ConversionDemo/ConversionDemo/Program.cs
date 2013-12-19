using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 3;
            long l = i;

            i = (int)l;

            //string s = "manuel";
            //i = (int)(object)s;

            int? n = null;
            if (n == null)
            {
                Console.WriteLine("n is een value type, maar wel degelijk null!?!?!?!");
            }

            Nullable<int> n2 = new Nullable<int>();
            if (!n2.HasValue)
            {
                Console.WriteLine("Oh, zo werkt dat dus!");
            }
            else
            {
                Console.WriteLine(n2.Value);
            }

        }
    }
}
