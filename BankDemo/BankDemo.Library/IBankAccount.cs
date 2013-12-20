using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Library
{
    public interface IBankAccount
    {
        decimal Saldo { get; }

        void Stort(decimal bedrag);
    }
}
