
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using sis_v2.Utility;
using sis_v2.Models;
using SIS.Exceptions;


namespace sis_v2.Repository
{
    internal class SISRepository : ISISRepository

    {

        public string ConnectionString;
        SqlCommand cmd = null;

        public SISRepository()
        {
            ConnectionString = DbUtil.GetConnectionString();
            cmd = new SqlCommand();

        }

        public Course GetCourseById(int courseId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM COURSES WHERE COURSE_ID = @CourseId";

                cmd.Parameters.AddWithValue("@CourseId", courseId);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseId = (int)reader["COURSE_ID"],
                        TeacherId = (int)reader["TEACHER_ID"],
                        CourseName = (string)reader["COURSE_NAME"],
                        Credits = (int)reader["CREDITS"],
                    };
                    return course;
                }
                else
                {
                    // Course not found
                    return null;
                }
            }
        }



        public List<Course> DisplayCourseInfo()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                cmd.Parameters.Clear();


                cmd.CommandText = "Select * from Courses ";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseId = (int)reader["COURSE_ID"];
                    course.TeacherId = (int)reader["TEACHER_ID"];
                    course.CourseName = (string)reader["COURSE_NAME"];
                    course.Credits = (int)reader["CREDITS"];
                    courses.Add(course);

                }
            }
            return courses;

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

        public List<Teacher> DisplayTeacherInfo()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    cmd.Parameters.Clear();


                    cmd.CommandText = "Select * from Teacher ";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher.TeacherId = (int)reader["TEACHER_ID"];
                        teacher.FirstName = (string)reader["FIRST_NAME"];

                        teacher.Email = (string)reader["EMAIL"];

                        teacher.LastName = (string)reader["LAST_NAME"];
                        teachers.Add(teacher);
                    }



                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return teachers;
        }

        public int EnrollInCourse(Enrollment e, string courseName)
        {
            int course_id = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select COURSE_ID FROM COURSES WHERE COURSE_NAME=@desiredCourse";

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
                // Check if the student is already enrolled in the course
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM ENROLLMENTS WHERE COURSE_ID = @cid AND STUDENT_ID = @sid";
                cmd.Parameters.AddWithValue("@cid", course_id);
                cmd.Parameters.AddWithValue("@sid", e.StudentId);

                int existingEnrollments = (int)cmd.ExecuteScalar();
                if (existingEnrollments > 0)
                {
                    throw new DuplicateEnrollmentException("Student is already enrolled in the course.");
                }


                //not enrolled
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO ENROLLMENTS VALUES(@cid,@sid,@enroldate) ";
                cmd.Parameters.AddWithValue("@cid", course_id);
                cmd.Parameters.AddWithValue("@sid", e.StudentId);
                cmd.Parameters.AddWithValue("enroldate", e.EnrollmentDate);
                int enrollStatus = cmd.ExecuteNonQuery();
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

        public List<Payment> GetPaymentHistory(int id)
        {
            List<Payment> paymentHistory = new List<Payment>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select * from Payments where STUDENT_ID=@stuId ORDER BY PAYMENT_DATE DESC";
                cmd.Parameters.AddWithValue("@stuId", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    payment.PaymentId = (int)reader["PAYMENT_ID"];
                    payment.StudentId = (int)reader["STUDENT_ID"];
                    payment.PaymentDate = (DateTime)reader["PAYMENT_DATE"];
                    payment.Amount = (double)reader["AMOUNT"];

                    paymentHistory.Add(payment);
                }
                return paymentHistory;

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
                throw new StudentNotFoundException($"Student with id {stuId} not found");
            }



        }

        public int MakePayment(Payment p)
        {
            //check stu id exist in enrollments
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
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
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Students SET FIRST_NAME=@fname,LAST_NAME=@lname,PHONE=@phone,EMAIL=@email,DOB=@dob WHERE STUDENT_ID=@stu_id ";
                cmd.Parameters.AddWithValue("@fname", stu.FirstName);
                cmd.Parameters.AddWithValue("@lname", stu.LastName);
                cmd.Parameters.AddWithValue("@phone", stu.PhoneNo);
                cmd.Parameters.AddWithValue("@email", stu.Email);
                cmd.Parameters.AddWithValue("@dob", stu.DateOfBirth);
                cmd.Parameters.AddWithValue("@stu_id", stu.StudentId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int stuUpdateStatus = cmd.ExecuteNonQuery();

                return stuUpdateStatus;
            }
        }

        public int UpdateCourseInfo(Course course)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder("UPDATE COURSES SET ");

                // Add only the properties that are not null in the SQL query
                //if (course.CourseCode != null)
                //{
                //    sb.Append("COURSE_CODE = @courseCode, ");
                //    cmd.Parameters.AddWithValue("@courseCode", course.CourseCode);
                //}

                if (course.CourseName != null)
                {
                    sb.Append("COURSE_NAME = @courseName, ");
                    cmd.Parameters.AddWithValue("@courseName", course.CourseName);
                }

                if (course.TeacherId != null)
                {
                    sb.Append("TEACHER_ID = @tID, ");
                    cmd.Parameters.AddWithValue("@tID", course.TeacherId);
                }
                if (course.Credits != null)
                {
                    sb.Append("CREDITS= @credits ");
                    cmd.Parameters.AddWithValue("@credits", course.Credits);
                }

                // Remove the trailing comma and space
                sb.Length -= 2;

                // Add the WHERE clause
                sb.Append(" WHERE COURSE_ID = @c_id");
                cmd.Parameters.AddWithValue("@c_id", course.CourseId);

                // Set the command text
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int courseUpdateStatus = cmd.ExecuteNonQuery();

                return courseUpdateStatus;
            }
        }

        public List<Enrollment> GetEnrollments(int courseId)
        {
            List<Enrollment> enrollmentsPerCourse = new List<Enrollment>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select * from Enrollments ");
                sb.Append("WHERE COURSE_ID = @cid ");
                cmd.Parameters.AddWithValue("@cid", courseId);
                cmd.CommandText = sb.ToString();
                cmd.Connection = sqlconnection;
                sqlconnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment();
                    enrollment.EnrollmentId = (int)reader["Enrollment_ID"];
                    enrollment.StudentId = (int)reader["STUDENT_ID"];
                    enrollment.CourseId = (int)reader["COURSE_ID"];
                    enrollment.EnrollmentDate = (DateTime)reader["Enrollment_DATE"];
                    enrollmentsPerCourse.Add(enrollment);
                }
                return enrollmentsPerCourse;

            }

        }

        public Object GetTeacher(int courseId)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select c.COURSE_ID,c.COURSE_NAME,t.TEACHER_ID, CONCAT(t.FIRST_NAME, ' ', t.LAST_NAME) AS NAME FROM ");
                sb.Append("Courses c JOIN Teacher t");
                sb.Append(" On c.TEACHER_ID=t.TEACHER_ID ");
                sb.Append(" WHERE c.COURSE_ID=@cid");
                //cmd.CommandText = "Select * FROM Courses where course_id=@cid";
                cmd.Parameters.AddWithValue("@cid", courseId);
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var teacher = new
                    {
                        CourseId = (int)reader["COURSE_ID"],
                        CourseName = (string)reader["COURSE_NAME"],
                        TeacherId = (int)reader["TEACHER_ID"],
                        TeacherName = (string)reader["NAME"],
                    };
                    return teacher;
                }
                return null;
            }
        }

        public object GetStudentWithEnrollment(int enrollmentId)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select e.ENROLLMENT_ID,e.STUDENT_ID,CONCAT(s.FIRST_NAME, ' ', s.LAST_NAME) AS NAME FROM ");
                sb.Append("Students s JOIN Enrollments e");
                sb.Append(" On s.STUDENT_ID=e.STUDENT_ID ");
                sb.Append(" WHERE e.ENROLLMENT_ID=@eid");
                //cmd.CommandText = "Select * FROM Courses where course_id=@cid";
                cmd.Parameters.AddWithValue("@eid", enrollmentId);
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var studentForEnrollmetId = new
                    {
                        ENROLLMENT_ID = (int)reader["ENROLLMENT_ID"],
                        STUDENT_ID = (int)reader["STUDENT_ID"],
                        StudentName = (string)reader["NAME"],
                    };
                    return studentForEnrollmetId;
                }
                return null;
            }
        }

        public object GetCourse(int enrollmentId)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select e.ENROLLMENT_ID,e.COURSE_ID,c.COURSE_NAME FROM ");
                sb.Append("Courses c JOIN Enrollments e");
                sb.Append(" On c.COURSE_ID=e.COURSE_ID ");
                sb.Append(" WHERE e.ENROLLMENT_ID=@enid");
                //cmd.CommandText = "Select * FROM Courses where course_id=@cid";
                cmd.Parameters.AddWithValue("@enid", enrollmentId);
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var courseForEnrollmentId = new
                    {
                        ENROLLMENT_ID = (int)reader["ENROLLMENT_ID"],
                        COURSE_ID = (int)reader["COURSE_ID"],
                        COURSE_NAME = (string)reader["COURSE_NAME"],
                    };
                    return courseForEnrollmentId;
                }
                return null;
            }
        }

        public int UpdateTeacherInfo(Teacher teacher)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Teacher SET FIRST_NAME=@fname,LAST_NAME=@lname,EMAIL=@email WHERE TEACHER_ID=@t_id ";
                cmd.Parameters.AddWithValue("@fname", teacher.FirstName);
                cmd.Parameters.AddWithValue("@lname", teacher.LastName);

                cmd.Parameters.AddWithValue("@email", teacher.Email);

                cmd.Parameters.AddWithValue("@t_id", teacher.TeacherId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int teacherUpdateStatus = cmd.ExecuteNonQuery();

                return teacherUpdateStatus;
            }
        }

        public List<object> GetAssignedCourses(int teacherId)
        {
            List<object> courseToTeachers = new List<object>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select t.TEACHER_ID, CONCAT(t.FIRST_NAME, ' ', t.LAST_NAME) AS NAME,c.COURSE_ID,c.COURSE_NAME FROM ");
                sb.Append("Courses c JOIN Teacher t");
                sb.Append(" On c.TEACHER_ID=t.TEACHER_ID ");
                sb.Append(" WHERE t.TEACHER_ID=@tId");
                //cmd.CommandText = "Select * FROM Courses where course_id=@cid";
                cmd.Parameters.AddWithValue("@tId", teacherId);
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var courseToTeacher = new
                    {
                        CourseId = (int)reader["COURSE_ID"],
                        CourseName = (string)reader["COURSE_NAME"],
                        TeacherId = (int)reader["TEACHER_ID"],
                        TeacherName = (string)reader["NAME"],
                    };
                    courseToTeachers.Add(courseToTeacher);

                }
                return courseToTeachers;
            }
        }

        //public object GetStudent(int enrollmentId)
        //{
        //    throw new NotImplementedException();
        //}

        //List<object> ISISRepository.GetStudentWithEnrollment(int teacherId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<object> GetStudentWithPayment(int paymentId)
        {
            List<object> studentToPyaments = new List<object>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select p.PAYMENT_ID,p.STUDENT_ID,CONCAT(s.FIRST_NAME, ' ', s.LAST_NAME) AS NAME FROM ");
                sb.Append("Students s JOIN Payments p");
                sb.Append(" On s.STUDENT_ID=p.STUDENT_ID ");
                sb.Append(" WHERE p.PAYMENT_ID=@pid");
                //cmd.CommandText = "Select * FROM Courses where course_id=@cid";
                cmd.Parameters.AddWithValue("@pid", paymentId);
                cmd.CommandText = sb.ToString();

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var studentToPyament = new
                    {
                        PAYMENT_ID = (int)reader["PAYMENT_ID"],
                        STUDENT_ID = (int)reader["STUDENT_ID"],
                        StudentName = (string)reader["NAME"],
                    };
                    studentToPyaments.Add(studentToPyament);
                }
                return studentToPyaments;
            }
        }

        public object GetPaymentAmount(int paymentId)
        {

            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();

                cmd.CommandText = "Select PAYMENT_ID,AMOUNT FROM Payments WHERE PAYMENT_ID=@pid";
                cmd.Parameters.AddWithValue("@pid", paymentId);


                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var amountFromPyamentId = new
                    {
                        PAYMENT_ID = (int)reader["PAYMENT_ID"],
                        AMOUNT = (double)reader["AMOUNT"],

                    };
                    return amountFromPyamentId;
                }
                return null;
            }
        }


        public object GetPaymentDate(int paymentId)
        {
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                cmd.Parameters.Clear();

                cmd.CommandText = "Select PAYMENT_ID,PAYMENT_DATE FROM Payments WHERE PAYMENT_ID=@pid";
                cmd.Parameters.AddWithValue("@pid", paymentId);


                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var dateFromPyamentId = new
                    {
                        PAYMENT_ID = (int)reader["PAYMENT_ID"],
                        PAYMENT_DATE = (DateTime)reader["PAYMENT_DATE"],

                    };
                    return dateFromPyamentId;
                }
                return null;
            }
        }

        public Teacher GetTeacherById(int tId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {


                cmd.Parameters.Clear();
                cmd.CommandText = "Select * from Teacher where TEACHER_ID=@teacherId ";
                cmd.Parameters.AddWithValue("@teacherId", tId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacherById= new Teacher()
                    {
                        // student.StudentId = (int)reader["STUDENT_ID"];
                        FirstName = (string)reader["FIRST_NAME"],
                        
                        Email = (string)reader["EMAIL"],
                       
                        LastName = (string)reader["LAST_NAME"],
                    };
                    return teacherById;

                }
                throw new TeacherNotFoundException($"Teacher with id {tId} not exists");
            }
        }
    }
}
