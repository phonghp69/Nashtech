using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int bId { get; set; }
        public string bName { get; set; }
        public string bAuthor { get; set; } 
        public string bDescription { get; set; }
        public string cId { get; set; }
        public Category Category { get; set; }
        
    }
}