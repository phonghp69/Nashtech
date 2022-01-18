using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_Day1;
using static Assignment_Day1.Member;

namespace Assigment_Day1.Implement
{
    public class ClassManipulation: IClassManipulation
    {
       

        public List<Member> GetMemberByGender(List<Member> list, Genderz gender)
        {
            foreach (var item in list)
            {
                if (item.Gender == gender)
                {
                    item.Show();
                }
            }
            return list;
        }

        public List<string> GetMemberFullName(List<Member> list)
        {

            var rs = new List<String>();
          
            foreach (var item in list)
            {
               String fullName = item.FirstName + " " + item.LastName;
               Console.WriteLine(fullName);
            }
            return rs;
        }

        public Member GetMemberOldest(List<Member> list)
        {
           
            var oldest = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                var member = list[i];
                if (member.CompareTo(oldest) > 0)
                {
                    oldest = member;

                }
            }
            Console.WriteLine(oldest);
            return oldest;
            
        }

        public List<Member> GetMembersInPlace(List<Member> list,string place)
        {
           
            foreach (var item in list)
            {
                if (item.Place.Equals(place))
                {
                    item.Show();
                }
            }
            return list;
        }
        
        public Tuple<List<Member>, List<Member>, List<Member>> SlitMembersByBirthYear(List<Member> list)
        {
            var list1 = new List<Member>();
            var list2 = new List<Member>();
            var list3 = new List<Member>();
            foreach(var item in list)
            {
                var birthYear = item.BirthDay.Year;
                switch (birthYear)
                {
                    case 2000:
                        list1.Add(item);
                        item.Show();
                        break;
                    case > 2000:
                        list2.Add(item);
                        item.Show();
                        break;
                    case < 2000:
                        list3.Add(item);
                        item.Show();
                        break;

                }
            }
            return Tuple.Create(list1, list2, list3);
        }
    }
}
