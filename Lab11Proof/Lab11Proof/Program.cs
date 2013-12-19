using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11Proof
{
    class Program
    {
        static void Main(string[] args)
        {
            string accountNumber = Console.ReadLine();
            if (accountNumber.Length != 9)
            {
                throw new ArgumentException("Account number should contain 9 digits.");
            }

            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                // Better: char c = accountNumber[i]
                string sub = accountNumber.Substring(i, 1);
                int number;

                // Better: char.IsDigit --> (int)char.GetNumericValue
                if (!int.TryParse(sub, out number))
                {
                    string message = string.Format("Character at position {0} with value {1} is not a number.", i, sub);
                    throw new ArgumentException(message);
                }

                total += (9 - i) * number;
            }


            if (total % 11 == 0)
            {
                Console.WriteLine("Account number is VALID");
            }
            else
            {
                Console.WriteLine("Account number is INVALID");
            }

            Console.WriteLine("Super cool short Linq solution: {0}", 
                accountNumber.Select((c, j) => (int)char.GetNumericValue(c) * (9 - j)).Sum() % 11 == 0 ? "VALID" : "INVALID");

        }
    }
}
