using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reception_system.Model
{
    public class Visitor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; } 

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Note { get; set; }

        [Required]
        public int Phone { get; set; }
    }

}

