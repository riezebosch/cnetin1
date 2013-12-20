using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Library
{
    internal class Spaarrekening : IBankAccount
    {
        public decimal Saldo
        {
            get;
            private set;
        }

        public void Stort(decimal bedrag)
        {
            Saldo += bedrag;
        }

    }
}
