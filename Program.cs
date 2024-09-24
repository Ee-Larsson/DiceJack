using System.Runtime.InteropServices;

namespace DiceJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int d6 = rand.Next(1, 7);
            Console.WriteLine("Welcome to the game of DiceJack! Mind telling me your name?");

            string ap = Console.ReadLine();

            Console.WriteLine("Alright, " + ap + ", do you know the rules of the game?");
            string rules = Console.ReadLine();
            while (rules == "no" || rules == "nope" || rules == "No" || rules == "Nope" || rules == "negative" || rules == "Negative" || rules == "No clue" || rules == "no clue")
            {
                Console.WriteLine("Very well, the rules are as follows");
                Console.WriteLine("You roll the dice, the number it lands on gets added to your total amount of points");
                Console.WriteLine("The goal is to get as close as possible to 21 points, while also staying below 21");
                Console.WriteLine("Do you understand the rules now?");
                rules = Console.ReadLine();
            }

            int pp = 0;
            int dp = 0;

            Console.WriteLine("How much money do you want to bet?");
            int bettingMoney = int.Parse(Console.ReadLine());

            string bettingAnswer = "";

            if (bettingMoney == 0)
            {
                Console.WriteLine("Are you not planning on betting anything!?");
                bettingAnswer = Console.ReadLine();
            }
            if (bettingAnswer != "no" && bettingAnswer != "nope" && bettingAnswer != "No" && bettingAnswer != "Nope" && bettingAnswer != "negative" && bettingAnswer != "Negative" && bettingAnswer != "I don't plan on gambling" && bettingAnswer != "No I don't")
            {
                Console.WriteLine("We shall now start the game");
                while (ap != "no")
                {
                    while (ap != "stop")
                    {
                        Console.WriteLine("Do you wish to continue or stop?");
                        ap = Console.ReadLine();
                        if (ap == "stop")
                        {
                            break;
                        }
                        d6 = rand.Next(1, 7);
                        Console.WriteLine("You rolled " + d6 + "!");
                        pp += d6;

                        while (dp < 17)
                        {
                            d6 = rand.Next(1, 7);
                            Console.WriteLine("The dealer rolled " + d6 + "!");
                            dp += d6;
                            break;
                        }


                        Console.WriteLine("Your total amount of points is " + pp + ". The dealers total amount of points is " + dp + ".");
                        if (pp >> dp >= 22 || dp >> pp >= 22)
                        {
                            break;
                        }
                        else if (pp >= 22)
                        {
                            break;
                        }
                        else if (dp >= 22)
                        {
                            break;
                        }
                        else if (pp == 21 && dp == 21)
                        {
                            break;
                        }
                        else if (pp == 21)
                        {
                            break;
                        }
                        else if (dp == 21)
                        {
                            break;
                        }
                    }
                    if (pp >> dp >= 22 || dp >> pp >= 22)
                    {
                        Console.WriteLine("Both of you are above 21, looks like it's a draw");
                        Console.WriteLine("Your money remains as " + bettingMoney);
                    }
                    else if (pp >= 22)
                    {
                        bettingMoney = bettingMoney / 2;
                        Console.WriteLine("Your total amount of points is above 21, the dealer wins.");
                        Console.WriteLine("You money has decreased to " + bettingMoney);
                    }
                    else if (dp >= 22)
                    {
                        bettingMoney = bettingMoney * 2;
                        Console.WriteLine("The dealer's amount of points is above 21, which means that you win this round.");
                        Console.WriteLine("You money has increased to " + bettingMoney);
                    }
                    else if (pp == 21 && dp == 21)
                    {
                        Console.WriteLine("You both have landed on exactly 21 points, it's a draw.");
                        Console.WriteLine("Your money remains as " + bettingMoney);
                    }
                    else if (pp == 21)
                    {
                        bettingMoney = bettingMoney * 2;
                        Console.WriteLine("You have landed on exactly 21 points, congratulations you win.");
                        Console.WriteLine("You money has increased to " + bettingMoney);
                    }
                    else if (dp == 21)
                    {
                        bettingMoney = bettingMoney / 2;
                        Console.WriteLine("The dealer has landed on exactly 21 points, they win.");
                        Console.WriteLine("You money has decreased to " + bettingMoney);
                    }
                    else if (21 > dp && dp > pp)
                    {
                        bettingMoney = bettingMoney / 2;
                        Console.WriteLine("The dealer's amount of points is closer to 21 than yours which means that they win.");
                        Console.WriteLine("You money has decreased to " + bettingMoney);
                    }
                    else if (21 > pp && pp > dp)
                    {
                        bettingMoney = bettingMoney * 2;
                        Console.WriteLine("Your total amount of points is closer to 21 than the dealers, which means that you won.");
                        Console.WriteLine("You money has increased to " + bettingMoney);
                    }
                    else if (pp == dp)
                    {
                        Console.WriteLine("You and the dealer have the same amount of points, looks like it's a draw");
                        Console.WriteLine("Your money remains as " + bettingMoney);
                    }
                    Console.WriteLine("Do you wish to play another game of DiceJack?");
                    ap = Console.ReadLine();
                    dp = 0;
                    pp = 0;
                }
            }
            else
            {
                Console.WriteLine("Since you don't plan on betting anything then I must ask you to please fuck off.");
            }
        }
        }
    }
