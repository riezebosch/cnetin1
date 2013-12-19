using EenAndereNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.EenGenesteNamespace
{
    namespace NogEenNiveautjeDieper
    {
         /// <summary>
         /// Kijk eens wat een goede beschrijving op deze class.
         /// Let goed op! Want deze class bevat ons entry point van de applicatie!
         /// </summary>
        class Program
        {
            public static DateTime MyNow { get; set; }

            static void Main(string[] args)
            {
                MyClass bestelling = new MyClass();
                bestelling.BestelMijnSnackVoorTussenDeMiddag(MijnOpties.Kroket | MijnOpties.Frikandel) ;
            }
        }
    }
}

namespace EenAndereNamespace
{
    [Flags]
    enum MijnOpties
    {
        Frikandel = 1, 
        Frikapdel = 1,
        Kroket = 2, 
        Gehaktbal = 4, 
        Vegetarisch = 8 , 
        Overige = 16,
        Allemaal = 31
    }

    class MyClass
    {
        ConsoleApplication1.EenGenesteNamespace.NogEenNiveautjeDieper.Program program;

        public void BestelMijnSnackVoorTussenDeMiddag(MijnOpties optie)
        {
            if ((MijnOpties.Frikandel & optie) == MijnOpties.Frikandel)
            {
                Console.WriteLine("Hoera voor de Frikandel");
            }
            Console.WriteLine(optie);
        }

        public void BestelMijnSnackVoorTussenDeMiddag(MijnOpties optie, string naam)
        {

        }
    }
}