using System.Collections.Generic;

namespace EventManagementPlatform.Models
{
    public class EventManager
    {
        public int EventManagerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}