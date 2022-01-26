using AssignmentDay5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay5.Service
{
    public class ListMem : IListMem
    {
        public List<Person> GetPeopleByGender(List<Person> members, Gender gender)
        {
            var lst = new List<Person>();
            foreach (var m in members)
            {
                if (m.Gender == gender)
                    lst.Add(m);
            }

            return lst;
        }
        
        public List<Person> CreatePeople()
        {
            return new List<Person> {
              new Person{FirstName = "Phuc",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,7,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true},
                new Person{FirstName = "Huyen",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthAdress="Hung Yen",PhoneNumber="094632123",IsGraduated=false},
               new Person{FirstName = "Thuy Phuong",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,4,27)
              ,BirthAdress="Bac Ninh",PhoneNumber="083641232",IsGraduated=true},
               new Person{FirstName = "Khoi",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,4,23)
              ,BirthAdress="Ha Noi",PhoneNumber="0876416708",IsGraduated=true},
                new Person{FirstName = "Hoa",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,12,6)
              ,BirthAdress="Lang Son",PhoneNumber="0912321643",IsGraduated=true}
            };
        }

        public List<Person> GetPeopleFullName(List<Person> members)
        {
            foreach(var item in members)
            {             
                Console.WriteLine(item.FullName);
            }
            return members;
        }

        public List<Person> GetPeopleOldest(List<Person> members)
        {
            var get_member_oldest = (from Person in members orderby Person.DateOfBirth ascending select Person).FirstOrDefault();

            Console.WriteLine(get_member_oldest);

            return members;
        }
    }
}
