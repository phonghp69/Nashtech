using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentEFCore1.Models;
using AssignmentEFCore1.Responsitory;
namespace AssignmentEFCore1.Services
{
    public class Services : IServices
    { private readonly IResponsitory _iResponsitory;
        
        public Services(IResponsitory iResponsitory)
        {
            _iResponsitory = iResponsitory;
        }

        public void Create(Student student)
        {
           _iResponsitory.Create(student);
        }

        public void Delete(int Id)
        {
            _iResponsitory.Delete(Id);
        }

        public List<Student> GetStudents()
        {
            return _iResponsitory.GetStudents();
        }

        public void Update(Student student)
        {
            _iResponsitory.Update(student);
        }
    }
}