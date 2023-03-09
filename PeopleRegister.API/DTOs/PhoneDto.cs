
using System.ComponentModel.DataAnnotations;

namespace PeopleRegister.API.DTOs
{
    public class PhoneDto
    {
        public int Id { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
