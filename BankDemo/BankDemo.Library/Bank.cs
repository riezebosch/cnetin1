using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Library
{
    public class Bank
    {
        public IBankAccount OpenAccount()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                return new Spaarrekening();
            }

            return new Betaalrekening();
        }
    }
}
