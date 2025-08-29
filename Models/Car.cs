namespace CarRentalAPI.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal PricePerMinute { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}