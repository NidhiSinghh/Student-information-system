
using SIS.Exceptions;
using sis_v2.Models;
using sis_v2.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Service
{
    internal class SISservice: ISISService
    {

        ISISRepository isisrepository;
        public SISservice()
        {
            isisrepository = new SISRepository();

        }

        public void DisplayCourseInfo()
        {
            List<Course> courseInfo = isisrepository.DisplayCourseInfo();
            if (courseInfo != null)
            {
                foreach (Course course in courseInfo)
                {
                    Console.WriteLine(course);
                }
            }
            else
            {
                Console.WriteLine("Course information cant be displayed");
            }
        }

        public void DisplayStudentInfo()
        {
            
            List<Student> stuInfo=isisrepository.DisplayStudentInfo();
            if (stuInfo != null)
            {
                foreach (Student student in stuInfo)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Student information cant be displayed");
            }
        }

        public void DisplayTeacherInfo()
        {
            List<Teacher> teacherInfo = isisrepository.DisplayTeacherInfo();
            if (teacherInfo != null)
            {
                foreach (Teacher teacher in teacherInfo)
                {
                    Console.WriteLine(teacher);
                }
            }
            else
            {
                Console.WriteLine("Course information cant be displayed");
            }
        }

        public void EnrollInCourse()
        {
            try
            {
                //check whether student exisrs then check whether that course exists
                Console.WriteLine("Enter student id");
                int stuId = int.Parse(Console.ReadLine());

                Console.WriteLine("Entire the desire course");
                string desiredCourse = Console.ReadLine();

                Enrollment enroll = new Enrollment()
                {
                    StudentId = stuId,
                    EnrollmentDate = DateTime.Now,
                };
                int enrollStatus = isisrepository.EnrollInCourse(enroll, desiredCourse);
                if (enrollStatus != 0)
                {
                    Console.WriteLine($"Student {stuId} enrolled in {desiredCourse} ");
                }
                else
                {
                    Console.WriteLine("couldnt enroll");
                }
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GetAssignedCourses()
        {
            Console.WriteLine("Enter teacher id");
            int teacherId = int.Parse(Console.ReadLine());
            List<Object> coursesToTeacher = isisrepository.GetAssignedCourses(teacherId);
            foreach (Object course in coursesToTeacher)
            { Console.WriteLine(course); }
        }

        public void GetCourse()
        {
            Console.WriteLine("Enter Enrollment id");
            int eId = int.Parse(Console.ReadLine());
            var result = isisrepository.GetCourse(eId);
            Console.WriteLine(result);
        }

        public void GetCourseById()
        {
            Console.WriteLine("ENter course id");
            int cId=int.Parse(Console.ReadLine());
            Course courseById = isisrepository.GetCourseById(cId);
            if (courseById != null)
            {
                Console.WriteLine(courseById);
                //Console.WriteLine($"Course found: ID: {courseById.CourseId}, Code: {courseById.CourseCode}, Name: {courseById.CourseName}, Instructor: {courseById.Instructor}");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }

        }

        public void GetEnrolledCourses()
        {
            List<Object> stuWithCourseDetails=isisrepository.GetEnrolledCourses();
            foreach (var student in stuWithCourseDetails)
            {
                //foreach(var studentWithCourse in student)
                //{
                    //var stuToCourseDetail = (dynamic)student;
                    //Console.WriteLine($"Student: {stuToCourseDetail.FirstName} {stuToCourseDetail.LastName}\t Enrolled Course: {stuToCourseDetail.CourseName}");
                    //Console.WriteLine($"Enrolled Course: {stuToCourseDetail.CourseName}");
                    Console.WriteLine(student);
                    //Console.WriteLine($"Student: {studentWithCourse.FirstName} {studentWithCourse.LastName} Enrolled Course: {studentWithCourse.CourseName}");

                    //Console.WriteLine(); // Add a newline for better readability
                //}
            }
        }

        public void GetEnrollments()
        {
            Console.WriteLine("Enter courseid whose enrollments you want to see");
            int courseId = int.Parse(Console.ReadLine());
            List<Enrollment> stuEnrolled =isisrepository.GetEnrollments(courseId);
            if( stuEnrolled != null )
            {
                foreach(Enrollment enrollment in stuEnrolled) 
                { 
                    Console.WriteLine(enrollment);
                }
            }
            else
            {

                Console.WriteLine("No enrollments record found");
            }
        }

        public void GetPaymentAmount()
        {
            Console.WriteLine("Enter payment id");
            int payId = int.Parse(Console.ReadLine());
            var paymentAmountFromId=isisrepository.GetPaymentAmount(payId);
            Console.WriteLine(paymentAmountFromId);
        }

        public void GetPaymentDate()
        {
            Console.WriteLine("Enter payment id");
            int payId=int.Parse(Console.ReadLine());
            var payDate=isisrepository.GetPaymentDate(payId);
            Console.WriteLine(payDate);
        }

        public void GetPaymentHistory()

        {
            Console.WriteLine("Enter student id");
            int stuId=int.Parse(Console.ReadLine());
            Student s=isisrepository.getStudentById(stuId);
            if (s!=null)
            {
                List<Payment> payForAStudent = isisrepository.GetPaymentHistory(stuId);
                foreach (Payment payment in payForAStudent)
                {
                    Console.WriteLine(payment);

                }
            }
            else
            {
                Console.WriteLine("Student doesnt exist");
            }
        }

        public void GetStudentById()
        {
            try
            {
                Console.WriteLine("ENter student id");
                int sId = int.Parse(Console.ReadLine());
                Student studentById = isisrepository.getStudentById(sId);
                if (studentById != null)
                {
                    Console.WriteLine(studentById);
                    //Console.WriteLine($"Course found: ID: {courseById.CourseId}, Code: {courseById.CourseCode}, Name: {courseById.CourseName}, Instructor: {courseById.Instructor}");
                }
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void GetStudentWithEnrollment()
        {
            Console.WriteLine("Enter Enrollment id");
            int eId = int.Parse(Console.ReadLine());
            var result = isisrepository.GetStudentWithEnrollment(eId);
            Console.WriteLine(result);
        }

        public void GetStudentWithPayment()
        {
            Console.WriteLine("Enter Payment id");
            int paymentId = int.Parse(Console.ReadLine());
            var result = isisrepository.GetStudentWithPayment(paymentId);
            foreach(Object o in result)
            {  Console.WriteLine(o); }
            
        }

        public void GetTeacher()
        {
            Console.WriteLine("Enter Course id");
            int courseId=int.Parse(Console.ReadLine()) ;
            var result=isisrepository.GetTeacher(courseId);
            Console.WriteLine(result);
        }

        public void GetTeacherById()
        {
            try
            {
                Console.WriteLine("ENter teacher id");
                int tId = int.Parse(Console.ReadLine());
                Teacher teacherById = isisrepository.GetTeacherById(tId);
                if (teacherById != null)
                {
                    Console.WriteLine(teacherById);
                    //Console.WriteLine($"Course found: ID: {courseById.CourseId}, Code: {courseById.CourseCode}, Name: {courseById.CourseName}, Instructor: {courseById.Instructor}");
                }
            }
            catch (TeacherNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void MakePayment()
        {
            Console.WriteLine("enter student id");
            int stuIdtoPay=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter payment amount");
            double amt=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter payment date");
            DateTime dt=DateTime.Parse(Console.ReadLine());

            Payment payment = new Payment()
            {
                StudentId = stuIdtoPay,
                Amount = amt,
                PaymentDate = dt,
            };
            int payStatus=isisrepository.MakePayment(payment);
            if (payStatus != 0)
            {
                Console.WriteLine("Payment successful");
            }
            else
            {
                Console.WriteLine("Payment unsuccesful");
            }
        }

        public void UpdateCourseInfo()
        {
            try
            {
                Console.WriteLine("Enter course id");
                int cId = int.Parse(Console.ReadLine());
                Course courseInfoFromId = isisrepository.GetCourseById(cId);

                if (isisrepository.GetCourseById(cId) != null)
                {
                    Console.WriteLine("Enter new teacher id (optional, press Enter to skip)");
                    string input = Console.ReadLine();
                    int? tId = input != "" ? int.Parse(input) : (int?)null;

                    Console.WriteLine("Enter new course name (optional, press Enter to skip)");
                    input = Console.ReadLine();
                    string? cName = input != "" ? input : null;

                    Console.WriteLine("Enter new credits (optional, press Enter to skip)");
                    input = Console.ReadLine();
                    int? credits = input != "" ? int.Parse(input) : (int?)null;

                    int courseUpdateStatus = isisrepository.UpdateCourseInfo(new Course()
                    {
                        CourseId = cId,
                        TeacherId = tId,
                        CourseName = cName,
                        Credits = credits,

                    });


                    if (courseUpdateStatus != 0)
                    {
                        Console.WriteLine("Course info updated");
                    }
                    else
                    {
                        Console.WriteLine("Course info not updated");
                    }
                }
                else
                {
                    throw new CourseNotFoundException($"Course with id {cId} not found !!");
                }
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
            

        }


        public void UpdateStudentInfo()
        {
            //check if student exists
            Console.WriteLine("Enter student id to update the details");
            int stuId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter first name");
            string fname=Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lname=Console.ReadLine();
            Console.WriteLine("Enter email");
            string email=Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phone=Console.ReadLine();
            Console.WriteLine("Enter DOB");
            DateTime dob=DateTime.Parse(Console.ReadLine());

            int stuUpdateStatus=isisrepository.UpdateStudentInfo(new Student()
            {
                StudentId=stuId,
                FirstName=fname,
                LastName=lname,
                DateOfBirth=dob,
                Email=email,
                PhoneNo=phone,

            });

            if (stuUpdateStatus==0)
            {
                Console.WriteLine("Informaton not updated");
            }
            else
            {
                Console.WriteLine("Info updated");
            }
        }

        public void UpdateTeacherInfo()
        {

            try
            {
                //check if teacher exists
                Console.WriteLine("Enter teacher id to update the details");
                int teacherId = int.Parse(Console.ReadLine());
                if (isisrepository.GetTeacherById(teacherId) != null)
                {
                    Console.WriteLine("Enter first name");
                    string fname = Console.ReadLine();
                    Console.WriteLine("Enter last name");
                    string lname = Console.ReadLine();
                    Console.WriteLine("Enter email");
                    string email = Console.ReadLine();


                    int teacherUpdateStatus = isisrepository.UpdateTeacherInfo(new Teacher()
                    {
                        TeacherId = teacherId,
                        FirstName = fname,
                        LastName = lname,
                        Email = email,


                    });

                    if (teacherUpdateStatus == 0)
                    {
                        Console.WriteLine("Informaton not updated");
                    }
                    else
                    {
                        Console.WriteLine("Info updated");
                    }

                }
                else
                {
                    throw new TeacherNotFoundException($"Teacher with id {teacherId} not found");
                }
            }
            catch (TeacherNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexcpected error :{e.Message}");
            }
            
        }

    }

}
