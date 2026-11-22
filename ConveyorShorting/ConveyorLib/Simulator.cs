namespace LoadShorting;

/// <summary>
/// Handles all loads one after another.
/// </summary>
public class Simulator
{
    private UserInput _input;
    private Statistics _statistics;
    private OutputPrinter _printer;
    private RandomHelper _random;
    private DestinationSelector _selector;

    public Simulator(UserInput input, Statistics statistics, OutputPrinter printer)
    {
        _input = input;
        _statistics = statistics;
        _printer = printer;
        _random = new RandomHelper();
        _selector = new DestinationSelector(input, _random);
    }

    public void RunAllLoads()
    {
        Console.WriteLine();

        for (int id = 1; id <= _input.LoadCount; id++)
        {
            // 1. A new load arrives
            Load load = _random.CreateLoad(id, _input.TotePercent);

            // 2. Select a destination
            int selectedDestination = _selector.GetNextDestination();

            // 3. Does the divert fail? Then the load reaches destination 0
            int reachedDestination = selectedDestination;
            if (_random.IsHit(_input.FailurePercent))
            {
                reachedDestination = 0;
            }

            // 4. Remember and print
            _statistics.AddLoad(load, reachedDestination);
            _printer.PrintReachedDestination(load, selectedDestination, reachedDestination);
        }
    }
}
