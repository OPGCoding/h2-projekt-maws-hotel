using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class SupportRequest
    {
        public int Id { get; set; }           // Auto-genererende ID
        public string Name { get; set; }      // Navn på den person, der sender anmodningen
        public string Email { get; set; }     // Email på afsenderen
        public string Subject { get; set; }   // Emne for supportanmodningen
        public string Message { get; set; }   // Selve beskeden
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Tidsstempel for hvornår anmodningen blev modtaget
        public string Status { get; set; } = "Pending";  // Status på anmodningen
    }

}
