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
    /// Decides randomly whether something happens, with a chance given in percent.
    /// </summary>
    /// <param name="percent">
    /// The chance that it happens, as a whole number from 0 to 100.
    /// 0 = never happens, 50 = about every second time, 100 = always happens.
    /// </param>
    /// <returns>
    /// true if it happens this time, false if it does not.
    /// </returns>
    /// <remarks>
    /// How it works: a random number from 1 to 100 is drawn. If the number is
    /// less than or equal to the percent value, it counts as a "hit".
    /// Example with percent = 30: the numbers 1 to 30 are a hit and 31 to 100
    /// are a miss, so it returns true about 30 times out of 100.
    /// It is used to decide whether a load is a tote and whether a divert fails.
    /// </remarks>
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
