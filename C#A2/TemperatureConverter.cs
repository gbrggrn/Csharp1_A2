using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// The user can decide to display either a Fahrenheit to Celcius conversion or the other way around.
    /// Utilizes two arrays of doubles to hold the converted temperature values.
    /// The arrays are initialized and populated when the constructor is called at the start of the program
    /// essentially pre-loading them before the user enters the class.
    /// </summary>
    internal class TemperatureConverter
    {
        private readonly InputValidation validation;
        private readonly double[] celciusArr = new double[21];
        private readonly double[] fahrenheitArr = new double[21];
        private bool fahrenheitIfTrue;

        /// <summary>
        /// Constructor assigns a reference to an instance of validation to a private readonly field,
        /// then calls two methods to populate the arrays of doubles with converted temperature values.
        /// </summary>
        /// <param name="validation">A reference to an instance of the InputValidation-class</param>
        public TemperatureConverter(InputValidation validation)
        {
            this.validation = validation;

            PopulateCelciusArr(celciusArr);
            PopulateFahrenheitArr(fahrenheitArr);
        }

        /// <summary>
        /// Displays the submenu for this class, and prompts the user for a choice through calling a method
        /// from the InputValidation-class. A switch statement with the user input as argument is then
        /// used to control the flow of the class.
        /// </summary>
        public void SubMenuConverter()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("       --- Convert Temperatures between Celcius and Fahrenheit ---");
                Console.WriteLine();
                Console.WriteLine("    1. Display Fahrenheit to Celcius");
                Console.WriteLine("    2. Display Celcius to Fahrenheit");
                Console.WriteLine("    3. Return to the main menu");
                Console.WriteLine();

                int choice = validation.ValidateIntRange("Menu choice", 1, 3);

                switch (choice)
                {
                    case 1:
                        fahrenheitIfTrue = true;
                        Conversion("Fahrenheit", "Celcius", celciusArr);
                        break;
                    case 2:
                        fahrenheitIfTrue = false;
                        Conversion("Celcius", "Fahrenheit", fahrenheitArr);
                        break;
                    case 3:
                        Console.Clear();
                        return;
                }
            }
        }

        /// <summary>
        /// Writes the title for this choice to the console and calls PrintConversion() to print the
        /// desired temperature conversion.
        /// </summary>
        /// <param name="fromTemp">The name of the temperature to convert from</param>
        /// <param name="toTemp">The name of the temperature to convert to</param>
        /// <param name="arrToPrint">The array of doubles containing the values to print</param>
        private void Conversion(string fromTemp, string toTemp, double[] arrToPrint)
        {
            Console.Clear();

            Console.WriteLine("       --- " + fromTemp + " to " + toTemp + " ---");
            Console.WriteLine();

            PrintConversion(arrToPrint);

            Console.WriteLine();
            Console.WriteLine("    Press enter to return");
            Console.ReadLine();
            Console.Clear();

        }

        /// <summary>
        /// Populates the celciusArr with converted values at an interval of every 10 degrees fahrenheit.
        /// The size of the array decides the span of degrees (0-100 C = [21]).
        /// </summary>
        /// <param name="celciusArr">An array of doubles for storing converted celcius values</param>
        private static void PopulateCelciusArr(double[] celciusArr)
        {
            double fahrenheit = 0;

            for (int i = 0; i < celciusArr.Length; i++)
            {
                celciusArr[i] = 5.0/9 * (fahrenheit -32);
                fahrenheit += 10;
            }
        }

        /// <summary>
        /// Populates the fahrenheitArr with converted values at an interval of every 5 degrees celcius.
        /// The size of the array decides the span of degrees (0-200 F = [21]).
        /// </summary>
        /// <param name="fahrenheitArr">An array of doubles for storing converted fahrenheit values</param>
        private static void PopulateFahrenheitArr(double[] fahrenheitArr)
        {
            double celcius = 0;

            for (int i = 0; i < fahrenheitArr.Length; i++)
            {
                fahrenheitArr[i] = 9.0 / 5 * celcius + 32;
                celcius += 5;
            }
        }

        /// <summary>
        /// Checks whether to print F->C or C->F and sets the interval and degree notation-strings thereafter.
        /// Utilizes a for-loop to print a formatted string containing the values to be converted and the
        /// converted values.
        /// </summary>
        /// <param name="arrToPrint">The array of doubles containing the values to print</param>
        private void PrintConversion(double[] arrToPrint)
        {
            double fromTemp = 0;
            double interval;
            int loopCounter = 0;
            string tempFrom;
            string tempTo;

            if (fahrenheitIfTrue == true)
            {
                interval = 10;
                tempFrom = "F";
                tempTo = "C";
            }
            else
            {
                interval = 5;
                tempFrom = "C";
                tempTo = "F";
            }

            Console.Write("    ");
            for (int i = 0; i < arrToPrint.Length; i++)
            {
                loopCounter++;

                Console.Write($"{fromTemp,5} {tempFrom} = {arrToPrint[i],6:F2} {tempTo}");
                
                if (loopCounter % 3 == 0) //newline and indentation for new row
                {
                    Console.Write("\n");
                    Console.Write("    ");
                }

                fromTemp += interval;
            }

            Console.WriteLine();
        }
    }
}
