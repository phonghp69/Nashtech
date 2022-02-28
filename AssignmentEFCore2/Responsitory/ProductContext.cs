using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssignmentEFCore2.Models;
namespace AssignmentEFCore2.Responsitory
{
    public class ProductContext : DbContext
    {
        public ProductContext(){}
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
         public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
       
    }
}