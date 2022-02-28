using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AssignmentEFCore2.Models
{
     [Table("Product")]
    public class Product
    {
          [Key]
        public int pId { get; set; }

        // [Column("ProductName", TypeName = "ntext")]
        public string pName { get; set; }
        
        // [Column("Manufacture", TypeName = "ntext")]
        public string Manufacture { get; set; }

        //public int CategoryId { get; set; }
        [ForeignKey("cId")]
        public Category Category { get; set; }
    }
}