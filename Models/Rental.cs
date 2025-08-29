namespace CarRentalAPI.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int CarID { get; set; }
        public int ClientID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal TotalCost { get; set; }
        public int DurationInMinutes { get; set; }

        // Навигационные свойства
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
    }
}