using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            int[] items = new int[2];
            items[0] = 6;
            items[1] = 3;

            int[] temp = new int[3];
            Array.Copy(items, temp, items.Length);
            items = temp;

            int[] clone1 = (int[])items.Clone();
            int[] clone2 = (int[])items;

            items = new int[3];
            items[2] = 5;

            Console.WriteLine("Length: {0}, Rank: {1}", items.Length, items.Rank);

            int[, ,] multi = new int[2, 3, 5];
            multi[0, 0, 0] = 1;
            multi[0, 1, 0] = 2;

            Console.WriteLine(multi[0, 0, 0]);

            Console.WriteLine("Length: {0}, Rank: {1}, GetLength: {2}", multi.Length, multi.Rank, multi.GetLength(1));

            int i1 = 5;
            var i2 = 5;
            object i3 = 5;

            i3 = "opeens een string";
            //i2 = "opeens een string";

            int[] items1 = new int[] { 1, 2, 3, 4 };
            int[] items2 = new[] { 1, 2, 3, 4 };
            int[] items3 = { 1, 2, 3, 4 };

            //var items4 = { 1, 2, 3, 4 };
            var items4 = new[] { 1, 2, 3, 4 };

            int[][] arrays = new int[2][];
            arrays[0] = new[] { 2, 3 };
            arrays[1] = new[] { 2, 3, 4 };

            Console.WriteLine(arrays[0][0]);

            int[] kandit = new int[3] { 1, 2, 3, 4 };
        }
    }
}
