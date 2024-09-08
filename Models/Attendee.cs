namespace EventManagement.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string FullName { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
