namespace EventManagement.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }  // New property

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Attendee> Attendees { get; set; }
        public EventDetail EventDetail { get; set; }
        public decimal Price
        {
            get => _price;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                _price = value;
            }
        }
        private decimal _price;
      

        // Method to set the price with validation
        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}
