using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedListDemo
{
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SortedList<int> {4, 2, 15, 3 };

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
