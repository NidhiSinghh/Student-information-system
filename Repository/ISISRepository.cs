
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
        List<Payment> GetPaymentHistory(int id);
        List<Course> DisplayCourseInfo();
        List<Teacher> DisplayTeacherInfo();
        int UpdateCourseInfo(Course course);
        Course GetCourseById(int cId);
        Teacher GetTeacherById(int tId);
        List<Enrollment> GetEnrollments(int courseId);
        Object GetTeacher(int courseId);
        //int AssignTeacher(Teacher t, int courseId);
        //Object GetStudent(int enrollmentId);
        Object GetCourse(int enrollmentId);
        int UpdateTeacherInfo(Teacher teacher);
        List<object> GetAssignedCourses(int teacherId);
        Object GetStudentWithEnrollment(int eId);
        List<Object> GetStudentWithPayment(int paymentId);
        Object GetPaymentAmount(int PaymentId);
        Object GetPaymentDate(int PaymentId);
        


    }
}
