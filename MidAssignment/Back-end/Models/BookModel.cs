
namespace Back_end.Models
{
    
    public class BookModel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; } 
        public string Description { get; set; }
        public int? RequestId { get; set; } = null;
        public int CategoryId { get; set; }      
        public bool Available { get; set; }
    }
}