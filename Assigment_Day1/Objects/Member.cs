using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment_Day1
{
    public class Member : IComparable
    {

        public Member(string firstName, DateTime birthDay)
        {
            this.FirstName = firstName;
            this.BirthDay = birthDay;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enum Genderz { Male, Female, Other }
        private Genderz gender1;

        public Genderz Gender
        {
            get { return gender1; }
            set { gender1 = value; }
        }


        public DateTime BirthDay { get; set; }

        public string Phone { get; set; }
        public string Place { get; set; }
        public  uint Age
        {
            get
            {
                return (uint)(DateTime.Now.Year - BirthDay.Year);
            }
        }
        // public uint Age { get;  set; }
        public bool Graduated { get; set; }

        public Member() { }
        public Member(string fistname, string lastname, Genderz gender, DateTime birth, string phone, string place, bool graduated)
        {
            FirstName = fistname;
            LastName = lastname;
            Gender = gender;
            BirthDay = birth;
            Phone = phone;
            Place = place;
           
            Graduated = graduated;
        }

        public void Show()
        {
            Console.WriteLine(FirstName + "\t" + LastName + "\t" + Gender + "\t" + BirthDay.ToString("yyyy/MM/dd") + "\t" + Phone + "\t" + Place + "\t" + Age + "\t" + Graduated);

            //Console.WriteLine($"{FirstName} {LastName} {Gender} {BirthDay.ToString("dd/MM/yyyy")} {Place} {Phone} {Age} {Graduated}");

        }



        public string FullName
        {
            get { return FirstName + LastName; }
        }


        public int ToTalDays
        {
            get
            {
                return (int)(DateTime.Now - BirthDay).TotalDays;
            }
        }
        public int CompareTo(object obj)
        {
            return ToTalDays.CompareTo((Member)obj);
        }

    }
}
