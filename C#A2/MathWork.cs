using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// Prompts the user for two positive integers, then "does math" to those integers.
    /// 1. It prints the sum of the numbers within the given range.
    /// 2. It prints the even numbers in the given range.
    /// 3. It prints the uneven numbers in the given range.
    /// 4. It prints a multiplication-table 1-9.
    /// 5. It prints the square roots for all numbers within the given range.
    /// Primary constructor assigns a reference to an instance of the InputValidation-class to a private readonly field.
    /// </summary>
    /// <param name="validation">A reference to an instance of the InputValidation-class</param>
    internal class MathWork(InputValidation validation)
    {
        private readonly InputValidation validation = validation;

        /// <summary>
        /// Prompts the user for two positive integers, then uses a helper method to decide which one
        /// is biggest, so that they can be passed to other methods in order of number1 = smaller, number 2 = bigger.
        /// Prints out the sum of the numbers within the range.
        /// Calls a number of methods to execute the different functions and display the results of those.
        /// Prompts the user with a choice to either exit or do it all again at the end.
        /// 
        /// Contains two different methods for ensuring the first integer is smaller than the second one.
        /// I left the tuple-swap version in, but commented out, for learning purposes.
        /// </summary>
        public void Calculate()
        {
            Console.Clear();
            Console.WriteLine("       --- MATH WORKS ---");
            Console.WriteLine();

            Console.WriteLine("    Enter two positive integers to see the sum of all integers between them.");
            Console.WriteLine("    Please make the first integer smaller than the second one.");
            int number1 = validation.ValidateIntRange("Integer 1", 0, int.MaxValue); //kind of a big range... Everything above 1-15 looks very weird.
            int number2 = validation.ValidateIntRange("Integer 2", number1, int.MaxValue);

            /*if (Number1BiggestIfTrue(number1, number2) == true)
            {
                (number1, number2) = (number2, number1); //uses tuple logic to switch the values if number 1 is bigger than number 2
            }*/

            Console.WriteLine();
            Console.WriteLine("    The sum of numbers between " + number1.ToString() + " and " + number2.ToString() + " = " + SumNumbers(number1, number2).ToString());
            Console.WriteLine();

            PrintEvenNumbers(number1, number2);

            PrintOddNumbers(number1, number2);

            PrintMultiplicationTable();

            CalculateSquareRoots(number1, number2);

            if (ExitCalculation() == true)
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Calculate();
            }
        }

        /// <summary>
        /// Checks if number1 is bigger than number2 and returns a boolean value.
        /// </summary>
        /// <param name="number1">Holds the first user input from Calculate()</param>
        /// <param name="number2">Holds the second user input from Calculate()</param>
        /// <returns>true if number1 is bigger and needs to be switched, else false.</returns>
        private bool Number1BiggestIfTrue(int number1, int number2)
        {
            if (number1 > number2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates the square root of every number in the given range.
        /// Each iteration, as per the assignment, "calculates from the counter's current value to the end number".
        /// </summary>
        /// <param name="num1">Holds the smaller user input from Calculate()</param>
        /// <param name="num2">Holds the larger user input from Calculate()</param>
        private void CalculateSquareRoots(int num1, int num2)
        {
            Console.WriteLine();
            Console.WriteLine("       Square Roots!");
            Console.WriteLine();

            for (int i = num1; i <= num2; i++)
            {
                Console.Write("    Sqrt({0,2} to {0,2})", i, num2); //formatted string for the start of every line

                for (int j = i; j <= num2; j++)
                {
                    Console.Write("{0,6}", Math.Sqrt(j).ToString("F2")); //formatted string for every value to print
                }

                Console.WriteLine();

            }
        }

        /// <summary>
        /// Prints the even numbers in the given range to the console.
        /// </summary>
        /// <param name="number1">Holds the smaller user input from Calculate()</param>
        /// <param name="number2">Holds the larger user input from Calculate()</param>
        private void PrintEvenNumbers(int number1, int number2)
        {
            Console.WriteLine();

            Console.WriteLine("    Even numbers between " + number1 + " and " + number2);

            Console.Write("    ");
            for (int i = number1; i <= number2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i.ToString() + "  ");
                }
            }

            Console.WriteLine();

        }

        /// <summary>
        /// Prints a multiplication table (1-9).
        /// </summary>
        private void PrintMultiplicationTable()
        {
            int sizeOfTable = 9;

            Console.WriteLine();
            Console.WriteLine("       Multiplicationtable!");
            Console.WriteLine();

            Console.Write("     ");
            for (int i = 1; i <= sizeOfTable; i++)
            {
                Console.Write("{0, 4}", i); //prints the top numbers
            }
            
            Console.WriteLine();
            Console.WriteLine("        ---------------------------------"); //to visually split the top numbers from the table

            for (int row = 1; row <= sizeOfTable; row++)
            {
                Console.Write("{0, 4}:", row); //prints the start of each row

                for (int col = 1; col <= sizeOfTable; col++)
                {
                    Console.Write("{0, 4}", + row * col); //prints each row
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints odd numbers within the given range.
        /// </summary>
        /// <param name="number1">Holds the smaller user input from Calculate()</param>
        /// <param name="number2">Holds the larger user input from Calculate()</param>
        private void PrintOddNumbers(int number1, int number2)
        {
            Console.WriteLine();

            Console.WriteLine("    Odd numbers between " + number1 + " and " + number2);

            Console.Write("    ");
            for (int i = number1; i <= number2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i.ToString() + "  ");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sums all the numbers within the given range. 
        /// </summary>
        /// <param name="start">Holds the smaller user input from Calculate()</param>
        /// <param name="end">Holds the larger user input from Calculate()</param>
        /// <returns>Returns the sum as an int</returns>
        public int SumNumbers(int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += i;
            }

            return sum;
        }

        /// <summary>
        /// Propmpts the user for a yes/no answer as to whether they want to return to the main menu or not.
        /// </summary>
        /// <returns>true if answer is "y", else false</returns>
        private bool ExitCalculation()
        {
            Console.WriteLine();
            Console.WriteLine("    Return to main menu?");
            Console.WriteLine("    Please answer y/n");
            Console.WriteLine();

            if (validation.YesOrNoString("Answer") == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
