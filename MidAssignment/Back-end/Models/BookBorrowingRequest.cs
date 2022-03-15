using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Models
{
     [Table("Request")]
    public class BookBorrowingRequest
    {
        [Key]
        public int rId { get; set; }
        public string rName { get; set; }
    }
}