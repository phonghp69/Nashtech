using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Entities
{
    [Table("Request")]
    public class BookBorrowingRequest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int RequestDetailsId{ get; set;} 
        public ICollection<Book> Book { get; set; }
        public BookBorrowingRequestDetails RequestDetails { get; set;}

    }
}