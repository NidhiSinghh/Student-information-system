
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using sis_v2.Utility;
using sis_v2.Models;


namespace sis_v2.Repository
{
    internal class SISRepository:ISISRepository

    {

        public string ConnectionString;
        SqlCommand cmd = null;

       public SISRepository() {
            ConnectionString=DbUtil.GetConnectionString();
            cmd= new SqlCommand();
        
        }

        public List<Student> DisplayStudentInfo()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    cmd.Parameters.Clear();


                    cmd.CommandText = "Select * from Students ";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentId = (int)reader["STUDENT_ID"];
                        student.FirstName = (string)reader["FIRST_NAME"];
                        student.PhoneNo = (string)reader["PHONE"];
                        student.Email = (string)reader["EMAIL"];
                        student.DateOfBirth = (DateTime)reader["DOB"];
                        student.LastName = (string)reader["LAST_NAME"];
                        students.Add(student);
                    }
                    


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;


        }

        public int EnrollInCourse(Enrollment e,string courseName)
        {
            int course_id = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select COURSE_ID FROM COURSES WHERE COURSE_NAME=@desiredCourse" ;

                cmd.Parameters.AddWithValue("@desiredCourse", courseName);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        course_id = (int)reader["COURSE_ID"];
                    }
                }
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO ENROLLMENTS VALUES(@cid,@sid,@enroldate) ";
                cmd.Parameters.AddWithValue("@cid",course_id);
                cmd.Parameters.AddWithValue("@sid",e.StudentId);
                cmd.Parameters.AddWithValue("enroldate",e.EnrollmentDate);
                int enrollStatus=cmd.ExecuteNonQuery();
                return enrollStatus;
           }
        }

        public List<object> GetEnrolledCourses()
        {
            List<object> stuToCourseDetails = new List<object>();
            //List<Course> stuToCourseDetails = new List<object>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT S.FIRST_NAME,S.LAST_NAME,C.COURSE_NAME ");
                sb.Append("FROM STUDENTS S JOIN Enrollments E  ON S.STUDENT_ID=E.STUDENT_ID ");
                sb.Append("JOIN COURSES   C ON C.COURSE_ID=E.COURSE_ID ");
                sb.Append("GROUP BY S.STUDENT_ID,S.FIRST_NAME,S.LAST_NAME,C.COURSE_NAME");
                cmd.CommandText = sb.ToString();
                
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var stuToCourseDetail = new
                    {
                        FirstName = (string)reader["FIRST_NAME"],
                        LastName = (string)reader["LAST_NAME"],
                        CourseName = (string)reader["COURSE_NAME"],
                        

                    };

                    stuToCourseDetails.Add(stuToCourseDetail);
                    
                  

                }

                return stuToCourseDetails;
            }
        }

        public Student getStudentById(int stuId)
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {


                cmd.Parameters.Clear();
                cmd.CommandText = "Select * from Students where STUDENT_ID=@stuId ";
                cmd.Parameters.AddWithValue("@stuId", stuId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student studentbyId = new Student()
                    {
                        // student.StudentId = (int)reader["STUDENT_ID"];
                        FirstName = (string)reader["FIRST_NAME"],
                        PhoneNo = (string)reader["PHONE"],
                        Email = (string)reader["EMAIL"],
                        DateOfBirth = (DateTime)reader["DOB"],
                        LastName = (string)reader["LAST_NAME"],
                    };
                    return studentbyId;

                }
                return null;
            }
                    
                
         
        }

        public int MakePayment(Payment p)
        {
            //check stu id exist in enrollments
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO PAYMENTS VALUES(@pamount,@sid,@pdate) ";
                cmd.Parameters.AddWithValue("@pamount", p.Amount);
                cmd.Parameters.AddWithValue("@sid", p.StudentId);
                cmd.Parameters.AddWithValue("pdate", p.PaymentDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int payStatus = cmd.ExecuteNonQuery();
                return payStatus;

            }
        }

        public int UpdateStudentInfo(Student stu)
        {
            
                using(SqlConnection sqlconnection = new SqlConnection(ConnectionString))
                {
                    cmd.Parameters.Clear ();
                    cmd.CommandText = "UPDATE Students SET FIRST_NAME=@fname,LAST_NAME=@lname,PHONE=@phone,EMAIL=@email,DOB=@dob WHERE STUDENT_ID=@stu_id ";
                    cmd.Parameters.AddWithValue("@fname",stu.FirstName);
                    cmd.Parameters.AddWithValue("@lname", stu.LastName);
                    cmd.Parameters.AddWithValue("@phone", stu.PhoneNo);
                    cmd.Parameters.AddWithValue("@email", stu.Email);
                    cmd.Parameters.AddWithValue("@dob", stu.DateOfBirth);
                    cmd.Parameters.AddWithValue("@stu_id", stu.StudentId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int stuUpdateStatus=cmd.ExecuteNonQuery();

                    return stuUpdateStatus;
                }

           
        }
    }
}
