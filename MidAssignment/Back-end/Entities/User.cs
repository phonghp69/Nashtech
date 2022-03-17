using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; } = null;
        public DateTime Dateofbirth { get; set; }
        public string Phone { get; set; } = null;
        public string Address { get; set; } = null;
        public bool Permissions { get; set; }
        public ICollection<BookBorrowingRequest> Request { get; set; }
    }
}