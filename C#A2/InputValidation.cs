using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// Helper methods for handling validation of input for all classes, to avoid faulty input according to
    /// method parameters and null values.
    /// </summary>
    internal class InputValidation
    {
        /// <summary>
        /// Used to ensure that string input that is supposed to be used as an integer is NOT null and
        /// IS an integer.
        /// </summary>
        /// <param name="question">What the input is called according to the context of the question, for example "Menu choice"</param>
        /// <returns>A valid integer</returns>
        public int ValidateInt(string question)
        {
            string? inputAsString;

            while (true)
            {
                Console.Write("    " + question + ":");
                inputAsString = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(inputAsString) == true)
                {
                    Console.WriteLine("    " + question + " can not be null");
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    continue;
                }

                if (int.TryParse(inputAsString, out int validInput) == true)
                {
                    return validInput;
                }
                else
                {
                    Console.WriteLine("    " + question + " has to be a valid integer");
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        /// <summary>
        /// Attempts to validate an int that has to be within a certain range.
        /// </summary>
        /// <param name="question">What the input is called according to the context of the question, for example "Menu choice"</param>
        /// <param name="min">The minimum integer value allowed</param>
        /// <param name="max">The maximum integer value allowed</param>
        /// <returns>A valid integer</returns>
        public int ValidateIntRange(string question, int min, int max)
        {
            int val;
            
            do
            {
                val = ValidateInt(question); //calls the ValidateInt() method first to ensure a valid integer

                if (val < min || val > max) //this if statement is needed to provide user feedback, it does not affect the functionality of this method
                {
                    Console.WriteLine("    Integer has to be a value between " + min.ToString() + " and " + max.ToString());
                }
            } while (val < min || val > max); //do while(integer is not within valid range)

            return val; //returns validated integer
        }

        /// <summary>
        /// Used to ensure that string input is NOT null, and is NOT an integer or floating point number
        /// </summary>
        /// <param name="question">What the input is called according to the context of the question, for example "Menu choice"</param>
        /// <returns>A valid string</returns>
        public string ValidateString(string question)
        {
            string? input;

            while (true)
            {
                Console.Write("    " + question + ":");
                input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input) == true)
                {
                    Console.WriteLine("    " + question + " can not be null");
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    continue;
                }

                if (double.TryParse(input, out double doubleTrash) == true) //double.TryParse covers both floating-point numbers and integers
                {
                    Console.WriteLine("    " + question + " has to be a valid string");
                    Console.WriteLine("    Press enter to continue");
                    Console.ReadLine();
                    continue;
                }

                return input;
            }
        }

        /// <summary>
        /// Used for validating yes/no choices in the program.
        /// Basically adds a condition to the ValidateString() method.
        /// </summary>
        /// <param name="question">What the input is called according to the context of the question, for example "Menu choice"</param>
        /// <returns>A valid "y" or "n" string</returns>
        public string YesOrNoString(string question)
        {
            string? output;

            do
            {
                output = ValidateString(question);

                if (output != "y" && output != "n")
                {
                    Console.WriteLine("    " + question + " has to be y/n");
                }

            } while (output != "y" && output != "n"); //do while(return value from ValidateString() is not "y" or "n")

            return output;
        }
    }
}
