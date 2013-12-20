//#define HALLO
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    class ElevenProofAttribute : Attribute
    {

    }

    class MaxLengthAttribute : Attribute
    {
        public string Pattern { get; private set; }

        public MaxLengthAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public int Length { get; set; }

        
    }

    class Program
    {
        class Persoon
        {
            [ElevenProof]
            public string BurgerServiceNummer { get; set; }

            [MaxLength("#### ?? ####", Length = 50)]
            public string Name { get; set; }

            [MaxLength("####", Length = 10)]
            public string Koosnaampje { get; set; }
        }

        static void Main(string[] args)
        {
#if DEBUG
            foreach (var prop in typeof(Persoon).GetProperties())
            {
                Console.WriteLine("Property: {0}", prop.Name);
                foreach (object attr in prop.GetCustomAttributes(true))
                {
                    Console.WriteLine("  Attribute: {0}", attr.GetType().Name);
                    MaxLengthAttribute length = attr as MaxLengthAttribute;
                    if (length != null)
                    {
                        Console.WriteLine("  Length: {0}, Pattern: {1}", length.Length, length.Pattern);
                    }
                }
            }
#endif

            DitIsAlleenNuttingBijDebugging("HALLO, CNETIN!");
            Debug.Write("Hoi, Debug.Write");

            int resultaat = MoeilijkeBerekeningMaarAlleenInDebugRelevant();
            Console.WriteLine(resultaat);

            MoeilijkeBerekeningMaarAlleenInDebugRelevant(out resultaat);
            Console.WriteLine(resultaat);
        }

        [Conditional("DEBUG")]
        private static void DitIsAlleenNuttingBijDebugging(string message)
        {
            Console.WriteLine(message);
        }

        // Kan alleen op void methods
        //[Conditional("DEBUG")]
        private static int MoeilijkeBerekeningMaarAlleenInDebugRelevant()
        {
            return 3;
        }

        // Kan niet op out parameters
        //[Conditional("DEBUG")]
        private static void MoeilijkeBerekeningMaarAlleenInDebugRelevant(out int result)
        {
            result = 3;
        }

    }
}
