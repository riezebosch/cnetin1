using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    delegate int MijnEigenDelegate(string input);

    class Program
    {
        static void Main(string[] args)
        {
            DoeIetsMetMijnEigenDelegate(DezeMethodeVoldoetAanDeSignatuurVanMijnEigenDelegate);
            DoeIetsMetMijnEigenDelegate(EenAnderVoorbeeld);
        }

        static int DezeMethodeVoldoetAanDeSignatuurVanMijnEigenDelegate(string invoer)
        {
            Console.WriteLine(invoer);
            return 4;
        }

        static int EenAnderVoorbeeld(string invoer)
        {
            if (invoer == "een")
                return 1;
            if (invoer == "twee")
                return 2;

            return -1;
        }

        static void DoeIetsMetMijnEigenDelegate(MijnEigenDelegate methode)
        {
            int result = methode("twee");
            Console.WriteLine(result);
        }
    }
}
