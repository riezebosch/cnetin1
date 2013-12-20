using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedListDemo
{
    delegate bool RemoveDelegate<T>(T item);

    class SortedList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        public void Add(T item)
        {
            var current = _items.First;

            while (current != null &&  current.Value.CompareTo(item) < 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                _items.AddLast(item);
            }
            else
            {
                _items.AddBefore(current, item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(RemoveDelegate<T> check)
        {
            var current = _items.First;
            while (current != null)
            {
                var next = current.Next;
                if (check(current.Value))
                {
                    _items.Remove(current);
                }

                current = next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SortedList<int> { 1, 2, 2, 3, 4};

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(", ", list));

            list.Remove(IsEven);

            // Dit is precies hetzelfde maar dan met een "anonymous method"
            list.Remove(delegate(int item) { return item % 2 == 0; });

            // Dit is precies hetzelfde maar dan met een Lambda van Linq
            list.Remove(item => item % 2 == 0);

            Console.WriteLine(string.Join(", ", list));

            list.Remove(IsGreaterThanFive);
            Console.WriteLine(string.Join(", ", list));
        }

        static bool IsEven(int item)
        {
            return item % 2 == 0;
        }

        static bool IsGreaterThanFive(int item)
        {
            return item > 5;
        }
    }
}
