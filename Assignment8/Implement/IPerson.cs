using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment8.Models;
namespace Assignment8.Implement
{
    public interface IPerson
    {
       List<PersonModel> GetAll();
         PersonModel? GetOne(Guid id);

         PersonModel Add(PersonModel PersonModel);    

         PersonModel? Update(PersonModel PersonModel);

        void Delete(Guid id);

        List<PersonModel> Add(List<PersonModel> persons);

        void Delete(List<Guid> ids);   
    }
}