using System;
using System.ComponentModel.DataAnnotations;

namespace HotelWebsite.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime? Birthday { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}