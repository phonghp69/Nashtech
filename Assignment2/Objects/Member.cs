using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Member
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
        public uint Age
        {
            get
            {
                return (uint)(DateTime.Now.Year - BirthDay.Year);
            }
        }
        
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

        public string Show(){
          return ($" {FirstName}   {LastName}   {Gender}   {BirthDay.ToString("yyyy/MM/dd")}   {Place}   {Phone}   {Age}   {Graduated}");

        }
        public string FullName(){
                return ($" {FirstName}   {LastName}");
           // return FirstName +" "+LastName ;
        }
      
    }
}
