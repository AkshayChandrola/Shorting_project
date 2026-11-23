using System;

namespace Task_2.Events
{
    public class OrderEventArgs : EventArgs
    {
        public int RouteIndex { get; }
        public bool IsFailed { get; }

        public OrderEventArgs(int routeIndex, bool isFailed)
        {
            RouteIndex = routeIndex;
            IsFailed = isFailed;
        }
    }
}
