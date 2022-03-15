using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_end.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int uid{ get; set; }
        public string username{ get; set; }
        public string password{ get; set; }
        public string name{ get; set; }
        public string gender{ get; set; }
        public DateTime dateofbirth{ get; set; }
        public string email{ get; set; }
        public string phone{ get; set; }
        public string address{ get; set; }
        public bool permissions { get; set; }
        

        
    }
}