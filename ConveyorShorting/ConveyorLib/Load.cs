namespace LoadShorting;

/// <summary>
/// Represents a load, such as a tote or carton, that arrives at a designated location.One load (tote or carton) that arrives at the X mark.
/// </summary>
/// <remarks>A load can either be a tote or a carton, and it contains a specific number of products (SKUs) and
/// items. Use the <see cref="IsTote"/> property to determine the type of load, and the <see cref="TypeName"/> property
/// to retrieve the type name as a string.</remarks>
public class Load
{
    public int Id { get; set; }

    // true = tote, false = carton
    public bool IsTote { get; set; }

    // Number of different products (SKUs) in the load
    public int SkuCount { get; set; }

    // Number of items in the load (all products together)
    public int ItemCount { get; set; }

    public string TypeName
    {
        get
        {
            if (IsTote)
            {
                return "Tote";
            }

            return "Carton";
        }
    }
}
