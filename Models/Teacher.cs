using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Models
{
    internal class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }

    //    public Teacher() { }

    //    public Teacher(int id, string firstName, string lastName, string email)
    //    {
    //        TeacherId = id;
    //        FirstName=firstName;
    //        LastName=lastName;
    //        Email=email;

    //}
        public override string ToString()
        {
            return $"Teacher Id:{TeacherId}\tfirst Name:{FirstName}\tLast Name:{LastName}\tEMail:{Email}";
        }

    }

   
}
