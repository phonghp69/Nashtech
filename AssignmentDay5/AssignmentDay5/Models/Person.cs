using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay5.Models
{
    
        public enum Gender { Male, Female, Other }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string PhoneNumber { get; set; }
            public string BirthAdress { get; set; }
            public bool IsGraduated { get; set; }
            public string FullName => $"{FirstName} {LastName}"; 
       
    }
    
}
