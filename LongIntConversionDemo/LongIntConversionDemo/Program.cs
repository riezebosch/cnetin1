using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongIntConversionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            checked
            {
                long l = long.MaxValue;
                int i = (int)l;

                Console.WriteLine(i); 
            }
        }
    }
}
