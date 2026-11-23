using System;
using Task_2.Models;
using Task_2.Events;

namespace Task_2.Services
{
    public class RouteService
    {
        private readonly Random _rand = new Random();
        private readonly int _totalOrders;
        private readonly int _maxConsecutive;
        private readonly int _maxFailurePercent;

        public Route[] Routes { get; }

        public event EventHandler<OrderEventArgs> OrderProcessed;

        public RouteService(int routeCount, int totalOrders, int maxConsecutive, int maxFailurePercent)
        {
            _totalOrders = totalOrders;
            _maxConsecutive = maxConsecutive;
            _maxFailurePercent = maxFailurePercent;

            Routes = new Route[routeCount];
            for (int i = 0; i < routeCount; i++)
            {
                Routes[i] = new Route
                {
                    Name = "route" + (i + 1),
                    Assigned = 0,
                    Failed = 0,
                    FailurePercent = _rand.Next(0, _maxFailurePercent + 1)
                };
            }
        }

        protected virtual void OnOrderProcessed(OrderEventArgs e)
        {
            OrderProcessed?.Invoke(this, e);
        }

        public void ProcessOrders()
        {
            int processedOrders = 0;
            int n = Routes.Length;

            while (processedOrders < _totalOrders)
            {
                int groupSize = _rand.Next(1, _maxConsecutive + 1);
                int idx = _rand.Next(0, n);

                for (int i = 0; i < groupSize && processedOrders < _totalOrders; i++)
                {
                    Routes[idx].Assigned++;
                    bool isFailed = _rand.Next(0, 100) < Routes[idx].FailurePercent;
                    if (isFailed)
                    {
                        Routes[idx].Failed++;
                    }

                    OnOrderProcessed(new OrderEventArgs(idx, isFailed));

                    processedOrders++;
                }
            }
        }
    }
}
