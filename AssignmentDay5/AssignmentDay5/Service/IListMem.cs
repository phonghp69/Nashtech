using AssignmentDay5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay5.Service
{
   public interface IListMem
    {
        public List<Person> GetPeopleByGender(List<Person> members, Gender gender);
        public List<Person> GetPeopleFullName(List<Person> members);
        public List<Person> GetPeopleOldest(List<Person> members);
        public List<Person> CreatePeople();
       
    }
}
