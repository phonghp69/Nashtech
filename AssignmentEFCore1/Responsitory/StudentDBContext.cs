using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssignmentEFCore1.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentEFCore1.Responsitory {
    public class StudentDBContext : DbContext {
        public StudentDBContext() { }
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        // }

        public DbSet<Student> Student { get; set; }
    }
}
