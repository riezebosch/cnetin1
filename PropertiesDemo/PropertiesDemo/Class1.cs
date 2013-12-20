using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesDemo
{
    public class Class1
    {
        public int AutoImplementedProperty { get; set; }

        private int _fullProperty;

        public int FullProperty
        {
            get { return _fullProperty; }
            set { _fullProperty = value; }
        }



        private int _zoDoenZeHetInJavaProperty;
        public void SetZoDoenZeHetInJavaProperty(int value)
        {
            _zoDoenZeHetInJavaProperty = value;
        }

        public int GetZoDoenZeHetInJavaProperty()
        {
            return _zoDoenZeHetInJavaProperty;
        }

        int[] _items = new int[16];

        public string this[int input, double d2]
        {
            get
            {
                return _items[input].ToString();
            }
        }

        static void Main(string[] args)
        {
            var c = new Class1();
            var s = c[3, 3.0];

            List<int> lijstje = new List<int>();
            lijstje.Add(1);

            int getal = lijstje[0];
        }
    }
}
