
namespace Back_end.Models
{
  public enum Status {Approved,Rejected,Waiting }
    public class BookBorrowingRequestDetailsModel
    {
      
        public int Id { get; set; } 
        public int UserId { get; set; }      
        public DateTime Dateborrow { get; set; }
        public Status Status { get; set; }
        public int UserModId { get; set; }
        
    }
}