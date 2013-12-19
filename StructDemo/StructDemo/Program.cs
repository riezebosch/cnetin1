using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{
    public class Employee
    {
        public string firstName;
        public int age;

        public void UpdateAge(int newAge)
        {
            int calc = age + newAge - 31 * 16;
            age = newAge;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.age = 31;
            emp.firstName = "Manuel";

            emp.UpdateAge(32);

            Console.WriteLine(emp.firstName);
            Console.WriteLine(emp.age);

            Employee emp2 = emp;
            emp2.firstName = "Pietje";

            Console.WriteLine(emp.firstName);
        }
    }
}
