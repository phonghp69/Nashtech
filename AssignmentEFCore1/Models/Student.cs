using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AssignmentEFCore1.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Column("FistName", TypeName="ntext")]
        [MaxLength(50)]
        public string FirstName { get; set;}

        [Column("LastName", TypeName="ntext")]
        [MaxLength(50)]
        public string LastName { get; set;}

        [Column("City", TypeName="ntext")]
        [MaxLength(150)]
        public string City { get; set;}
        
        [Column("State", TypeName="ntext")]
        [MaxLength(150)]
        public string State { get; set;}
    }
}