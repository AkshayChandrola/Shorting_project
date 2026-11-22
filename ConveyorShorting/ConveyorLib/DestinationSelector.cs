namespace LoadShorting;

/// <summary>
/// Chooses the destination for every load.
/// </summary>
public class DestinationSelector
{
    private UserInput _input;
    private RandomHelper _random;

    /// <summary>
    /// Represents the index of the last destination used in a round-robin selection process.last destination used by round robin
    /// </summary>
    /// <remarks>This field is used to track the last selected destination in a round-robin algorithm.  It is
    /// typically incremented or updated to ensure even distribution across destinations.</remarks>
    private int _lastRoundRobin = 0;   
    private int _currentDestination = 0;

    /// <summary>
    /// how many more loads get the current destination
    /// </summary>
    private int _loadsLeft = 0;        

    public DestinationSelector(UserInput input, RandomHelper random)
    {
        _input = input;
        _random = random;
    }

    public int GetNextDestination()
    {
        /// <summary>
        /// check if we need to choose a new destination. If no loads are left for the current destination, select a new one based on the defined strategy (round robin or random). Reset the count of loads left for the new destination.
        /// </summary>  
        if (_loadsLeft == 0)
        {
            _currentDestination = ChooseNewDestination();
            _loadsLeft = _input.ConsecutiveLoads;
        }

        _loadsLeft = _loadsLeft - 1;
        return _currentDestination;
    }

    private int ChooseNewDestination()
    {
        if (_input.Strategy == 1)
        {
            // Round robin: 1, 2, 3, ..., n, 1, 2, 3, ...
            _lastRoundRobin = _lastRoundRobin + 1;
            if (_lastRoundRobin > _input.DestinationCount)
            {
                _lastRoundRobin = 1;
            }

            return _lastRoundRobin;
        }

        // Random: every destination has the same chance
        return _random.GetNumber(1, _input.DestinationCount);
    }
}
