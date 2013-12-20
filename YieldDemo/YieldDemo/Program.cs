using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldDemo
{
    class Program
    {
        static IEnumerable ForMetYieldReturn()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return i;
            }

            yield return 250;
            yield return "aap";
        }


        class MijnEigenGeschrevenEnumeratorDieNormaalDoorDeCompilerGegenereerdWordt 
            : IEnumerable, IEnumerator
        {
            public IEnumerator GetEnumerator()
            {
                Current = 0;
                return this;
            }

            public object Current
            {
                get;
                private set;
            }

            public bool MoveNext()
            {
                if (Current is int)
                {
                    if ((int)Current < 250)
                    {
                        Current = ((int)Current) + 1;
                        return true;
                    }

                    if ((int)Current == 250)
                    {
                        Current = "aap";
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                Current = 0;
            }
        }


        static IEnumerable ForMetEigenGeschrevenEnumerator()
        {
            return new MijnEigenGeschrevenEnumeratorDieNormaalDoorDeCompilerGegenereerdWordt();
        }

        static void Main(string[] args)
        {
            foreach (var item in ForMetYieldReturn())
            {
                Console.WriteLine(item);
            }

            foreach (var item in ForMetEigenGeschrevenEnumerator())
            {
                Console.WriteLine(item);
            }
        }
    }
}
