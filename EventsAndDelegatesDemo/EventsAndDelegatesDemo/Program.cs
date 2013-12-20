using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsAndDelegatesDemo
{
    delegate void Execute(string message);

    class AndereClass
    {
        public void ShowDialog(string message)
        {
            MessageBox.Show(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Execute callback = new Execute(Print);
            callback += new Execute(Print);
            callback += Save;
            callback += new Execute(Console.WriteLine);

            callback += new Execute(new AndereClass().ShowDialog);
            callback += delegate(string message) 
            { 
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine(message); 
                Console.ForegroundColor = ConsoleColor.Gray; 
            };

            callback += message => Console.WriteLine(message + " vanuit een lambda");

            callback("Hoi");
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void Save(string message)
        {
            using (var writer = File.AppendText("output.log"))
            {
                writer.WriteLine(message);
            }
        }
    }
}
