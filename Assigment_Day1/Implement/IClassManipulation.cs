using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_Day1;
using static Assignment_Day1.Member;

namespace Assigment_Day1.Implement
{
    public interface IClassManipulation
    {
         
        public List<Member> GetMemberByGender(List<Member> list , Genderz gender);
       public Member GetMemberOldest(List<Member> list);
       public List<string> GetMemberFullName(List<Member> list);
     public  List<Member> GetMembersInPlace(List<Member> list, string place);
     public Tuple<List<Member>, List<Member>, List<Member>> SlitMembersByBirthYear(List<Member> list);
    }
}