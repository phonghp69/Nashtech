using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment7.Models;

namespace Assignment7.Implement
{
    public class Person : IPerson
    {
        public void Create(PersonModel person)
        {
           if (person.Id == 0)
            {
                var newId = list.Max(x => x.Id);
                person.Id = newId + 1;
                list.Add(person);
            }
            else
            {
                list.RemoveAll(x => x.Id == person.Id);
                list.Add(person);
            }
        }

       

        public static List<PersonModel> list = new List<PersonModel>{
        new PersonModel
            {
                Id = 1,
                BirthPlace = "Ha Noi", DateOfBirth = new DateTime(2000, 1, 20), FirstName = "Tuan ",
                Gender = Gender.Male, LastName = "Phong", IsGraduated = true, PhoneNumber = "0111222333"
            },
            new PersonModel
            {
                Id = 2,
                BirthPlace = "HCM", DateOfBirth = new DateTime(1999, 1, 20), FirstName = "Van",
                Gender = Gender.Female, LastName = "Phuc", IsGraduated = false, PhoneNumber = "0111422333"
            },
            new PersonModel
            {
                Id = 3,
                BirthPlace = "Da Nang", DateOfBirth = new DateTime(2000, 11, 11), FirstName = "Dinh",
                Gender = Gender.Other, LastName = "Khoi", IsGraduated = true, PhoneNumber = "0111522333"
            },
        };

        public void Update(PersonModel person)
        {
           if (person.Id == 0)
            {
                var newId = list.Max(x => x.Id);
                person.Id = newId + 1;
                list.Add(person);
            }
            else
            {
                list.RemoveAll(x => x.Id == person.Id);
                list.Add(person);
            }

        }

        public List<PersonModel> List()
        {
            return list;
        }

        public PersonModel Details(int id)
        {
            var detail = list.Where(s => s.Id == id).FirstOrDefault();
            return detail;
        }
         public PersonModel Delete(int id)
        {
            var person = list.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                list.Remove(person);
            }
            return person;
        }

       
    }
}