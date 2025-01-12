using System.Runtime.CompilerServices;

namespace C_A2
{
    /// <summary>
    /// 
    /// READ ME FIRST:
    /// 1. For examples of do while-loops, see class InputValidation
    /// 2. I chose another approach to the temperature conversion assigment, if not satisfactory: I can rewrite it
    ///    more in line with the assignment.
    /// 3. A whole lot more comments this time! I would very much like some specific feedback on those.
    /// 4. If it is the same examinator reading this as last time: Thank you for some specific feedback! 
    ///    It is appreciated since I study 100% distance and rarely have other interactions with teachers
    ///    other than receiving grades upon completion of assigments.
    /// 
    /// This class is responsible for initializing itself and all other classes, as well as defining
    /// the relationships between them, before getting the show rolling and start the user interaction.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Constructor sets the title of the console window.
        /// </summary>
        public Program()
        {
            Console.Title = "Programming in C# - A2 - By: Gustaf Berggren";
        }

        /// <summary>
        /// Declares and initializes a new instance of this class.
        /// Calls DefineDependencies().
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new();

            program.DefineDependencies();
        }

        /// <summary>
        /// Configures dependencies by initializing all classes within this application.
        /// Calls Run() to get the show rolling.
        /// </summary>
        private void DefineDependencies()
        {
            InputValidation validation = new();
            TemperatureConverter temperatureConverter = new(validation);
            StringFunctions stringFunctions = new(validation);
            MathWork mathWork = new(validation);
            Scheduler scheduler = new(validation);
            Menu menu = new(validation, temperatureConverter, stringFunctions, mathWork, scheduler);

            Run(menu);
        }

        /// <summary>
        /// Calls the public method DisplayMenu() from the Menu-class. Time for user interaction!
        /// </summary>
        /// <param name="menu">A reference to the instance of the Menu-class initialized in DefineDependencies()</param>
        private static void Run(Menu menu)
        {
            menu.DisplayMenu();
        }

    }
}
