using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Models
{
    internal class Enrollment
    {


        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //public Enrollment() { }

        //public Enrollment(int enrolId,int stuId,int courseId,DateTime enrolDate) { 
        //    EnrollmentId = enrolId;
        //    StudentId = stuId;
        //    CourseId = courseId;
        //   EnrollmentDate = enrolDate;
        //}

        public override string ToString()
        {
            return $"Enrollemt Id:{EnrollmentId}\t,Student Id:{StudentId}\t,Course Id: {CourseId},Enroll Date:{EnrollmentDate} ";
        }
    }
}
