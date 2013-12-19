using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    class Program
    {
        /// <summary>
        /// Hallo...
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="System.ArithmeticException" />
        static void Main(string[] args) 
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            int j = int.MaxValue;
            Console.WriteLine(j);

            checked
            {
                Console.WriteLine(++j); 
            }

            return;

            int i = 34;
            try
            {
                throw new Exception();
                i++;
                Console.WriteLine("Dit is nog in de try");
                throw new ArithmeticException("Er is iets misgegaan");
                Console.WriteLine("Dit wordt nooit meer uitgevoerd");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dit is in de exception: {0}", ex.Message);
                Console.WriteLine(i);

                i++;
            }
            finally
            {
                Console.WriteLine("Dit is in de finally.");
                Console.WriteLine(i);
                i = 0;
            }



        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }
    }
}
