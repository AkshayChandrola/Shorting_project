using Task_2.Models;

namespace Task_2.Services
{
    public class AppRunner
    {
        private readonly InputProvider _inputProvider;

        public AppRunner() : this(new InputProvider()) { }

        internal AppRunner(InputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public void Run()
        {
            var cfg = _inputProvider.GetConfig();

            var routeService = new RouteService(cfg.RouteCount, cfg.TotalOrders, cfg.MaxConsecutive, cfg.MaxFailurePercentage);

            int route0FailureCount = 0;
            routeService.OrderProcessed += (s, e) => { if (e.IsFailed && e.RouteIndex == 0) route0FailureCount++; };

            routeService.ProcessOrders();

            ReportService.PrintReport(routeService.Routes, cfg.TotalOrders, route0FailureCount);
        }
    }
}
