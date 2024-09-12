using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class EventDetail
    {
        [Key]
        public int EventId { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}
