using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleRegister.Domain.Entities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public int PhoneNumber { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person? Person { get; set; }
    }
}
