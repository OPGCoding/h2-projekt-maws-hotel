namespace HotelBooking.Models.Entity
{
    public class Costumer
    {
        public Guid Id {  get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Adresse { get; set; }

        public string? TelefonNr { get; set; }
    }
}
