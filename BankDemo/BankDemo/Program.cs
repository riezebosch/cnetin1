using BankDemo.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            IBankAccount rekening = bank.OpenAccount();
            rekening.Stort(100m);

            Console.WriteLine(rekening.Saldo);
        }
    }
}
