using HotelBooking.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
            
        }
        public DbSet<Costumer> Costumers { get; set; } 
    }
}
 