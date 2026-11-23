using System;
using Task_2.Models;

namespace Task_2.Services
{
    public static class ReportService
    {
        public static void PrintReport(Route[] routes, int totalOrders, int route0FailureCount)
        {
            Console.WriteLine();
            Console.WriteLine("Route\tAssigned Orders\tFailed Orders\tSuccessful\tAssigned %\tSuccess %\tFailure %");
            Console.WriteLine("Total Orders: " + totalOrders);

            for (int i = 0; i < routes.Length; i++)
            {
                var r = routes[i];
                double assignedPercentage = totalOrders > 0 ? (double)r.Assigned / totalOrders * 100 : 0;
                double successPercentage = r.Assigned > 0 ? (double)r.Successful / r.Assigned * 100 : 0;
                double failurePercentage = r.Assigned > 0 ? (double)r.Failed / r.Assigned * 100 : 0;

                Console.WriteLine($"{r.Name}\t{r.Assigned}\t\t{r.Failed}\t\t{r.Successful}\t\t{assignedPercentage:F2}%\t\t{successPercentage:F2}%\t\t{failurePercentage:F2}%");
            }

            Console.WriteLine();
            Console.WriteLine("Number of Total Orders that went to route0 after failure: " + route0FailureCount);
        }
    }
}
