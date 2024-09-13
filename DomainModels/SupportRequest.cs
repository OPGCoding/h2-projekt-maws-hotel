using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class SupportRequest : Common
    {       
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }   
        
        [Required]
        [EmailAddress]  
        [MaxLength(255)]
        public string Email { get; set; }   
        
        [Required]
        [MaxLength(255)]
        public string Subject { get; set; }   

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";  

    }

}
