using System.ComponentModel.DataAnnotations;

namespace PeopleRegister.Domain.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public int CPF { get; set; }

        public IEnumerable<Phone>? Phones { get; set; }
    }
}
