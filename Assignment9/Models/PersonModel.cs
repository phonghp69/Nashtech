using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
   public enum Gender{Male,Female, Other}
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime DateOfBirth {get; set;}
        public Gender Gender {get; set;}
        public string BirthPlace {get; set;}
    }
}