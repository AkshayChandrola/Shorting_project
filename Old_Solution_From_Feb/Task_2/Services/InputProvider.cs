using Task_2.Models;

namespace Task_2.Services
{
    public class InputProvider
    {
        public AppConfig GetConfig()
        {
            var cfg = new AppConfig();

            cfg.RouteCount = InputService.ReadInt(
                "Enter the number of available routes (n, must be >= 1): ",
                v => v >= 1,
                "Invalid input. Please enter an integer greater than or equal to 1: ");

            cfg.TotalOrders = InputService.ReadInt(
                "Enter the total number of orders to be sorted (m, must be >= 1): ",
                v => v >= 1,
                "Invalid input. Please enter an integer greater than or equal to 1: ");

            cfg.MaxConsecutive = InputService.ReadInt(
                "Enter the maximum number of consecutive orders that can be sorted on a single route (k, must be >= 1): ",
                v => v >= 1,
                "Invalid input. Please enter an integer greater than or equal to 1: ");

            cfg.MaxFailurePercentage = InputService.ReadInt(
                "Enter the maximum failure percentage per route (p, must be between 0 and 100): ",
                v => v >= 0 && v <= 100,
                "Invalid input. Please enter an integer between 0 and 100: ");

            return cfg;
        }
    }
}
