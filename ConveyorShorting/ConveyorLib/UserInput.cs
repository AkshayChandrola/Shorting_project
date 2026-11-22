namespace LoadShorting;

    /// <summary>
    /// Represents a utility class for collecting user input to configure a conveyor destination simulation.Asks the user for all values and stores them.
    /// </summary>
    /// <remarks>This class provides methods and properties to gather and store user-defined parameters for a
    /// simulation, such as the number of destinations, strategy type, failure percentage, and other related settings. The
    /// <see cref="AskUser"/> method prompts the user for input and validates the provided values.</remarks>
    public class UserInput
    {
        public int DestinationCount { get; set; }

        /// <summary>
        /// 1 = round robin, 2 = random
        /// </summary>
        public int Strategy { get; set; }

        public int ConsecutiveLoads { get; set; }

        public int FailurePercent { get; set; }

        public int LoadCount { get; set; }

        public int TotePercent { get; set; }

        public void AskUser()
        {
            Console.WriteLine("=== Conveyor destination simulation ===");

            DestinationCount = AskNumber("Number of destinations (destination 0 = failed divert)", 1, 6);

            Console.WriteLine("Strategy: 1 = Round robin, 2 = Random");
            Strategy = AskNumber("Strategy", 1, 2);

            ConsecutiveLoads = AskNumber("Consecutive loads with the same destination", 1, 100000);
            FailurePercent = AskNumber("Failure percentage", 0, 100);
            LoadCount = AskNumber("Number of Total loads", 1, 10000000);
            TotePercent = AskNumber("Percentage of totes (the rest are cartons)", 0, 100);
        }

        /// <summary>
        /// Prompts the user with a question and repeatedly requests input until a valid whole number  within the specified
        /// range is entered.Asks one question until the user enters a valid whole number between min and max.
        /// </summary>
        /// <remarks>If the user provides no input (e.g., EOF is encountered), the program will
        /// terminate.</remarks>
        /// <param name="question">The question to display to the user.</param>
        /// <param name="min">The minimum allowable value (inclusive).</param>
        /// <param name="max">The maximum allowable value (inclusive).</param>
        /// <returns>The valid whole number entered by the user within the specified range.</returns>
        private int AskNumber(string question, int min, int max)
        {
            while (true)
            {
                Console.Write(question + " [" + min + "-" + max + "]: ");
                string text = Console.ReadLine();

                if (text == null)
                {
                    Console.WriteLine("No input available. Program stops.");
                    Environment.Exit(1);
                }

                int number;
                bool isNumber = int.TryParse(text, out number);

                if (isNumber && number >= min && number <= max)
                {
                    return number;
                }

                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }

