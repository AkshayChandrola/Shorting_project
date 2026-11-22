namespace LoadShorting;

/// <summary>
/// Provides utility methods for generating random numbers and simulating probabilistic outcomes.Everything that needs random numbers is in this class.
/// </summary>
/// <remarks>This class offers methods to generate random integers within a specified range, determine
/// probabilistic outcomes, and create randomized loads (e.g., totes or cartons) with varying characteristics. It is
/// designed to simplify common randomization tasks in applications requiring random number generation or probabilistic
/// logic.</remarks>
public class RandomHelper
{
    private Random _random = new Random();

    /// <summary>
    /// Random number from min to max (both included)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int GetNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    /// <summary>
    /// Returns true with a chance of "percent" (0 = never, 100 = always)
    /// </summary>
    /// <param name="percent"></param>
    /// <returns></returns>
    public bool IsHit(int percent)
    {
        int number = GetNumber(1, 100);
        return number <= percent;
    }

    /// <summary>
    /// Creates a random tote or carton
    /// </summary>
    /// <param name="id"></param>
    /// <param name="totePercent"></param>
    /// <returns></returns>
    public Load CreateLoad(int id, int totePercent)
    {
        Load load = new Load();
        load.Id = id;

        if (IsHit(totePercent))
        {
            // Tote: up to 10 different SKUs, up to 20 items in total
            load.IsTote = true;
            load.SkuCount = GetNumber(1, 10);
            load.ItemCount = GetNumber(load.SkuCount, 20);
        }
        else
        {
            // Carton: only 1 SKU, up to 40 items
            load.IsTote = false;
            load.SkuCount = 1;
            load.ItemCount = GetNumber(1, 40);
        }

        return load;
    }
}
