using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEFCore2.Models
{
    [Table("Categories")]  
     public class Category
    {
         [Key]
        public int cId { get; set; }

        // [Column("CategoryName", TypeName="ntext")]
        // [MaxLength(150)]
        public string cName { get; set; }
         public List<Product> products { get; } = new List<Product>();
    }
}