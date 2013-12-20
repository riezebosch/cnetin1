using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndGenericsDemo
{
    class Program
    {
        class MijnAutomatischeRedimArray<T> : IEnumerable
        {
            public static string WordtDezeGedeeld;

            T[] _items;

            public MijnAutomatischeRedimArray(int size)
            {
                _items = new T[size];
            }

            public T this[int index]
            {
                get 
                {
                    return _items[index];
                }
                set 
                {
                    if (index >= _items.Length)
                    {
                        T[] temp = new T[index + 1];
                        Array.Copy(_items, temp, _items.Length);
                        _items = temp;
                    }

                    _items[index] = value;
                }
            }

            public IEnumerator GetEnumerator()
            {
                //foreach (var item in _items)
                //{
                //    yield return item;
                //}

                return _items.GetEnumerator();
            }

            public static MijnAutomatischeRedimArray<T> Create()
            {
                return new MijnAutomatischeRedimArray<T>(50);
            }
        }

        static void Main(string[] args)
        {
            //int[] items = new int[3];
            //items[0] = 4;
            //items[1] = 2;
            //items[2] = 6;

            //int[] temp = new int[4];
            //Array.Copy(items, temp, items.Length);
            //items = temp;

            //items[3] = 6;

            MijnAutomatischeRedimArray<int> items = new MijnAutomatischeRedimArray<int>(3);
            items[0] = 4;
            items[1] = 2;
            items[2] = 6;

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            items[3] = 6;

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }


            MijnAutomatischeRedimArray<string> deelnemers = new MijnAutomatischeRedimArray<string>(5);
            deelnemers[0] = "Pietje";
            deelnemers[1] = "Jantje";

            // Kan nu geen integers meer inserten!
            deelnemers[3] = 5.ToString();

            foreach (var item in deelnemers)
            {
                Console.WriteLine(item);
            }

            foreach (int item in items)
            {
                Console.WriteLine(item * 3);
            }

            ArrayList oud = new ArrayList(5);
            oud.Add("string");
            oud.Add(4);

            List<int> nieuw = new List<int>(3);
            nieuw.Add(3);
            nieuw.Add(4);

            Console.WriteLine("Zijn deze twee collections van hetzelfde type?: {0}",
                items.GetType() == deelnemers.GetType());

            MijnAutomatischeRedimArray<int>.WordtDezeGedeeld = "Misschien niet";
            MijnAutomatischeRedimArray<string>.WordtDezeGedeeld = "Mogelijk wel";

            Console.WriteLine(MijnAutomatischeRedimArray<int>.WordtDezeGedeeld);
            Console.WriteLine(MijnAutomatischeRedimArray<string>.WordtDezeGedeeld);

            var dict = new Dictionary<string, int>();
            dict["manuel"] = 6;


            MijnAutomatischeRedimArray<int>.Create();

            int i = CreateInstance<int>();

            // Dit kan niet omdat string geen default constructor heeft
            // wat we hebben afgedwongen in de "generic constraints" 
            //string s = CreateInstance<string>();

            // Compare in Greatest omdat beide types de IComparable interface implementeren
            Console.WriteLine(Greatest(2, 5));
            Console.WriteLine(Greatest("een", "manuel"));
        }

        private static T CreateInstance<T>()
            where T: new()
        {
            return new T();
        }

        private static T Greatest<T>(T p1, T p2)
            where T: IComparable
        {
            if (p1 is int)
            {
                int x = (int)(object)p1;
            }

            if (p1 == null)
            {

            }
            if (p1.CompareTo(p2) >= 0)
            {
                return p1;
            }
            else
            {
                return p2;
            }
        }
    }
}
