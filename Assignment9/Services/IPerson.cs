using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;
namespace Assignment9.Services
{
    public interface IPerson
    {

        List<PersonModel> GetAll();
        void Add(PersonModel person);
        void Update(int id, PersonModel person);
        void Delete(int id);
        List<PersonModel> FilterName(string name);
         List<PersonModel> FilterPlace(string birthplace);
          List<PersonModel> FilterGender(Gender gender);
      
    }
}