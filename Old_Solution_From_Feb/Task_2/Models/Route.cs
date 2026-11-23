using System;

namespace Task_2.Models
{
    public class Route
    {
        public string Name { get; set; }
        public int Assigned { get; set; }
        public int Failed { get; set; }
        public int FailurePercent { get; set; }

        public int Successful => Assigned - Failed;
    }
}
