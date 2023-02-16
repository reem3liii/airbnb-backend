using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airbnb.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "varchar(14)")]
        public string NID { get; set; }

        /*[EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }*/

        [Required]
        public char Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        /*[ForeignKey("Place")]
        public int PlaceId  { get; set; }
        public virtual Place Place { get; set; }
        public virtual Contract Contract { get; set; }*/
    }
}
