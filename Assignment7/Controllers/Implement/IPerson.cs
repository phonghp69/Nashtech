using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment7.Models;

namespace Assignment7.Implement
{
    public interface IPerson
    {
        public List<PersonModel> List();
        public void Create(PersonModel per);
         public PersonModel Details(int id);
        public void Update(PersonModel per);
        public PersonModel Delete(int id);
       
    }
}