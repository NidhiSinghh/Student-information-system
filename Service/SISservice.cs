
using sis_v2.Models;
using sis_v2.Repository;
using System;
using System.Collections.Generic;
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

        public void EnrollInCourse()
        {
            //check whether student exisrs then check whether that course exists
            Console.WriteLine("Enter student id");
            int stuId = int.Parse(Console.ReadLine());

            Console.WriteLine("Entire the desire course");
            string desiredCourse = Console.ReadLine();

            Enrollment enroll = new Enrollment()
            {
                StudentId=stuId,
                EnrollmentDate=DateTime.Now,
            };
            int enrollStatus=isisrepository.EnrollInCourse(enroll, desiredCourse);
            if (enrollStatus != 0)
            {
                Console.WriteLine($"Student {stuId} enrolled in {desiredCourse} ");
            }
            else
            {
                Console.WriteLine("couldnt enroll");
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

        public void MakePayment()
        {
            Console.WriteLine("enter student id");
            int stuIdtoPay=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter payment amount");
            double amt=double.Parse(Console.ReadLine());

            Payment payment = new Payment()
            {
                StudentId = stuIdtoPay,
                Amount = amt,
                PaymentDate = DateTime.Now,
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
    }

}
