using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment8.Models;
namespace Assignment8.Implement
{
    public class Person : IPerson
    {
        public static List<PersonModel> list = new List<PersonModel>{
             new PersonModel{              
                 Title = "task 1",
                 IsCompleted = true
            },
            new PersonModel{
                 Title = "task 2",
                 IsCompleted = false
            },
            new PersonModel{
                 Title = "task 3",
                 IsCompleted = false
            }
        };

        public PersonModel Add(PersonModel PersonModel)
        {
            list.Add(PersonModel);
            return PersonModel;
        }

        public List<PersonModel> Add(List<PersonModel> persons)
        {
            list.AddRange(persons); 
            return persons;   
        }

        public void Delete(Guid id)
        {
           var rs = list.FirstOrDefault(t => t.Id == id);
            if (rs != null)
            {
                list.Remove(rs);
            }
        }

        public void Delete(List<Guid> ids)
        {
               list.RemoveAll(x => ids.Contains(x.Id));
        }

        public List<PersonModel> GetAll()
        {
          return list;
        }

        public PersonModel? GetOne(Guid id)
        {
              return list.FirstOrDefault(x => x.Id == id);  
        }

        public PersonModel? Update(PersonModel PersonModel)
        {
             var rs = list.FirstOrDefault(x => x.Id == PersonModel.Id);
            if (rs == null) return null;
            rs.Title = PersonModel.Title;
            rs.IsCompleted = PersonModel.IsCompleted;

            return rs;
        }
    }
}