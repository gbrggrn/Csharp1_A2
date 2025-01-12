using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// The user can decide to either enter a string and learn its' length or "predict their day" through
    /// a series of predetermined comments about weekdays.
    /// Primary constructor assigns a reference to an instance of the InputValidation-class to a private readonly field.
    /// </summary>
    /// <param name="validation">A reference to an instance of the InputValidation-class</param>
    internal class StringFunctions(InputValidation validation)
    {
        private readonly InputValidation validation = validation;

        /// <summary>
        /// Displays the submenu for this class, and prompts the user for a choice through calling a method
        /// from the InputValidation-class. A switch statement with the user input as argument is then
        /// used to control the flow of the class.
        /// </summary>
        public void SubMenuStringFunctions()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("       --- FUN WITH STRINGS! ---");
                Console.WriteLine();
                Console.WriteLine("    1. Get the length of any string!");
                Console.WriteLine("    2. Let me predict your day!");
                Console.WriteLine("    3. No more fun with strings, main menu please.");
                Console.WriteLine();

                int choice = validation.ValidateIntRange("Menu choice", 1, 3);

                switch (choice)
                {
                    case 1:
                        StringLength();
                        break;
                    case 2:
                        PredictMyDay();
                        break;
                    case 3:
                        Console.Clear();
                        return;
                }
            }
        }

        /// <summary>
        /// Propmpts the user for a string of any length, validates that input, then calculates the
        /// length of it using the generic method .Length and assigns that value to an int variable.
        /// Prints the length of the string.
        /// </summary>
        private void StringLength()
        {
            Console.Clear();
            Console.WriteLine("       --- STRING LENGTH CALCULATOR! ---");
            Console.WriteLine();
            Console.WriteLine("    Please enter a string of any length below:");

            string? stringToCalculate = validation.ValidateString("String");

            int lengthOfString = stringToCalculate.Length;

            Console.WriteLine();
            Console.WriteLine("    Your string is " + lengthOfString + " characters long");
            Console.WriteLine();
            Console.WriteLine("    Press enter to return");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        /// <summary>
        /// Prompts the user for an integer between 1-7, validates that input, then uses it as
        /// an argument for a switch statement where the cases contain the specific predetermined 
        /// comments about weekdays.
        /// </summary>
        private void PredictMyDay()
        {
            Console.Clear();
            Console.WriteLine("       --- LET'S PREDICT YOUR DAY! ---");
            Console.WriteLine();
            Console.WriteLine("    Please enter an integer between 1 and 7");
            Console.WriteLine();

            int choice = validation.ValidateIntRange("Integer", 1, 7);

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("    Keep calm on Mondays! You can fall apart!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("    Tuesdays and Wednesdays break your heart!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("    Tuesdays and Wednesdays break your heart!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("    Thursday is your lucky day, don't wait for Friday!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("    Friday, you are in love!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine("    Saturday, do nothing and do plenty of it!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 7:
                    Console.WriteLine();
                    Console.WriteLine("    And Sunday always comes too soon!");
                    Console.WriteLine();
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
    }
}
