using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// Constructor receives references to the instances of the dependent classes and assigns them to private 
    /// readonly fields to be used within this class.
    /// </summary>
    /// <param name="validation">A reference to an instance of the InputValidation-class</param>
    /// <param name="temperatureConverter">A reference to an instance of the TemperatureConverter-class</param>
    /// <param name="stringFunctions">A reference to an instance of the StringFunctions-class</param>
    /// <param name="mathWork">A reference to an instance of the MathWork-class</param>
    /// <param name="scheduler">A reference to an instance of the Scheduler-class</param>
    internal class Menu (InputValidation validation, TemperatureConverter temperatureConverter, StringFunctions stringFunctions, MathWork mathWork, Scheduler scheduler)
    {
        private readonly InputValidation validation = validation;
        private readonly TemperatureConverter temperatureConverter = temperatureConverter;
        private readonly StringFunctions stringFunctions = stringFunctions;
        private readonly MathWork mathWork = mathWork;
        private readonly Scheduler scheduler = scheduler; 

        /// <summary>
        /// Displays the main-menu and prompts the user for an option through calling an input validation method. It uses a switch-statement with the user input as an argument to decide
        /// which part of the functionality to access.
        /// </summary>
        public void DisplayMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("       --- MAIN MENU ---");
                Console.WriteLine();
                Console.WriteLine("    1. Convert Temperatures");
                Console.WriteLine("    2. Fun With Strings");
                Console.WriteLine("    3. Do Math");
                Console.WriteLine("    4. Scheduler");
                Console.WriteLine("    5. Close the Application");
                Console.WriteLine();

                int choice = validation.ValidateIntRange("Menu choice", 1, 5);

                switch (choice)
                {
                    case 1:
                        temperatureConverter.SubMenuConverter();
                        break;
                    case 2:
                        stringFunctions.SubMenuStringFunctions();
                        break;
                    case 3:
                        mathWork.Calculate();
                        break;
                    case 4:
                        scheduler.SubMenuScheduler();
                        break;
                    case 5:
                        CloseApp();
                        break;
                }
            }
        }

        /// <summary>
        /// Prompts the user as to if they want to exit the application through calling an input validation method.
        /// If the user inputs "y" for "yes" Environment.Exit(0) is called to terminate the application.
        /// Else, the user can press enter, let the method finish and return to DisplayMenu().
        /// </summary>
        private void CloseApp()
        {
            Console.WriteLine();
            Console.WriteLine("    Would you like to exit the application?");
            Console.WriteLine("    y/n");

            if (validation.YesOrNoString("Answer") == "y")
            {
                Console.WriteLine();
                Console.WriteLine("    Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("    Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
