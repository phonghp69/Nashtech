using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int cId { get; set;}
        public string type { get; set;}
        public int bId { get; set;}
    }
}