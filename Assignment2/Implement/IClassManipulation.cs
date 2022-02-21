using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2;
using static Assignment2.Member;

namespace Assigment2.Implement
{
    public interface IClassManipulation
    {

        List<Member> GetMemberByGender(List<Member> list, Genderz gender);
        Member GetMemberOldest(List<Member> list);
        List<string> GetMemberFullName(List<Member> list);
        List<Member> GetMembersInPlace(List<Member> list, string place);
        public List<Member> GetListSplitByAge(List<Member> list);
    }
    public class ClassManipulation : IClassManipulation
    {


        public List<Member> GetMemberByGender(List<Member> list, Genderz gender)
        {
            var get_member_by_gender = from Member in list where Member.Gender == gender select Member;

            foreach (var item in get_member_by_gender)
            {
                Console.WriteLine(item.Show());
            }
            return list;
        }

        public List<string> GetMemberFullName(List<Member> list)
        {
            var get_member_full_name = (from Member in list select Member.FullName()).ToList();
             get_member_full_name.ForEach(Member => Console.WriteLine(Member));
            
           
            return get_member_full_name.ToList();
        }

        public Member GetMemberOldest(List<Member> list)
        {


            var get_member_oldest = (from Member in list orderby Member.BirthDay ascending select Member).FirstOrDefault();

            
            Console.WriteLine(get_member_oldest.Show());
            return null;

        }

        public List<Member> GetMembersInPlace(List<Member> list, string place)
        {

            var get_member_place = (from Member in list where Member.Place == place select Member).FirstOrDefault();
            
                Console.WriteLine(get_member_place.Show());
            
            return list;
        }

        public List<Member> GetListSplitByAge(List<Member> list)
        {
            var ListEqual2000 = (from member in list where member.BirthDay.Year == 2000 select member);
            var ListUnder2000 = (from member in list where member.BirthDay.Year < 2000 select member);
            var ListOver2000 = (from member in list where member.BirthDay.Year > 2000 select member);

            foreach (var item in ListEqual2000)
            {
                Console.WriteLine(item.Show());
            }
            Console.WriteLine("=======================");
            foreach (var item in ListUnder2000)
            {
                Console.WriteLine(item.Show());
            }
            Console.WriteLine("=======================");
            foreach (var item in ListOver2000)
            {
                Console.WriteLine(item.Show());
            }

            return list;

        }


    }
}