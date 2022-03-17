using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Entities
{
    [Table("RequestDetails")]
    public class BookBorrowingRequestDetails
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Dateborrow { get; set; }
        public Status Status { get; set; }
        public int UserModId { get; set; }
        public User User { get; set; }
       
    }
    public enum Status { Approved, Rejected, Waiting }
}