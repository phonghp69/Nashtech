using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Models
{
    [Table("RequestDetails")]
    public class BookBorrowingRequestDetails
    {
        [Key]
        public int did { get; set; }
        public int uid { get; set; }
        public DateTime dateborrow { get; set; }
        public string status { get; set; }
        public string whorequest { get; set; }
    }
}