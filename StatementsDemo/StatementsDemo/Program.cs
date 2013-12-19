using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementsDemo
{
    enum Suit { Clubs, Hearts, Diamonds, Spades }
    class Program
    {
        static void Main(string[] args)
        {
            Suit trumps = Suit.Clubs;
            switch (trumps)
            {
                case Suit.Clubs:
                case Suit.Hearts:
                    Console.WriteLine("ik heb geen verstand van kaartspelletjes");
                    if (DateTime.Now.Year == 2013)
                    {
                        break;
                    }

                    Console.WriteLine("Welkom in 2014" );
                    break;
                case Suit.Diamonds:
                    break;
                case Suit.Spades:
                    break;
                default:
                    break;
            }

            string input = "manuel";
            switch (input)
            {
                case "manuel":
                    Console.WriteLine("Welkom bij CNETIN");
                    break;
                case "janpeter":
                    Console.WriteLine("Welkom bij SharePoint");
                    break;
                default:
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //int i = 5;
            //Console.WriteLine(i);


            

        }
    }
}
