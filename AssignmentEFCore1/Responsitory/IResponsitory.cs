using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore1.Models;
namespace AssignmentEFCore1.Responsitory
{
    public interface IResponsitory
    {
         public List<Student> GetStudents();
        public void Create(Student student);

        public void Update(Student student);

        public void Delete(int Id);
    }
}