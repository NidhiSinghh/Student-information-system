
using sis_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Repository
{
    internal interface ISISRepository
    {
        Student getStudentById(int id);
        int UpdateStudentInfo(Student stu);
        List<Student> DisplayStudentInfo();
        List<Object> GetEnrolledCourses();
        int EnrollInCourse(Enrollment e,string courseName);
        int MakePayment(Payment p);

    }
}
