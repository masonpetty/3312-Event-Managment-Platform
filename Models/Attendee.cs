namespace EventManagementPlatform.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();
    }
}