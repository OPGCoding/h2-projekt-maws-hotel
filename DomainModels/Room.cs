using System;
using System.Collections.Generic;

namespace DomainModels
{
    public class Room : Common
    {
        // The Id property is inherited from Common

        public bool CurrentlyBooked { get; set; }   // Tracks whether the room is booked
        public float Price { get; set; }            // Room price
        public int DigitalKey { get; set; }         // Digital key (for unlocking the room)
        public int Type { get; set; }               // Room type (e.g., single, double)
        public string Photos { get; set; }          // String for storing paths/URLs of room photos

        // Collection of bookings for this room
        public ICollection<Booking> Bookings { get; set; }  // Navigation property
    }
}
