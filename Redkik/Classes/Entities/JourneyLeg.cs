using System;
using System.Collections.Generic;

namespace Redkik.Classes
{
    public class JourneyLeg
    {
        public DateTimeOffset? startTime { get; set; }
        public DateTimeOffset? endTime { get; set; }
        public string? start { get; set; }
        public string? end { get; set; }
        public List<string>? transportTypes { get; set; }
        public List<string>? transportFeatures { get; set; }

        public JourneyLeg(DateTimeOffset startTime, DateTimeOffset endTime, string origin, string destination, string transportType)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            start = origin;
            end = destination;
            transportTypes = new List<string> { transportType };
            transportFeatures = new List<string>();
        }
    }
}
