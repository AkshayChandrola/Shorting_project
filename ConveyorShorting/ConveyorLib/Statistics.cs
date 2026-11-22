namespace LoadShorting;

/// <summary>
/// Counts what happened to the loads and calculates the results.
/// </summary>
public class Statistics
{
    /// <summary>
    /// Represents the number of totes assigned to each destination.Index = destination number (0 to n). Destination 0 = failed divert.
    /// </summary>
    /// <remarks>The index of the array corresponds to the destination number, where destination 0 represents
    /// failed diverts. Each element in the array indicates the count of totes for the respective destination.</remarks>

    private int[] _totesPerDestination;
    private int[] _cartonsPerDestination;

    private int _totalLoads = 0;
    private int _totalTotes = 0;
    private int _totalCartons = 0;
    private int _skusOfAllTotes = 0;
    private int _itemsOfAllCartons = 0;

    public int DestinationCount { get; set; }

    public Statistics(int destinationCount)
    {
        DestinationCount = destinationCount;
        _totesPerDestination = new int[destinationCount + 1];
        _cartonsPerDestination = new int[destinationCount + 1];
    }

    /// <summary>
    /// Updates the load tracking statistics for a specific destination.Remember that a load reached a destination
    /// </summary>
    /// <remarks>This method increments the total load count and updates the statistics for either totes or
    /// cartons  based on the type of the provided load. For totes, it updates the total number of totes, the count  of
    /// totes delivered to the specified destination, and the total SKU count across all totes. For cartons,  it updates
    /// the total number of cartons, the count of cartons delivered to the specified destination,  and the total item
    /// count across all cartons.</remarks>
    /// <param name="load">The load to be added, which contains information about its type and contents.</param>
    /// <param name="reachedDestination">The identifier of the destination where the load was delivered.</param>
    public void AddLoad(Load load, int reachedDestination)
    {
        _totalLoads = _totalLoads + 1;

        if (load.IsTote)
        {
            _totesPerDestination[reachedDestination] = _totesPerDestination[reachedDestination] + 1;
            _totalTotes = _totalTotes + 1;
            _skusOfAllTotes = _skusOfAllTotes + load.SkuCount;
        }
        else
        {
            _cartonsPerDestination[reachedDestination] = _cartonsPerDestination[reachedDestination] + 1;
            _totalCartons = _totalCartons + 1;
            _itemsOfAllCartons = _itemsOfAllCartons + load.ItemCount;
        }
    }

    public int GetToteCount(int destination)
    {
        return _totesPerDestination[destination];
    }

    public int GetCartonCount(int destination)
    {
        return _cartonsPerDestination[destination];
    }

    public int GetLoadCount(int destination)
    {
        return _totesPerDestination[destination] + _cartonsPerDestination[destination];
    }

    /// <summary>
    /// Percentage of all loads that reached this destination
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>
    public double GetPercentage(int destination)
    {
        if (_totalLoads == 0)
        {
            return 0;
        }

        return GetLoadCount(destination) * 100.0 / _totalLoads;
    }

    public double GetAverageSkusPerTote()
    {
        if (_totalTotes == 0)
        {
            return 0;
        }

        return (double)_skusOfAllTotes / _totalTotes;
    }

    public double GetAverageItemsPerCarton()
    {
        if (_totalCartons == 0)
        {
            return 0;
        }

        return (double)_itemsOfAllCartons / _totalCartons;
    }
}
