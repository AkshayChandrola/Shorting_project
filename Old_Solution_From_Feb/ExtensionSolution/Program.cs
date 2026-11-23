using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ExtensionSolution
{
    public class Load
    {
        public string Type;    //to store whether it is a Tote or Carton
        public int Destination; //to store the destination of the load
        public int NumberOfSKUs; //to store the number of SKUs in the load
        public int TotalItems; //to store the total number of items in the load
    }

    class Program
    {
        static void Main(string[] args)
        {
            //to generate random number
            Random rnd = new Random();

            //Create a list to store all the loads
            List<Load> loads = new List<Load>();

            //Ask user for the total number of loads
            Console.WriteLine("Enter the total number of loads: ");
            int totalLoads = Convert.ToInt32(Console.ReadLine());

            //Ask for percentage of Totes
            Console.WriteLine("Enter the percentage of Totes: ");
            int percentageTotes = Convert.ToInt32(Console.ReadLine());

            //Calculate number of totes
            int numberOfTotes = (totalLoads * percentageTotes) / 100;

            //remaining load will be Cartons
            int numberOfCartons = totalLoads - numberOfTotes;

            //Create Totes
            for (int i = 0; i < numberOfTotes; i++)
            {
                // Create a new Load object
                Load tote = new Load();

                // Set type as Tote
                tote.Type = "Tote";

                // Assign random destination between 1 and 5 (assuming there are 5 destinations)
                tote.Destination = rnd.Next(1, 6);

                // Totes can have up to 10 different SKUs
                tote.NumberOfSKUs = rnd.Next(1, 11);

                // Totes can have up to 20 total items
                tote.TotalItems = rnd.Next(1, 21);

                // Add tote to the list
                loads.Add(tote);
            }

            // Create Cartons   
            for (int i = 0; i < numberOfCartons; i++)
            {
                // Create a new Load object
                Load carton = new Load();

                // Set type as Carton
                carton.Type = "Carton";

                // Assign random destination between 1 and 5
                carton.Destination = rnd.Next(1, 6);

                // Cartons have only 1 SKU
                carton.NumberOfSKUs = 1;

                // Cartons can have up to 40 items
                carton.TotalItems = rnd.Next(1, 41);

                // Add carton to the list
                loads.Add(carton);
            }

            //print number Totes and Cartons for each destination

            Console.WriteLine("\n--- Loads per Destination ---");

            // Check for each destination (1 to 5)
            for (int dest = 1; dest <= 5; dest++)
            {
                int toteCount = 0;
                int cartonCount = 0;

                // Loop through all loads
                for (int i = 0; i < loads.Count; i++)
                {
                    // If load matches current destination
                    if (loads[i].Destination == dest)
                    {
                        // Check type and increase counter
                        if (loads[i].Type == "Tote")
                            toteCount++;
                        else
                            cartonCount++;
                    }
                }

                // Print result for this destination
                Console.WriteLine("Destination " + dest +
                    ": Totes = " + toteCount +
                    ", Cartons = " + cartonCount);
            }

            // Calculate average

            double totalSKUsInTotes = 0;        // Total SKUs in all totes
            double totalItemsInCartons = 0;     // Total items in all cartons

            // Loop through all loads
            for (int i = 0; i < loads.Count; i++)
            {
                // If it is a tote, add its SKUs
                if (loads[i].Type == "Tote")
                    totalSKUsInTotes += loads[i].NumberOfSKUs;

                // If it is a carton, add its total items
                if (loads[i].Type == "Carton")
                    totalItemsInCartons += loads[i].TotalItems;
            }

            double averageSKUsPerTote = 0;
            double averageItemsPerCarton = 0;

            // Avoid division by zero
            if (numberOfTotes > 0)
                averageSKUsPerTote = totalSKUsInTotes / numberOfTotes;

            if (numberOfCartons > 0)
                averageItemsPerCarton = totalItemsInCartons / numberOfCartons;

            // Print averages
            Console.WriteLine("\n--- Averages ---");
            Console.WriteLine("Average SKUs per Tote: " + averageSKUsPerTote);
            Console.WriteLine("Average Items per Carton: " + averageItemsPerCarton);
        }
    }
}