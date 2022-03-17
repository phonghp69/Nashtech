using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set;}
        public string Type { get; set;}
         public ICollection<Book> Book { get; set; }
    }
}