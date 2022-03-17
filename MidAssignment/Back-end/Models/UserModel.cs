
namespace Back_end.Models
{
   
    public class UserModel
    {
        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Permissions { get; set; }

    }
}