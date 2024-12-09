using System;
using System.Collections.Generic;

namespace EventManagementPlatform.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();
    }
}