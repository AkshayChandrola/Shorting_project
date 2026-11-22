namespace LoadShorting;

/// <summary>
/// Provides methods for printing load and summary information to the console.Prints everything to the console.
/// </summary>
/// <remarks>This class is designed to output information about loads and their destinations, as well as a summary
/// of statistics at the end of processing. It is intended for use in scenarios where console output is sufficient for
/// monitoring or debugging purposes.</remarks>
public class OutputPrinter
{
    /// <summary>
    /// Logs a message indicating that a load has reached its destination.Called for every load, right after it reached its destination
    /// </summary>
    /// <remarks>If the actual destination differs from the intended destination, the log message will include
    /// a note indicating the failure to divert the load.</remarks>
    /// <param name="load">The load that reached its destination. Must not be <see langword="null"/>.</param>
    /// <param name="selectedDestination">The intended destination for the load.</param>
    /// <param name="reachedDestination">The actual destination where the load arrived.</param>
    public void PrintReachedDestination(Load load, int selectedDestination, int reachedDestination)
    {
        string text = "Load " + load.Id + " (" + load.TypeName + ") reached destination " + reachedDestination;

        if (reachedDestination != selectedDestination)
        {
            text = text + "   [divert to destination " + selectedDestination + " failed]";
        }

        Console.WriteLine(text);
    }

    /// <summary>
    /// Prints a summary of statistical data to the console, including destination-specific metrics and overall
    /// averages.Called once at the end
    /// </summary>
    /// <remarks>The summary includes the following information for each destination: <list type="bullet">
    /// <item><description>The total number of loads.</description></item> <item><description>The percentage of total
    /// loads.</description></item> <item><description>The total number of totes.</description></item>
    /// <item><description>The total number of cartons.</description></item> </list> Additionally, the method outputs
    /// the average number of SKUs per tote and the average number of items per carton.</remarks>
    /// <param name="statistics">An instance of <see cref="Statistics"/> containing the data to summarize. Cannot be <see langword="null"/>.</param>
    public void PrintSummary(Statistics statistics)
    {
        Console.WriteLine();
        Console.WriteLine("=== Summary ===");
        Console.WriteLine($"{"Destination", -12} | {"Loads",6} | {"Percent",9} | {"Totes",6} | {"Cartons",8}");

        for (int destination = 0; destination <= statistics.DestinationCount; destination++)
        {
            Console.WriteLine(
                $"{destination,-12} | " +
                $"{statistics.GetLoadCount(destination),6} | " +
                $"{statistics.GetPercentage(destination),7:0.00} % | " +
                $"{statistics.GetToteCount(destination),6} | " +
                $"{statistics.GetCartonCount(destination),8}");
        }

        Console.WriteLine();
        Console.WriteLine("Average SKUs per tote: " + statistics.GetAverageSkusPerTote().ToString("0.00"));
        Console.WriteLine("Average items per carton: " + statistics.GetAverageItemsPerCarton().ToString("0.00"));
    }
}
