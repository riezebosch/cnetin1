using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Library
{
    public class Betaalrekening : IBankAccount
    {
        public Betaalrekening()
        {
        }

        public decimal Saldo { get; set; }

        public void Stort(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}
