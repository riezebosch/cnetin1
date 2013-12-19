using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CastOperatorDemo
{
    class Program : string
    {
        class BankAccount
        {
            public string Number { get; set; }

            public static implicit operator BankAccount(string input)
            {
                return new BankAccount { Number = input };
            }

            public static BankAccount operator +(BankAccount account, string input)
            {
                account.Number += input;
                return account;
            }
        }

        static void Main(string[] args)
        {
            var ba = new BankAccount { Number = "123456789" };
            BankAccount ba2 = "123456789";

            // Deze is lelijk omdat de + operator ook de oorspronkelijke instantie aanpast.
            ba = ba + "nog een string";

            // Voorbeeld waar toegepast in het .NET framework, druk op F12 om naar
            // de type definitie te gaan.
            XNamespace xmlns = "urn:www-infosupport-com:training:cnetin";


            int i2 = int.Parse("2");
            int i3 = Convert.ToInt32("3");
        }
    }
}
