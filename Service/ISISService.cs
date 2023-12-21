using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Service
{
    internal interface ISISService
    {

        void DisplayStudentInfo();
       void UpdateStudentInfo();
        void GetEnrolledCourses();
       void EnrollInCourse();
        void MakePayment();
        void GetPaymentHistory();
        void DisplayCourseInfo();
        void DisplayTeacherInfo();
        void UpdateCourseInfo();
        void GetCourseById();
        void GetEnrollments();
        void GetTeacher();
        void GetStudentWithEnrollment();
        void  GetCourse();
        void UpdateTeacherInfo();
        void GetAssignedCourses();
        void GetStudentWithPayment();
        void GetPaymentAmount();
        void GetPaymentDate();
        void GetStudentById();
        void GetTeacherById();
    }
}
