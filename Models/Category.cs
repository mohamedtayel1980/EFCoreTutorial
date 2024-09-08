namespace EventManagement.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
    }
}
