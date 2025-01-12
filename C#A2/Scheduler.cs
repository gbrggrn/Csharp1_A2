using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_A2
{
    /// <summary>
    /// Prompts the user for three integers representing the starting week and ending week for the schedule,
    /// and the interval of working weeks.
    /// Prints a schedule based on these values.
    /// Primary constructor assigns a reference to an instance of the InputValidation-class to a private readonly field.
    /// </summary>
    /// <param name="validation">A reference to an instance of the InputValidation-class</param>
    internal class Scheduler(InputValidation validation)
    {
        private readonly InputValidation validation = validation;

        /// <summary>
        /// Prompts the user with the submenu for this class.
        /// Implements a switch statement with the user input as argument.
        /// Out keyword is used to allow SetVariables() to modify variables passed to it.
        /// </summary>
        public void SubMenuScheduler()
        {
            Console.Clear();

            int startWeek, endWeek, interval; //declares the int variables this class works with

            while (true)
            {
                Console.WriteLine("       --- SCHEDULER ---");
                Console.WriteLine();
                Console.WriteLine("    1. Show a list of weekends to work");
                Console.WriteLine("    2. Show a list of nights to work");
                Console.WriteLine("    3. Return to the main menu");
                Console.WriteLine();

                int choice = validation.ValidateIntRange("Menu choice", 1, 3);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Weekends");
                        SetVariables("weekends", out startWeek, out endWeek, out interval);
                        PrintSchedule("weekends", startWeek, endWeek, interval);
                        break;
                    case 2:
                        Console.WriteLine("Nights");
                        SetVariables("nights", out startWeek, out endWeek, out interval);
                        PrintSchedule("weekends", startWeek, endWeek, interval);
                        break;
                    case 3:
                        Console.Clear();
                        return;
                }
            }
        }

        /// <summary>
        /// Prompts the user for input to assign to the instance variables.
        /// Modifies the passed variables through the "out" keyword. "Returning" multiple values.
        /// </summary>
        /// <param name="option">A string used to tailor the title and last prompt for either "weekends" or "nights"</param>
        private void SetVariables(string option, out int startWeek, out int endWeek, out int interval)
        {
            Console.Clear();

            Console.WriteLine("       --- " + option.ToUpper() + " ---");
            Console.WriteLine();

            Console.WriteLine("    Enter the week when you want the schedule to start (1-52)");
            startWeek = validation.ValidateIntRange("Startweek", 1, 52);
            Console.WriteLine();

            Console.WriteLine("    Enter the week when you want the schedule to end (1-52)");
            endWeek = validation.ValidateIntRange("Endweek", startWeek, 52);
            Console.WriteLine();

            Console.WriteLine("    Enter the interval for when you work " + option.ToLower() + " (1-52)");
            interval = validation.ValidateIntRange("Interval", 1, 52);

        }

        /// <summary>
        /// Prints the schedule.
        /// </summary>
        /// <param name="option">A string used to tailor the title and last prompt for either "weekends" or "nights"</param>
        /// <param name="startWeek">Holds the user input for startWeek</param>
        /// <param name="endWeek">Holds the user input for endWeek</param>
        /// <param name="interval">Holds the user input for interval</param>
        private static void PrintSchedule(string option, int startWeek, int endWeek, int interval)
        {
            int printCounter = 0; //tracks number of times a week is printed
            int loopCounter = 0; //tracks number of times loop has run

            Console.Clear();

            Console.WriteLine("       --- SCHEDULE FOR " + option.ToUpper() + " ---"); //page title
            Console.WriteLine();

            Console.Write("    ");
            for (int i = startWeek; i <= endWeek; i++)
            {
                loopCounter++; //increments loopCounter first to avoid interpreting first run as "0"

                if (loopCounter % interval == 0) //print the weeks according to interval
                {
                    Console.Write("Week " + i.ToString().PadLeft(2) + "    ");
                    printCounter++; //increments every time a print is executed
                }

                if (printCounter % 3 == 0 && loopCounter % interval == 0) //new line every three prints, but only if a print has just been executed
                {
                    Console.Write("\n");
                    Console.Write("    ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
