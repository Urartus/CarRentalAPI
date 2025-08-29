namespace CarRentalAPI.Models
{
    public class RentalRequest
    {
        public int CarID { get; set; }
        public int ClientID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}