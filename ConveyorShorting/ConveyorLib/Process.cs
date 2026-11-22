namespace LoadShorting;

/// <summary>
/// Represents a process that simulates and outputs the results of a user-defined operation.
/// </summary>
/// <remarks>This class orchestrates the flow of user input, simulation, and output generation.  It collects user
/// input, initializes necessary components, runs simulations, and prints a summary of the results.</remarks>
public class Process
{
    public void Run()
    {
        UserInput input = new UserInput();
        input.AskUser();

        Statistics statistics = new Statistics(input.DestinationCount);
        OutputPrinter printer = new OutputPrinter();

        Simulator simulator = new Simulator(input, statistics, printer);
        simulator.RunAllLoads();

        printer.PrintSummary(statistics);
    }
}
