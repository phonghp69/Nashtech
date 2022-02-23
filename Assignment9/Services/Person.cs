using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;
namespace Assignment9.Services
{
    public class Person : IPerson
    {
        public static List<PersonModel> list = new List<PersonModel>{
        new PersonModel
            {
                Id = 1,
                BirthPlace = "Ha Noi", DateOfBirth = new DateTime(2000, 1, 20), FirstName = "Tuan ",
                Gender = Gender.Male, LastName = "Phong"
            },
            new PersonModel
            {
                Id = 2,
                BirthPlace = "HCM", DateOfBirth = new DateTime(1999, 1, 20), FirstName = "Van",
                Gender = Gender.Female, LastName = "Phuc"
            },
            new PersonModel
            {
                Id = 3,
                BirthPlace = "Da Nang", DateOfBirth = new DateTime(2000, 11, 11), FirstName = "Dinh",
                Gender = Gender.Other, LastName = "Khoi"
            },
        };

        public void Add(PersonModel person)
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

        public void Delete(int id)
        {
            var person = list.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                list.Remove(person);
            }

        }

        public List<PersonModel> FilterName(string name)
        {
            return list.Where(person =>
                 (person.FirstName.ToLower().Trim() + " " + person.LastName.ToLower().Trim()).Trim() == name.ToLower().Trim()).ToList();
        }
        public List<PersonModel> FilterPlace(string birthplace)
        {

            return list.Where(person => person.BirthPlace.ToLower().Trim() == birthplace.ToLower().Trim()).ToList();

        }
        public List<PersonModel> FilterGender(Gender gender)
        {

            return list.Where(person => person.Gender == gender).ToList();

        }


        public List<PersonModel> GetAll()
        {

            return list;
        }

        public void Update(int id, PersonModel personz)
        {
            var person = list.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                person.FirstName = personz.FirstName;
                person.LastName = personz.LastName;
                person.DateOfBirth = personz.DateOfBirth;
                person.Gender = personz.Gender;
                person.BirthPlace = personz.BirthPlace;
            }
        }
    }
}

