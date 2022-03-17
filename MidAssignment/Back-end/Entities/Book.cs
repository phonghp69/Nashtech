using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Entities
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; }
        public int? RequestId { get; set; } = null;
        
        public Category Category { get; set; }
        public BookBorrowingRequest? Request { get; set; }
        
        
    }
}