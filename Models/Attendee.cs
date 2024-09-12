namespace EventManagement.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string FullName { get; set; }
        public List<Event> Events { get; set; }

    }
}
