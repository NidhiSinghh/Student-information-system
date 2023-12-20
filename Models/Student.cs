using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Models
{
    internal class Student
    {
        public int StudentId {get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNo {  get; set; }

        //public Student() { }
        //public Student(int id,string firstName,string lastName,DateTime dateOfBirth,string email,string phoneNo)
        //{
        //    StudentId = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    DateOfBirth = dateOfBirth;
        //    Email = email;
        //    PhoneNo = phoneNo;


        //}
        public override string ToString()
        {
            return $"Student Id:{StudentId}\tfirst Name:{FirstName}\tLast Name:{LastName}\t DOB:{DateOfBirth}\tEmail:{Email}\tPhone:{PhoneNo} ";
      }

    }
}
