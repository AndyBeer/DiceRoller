using System;

namespace Wk1ExtraLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dice Rolling program requirements:
            //1.0 prompt user to enter # of sides for a pair of dice
            //1.1 Challenge #2: validate user's input.  Continue to prompt until a valid input provided by user
            //2.0 take and store # of sided dice
            //3.0 prompt user to roll dice
            //4.0 2 * n-sided dice "roll" using random number class
            //5.0 display results of each
            //6.0 Continue loop to try again
            //7.0 Challenge #1: Use DiceRollerApp class to display special messages for craps, snake eyes and box cars (?)

            bool keepGoing = true;
            bool rollDice = true;
            int userSides;
            int i = 1;
            int j;
            int numDice;

            Console.WriteLine($"\nWelcome to the D&D Dice Roller!!\n");
            
            ContinueLoop("Ready to roll some dice?  y/n");
            
            while (keepGoing)
            {
                userSides = ValidateInteger();
                numDice = HowManyDice();

                while (rollDice)
                {
                    Console.WriteLine($"Roll #{i}", i++);
                    for (j = 1; j <= numDice; j++)
                    {
                        Console.WriteLine(RollingDice(userSides));
                    }
                    break;
                }
                keepGoing = ContinueLoop("Would you like to roll again? y/n");
            }

        }
        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string output = Console.ReadLine();

            return output;
        }
        public static bool ContinueLoop(string question)
        {
            string answer = GetInput(question);
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.WriteLine("OK, goodbye!");
                return false;
            }
            else
            {
                return ContinueLoop("I'm sorry, I didnt catch that.  Please input y to try again, or n to exit.");
            }
        }
        public static bool ContinueRollDice(string input)
        {
            string answer = GetInput(input);
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.WriteLine("OK.  Goodbye!");

                return false;
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid response.\nPlease input y to roll dice, or n to start over.");
                return ContinueRollDice(input);
            }
        }
        public static int ValidateInteger()
        {
            string answer = GetInput("How many sides should each die have?");
            int output;
            if (int.TryParse(answer, out output) && output > 0)
            {
                return output;
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid response.  Please use a positive integer and try again.");
                return ValidateInteger();
            }
        }
        public static int RollingDice(int sidesOfDice)
        {
            Random rnd = new Random();

            int dieRoll = rnd.Next(1, (sidesOfDice + 1));

            if (dieRoll == sidesOfDice)
            {
                Console.Write("Critical Hit!---  ");
            }
            else if (dieRoll ==1)
            {
                Console.Write("Critical FAIL...  ");
            }

            return dieRoll;
        }
        public static int HowManyDice()
        {
            string answer = GetInput("How many dice are you looking to roll?");
            int diceNum;

            if (int.TryParse(answer, out diceNum) && diceNum > 0)
            {
                return diceNum;
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid response.  Please use a positive integer and try again.");
                return HowManyDice();
            }
        }
    }
}

