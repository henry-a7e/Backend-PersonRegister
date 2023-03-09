
using System.ComponentModel.DataAnnotations;

namespace PeopleRegister.API.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string Birthdate { get; set; }
        [Required]
        public long CPF { get; set; }
    }
}
