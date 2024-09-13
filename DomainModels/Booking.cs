using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Booking : Common
    {
        public int Id { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        // Foreign key linking to Profile
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        // Navigation property back to the Profile
        public Profile Profile { get; set; }

        // Foreign key linking to Room
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        // Navigation property to the Room
        public Room Room { get; set; }
    }
}
