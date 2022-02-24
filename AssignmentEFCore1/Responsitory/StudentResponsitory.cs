using System;
using System.Collections.Generic;
using AssignmentEFCore1.Models;

namespace AssignmentEFCore1.Responsitory{
    public class StudentResponsitory : IResponsitory
    {private readonly StudentDBContext _studentDbContext;
        public StudentResponsitory(StudentDBContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public void Create(Student student)
        {
            _studentDbContext.Student.Add(student);
            _studentDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var studentDelete = _studentDbContext.Student.Where(x => x.StudentId == Id).FirstOrDefault();
            _studentDbContext.Student.Remove(studentDelete);
            _studentDbContext.SaveChanges();
        }

        public List<Student> GetStudents()
        {
           return _studentDbContext.Student.ToList();
        }

        public void Update(Student student)
        {
            var studentUpdate = _studentDbContext.Student.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            studentUpdate.FirstName = student.FirstName;
            studentUpdate.LastName = student.LastName;
            studentUpdate.City = student.City;
            studentUpdate.State = student.State;
            _studentDbContext.SaveChanges();

        }
    }
}